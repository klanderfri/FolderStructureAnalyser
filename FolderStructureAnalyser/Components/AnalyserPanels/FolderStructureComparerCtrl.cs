﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.BandedGrid;
using DevExpress.XtraGrid.Views.BandedGrid.ViewInfo;
using DevExpress.XtraGrid.Views.Base;
using FolderStructureAnalyser.DataObjects;
using FolderStructureAnalyser.Enums;
using FolderStructureAnalyser.Events;
using FolderStructureAnalyser.Exceptions;
using FolderStructureAnalyser.Helpers;
using FolderStructureAnalyser.SessionBound;

namespace FolderStructureAnalyser.Components.AnalyserPanels
{
    public partial class FolderStructureComparerCtrl : FolderStructureParentCtrl
    {
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

            var differences = StructureComparer.CompareFolders(originalPath, clonePath, Session.Settings.CompareFileHashes, worker);

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
        /// Sets the data source of the grid.
        /// </summary>
        /// <param name="differences">The list of differences to show the user.</param>
        private void updateDataSource(BindingList<StructureDifference> differences)
        {
            /* For some reason, assigning the differences directly to the
             * data-source, like so:
             * 
             * gridControl.DataSource = differences;
             * 
             * ... raises the exception below:
             * 
             * System.Reflection.TargetInvocationException: 'Property accessor 'FullName' on object 'System.IO.FileInfo' threw the following exception:'Object does not match target type.''
             * TargetException: Object does not match target type.
             * 
             * I do not know why, but assigning a new, empty binding list, and
             * then adding all the differences, one by one, seems to work.
             * 
             * I speculate that the grid-control wants to be able to raise some
             * event for every row added to it, and that it can't do that when
             * all rows are added as a collection?
             */
            gridControl.DataSource = new BindingList<StructureDifference>();
            foreach (var diff in differences)
            {
                (gridControl.DataSource as BindingList<StructureDifference>).Add(diff);
            }
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

        /// <summary>
        /// Sets the forecolor of a cell to indicate a missing file.
        /// </summary>
        /// <param name="e">The arguments for the custom draw cell event.</param>
        private void setMissingFileFontColour(RowCellCustomDrawEventArgs e)
        {
            e.Appearance.ForeColor = Session.Settings.GridErrorColour;
        }

        /// <summary>
        /// Gets a specific row from the grid.
        /// </summary>
        /// <param name="rowHandle">The row handle of the row to get.</param>
        /// <returns>The fetched row.</returns>
        private StructureDifference getRow(int rowHandle)
        {
            return advBandedGridView.GetRow(rowHandle) as StructureDifference;
        }

        /// <summary>
        /// Checks if a column holds information about the original disk item.
        /// </summary>
        /// <param name="column">The column to test.</param>
        /// <returns>TRUE if the column holds information about the original disk item, else FALSE.</returns>
        private bool columnHoldsOriginal(BandedGridColumn column)
        {
            return column.Name.StartsWith("bandedGridColumnOriginal");
        }

        /// <summary>
        /// Checks if a column holds information about the clone disk item.
        /// </summary>
        /// <param name="column">The column to test.</param>
        /// <returns>TRUE if the column holds information about the clone disk item, else FALSE.</returns>
        private bool columnHoldsClone(BandedGridColumn column)
        {
            return column.Name.StartsWith("bandedGridColumnClone");
        }

        private void gridControl_DoubleClick(object sender, EventArgs e)
        {
            var hitInfo = GridHandler.GetHitInfo(sender as GridControl, MousePosition) as BandedGridHitInfo;
            var row = hitInfo.View.GetRow(hitInfo.RowHandle) as StructureDifference;

            if (hitInfo.Band == gridBandDiskItems)
            {
                var diskItem = columnHoldsOriginal(hitInfo.Column) ? row.Original.Info : row.Clone.Info;
                var folderBehaviour = OpenFolderBehaviour.SelectInParent;

                if (!diskItem.Exists)
                {
                    //The file or folder is missing. Open its parent.
                    diskItem = FileHandler.GetParentFolder(diskItem.FullName);
                    folderBehaviour = OpenFolderBehaviour.OpenItself;
                }

                FileHandler.InvokeExplorer(diskItem, folderBehaviour);
            }
        }

        private void advBandedGridView_CustomDrawCell(object sender, RowCellCustomDrawEventArgs e)
        {
            var column = e.Column as BandedGridColumn;
            var row = getRow(e.RowHandle);

            if (column == bandedGridColumnItemTypeIndex)
            {
                DrawCellNodeIcon(e, e.Column.Width, row.DiffInfo.ItemTypeImageIndex);
            }
            if (column == bandedGridColumnProblemTypeIndex)
            {
                DrawCellNodeIcon(e, e.Column.Width, row.DiffInfo.DifferenceTypeImageIndex);
            }
            if (columnHoldsClone(column) && cloneIsMissingDiskItem(row.DiffInfo))
            {
                setMissingFileFontColour(e);
            }
            if (columnHoldsOriginal(column) && cloneHasAdditionalDiskItem(row.DiffInfo))
            {
                setMissingFileFontColour(e);
            }
        }

        private void repositoryItemTextEditItemTypeIndex_CustomDisplayText(object sender, CustomDisplayTextEventArgs e)
        {
            e.DisplayText = (Convert.ToInt32(e.Value) == 1) ? "Folder" : "File";
        }

        private void repositoryItemTextEditProblemTypeIndex_CustomDisplayText(object sender, CustomDisplayTextEventArgs e)
        {
            var problem = Convert.ToInt32(e.Value);
            
            switch (problem)
            {
                case 4:
                    e.DisplayText = "Additional disk item";
                    break;
                case 5:
                    e.DisplayText = "Missing disk item";
                    break;
                case 6:
                    e.DisplayText = "Different sizes";
                    break;
                case 7:
                    e.DisplayText = "Different attributes";
                    break;
                case 8:
                    e.DisplayText = "Different hash codes";
                    break;
                default:
                    throw new UnhandledSwitchCaseException(problem);
            }
        }
    }
}
