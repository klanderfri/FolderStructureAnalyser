using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;
using FolderStructureAnalyser.DataObjects;
using FolderStructureAnalyser.Events;
using FolderStructureAnalyser.Helpers;
using FolderStructureAnalyser.SessionBound;

namespace FolderStructureAnalyser.Components.AnalyserPanels
{
    public partial class FolderStructureAnalyserCtrl : FolderStructureParentCtrl
    {
        /// <summary>
        /// The folder structure from the last finished analysis.
        /// </summary>
        private BindingList<DiskItemNode> LastAnalysedStructure { get; set; }

        public FolderStructureAnalyserCtrl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Runs the analysis of the folder structure.
        /// </summary>
        public void AnalyseFolderStructure()
        {
            if (MayStartAnalysis())
            {
                //Select folder.
                var rootPath = ShowSelectFolderDialog("Select root folder", "Select the root folder to analyse.");

                if (PathIsValid(rootPath))
                {
                    //Run the analysis.
                    StartAnalysis(rootPath);
                }
            }
        }

        /// <summary>
        /// Sets the focused node as root.
        /// </summary>
        public void SetFocusedNodeAsRoot()
        {
            //Find the node.
            var node = getDiskItemFromNode(treeListFolderStructure.FocusedNode);

            //Check if the node represent a folder.
            if (node?.IsFolder ?? false)
            {
                //OK, set the node as root.

                var newRoot = node.FolderData;
                var newStructure = new BindingList<DiskItemNode>();
                var folderID = 0;
                var worker = new BackgroundWorker();

                addFolderToDataSource(worker, newStructure, newRoot, ref folderID, null);

                updateDataSource(newStructure);
            }
        }

        /// <summary>
        /// Resets the tree to show the structure from the last analysis.
        /// </summary>
        public void ResetTreeToLastAnalyse()
        {
            updateDataSource(LastAnalysedStructure);
        }

        /// <summary>
        /// Sets the data source of the analyser tree.
        /// </summary>
        /// <param name="folderStructure">The folder structer that are to be used as datasource.</param>
        private void updateDataSource(BindingList<DiskItemNode> folderStructure)
        {
            treeListFolderStructure.DataSource = folderStructure;

            if (treeListFolderStructure.Nodes.Any())
            {
                treeListFolderStructure.Nodes[0].Expand();
            }
        }

        private void FolderStructureAnalyserCtrl_DoFolderStructureAnalysis(object sender, DoWorkEventArgs e)
        {
            var rootPath = (e.Argument as IEnumerable<string>).First();
            var structure = new BindingList<DiskItemNode>();
            var worker = (sender as FolderStructureParentCtrl).AnalysisWorker;

            //Create the folder structure.
            var root = new FolderData(worker, rootPath);

            //Check if the process was cancelled.
            if (worker.CancellationPending)
            {
                e.Cancel = true;
                return;
            }

            //Add the structure to the data source.
            var nodeID = 0;
            addFolderToDataSource(worker, structure, root, ref nodeID, null);

            //Check if the process was cancelled.
            if (worker.CancellationPending)
            {
                e.Cancel = true;
                return;
            }

            //Pass the analysed structure back.
            e.Result = structure;
        }

        private void FolderStructureAnalyserCtrl_FolderStructureAnalysisFinished(object sender, OperationFinishedArgs e)
        {
            if (!e.Cancelled)
            {
                //Update the structure shown.
                var structure = e.Result as BindingList<DiskItemNode>;
                updateDataSource(structure);
                LastAnalysedStructure = structure;
            }
        }

