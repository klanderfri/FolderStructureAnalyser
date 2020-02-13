using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraTreeList;
using FolderStructureAnalyser.BuisnessObjects;
using FolderStructureAnalyser.GUI;
using FolderStructureAnalyser.SessionBound;

namespace FolderStructureAnalyser.Components
{
    public partial class AnalyserTreeListCtrl : UserControl, ISessionBound
    {
        public Session Session { get; set; }

        /// <summary>
        /// Tells if the control is busy analysing a folder structure.
        /// </summary>
        public bool IsBusy
        {
            get { return backgroundWorkerStructureAnalyser.IsBusy; }
        }

        public AnalyserTreeListCtrl()
        {
            InitializeComponent();
        }

        public void SessionSet(Session session)
        {
            Session = session;
        }

        /// <summary>
        /// Loads a folder structure.
        /// </summary>
        /// <param name="rootPath">The path to the root folder.</param>
        /// <remarks>The tree list is reusable due to the passing of the path as a parameter instead of fetching it from the session.</remarks>
        public void LoadFolderStructure(string rootPath)
        {
            backgroundWorkerStructureAnalyser.RunWorkerAsync(rootPath);
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
            beginUpdate();

            try
            {
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

        private void backgroundWorkerStructureAnalyser_DoWork(object sender, DoWorkEventArgs e)
        {
            var rootPath = e.Argument as string;
            var structure = new BindingList<FolderNode>();

            //Create the folder structure.
            var root = new Folder(Session, rootPath);

            //Add the structure to the data source.
            var folderID = 0;
            addDirectoryToDataSource(structure, root, ref folderID, null);

            e.Result = structure;
        }

        private void backgroundWorkerStructureAnalyser_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            updateDataSource(e.Result as BindingList<FolderNode>);
        }

        /// <summary>
        /// Adds a directory and its structure to the tree.
        /// </summary>
        /// <param name="structure">The folder structure containing the folder nodes.</param>
        /// <param name="directory">The folder to add.</param>
        /// <param name="folderID">The ID that should be assigned the node.</param>
        /// <param name="parentID">The ID of the node representing the folder parent.</param>
        private void addDirectoryToDataSource(BindingList<FolderNode> structure, Folder directory, ref int folderID, int? parentID)
        {
            //Add the node representing the folder.
            var node = new FolderNode()
            {
                ID = folderID++,
                ParentID = parentID,
                Name = directory.Info.Name,
                SizeInBytes = directory.SizeInBytes,
                FolderData = directory
            };
            structure.Add(node);

            //Add the nodes representing all the children.
            foreach (var child in directory.SubFolders)
            {
                addDirectoryToDataSource(structure, child, ref folderID, node.ID);
            }
        }

        private void repositoryItemTextEditFileSizeEdit_CustomDisplayText(object sender, CustomDisplayTextEventArgs e)
        {
            //Show the size (in MB, GB, etc) instead of just the bytes.
            var sizeInBytes = Convert.ToInt64(e.Value);
            e.DisplayText = Session.Tools.ByteSizeConverter.SizeStringFromByte(sizeInBytes);
        }

        private void treeListFolderStructure_CustomDrawNodeCell(object sender, CustomDrawNodeCellEventArgs e)
        {
            if (e.Column == treeListColumnSize)
            {
                //Use the specified colour to indicate big folders.
                var sizeInBytes = Convert.ToInt64(e.CellValue);
                if (sizeInBytes >= Session.Settings.FolderStructureSettings.BigFolderInBytes)
                {
                    e.Appearance.ForeColor = Session.Settings.FolderStructureSettings.BigFolderColour;
                }
            }
        }
    }
}
