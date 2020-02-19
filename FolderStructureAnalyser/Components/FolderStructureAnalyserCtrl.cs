using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;
using FolderStructureAnalyser.DataObjects;
using FolderStructureAnalyser.Helpers;
using FolderStructureAnalyser.SessionBound;

namespace FolderStructureAnalyser.Components
{
    public partial class FolderStructureAnalyserCtrl : FolderStructureParentCtrl
    {
        /// <summary>
        /// The folder structure from the last finished analysis.
        /// </summary>
        private BindingList<FolderNode> LastAnalysedStructure { get; set; }

        public FolderStructureAnalyserCtrl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Loads a folder structure the user selects.
        /// </summary>
        public void LoadFolderStructure()
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
            if (treeListFolderStructure.FocusedNode != null)
            {
                var newRoot = getFolderFromNode(treeListFolderStructure.FocusedNode).FolderData;
                var newStructure = new BindingList<FolderNode>();
                var folderID = 0;
                var worker = new BackgroundWorker();

                addFolderToDataSource(worker, newStructure, newRoot, ref folderID, null);

                updateDataSource(newStructure);
            }
        }

        public void ResetTreeToLastAnalyse()
        {
            updateDataSource(LastAnalysedStructure);
        }

        /// <summary>
        /// Begins update of the visual content of the tree.
        /// </summary>
        private void beginUpdate()
        {
            treeListFolderStructure.BeginUpdate();
            treeListFolderStructure.BeginUnboundLoad();
        }

        /// <summary>
        /// Ends update of the visual content of the tree.
        /// </summary>
        private void endUpdate()
        {
            treeListFolderStructure.EndUnboundLoad();
            treeListFolderStructure.EndUpdate();
        }

        /// <summary>
        /// Sets the data source of the analyser tree.
        /// </summary>
        /// <param name="folderStructure">The folder structer that are to be used as datasource.</param>
        private void updateDataSource(BindingList<FolderNode> folderStructure)
        {
            try
            {
                beginUpdate();
                treeListFolderStructure.DataSource = folderStructure;
            }
            finally
            {
                endUpdate();
            }

            if (treeListFolderStructure.Nodes.Any())
            {
                treeListFolderStructure.Nodes[0].Expand();
            }
        }

        private void FolderStructureAnalyserCtrl_DoFolderStructureAnalysis(object sender, DoWorkEventArgs e)
        {
            var rootPath = (e.Argument as IEnumerable<string>).First();
            var structure = new BindingList<FolderNode>();
            var worker = (sender as FolderStructureParentCtrl).AnalysisWorker;

            //Create the folder structure.
            var root = new FolderData(Session, worker, rootPath);

            //Check if the process was cancelled.
            if (worker.CancellationPending)
            {
                e.Cancel = true;
                return;
            }

            //Add the structure to the data source.
            var folderID = 0;
            addFolderToDataSource(worker, structure, root, ref folderID, null);

            //Check if the process was cancelled.
            if (worker.CancellationPending)
            {
                e.Cancel = true;
                return;
            }

            //Pass the analysed structure back.
            e.Result = structure;
        }

