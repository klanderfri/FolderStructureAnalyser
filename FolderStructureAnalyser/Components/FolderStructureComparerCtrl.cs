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
                var description = "The clone folder is missing.";
                addDifference(differences, originalRootPath, cloneRootPath, description);
                return;
            }

            //Compare the folders.
            var original = new DirectoryInfo(originalRootPath);
            var clone = new DirectoryInfo(cloneRootPath);
            if (original.Name != clone.Name)
            {
                //Should only be possible to happen for the selected root folders.
                var format = "The clone root folder has a different name: {0}";
                addDifference(differences, originalRootPath, cloneRootPath, format, clone.Name);
            }
            if (original.Attributes != clone.Attributes)
            {
                var description = "The clone has different attributes.";
                var diff = new StructureDifference(originalRootPath, cloneRootPath, description);
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
                    addDifference(differences, originalRootPath, cloneRootPath, format, originalFile.Name);
                    continue;
                }

                //Compare the files.
                var cloneFile = cloneFiles[originalFile.Name];
                if (originalFile.Attributes != cloneFile.Attributes)
                {
                    var format = "The clone file {0} has different attributes.";
                    addDifference(differences, originalRootPath, cloneRootPath, format, cloneFile.Name);
                }
                if (originalFile.Length != cloneFile.Length)
                {
                    var format = "The clone file {0} has a different size.";
                    addDifference(differences, originalRootPath, cloneRootPath, format, cloneFile.Name);
                }
            }
        }

        private static void addDifference(BindingList<StructureDifference> differences, string originalRootPath, string cloneRootPath, string description)
        {
            var diff = new StructureDifference(originalRootPath, cloneRootPath, description);
            differences.Add(diff);
        }

        private static void addDifference(BindingList<StructureDifference> differences, string originalRootPath, string cloneRootPath, string descriptionFormat, params object[] descriptionArgs)
        {
            var description = String.Format(descriptionFormat, descriptionArgs);
            var diff = new StructureDifference(originalRootPath, cloneRootPath, description);
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
