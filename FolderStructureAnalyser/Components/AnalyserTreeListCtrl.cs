using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;
using FolderStructureAnalyser.BuisnessObjects;
using FolderStructureAnalyser.GUI;
using FolderStructureAnalyser.SessionBound;

namespace FolderStructureAnalyser.Components
{
    public partial class AnalyserTreeListCtrl : FolderStructureAnalyserCtrl
    {
        /// <summary>
        /// Tells if the control is busy analysing a folder structure.
        /// </summary>
        public bool IsBusy
        {
            get { return backgroundWorkerStructureAnalyser.IsBusy; }
        }

        /// <summary>
        /// The amount of timer ticks elapsed since the last analyse was started.
        /// </summary>
        private long ElapsedTicks { get; set; }

        /// <summary>
        /// Watch keeping track of the lenght of the folder structure analyse.
        /// </summary>
        private Stopwatch AnalyseOperationTime { get; set; } = new Stopwatch();

        /// <summary>
        /// Keeps the last known position of the parent of the control.
        /// </summary>
        private Point LastKnownParentPosition { get; set; }

        /// <summary>
        /// Keeps the last known size of the control.
        /// </summary>
        private Size LastKnownSize { get; set; }

        /// <summary>
        /// The folder structure from the last finished analyse.
        /// </summary>
        private BindingList<FolderNode> LastAnalysedStructure { get; set; }

        /// <summary>
        /// Event raised when the control has finished loading the folder structure.
        /// </summary>
        [Category("Analyse")]
        [Description("Occurs when the control has finished loading a folder structure.")]
        public event FolderStructureLoadFinishedHandler FolderStructureLoadFinished;

        /// <summary>
        /// Event raised when the control is about to load a folder structure.
        /// </summary>
        [Category("Analyse")]
        [Description("Occurs when the control is about to load a folder structure.")]
        public event FolderStructureLoadStartHandler FolderStructureLoadStart;

        /// <summary>
        /// Event raised when the loading of a folder structure has progressed.
        /// </summary>
        [Category("Analyse")]
        [Description("Occurs when the control is about to load a folder structure.")]
        public event FolderStructureLoadProgressChangedHandler FolderStructureLoadProgressChanged;

        /// <summary>
        /// Eventhandler for the event used when the folder structure has finished loading.
        /// </summary>
        /// <param name="sender">The user control raising the event.</param>
        /// <param name="e">The arguments for the event.</param>
        public delegate void FolderStructureLoadFinishedHandler(object sender, FolderStructureLoadFinishedArgs e);

        /// <summary>
        /// Eventhandler for the event used when the folder structure is about to be loaded.
        /// </summary>
        /// <param name="sender">The user control raising the event.</param>
        /// <param name="e">The arguments for the event.</param>
        public delegate void FolderStructureLoadStartHandler(object sender, FolderStructureLoadStartArgs e);

        /// <summary>
        /// Eventhandler for the event used when the loading of a folder structure has progressed.
        /// </summary>
        /// <param name="sender">The user control raising the event.</param>
        /// <param name="e">The arguments for the event.</param>
        public delegate void FolderStructureLoadProgressChangedHandler(object sender, TimedProgressChangedEventArgs e);

        /// <summary>
        /// Method raising the event used when the folder structure has finished loading.
        /// </summary>
        /// <param name="e">The arguments for the event.</param>
        protected virtual void OnFolderStructureLoadFinished(FolderStructureLoadFinishedArgs e)
        {
            FolderStructureLoadFinished?.Invoke(this, e);
        }

        /// <summary>
        /// Method raising the event used when the folder structure has finished loading.
        /// </summary>
        /// <param name="e">The arguments for the event.</param>
        protected virtual void OnFolderStructureLoadStart(FolderStructureLoadStartArgs e)
        {
            FolderStructureLoadStart?.Invoke(this, e);
        }

        /// <summary>
        /// Method raising the event used when the loading of a folder structure has progressed.
        /// </summary>
        /// <param name="e">The arguments for the event.</param>
        protected virtual void OnFolderStructureLoadProgressChanged(TimedProgressChangedEventArgs e)
        {
            FolderStructureLoadProgressChanged?.Invoke(this, e);
        }

        public AnalyserTreeListCtrl()
        {
            InitializeComponent();
        }

