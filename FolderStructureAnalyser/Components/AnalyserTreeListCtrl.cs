using System;
using System.ComponentModel;
using System.Drawing;
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

        /// <summary>
        /// Keeps the last known position of the parent of the control.
        /// </summary>
        private Point LastKnownParentPosition { get; set; }

        /// <summary>
        /// Keeps the last known size of the control.
        /// </summary>
        private Size LastKnownSize { get; set; }


        /// <summary>
        /// Event raised when the control has finished loading the folder structure.
        /// </summary>
        public event EventHandler FolderStructureLoadFinished;

        public AnalyserTreeListCtrl()
        {
            InitializeComponent();
        }

        public void SessionSet(Session session)
        {
            Session = session;
            LastKnownParentPosition = ParentForm.Location;
            LastKnownSize = Size;
        }

        /// <summary>
        /// Loads a folder structure.
        /// </summary>
        /// <param name="rootPath">The path to the root folder.</param>
        /// <remarks>The tree list is reusable due to the passing of the path as a parameter instead of fetching it from the session.</remarks>
        public void LoadFolderStructure(string rootPath)
        {
            splashScreenManagerWaitForStructureAnalyse.ShowWaitForm();
            backgroundWorkerStructureAnalyser.RunWorkerAsync(rootPath);
        }

        /// <summary>
        /// Cancels the running analyse.
        /// </summary>
        public void CancelAnalyse()
        {
            if (backgroundWorkerStructureAnalyser.IsBusy)
            {
                backgroundWorkerStructureAnalyser.CancelAsync();
            }
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
            var worker = sender as BackgroundWorker;

            //Create the folder structure.
            var root = new Folder(Session, worker, rootPath);

            //Check if the process was cancelled.
            if (worker.CancellationPending)
            {
                e.Cancel = true;
                return;
            }

            //Add the structure to the data source.
            var folderID = 0;
            addDirectoryToDataSource(worker, structure, root, ref folderID, null);
            e.Result = structure;

            //Check if the process was cancelled.
            if (worker.CancellationPending)
            {
                e.Cancel = true;
                return;
            }
        }

        private void backgroundWorkerStructureAnalyser_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (!e.Cancelled)
            {
                updateDataSource(e.Result as BindingList<FolderNode>);
            }

            splashScreenManagerWaitForStructureAnalyse.CloseWaitForm();

            //Tell the subscribers that the loading finished.
            var args = new FolderStructureLoadFinishedArgs() { Cancelled = e.Cancelled };
            OnFolderStructureLoadFinished(args);
        }

        /// <summary>
        /// Method raising the event used when the folder structure has finished loading.
        /// </summary>
        /// <param name="e">The arguments for the event.</param>
        protected virtual void OnFolderStructureLoadFinished(FolderStructureLoadFinishedArgs e)
        {
            FolderStructureLoadFinished?.Invoke(this, e);
        }

        /// <summary>
        /// Adds a directory and its structure to the tree.
        /// </summary>
        /// <param name="worker">The background worker responsible for process.</param>
        /// <param name="structure">The folder structure containing the folder nodes.</param>
        /// <param name="directory">The folder to add.</param>
        /// <param name="folderID">The ID that should be assigned the node.</param>
        /// <param name="parentID">The ID of the node representing the folder parent.</param>
        private void addDirectoryToDataSource(BackgroundWorker worker, BindingList<FolderNode> structure, Folder directory, ref int folderID, int? parentID)
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
                //Check if the process is to be cancelled.
                if (worker.CancellationPending) { return; }

                addDirectoryToDataSource(worker, structure, child, ref folderID, node.ID);
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

        private void AnalyserTreeListCtrl_ParentChanged(object sender, EventArgs e)
        {
            ParentForm.Move += ParentForm_Move;
        }

        private void ParentForm_Move(object sender, EventArgs e)
        {
            if (splashScreenManagerWaitForStructureAnalyse.IsSplashFormVisible)
            {
                //Find out how the wait form should be moved.
                int diffX = ParentForm.Location.X - LastKnownParentPosition.X;
                int diffY = ParentForm.Location.Y - LastKnownParentPosition.Y;
                var vector = new int[] { diffX, diffY };

                //Move the waitform.
                splashScreenManagerWaitForStructureAnalyse.SendCommand(WaitFormCommand.Move, vector);
            }

            //Update the known parent position.
            LastKnownParentPosition = ParentForm.Location;
        }

        private void AnalyserTreeListCtrl_Resize(object sender, EventArgs e)
        {
            if (splashScreenManagerWaitForStructureAnalyse.IsSplashFormVisible)
            {
                //Find out how the wait form should be moved.
                int diffX = (Size.Width - LastKnownSize.Width) / 2;
                int diffY = (Size.Height - LastKnownSize.Height) / 2;
                var vector = new int[] { diffX, diffY };

                //Move the waitform.
                splashScreenManagerWaitForStructureAnalyse.SendCommand(WaitFormCommand.Move, vector);
            }

            //Update the known size.
            LastKnownSize = Size;
        }
    }
}
