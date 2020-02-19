﻿using System;
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

        private void compareFolders(string originalRootPath, string cloneRootPath, BindingList<StructureDifference> differences, BackgroundWorker worker)
        {
            //Check if the clone folder exists.
            if (worker.CancellationPending) { return; }
            var clone = new DirectoryInfo(cloneRootPath);
            if (!clone.Exists)
            {
                var format = "The clone is missing a folder.";
                addDifference(differences, originalRootPath, cloneRootPath, format, clone.Name);
                return;
            }

            //Compare the folders.
            if (worker.CancellationPending) { return; }
            var original = new DirectoryInfo(originalRootPath);
            if (original.Attributes != clone.Attributes)
            {
                var format = "The clone folder has different attributes.";
                addDifference(differences, originalRootPath, cloneRootPath, format, clone.Name);
            }

            //Compare the files in the folders.
            compareFiles(originalRootPath, cloneRootPath, differences, worker);

            //Compare subfolders recursively.
            if (worker.CancellationPending) { return; }
            foreach (var indexOriginalSubfolder in FileHandler.GetDirectoryIndex(originalRootPath))
            {
                var originalSubfolder = indexOriginalSubfolder.Value;

                var originalPath = originalSubfolder.FullName;
                var clonePath = Path.Combine(cloneRootPath, originalSubfolder.Name);

                compareFolders(originalPath, clonePath, differences, worker);
            }
        }

        private void compareFiles(string originalRootPath, string cloneRootPath, BindingList<StructureDifference> differences, BackgroundWorker worker)
        {
            if (worker.CancellationPending) { return; }
            var originalFiles = FileHandler.GetFileIndex(originalRootPath);
            var cloneFiles = FileHandler.GetFileIndex(cloneRootPath);

            foreach (var indexOriginalFile in originalFiles)
            {
                //Check if the clone file exists.
                if (worker.CancellationPending) { return; }
                var originalFile = indexOriginalFile.Value;
                if (!cloneFiles.ContainsKey(originalFile.Name))
                {
                    var format = "The clone is missing a file.";
                    addDifference(differences, originalRootPath, cloneRootPath, format, originalFile.Name);
                    continue;
                }

                //Compare the files.
                if (worker.CancellationPending) { return; }
                var cloneFile = cloneFiles[originalFile.Name];
                if (originalFile.Attributes != cloneFile.Attributes)
                {
                    var format = "The clone file has different attributes.";
                    addDifference(differences, originalRootPath, cloneRootPath, format, cloneFile.Name);
                }
                if (originalFile.Length != cloneFile.Length)
                {
                    var format = "The clone file has a different size.";
                    addDifference(differences, originalRootPath, cloneRootPath, format, cloneFile.Name);
                }
            }
        }

        private void addDifference(BindingList<StructureDifference> differences, string originalRootPath, string cloneRootPath, string description, string itemName)
        {
            //Add the differences.
            var diff = new StructureDifference(originalRootPath, cloneRootPath, description, itemName);
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
                FileHandler.OpenFolderInExplorer(row.OriginalParentFolderFullPath);
            }
            if (hitInfo.Band == gridBandClone)
            {
                FileHandler.OpenFolderInExplorer(row.CloneParentFolderFullPath);
            }
        }
    }
}