        /// <summary>
        /// Adds a folder and its structure to the tree.
        /// </summary>
        /// <param name="worker">The backgroundWorker worker responsible for process.</param>
        /// <param name="structure">The folder structure containing the folder nodes.</param>
        /// <param name="folder">The folder to add.</param>
        /// <param name="nodeID">The ID that should be assigned the node.</param>
        /// <param name="parentID">The ID of the node representing the folder parent.</param>
        private void addFolderToDataSource(BackgroundWorker worker, BindingList<DiskItemNode> structure, FolderData folder, ref int nodeID, int? parentID)
        {
            //Add the node representing the folder.
            var folderNode = new DiskItemNode()
            {
                ID = nodeID++,
                ParentID = parentID,
                Name = folder.Info.Name,
                SizeInBytes = folder.SizeInBytes,
                StateImageIndex = 0,
                FolderData = folder
            };
            structure.Add(folderNode);

            //Add the nodes representing all the subfolders.
            foreach (var subfolder in folder.SubFolders)
            {
                //Check if the process is to be cancelled.
                if (worker.CancellationPending) { return; }

                addFolderToDataSource(worker, structure, subfolder, ref nodeID, folderNode.ID);
            }

            //Add the nodes representing all the subfolders.
            foreach (var file in folder.Files)
            {
                var fileNode = new DiskItemNode()
                {
                    ID = nodeID++,
                    ParentID = folderNode.ID,
                    Name = file.Name,
                    SizeInBytes = file.Length,
                    StateImageIndex = 1,
                    FileData = file
                };
                structure.Add(fileNode);
            }
        }
        
        /// <summary>
        /// Extracts the disk item from a tree node.
        /// </summary>
        /// <param name="node">The node representing the disk item.</param>
        /// <returns>The disk item.</returns>
        private DiskItemNode getDiskItemFromNode(TreeListNode node)
        {
            return treeListFolderStructure.GetDataRecordByNode(node) as DiskItemNode;
        }

        /// <summary>
        /// Gets the colour to use for a folder.
        /// </summary>
        /// <param name="folderSizeInBytes">The size of the folder in bytes.</param>
        /// <returns>The colour to use for the folder.</returns>
        private Color getFolderColour(long folderSizeInBytes)
        {
            var isBigFolder = Session.Tools.IsBigFolder(folderSizeInBytes);
            return isBigFolder ? Session.Settings.BigFolderColour : Color.Black;
        }

        private void repositoryItemTextEditFileSizeEdit_CustomDisplayText(object sender, CustomDisplayTextEventArgs e)
        {
            //Show the size (in MB, GB, etc) instead of just the bytes.
            var sizeInBytes = Convert.ToInt64(e.Value);
            e.DisplayText = Session.Tools.SizeStringFromByte(sizeInBytes);
        }

        private void treeListFolderStructure_CustomDrawNodeCell(object sender, CustomDrawNodeCellEventArgs e)
        {
            if (e.Column == treeListColumnSize)
            {
                //Use the (in the settings) specified colour to indicate big folders.
                e.Appearance.ForeColor = getFolderColour(Convert.ToInt64(e.CellValue));
            }
            if (e.Column == treeListColumnOpen)
            {
                DrawCellNodeIcon(e, e.Column.Width, 2);
            }
        }

        private void treeListFolderStructure_DoubleClick(object sender, EventArgs e)
        {
            if (GridHandler.HasHitColumn(treeListColumnOpen, MousePosition))
            {
                //Fetch the disk item node.
                var hitInfo = GridHandler.GetHitInfo(sender as TreeList, MousePosition);
                var diskItem = getDiskItemFromNode(hitInfo.Node);

                //Open the folder or the file parent folder.
                var folderToOpen = diskItem.IsFolder ? diskItem.FolderData.Info : diskItem.FileData.Directory;
                FileHandler.OpenFolderInExplorer(folderToOpen);
            }
        }

        private void treeListFolderStructure_GetStateImage(object sender, GetStateImageEventArgs e)
        {
            var diskItem = getDiskItemFromNode(e.Node);
            e.NodeImageIndex = diskItem.StateImageIndex;
        }

        private void treeListFolderStructure_BeforeExpand(object sender, BeforeExpandEventArgs e)
        {
            if (GridHandler.HasHitColumn(treeListColumnOpen, MousePosition))
            {
                e.CanExpand = false;
            }
        }

        private void treeListFolderStructure_BeforeCollapse(object sender, BeforeCollapseEventArgs e)
        {
            if (GridHandler.HasHitColumn(treeListColumnOpen, MousePosition))
            {
                e.CanCollapse = false;
            }
        }
    }
}