        public override void SessionSet(Session session)
        {
            base.SessionSet(session);
            LastKnownParentPosition = ParentForm.Location;
            LastKnownSize = Size;
            ParentForm.Move += ParentForm_Move;
        }

        /// <summary>
        /// Loads a folder structure the user selects.
        /// </summary>
        public void LoadFolderStructure()
        {
            if (mayStartAnalyse())
            {
                var path = ShowSelectFolderDialog("Select root folder", "Select the root folder to analyse.");
                LoadFolderStructure(path);
            }
        }

        /// <summary>
        /// Loads a folder structure.
        /// </summary>
        /// <param name="rootPath">The path to the root folder.</param>
        /// <remarks>The tree list is reusable due to the passing of the path as a parameter instead of fetching it from the session.</remarks>
        public void LoadFolderStructure(string rootPath)
        {
            if (mayStartAnalyse(rootPath))
            {
                //Tell the user that the loading has started.
                OnFolderStructureLoadStart(new FolderStructureLoadStartArgs());

                //Send a first progress update to indicate 0 seconds progressed.
                var progressArgs = new TimedProgressChangedEventArgs(0);
                OnFolderStructureLoadProgressChanged(progressArgs);

                //Start the timer keeping track of the progress.
                ElapsedTicks = 0;
                timerOperationTime.Start();
                AnalyseOperationTime.Restart();

                //Show the wait form.
                splashScreenManagerWaitForStructureAnalyse.ShowWaitForm();

                //Load the folder structure.
                Session.Settings.FolderStructureSettings.RootPath = rootPath;
                backgroundWorkerStructureAnalyser.RunWorkerAsync(rootPath);
            }
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
        /// Checks if an analyse can be started.
        /// </summary>
        /// <returns>TRUE if an analyse may start, else FALSE.</returns>
        private bool mayStartAnalyse()
        {
            if (IsBusy)
            {
                MessageBoxes.ShowAnalyseInProgressMessage();
                return false;
            }
            return true;
        }

        /// <summary>
        /// Checks if an analyse can be started.
        /// </summary>
        /// <param name="rootPath">The full path to the root folder that are to be analysed.</param>
        /// <returns>TRUE if an analyse may start, else FALSE.</returns>
        private bool mayStartAnalyse(string rootPath)
        {
            if (!mayStartAnalyse()) { return false; }
            if (String.IsNullOrWhiteSpace(rootPath)) { return false; }
            if (!Directory.Exists(rootPath))
            {
                MessageBoxes.ShowDirectoryDoesNotExistMessage(rootPath);
                return false;
            }
            return true;
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

        private void backgroundWorkerStructureAnalyser_DoWork(object sender, DoWorkEventArgs e)
        {
            var rootPath = e.Argument as string;
            var structure = new BindingList<FolderNode>();
            var worker = sender as BackgroundWorker;

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

        private void timerOperationTime_Tick(object sender, EventArgs e)
        {
            //Tell the user that the operation has progressed.
            var args = new TimedProgressChangedEventArgs(AnalyseOperationTime.ElapsedMilliseconds);
            OnFolderStructureLoadProgressChanged(args);
        }

        private void backgroundWorkerStructureAnalyser_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (!e.Cancelled)
            {
                //Update the structure shown.
                var structure = e.Result as BindingList<FolderNode>;
                updateDataSource(structure);
                LastAnalysedStructure = structure;
            }

            //Stop components needed to handle the operation.
            splashScreenManagerWaitForStructureAnalyse.CloseWaitForm();
            timerOperationTime.Stop();
            AnalyseOperationTime.Stop();

            //Make a last progress update.
            var progressArgs = new TimedProgressChangedEventArgs(AnalyseOperationTime.ElapsedMilliseconds);
            OnFolderStructureLoadProgressChanged(progressArgs);

            //Tell the subscribers that the loading finished.
            var finishedArgs = new FolderStructureLoadFinishedArgs() { Cancelled = e.Cancelled };
            OnFolderStructureLoadFinished(finishedArgs);
        }

        /// <summary>
        /// Adds a folder and its structure to the tree.
        /// </summary>
        /// <param name="worker">The background worker responsible for process.</param>
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
            if (e.NodeImageIndex >= 0)
            {
                var folder = getFolderFromNode(e.Node);
                e.NodeImageIndex = folder.StateImageIndex;
            }
        }
    }
}
