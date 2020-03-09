using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.BandedGrid;
using DevExpress.XtraGrid.Views.BandedGrid.ViewInfo;
using DevExpress.XtraGrid.Views.Base;
using FolderStructureAnalyser.DataObjects;
using FolderStructureAnalyser.Enums;
using FolderStructureAnalyser.Events;
using FolderStructureAnalyser.Helpers;
using FolderStructureAnalyser.SessionBound;

namespace FolderStructureAnalyser.Components.AnalyserPanels
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

        /// <summary>
        /// List of columns holding information about the original disk item.
        /// </summary>
        private List<BandedGridColumn> ColumnsForOriginal
        {
            get
            {
                return new List<BandedGridColumn>()
                {
                    bandedGridColumnOriginalName,
                    bandedGridColumnOriginalFullPath,
                    bandedGridColumnOriginalHash
                };
            }
        }

        /// <summary>
        /// List of columns holding information about the clone disk item.
        /// </summary>
        private List<BandedGridColumn> ColumnsForClone
        {
            get
            {
                return new List<BandedGridColumn>()
                {
                    bandedGridColumnCloneName,
                    bandedGridColumnCloneFullPath,
                    bandedGridColumnCloneHash
                };
            }
        }

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
        
        private void FolderStructureComparerCtrl_FolderStructureAnalysisFinished(object sender, OperationFinishedArgs e)
        {
            if (!e.Cancelled)
            {
                //Update the grid.
                var differences = e.Result as BindingList<StructureDifference>;
                updateDataSource(differences);

                //Check if the structures are identical.
                if (!differences.Any())
                {
                    MessageBoxes.ShowNoStructureDifferencesFoundMessage();
                }
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
                addDifference(differences, originalFolder, cloneFolder, DifferenceType.SubfolderMissing);
                return;
            }

            //Compare the folders.
            if (originalFolder.Attributes != cloneFolder.Attributes)
            {
                addDifference(differences, originalFolder, cloneFolder, DifferenceType.SubfolderAttributesDiffer);
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
                    addDifference(differences, originalSubfolder, cloneSubFolder, DifferenceType.SubfolderAdditional);
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
                    addDifference(differences, originalFile, cloneFile, DifferenceType.FileMissing);
                    continue;
                }

                //Compare the files.
                if (originalFile.Attributes != cloneFile.Attributes)
                {
                    addDifference(differences, originalFile, cloneFile, DifferenceType.FileAttributesDiffer);
                }
                if (originalFile.Length != cloneFile.Length)
                {
                    addDifference(differences, originalFile, cloneFile, DifferenceType.FileSizeDiffer);
                }
                else if (Session.Settings.CompareFileHashes && !FileHandler.HasIdenticalHashes(originalFile.FullName, cloneFile.FullName))
                {
                    addDifference(differences, originalFile, cloneFile, DifferenceType.FileHashDiffer);
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
                    addDifference(differences, originalFile, cloneFile, DifferenceType.FileAdditional);
                }
            }
        }

        /// <summary>
        /// Adds a difference to the list of differences to show the user.
        /// </summary>
        /// <param name="differences">The list of differences to show the user.</param>
        /// <param name="original">The original item.</param>
        /// <param name="clone">The clone item that differs from the original.</param>
        /// <param name="type">The type of difference difference.</param>
        private void addDifference(BindingList<StructureDifference> differences, FileSystemInfo original, FileSystemInfo clone, DifferenceType type)
        {
            //Add the differences.
            var diff = new StructureDifference(original, clone, type);
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

        /// <summary>
        /// Checks if the clone is missing a file.
        /// </summary>
        /// <param name="diffInfo">The information about the folder strucure difference.</param>
        /// <returns>TRUE if the clone is missing a file, else FALSE.</returns>
        private static bool cloneIsMissingDiskItem(DifferenceTypeDescription diffInfo)
        {
            return diffInfo.DifferenceType == DifferenceType.FileMissing
                || diffInfo.DifferenceType == DifferenceType.SubfolderMissing;
        }

        /// <summary>
        /// Checks if the clone has an additional file.
        /// </summary>
        /// <param name="diffInfo">The information about the folder strucure difference.</param>
        /// <returns>TRUE if the clone has an additional file, else FALSE.</returns>
        private static bool cloneHasAdditionalDiskItem(DifferenceTypeDescription diffInfo)
        {
            return diffInfo.DifferenceType == DifferenceType.FileAdditional
                || diffInfo.DifferenceType == DifferenceType.SubfolderAdditional;
        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            var hitInfo = GridHandler.GetHitInfo(sender as GridControl, MousePosition) as BandedGridHitInfo;
            var row = hitInfo.View.GetRow(hitInfo.RowHandle) as StructureDifference;

            if (hitInfo.Band == gridBandDiskItems)
            {
                var diskItem = ColumnsForOriginal.Contains(hitInfo.Column) ? row.Original : row.Clone;
                var parentFolder = FileHandler.GetParentFolder(diskItem.Info.FullName);
                FileHandler.OpenDiskItemInExplorer(parentFolder);
            }
        }

        private void bandedGridView1_CustomDrawCell(object sender, RowCellCustomDrawEventArgs e)
        {
            var column = e.Column as BandedGridColumn;
            var row = advBandedGridView1.GetRow(e.RowHandle) as StructureDifference;

            if (column == bandedGridColumnItemTypeIndex)
            {
                DrawCellNodeIcon(e, e.Column.Width, row.DiffInfo.ItemTypeImageIndex);
            }
            if (column == bandedGridColumnProblemTypeIndex)
            {
                DrawCellNodeIcon(e, e.Column.Width, row.DiffInfo.DifferenceTypeImageIndex);
            }
            if (ColumnsForClone.Contains(column) && cloneIsMissingDiskItem(row.DiffInfo))
            {
                e.Appearance.BackColor = Session.Settings.GridErrorColour;
            }
            if (ColumnsForOriginal.Contains(column) && cloneHasAdditionalDiskItem(row.DiffInfo))
            {
                e.Appearance.BackColor = Session.Settings.GridErrorColour;
            }
        }
    }
}
