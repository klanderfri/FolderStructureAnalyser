using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;
using FolderStructureAnalyser.BuisnessObjects;
using FolderStructureAnalyser.SessionBound;

namespace FolderStructureAnalyser.Components
{
    public partial class AnalyserTreeList : TreeList, ISessionBound
    {
        public Session Session { get; set; }

        public Folder Root { get; private set; }

        public AnalyserTreeList()
        {
            InitializeComponent();
            AddColumns();
        }

        private void AddColumns()
        {
            BeginUpdate();
            var colName = Columns.Add();
            colName.Caption = "Name";
            colName.VisibleIndex = 0;
            var colSize = Columns.Add();
            colSize.Caption = "Size";
            colSize.VisibleIndex = 1;
            EndUpdate();
        }

        public void SessionSet(Session session)
        {
            Session = session;
        }

        public AnalyserTreeList(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        /// <summary>
        /// Adds a folder structure to the tree view.
        /// </summary>
        /// <param name="settings">An object representing the settings for adding the folder structure.</param>
        /// <remarks>The tree list is reusable due to the passing of the settings as a parameter instead of fetching them from the session.</remarks>
        public void CreateFolderStructure(FolderStructureSettings settings)
        {
            Root = new Folder(Session, settings.RootPath);
        }

        public void LoadFolderStructure()
        {
            addDirectoryToTree(Root, null);
        }

        private void addDirectoryToTree(Folder directory, TreeListNode parentNode)
        {
            var directoryNode = addNode(directory, parentNode);

            foreach (var child in directory.SubFolders)
            {
                addDirectoryToTree(child, directoryNode);
            }
        }

        private TreeListNode addNode(Folder directory, TreeListNode parentNode)
        {
            var data = new object[] { directory.Info.Name, directory.SizeInMB };
            return AppendNode(data, parentNode);
        }
    }
}
