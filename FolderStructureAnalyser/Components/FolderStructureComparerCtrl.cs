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

        /// <summary>
        /// Runs the comparison of the folder structures.
        /// </summary>
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

        /// <summary>
        /// Asks the user for the two folders to compare.
        /// </summary>
        /// <returns>A list containing the full paths to the folders to compare. The first path is the original, the second is the clone.</returns>
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

        /// <summary>
        /// Compares two folders to see if the clone is identical to the original.
        /// </summary>
        /// <param name="originalFolderPath">The full path to the original folder.</param>
        /// <param name="cloneFolderPath">The full path to the clone folder.</param>
        /// <param name="differences">The data source holding any differences found.</param>
        /// <param name="worker">The worker responsible for the comparision.</param>
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

            //Check if the clone has any folders the original does not.
            foreach (var cloneSubFolder in FileHandler.GetSubfolders(cloneFolderPath))
            {
                //Get the information about the original subfolder.
                var originalSubfolder = FileHandler.GetFolderInfo(originalFolderPath, cloneSubFolder.Name);

                //Check if the clone has a folder the original does not.
                if (!originalSubfolder.Exists)
                {
                    var format = "The clone has an additional folder.";
                    addDifference(differences, originalSubfolder, cloneSubFolder, format);
                }
            }

            //Compare subfolders recursively
            foreach (var originalSubfolder in FileHandler.GetSubfolders(originalFolderPath))
            {
                //Get the paths of the subfolders.
                var originalSubfolderPath = originalSubfolder.FullName;
                var cloneSubfolderPath = Path.Combine(cloneFolderPath, originalSubfolder.Name);

                //Compare the folders.
                compareFolders(originalSubfolderPath, cloneSubfolderPath, differences, worker);
            }
        }

        /// <summary>
        /// Compares the files withing two folders to see if the clone has the same file content as the original.
        /// </summary>
        /// <param name="originalFolderPath">The full path to the original folder.</param>
        /// <param name="cloneFolderPath">The full path to the clone folder.</param>
        /// <param name="differences">The data source holding any differences found.</param>
        /// <param name="worker">The worker responsible for the comparision.</param>
        private void compareFiles(string originalFolderPath, string cloneFolderPath, BindingList<StructureDifference> differences, BackgroundWorker worker)
        {
            //Check if the clone has all the files the original has.
            foreach (var originalFile in FileHandler.GetFiles(originalFolderPath))
            {
                //Check for cancellation.
                if (worker.CancellationPending) { return; }

                //Get the information about the clone file.
                var cloneFile = FileHandler.GetFileInfo(cloneFolderPath, originalFile.Name);

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

            //Check if the clone has any files the original does not.
            foreach (var cloneFile in FileHandler.GetFiles(cloneFolderPath))
            {
                //Check for cancellation.
                if (worker.CancellationPending) { return; }
                
                //Get the information about the original file.
                var originalFile = FileHandler.GetFileInfo(originalFolderPath, cloneFile.Name);

                //Check if the clone has a file the original does not.
                if (!originalFile.Exists)
                {
                    var format = "The clone has an additional file.";
                    addDifference(differences, originalFile, cloneFile, format);
                }
            }
        }

        /// <summary>
        /// Adds a difference to the list of differences to show the user.
        /// </summary>
        /// <param name="differences">The list of differences to show the user.</param>
        /// <param name="original">The original item.</param>
        /// <param name="clone">The clone item that differs from the original.</param>
        /// <param name="description">A description of the difference.</param>
        private void addDifference(BindingList<StructureDifference> differences, FileSystemInfo original, FileSystemInfo clone, string description)
        {
            //Add the differences.
            var diff = new StructureDifference(original, clone, description);
            differences.Add(diff);

            //Raise the event.
            var args = new FolderStructureDifferenceAddedArgs(diff);
            OnFolderStructureDifferenceAdded(args);
        }

        /// <summary>
        /// Sets the data source of the grid.
        /// </summary>
        /// <param name="differences">The list of differences to show the user.</param>
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