        private void FolderStructureAnalyserCtrl_FolderStructureAnalysisFinished(object sender, RunWorkerCompletedEventArgs e)
        {
            if (!e.Cancelled)
            {
                //Update the structure shown.
                var structure = e.Result as BindingList<FolderNode>;
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
        /// <param name="folderID">The ID that should be assigned the node.</param>
        /// <param name="parentID">The ID of the node representing the folder parent.</param>
        private void addFolderToDataSource(BackgroundWorker worker, BindingList<FolderNode> structure, FolderData folder, ref int folderID, int? parentID)
        {
            //Add the node representing the folder.
            var node = new FolderNode()
            {
                ID = folderID++,
                ParentID = parentID,
                Name = folder.Info.Name,
                SizeInBytes = folder.SizeInBytes,
                StateImageIndex = 0,
                FolderData = folder
            };
            structure.Add(node);

            //Add the nodes representing all the children.
            foreach (var child in folder.SubFolders)
            {
                //Check if the process is to be cancelled.
                if (worker.CancellationPending) { return; }

                addFolderToDataSource(worker, structure, child, ref folderID, node.ID);
            }
        }

        /// <summary>
        /// Extracts the folder from a tree node.
        /// </summary>
        /// <param name="node">The node representing the folder.</param>
        /// <returns>The folder.</returns>
        private FolderNode getFolderFromNode(TreeListNode node)
        {
            return treeListFolderStructure.GetDataRecordByNode(node) as FolderNode;
        }

        /// <summary>
        /// Extracts the folder at a specific location.
        /// </summary>
        /// <param name="location">The point specifying the folder to get.</param>
        /// <returns>The folder.</returns>
        private FolderNode getFolderFromLocation(Point location)
        {
            var node = treeListFolderStructure.GetNodeAt(location);
            return getFolderFromNode(node);
        }

        /// <summary>
        /// Opens a specific folder in the Windows Explorer.
        /// </summary>
        /// <param name="folder">The folder to open.</param>
        private void openFolderInExplorer(FolderNode folder)
        {
            var path = folder.FolderData.Info.FullName;
            if (Directory.Exists(path))
            {
                try
                {
                    Process.Start(path);
                }
                catch (Win32Exception ex)
                {
                    var format = "Problem opening folder {1}.{0}Path: {2}{0}Error: {3}";
                    var message = String.Format(format, Environment.NewLine, folder.Name, path, ex.Message);
                    MessageBox.Show(message, "Problem opening folder.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                var message = "The folder does no longer exist.";
                MessageBox.Show(message, "Non-existing folder", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void repositoryItemTextEditFileSizeEdit_CustomDisplayText(object sender, CustomDisplayTextEventArgs e)
        {
            //Show the size (in MB, GB, etc) instead of just the bytes.
            var sizeInBytes = Convert.ToInt64(e.Value);
            e.DisplayText = ByteSizeConverter.SizeStringFromByte(sizeInBytes);
        }

        private void treeListFolderStructure_CustomDrawNodeCell(object sender, CustomDrawNodeCellEventArgs e)
        {
            if (e.Column == treeListColumnSize)
            {
                //Use the specified colour to indicate big folders.
                var sizeInBytes = Convert.ToInt64(e.CellValue);
                var sizeLimitInMB = Session.Settings.FolderStructureSettings.BigFolderInMB;
                var sizeLimitInBytes = ByteSizeConverter.BytesFromMB(sizeLimitInMB);
                if (sizeInBytes >= sizeLimitInBytes)
                {
                    e.Appearance.ForeColor = Session.Settings.FolderStructureSettings.BigFolderColour;
                }
                else
                {
                    e.Appearance.ForeColor = Color.Black;
                }
            }
            if (e.Column == treeListColumnOpen)
            {
                e.DefaultDraw();

                var openIcon = svgImageCollectionTreeIcons.GetImage(2);

                var location = e.Bounds.Location;
                int middleX = (e.Column.Width - openIcon.Width) / 2;
                location.Offset(middleX, 1);

                e.Graphics.DrawImage(openIcon, location);
                e.Handled = true;
            }
        }

        private void treeListFolderStructure_DoubleClick(object sender, EventArgs e)
        {
            var tree = sender as TreeList;
            var hitInfo = tree.CalcHitInfo(tree.PointToClient(MousePosition));
            if (hitInfo.Node != null && hitInfo.Column == treeListColumnOpen)
            {
                //Open folder.
                var folder = getFolderFromNode(hitInfo.Node);
                openFolderInExplorer(folder);
            }
        }

        private void treeListFolderStructure_GetStateImage(object sender, GetStateImageEventArgs e)
        {
            var folder = getFolderFromNode(e.Node);
            e.NodeImageIndex = folder.StateImageIndex;
        }
    }
}
