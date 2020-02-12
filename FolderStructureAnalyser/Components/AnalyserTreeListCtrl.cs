using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FolderStructureAnalyser.SessionBound;
using FolderStructureAnalyser.BuisnessObjects;
using DevExpress.XtraTreeList.Nodes;
using FolderStructureAnalyser.GUI;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraTreeList;

namespace FolderStructureAnalyser.Components
{
    public partial class AnalyserTreeListCtrl : UserControl, ISessionBound
    {
        public Session Session { get; set; }

        public AnalyserTreeListCtrl()
        {
            InitializeComponent();
        }

        public void SessionSet(Session session)
        {
            Session = session;
        }

        public void BeginUpdate()
        {
            treeListFolderStructure.BeginUpdate();
            treeListFolderStructure.BeginUnboundLoad();
        }

        public void EndUpdate()
        {
            treeListFolderStructure.EndUnboundLoad();
            treeListFolderStructure.EndUpdate();
        }

        public void SetDataSource(BindingList<FolderNode> structure)
        {
            BeginUpdate();

            try
            {
                treeListFolderStructure.DataSource = structure;
            }
            finally
            {
                EndUpdate();
            }

            if (treeListFolderStructure.Nodes.Any())
            {
                treeListFolderStructure.Nodes[0].Expand();
            }
        }

        /// <summary>
        /// Creates a data source representing the folder structure.
        /// </summary>
        /// <param name="rootPath">The path to the root folder.</param>
        /// <remarks>The tree list is reusable due to the passing of the path as a parameter instead of fetching it from the session.</remarks>
        public BindingList<FolderNode> CreateFolderStructure(string rootPath)
        {
            var structure = new BindingList<FolderNode>();

            //Create the folder structure.
            var root = new Folder(Session, rootPath);

            //Add the structure to the data source.
            var folderID = 0;
            addDirectoryToDataSource(structure, root, ref folderID, null);

            return structure;
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
            var sizeInBytes = Convert.ToInt64(e.Value);
            e.DisplayText = Session.Tools.ByteSizeConverter.SizeStringFromByte(sizeInBytes);
        }

        private void treeListFolderStructure_CustomDrawNodeCell(object sender, CustomDrawNodeCellEventArgs e)
        {
            if (e.Column == treeListColumnSize)
            {
                var sizeInBytes = Convert.ToInt64(e.CellValue);
                if (sizeInBytes >= Session.Settings.FolderStructureSettings.BigFolderInBytes)
                {
                    e.Appearance.ForeColor = Session.Settings.FolderStructureSettings.BigFolderColour;
                }
            }
        }
    }
}
