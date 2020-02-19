using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.BandedGrid.ViewInfo;
using FolderStructureAnalyser.DataObjects;
using FolderStructureAnalyser.Events;
using FolderStructureAnalyser.Helpers;

namespace FolderStructureAnalyser.Components
{
    public partial class FolderStructureComparerCtrl : FolderStructureParentCtrl
    {
        /// <summary>
        /// Event raised when the control has found a difference between two folder structures.
        /// </summary>
        [Category("Compare")]
        [Description("Occurs when the control has found a difference between two folder structures.")]
        public event FolderStructureDifferenceAddedHandler FolderStructureDifferenceAdded;

        /// <summary>
        /// Eventhandler for the event used when the control has found a difference between two folder structures.
        /// </summary>
        /// <param name="sender">The user control raising the event.</param>
        /// <param name="e">The arguments for the event.</param>
        public delegate void FolderStructureDifferenceAddedHandler(object sender, FolderStructureDifferenceAddedArgs e);

        /// <summary>
        /// Method raising the event used when the control has found a difference between two folder structures.
        /// </summary>
        /// <param name="e">The arguments for the event.</param>
        protected virtual void OnFolderStructureDifferenceAdded(FolderStructureDifferenceAddedArgs e)
        {
            FolderStructureDifferenceAdded?.Invoke(this, e);
        }

        /// <summary>
        /// The path to the original folder the user last selected.
        /// </summary>
        private string LastSelectedOriginalPath { get; set; }

        /// <summary>
        /// The path to the clone folder the user last selected.
        /// </summary>
        private string LastSelectedClonePath { get; set; }

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
            var originalFolderPath = ShowSelectFolderDialog("Select original", "Select the folder that is to act as original.", LastSelectedOriginalPath);
            if (!PathIsValid(originalFolderPath)) { return null; }
            LastSelectedOriginalPath = originalFolderPath;

            var cloneFolderPath = ShowSelectFolderDialog("Select clone", "Select the folder that is to act as clone.", LastSelectedClonePath);
            if (!PathIsValid(cloneFolderPath)) { return null; }
            LastSelectedClonePath = cloneFolderPath;

            if (originalFolderPath == cloneFolderPath)
            {
                MessageBoxes.ShowSameFolderSelectedForCompareMessage();
                return null;
            }
            else
            {
                return new List<string>() { originalFolderPath, cloneFolderPath };
            }
        }

        private void FolderStructureComparerCtrl_DoFolderStructureAnalysis(object sender, DoWorkEventArgs e)
        {
            var worker = (sender as FolderStructureComparerCtrl).AnalysisWorker;

            var rootPaths = e.Argument as List<string>;
            var originalPath = rootPaths[0];
            var clonePath = rootPaths[1];

            var differences = new BindingList<StructureDifference>();

            compareFolders(originalPath, clonePath, differences, worker);

            //Check if the process was cancelled.
            if (worker.CancellationPending)
            {
                e.Cancel = true;
                return;
            }

            //Pass the comparison result back.
            e.Result = differences;
        }

        private void FolderStructureComparerCtrl_FolderStructureAnalysisFinished(object sender, RunWorkerCompletedEventArgs e)
        {
            if (!e.Cancelled)
            {
                var differences = e.Result as BindingList<StructureDifference>;
                updateDataSource(differences);
            }
        }

        private void compareFolders(string originalFolderPath, string cloneFolderPath, BindingList<StructureDifference> differences, BackgroundWorker worker)
        {
            //Check for cancellation.
            if (worker.CancellationPending) { return; }

            //Get the information about the folders.
            var originalFolder = new DirectoryInfo(originalFolderPath);
            var cloneFolder = new DirectoryInfo(cloneFolderPath);

            //Check if the clone folder exists.
            if (!cloneFolder.Exists)
            {
                var format = "The clone is missing a folder.";
                addDifference(differences, originalFolder, cloneFolder, format);
                return;
            }

            //Compare the folders.
            if (originalFolder.Attributes != cloneFolder.Attributes)
            {
                var format = "The clone folder has different attributes.";
                addDifference(differences, originalFolder, cloneFolder, format);
            }

            //Compare the files in the folders.
            compareFiles(originalFolderPath, cloneFolderPath, differences, worker);

            //Compare subfolders recursively
            foreach (var originalSubfolder in FileHandler.GetDirectories(originalFolderPath))
            {
                //Get the paths of the subfolders.
                var originalSubfolderPath = originalSubfolder.FullName;
                var cloneSubfolderPath = Path.Combine(cloneFolderPath, originalSubfolder.Name);

                //Compare the folders.
                compareFolders(originalSubfolderPath, cloneSubfolderPath, differences, worker);
            }
        }

        private void compareFiles(string originalFolderPath, string cloneFolderPath, BindingList<StructureDifference> differences, BackgroundWorker worker)
        {
            //Check that the clone has all the files the original has.
            foreach (var originalFile in FileHandler.GetFiles(originalFolderPath))
            {
                //Check for cancellation.
                if (worker.CancellationPending) { return; }

                //Get the information about the clone file.
                var cloneFile = getFileInfo(cloneFolderPath, originalFile.Name);

                //Check if the clone file exists.
                if (!cloneFile.Exists)
                {
                    var format = "The clone is missing a file.";
                    addDifference(differences, originalFile, cloneFile, format);
                    continue;
                }

                //Compare the files.
                if (originalFile.Attributes != cloneFile.Attributes)
                {
                    var format = "The clone file has different attributes.";
                    addDifference(differences, originalFile, cloneFile, format);
                }
                if (originalFile.Length != cloneFile.Length)
                {
                    var format = "The clone file has a different size.";
                    addDifference(differences, originalFile, cloneFile, format);
                }
            }

            //Check that the clone doesn't have any additional files not present in the original.
            foreach (var cloneFile in FileHandler.GetFiles(cloneFolderPath))
            {
                //Check for cancellation.
                if (worker.CancellationPending) { return; }
                
                //Get the information about the original file.
                var originalFile = getFileInfo(originalFolderPath, cloneFile.Name);

                //Check if the clone has a file that the original doesn't have.
                if (!originalFile.Exists)
                {
                    var format = "The clone has an additional file.";
                    addDifference(differences, originalFile, cloneFile, format);
                    continue;
                }
            }
        }

        private static FileInfo getFileInfo(string parentFolderPath, string fileName)
        {
            return new FileInfo(Path.Combine(parentFolderPath, fileName));
        }

        private void addDifference(BindingList<StructureDifference> differences, FileSystemInfo original, FileSystemInfo clone, string description)
        {
            //Add the differences.
            var diff = new StructureDifference(original, clone, description);
            differences.Add(diff);

            //Raise the event.
            var args = new FolderStructureDifferenceAddedArgs(diff);
            OnFolderStructureDifferenceAdded(args);
        }

        private void updateDataSource(BindingList<StructureDifference> differences)
        {
            gridControl1.DataSource = differences;
        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            var hitInfo = GridHandler.GetHitInfo(sender as GridControl, MousePosition) as BandedGridHitInfo;
            var row = hitInfo.View.GetRow(hitInfo.RowHandle) as StructureDifference;

            if (hitInfo.Band == gridBandOriginal)
            {
                var parentFolder = FileHandler.GetParentFolder(row.OriginalFullPath);
                FileHandler.OpenFolderInExplorer(parentFolder);
            }
            if (hitInfo.Band == gridBandClone)
            {
                var parentFolder = FileHandler.GetParentFolder(row.CloneFullPath);
                FileHandler.OpenFolderInExplorer(parentFolder);
            }
        }
    }
}
