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

        /// <summary>
        /// Loads the folder structure.
        /// </summary>
        /// <param name="rootPath">The path to the root folder.</param>
        /// <remarks>The tree list is reusable due to the passing of the path as a parameter instead of fetching it from the session.</remarks>
        public void CreateFolderStructure(string rootPath)
        {
            treeListFolderStructure.BeginUpdate();
            treeListFolderStructure.Nodes.Clear();

            var root = new Folder(Session, rootPath);
            addDirectoryToTree(root, null);

            treeListFolderStructure.Nodes[0].Expand();
        }

        /// <summary>
        /// Adds a directory and its structure to the tree.
        /// </summary>
        /// <param name="directory">The directory to add.</param>
        /// <param name="parentNode">The parent node of the directory</param>
        private void addDirectoryToTree(Folder directory, TreeListNode parentNode)
        {
            //Add the node representing the directory.
            var data = new object[] { directory.Info.Name, directory.SizeInMB };
            var directoryNode = treeListFolderStructure.AppendNode(data, parentNode);

            //Add the nodes representing all the children.
            foreach (var child in directory.SubFolders)
            {
                addDirectoryToTree(child, directoryNode);
            }
        }
    }
}
