using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using FolderStructureAnalyser.DataObjects;
using FolderStructureAnalyser.Helpers;

namespace FolderStructureAnalyser.Components
{
    public partial class FolderStructureComparerCtrl : FolderStructureParentCtrl
    {
        public FolderStructureComparerCtrl()
        {
            InitializeComponent();
        }

        public void CompareFolderStructures()
        {
            if (MayStartAnalysis())
            {
                var paths = askUserForFoldersToCompare();

                if (paths != null)
                {
                    StartAnalysis(paths);
                }
            }
        }

        private List<string> askUserForFoldersToCompare()
        {
            var originalFolder = ShowSelectFolderDialog("Select original", "Select the folder that are to act as original.");
            if (!PathIsValid(originalFolder)) { return null; }

            var clonedFolder = ShowSelectFolderDialog("Select clone", "Select the folder that are to act as clone.");
            if (!PathIsValid(clonedFolder)) { return null; }

            return new List<string>() { originalFolder, clonedFolder };
        }

        private void FolderStructureComparerCtrl_DoFolderStructureAnalysis(object sender, DoWorkEventArgs e)
        {
            var rootPaths = e.Argument as List<string>;
            var originalPath = rootPaths[0];
            var clonePath = rootPaths[1];

            var differences = new BindingList<StructureDifference>();

            compareFolders(originalPath, clonePath, differences);

            e.Result = differences;
        }

        private void compareFolders(string originalRootPath, string cloneRootPath, BindingList<StructureDifference> differences)
        {
            //Check if the clone folder exists.
            if (!Directory.Exists(cloneRootPath))
            {
                var diff = new StructureDifference(originalRootPath, "The clone folder is missing.");
                differences.Add(diff);
                return;
            }

            //Compare the folders.
            var original = new DirectoryInfo(originalRootPath);
            var clone = new DirectoryInfo(cloneRootPath);
            if (original.Name != clone.Name)
            {
                //Should only be possible to happen for the selected root folders.
                var format = "The clone root folder has a different name: {0}";
                addDifference(originalRootPath, clone.Name, format, differences);
            }
            if (original.Attributes != clone.Attributes)
            {
                var diff = new StructureDifference(originalRootPath, "The clone has different attributes.");
                differences.Add(diff);
            }

            //Compare the files in the folders.
            compareFiles(originalRootPath, cloneRootPath, differences);

            //Compare subfolders recursively.
            foreach (var originalSubfolder in original.GetDirectories())
            {
                var originalPath = originalSubfolder.FullName;
                var clonePath = Path.Combine(cloneRootPath, originalSubfolder.Name);

                compareFolders(originalPath, clonePath, differences);
            }
        }

        private void compareFiles(string originalRootPath, string cloneRootPath, BindingList<StructureDifference> differences)
        {
            var originalFiles = FileHandler.GetFileIndex(originalRootPath);
            var cloneFiles = FileHandler.GetFileIndex(cloneRootPath);

            foreach (var indexOriginalFile in originalFiles)
            {
                //Check if the clone file exists.
                var originalFile = indexOriginalFile.Value;
                if (!cloneFiles.ContainsKey(originalFile.Name))
                {
                    var format = "The clone is missing the file '{0}'.";
                    addDifference(originalRootPath, originalFile.Name, format, differences);
                    continue;
                }

                //Compare the files.
                var cloneFile = cloneFiles[originalFile.Name];
                if (originalFile.Attributes != cloneFile.Attributes)
                {
                    var format = "The clone file {0} has different attributes.";
                    addDifference(originalRootPath, cloneFile.Name, format, differences);
                }
                if (originalFile.Length != cloneFile.Length)
                {
                    var format = "The clone file {0} has a different size.";
                    addDifference(originalRootPath, cloneFile.Name, format, differences);
                }
            }
        }

        private static void addDifference(string originalRootPath, string cloneFileName, string descriptionFormat, BindingList<StructureDifference> differences)
        {
            var description = String.Format(descriptionFormat, cloneFileName);
            var diff = new StructureDifference(originalRootPath, description);
            differences.Add(diff);
        }

        private void FolderStructureComparerCtrl_FolderStructureAnalysisFinished(object sender, RunWorkerCompletedEventArgs e)
        {
            if (!e.Cancelled)
            {
                var differences = e.Result as BindingList<StructureDifference>;
                updateDataSource(differences);
            }
        }

        private void updateDataSource(BindingList<StructureDifference> differences)
        {
            gridControl1.BeginUpdate();
            gridControl1.DataSource = differences;
            gridControl1.EndUpdate();
        }
    }
}
