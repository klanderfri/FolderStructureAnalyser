﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraTreeList;
using FolderStructureAnalyser.Components.Support;
using FolderStructureAnalyser.Enums;
using FolderStructureAnalyser.Events;
using FolderStructureAnalyser.Helpers;
using FolderStructureAnalyser.SessionBound;

namespace FolderStructureAnalyser.Components.AnalyserPanels
{
    public partial class FolderStructureParentCtrl : AnalyserUserControl
    {
        /// <summary>
        /// The description used by the wait form to describe the analysis in progress.
        /// </summary>
        [Category("Analyse")]
        [Description("The description used by the wait form to describe the analysis in progress.")]
        public string WaitFormDescription { get; set; }

        /// <summary>
        /// A short text telling what kind of analysis the control performs.
        /// </summary>
        [Category("Analyse")]
        [Description("A short text telling what kind of analysis the control performs.")]
        public string AnalysisType { get; set; }

        /// <summary>
        /// The background worker responsible for performing the analysis.
        /// </summary>
        public BackgroundWorker AnalysisWorker { get { return backgroundWorkerTimeHeavyAnalysis; } }

        /// <summary>
        /// The path the user last requested to be analysed. May or may not have finished the analysis.
        /// </summary>
        private IEnumerable<string> LastPathsRequestedForAnalysis { get; set; } = new List<string>();

        /// <summary>
        /// The paths involved in the last finished analysis.
        /// </summary>
        private IEnumerable<string> LastPathsAnalysed { get; set; } = new List<string>();

        /// <summary>
        /// Keeps the last known position of the parent of the control.
        /// </summary>
        private Point LastKnownRootFormPosition { get; set; }

        /// <summary>
        /// Keeps the last known size of the control.
        /// </summary>
        private Size LastKnownSize { get; set; }

        /// <summary>
        /// The amount of timer ticks elapsed since the last analysis was started.
        /// </summary>
        private long ElapsedTicks { get; set; }

        /// <summary>
        /// Watch keeping track of the lenght of the folder structure analysis.
        /// </summary>
        private Stopwatch AnalysisRunningTime { get; set; } = new Stopwatch();

        /// <summary>
        /// The ID of the operation that was last started by the control.
        /// </summary>
        private int LastStartedOperationID { get; set; }

        /// <summary>
        /// Event raised when the control is about to start analysing a folder structure.
        /// </summary>
        [Category("Analyse")]
        [Description("Occurs when the control is about to start analysing a folder structure.")]
        public event FolderStructureAnalysisStartingHandler FolderStructureAnalysisStarting;

        /// <summary>
        /// Event raised when the analysis of a folder structure has progressed.
        /// </summary>
        [Category("Analyse")]
        [Description("Occurs when the analysis of a folder structure has progressed.")]
        public event FolderStructureAnalysisProgressChangedHandler FolderStructureAnalysisProgressChanged;

        /// <summary>
        /// Event raised when the control has finished analysing the folder structure.
        /// </summary>
        [Category("Analyse")]
        [Description("Occurs when the control has finished analysing a folder structure.")]
        public event FolderStructureAnalysisFinishedHandler FolderStructureAnalysisFinished;

        /// <summary>
        /// Event raised when the analysis is called to be done.
        /// </summary>
        [Category("Analyse")]
        [Description("Occurs when the analysis is called to be done.")]
        public event DoFolderStructureAnalysisHandler DoFolderStructureAnalysis;

        /// <summary>
        /// Eventhandler for the event used when the control is about to start analysing a folder structure.
        /// </summary>
        /// <param name="sender">The user control raising the event.</param>
        /// <param name="e">The arguments for the event.</param>
        public delegate void FolderStructureAnalysisStartingHandler(object sender, OperationStartingArgs e);

        /// <summary>
        /// Eventhandler for the event used when the analysis of a folder structure has progressed.
        /// </summary>
        /// <param name="sender">The user control raising the event.</param>
        /// <param name="e">The arguments for the event.</param>
        public delegate void FolderStructureAnalysisProgressChangedHandler(object sender, OperationRuntimeChangedArgs e);

        /// <summary>
        /// Eventhandler for the event used when the control has finished analysing the folder structure.
        /// </summary>
        /// <param name="sender">The user control raising the event.</param>
        /// <param name="e">The arguments for the event.</param>
        public delegate void FolderStructureAnalysisFinishedHandler(object sender, OperationFinishedArgs e);

        /// <summary>
        /// Eventhandler for the event used when the analysis is called to be done.
        /// </summary>
        /// <param name="sender">The user control raising the event.</param>
        /// <param name="e">The arguments for the event.</param>
        public delegate void DoFolderStructureAnalysisHandler(object sender, DoWorkEventArgs e);

        /// <summary>
        /// Method raising the event used when the folder structure analysis is about to start.
        /// </summary>
        protected virtual void OnFolderStructureAnalysisStarting()
        {
            LastStartedOperationID = Session.Tools.CreateNewOperationID();

            var startingArgs = new OperationStartingArgs(LastStartedOperationID, AnalysisType);
            OnFolderStructureAnalysisStarting(startingArgs);
        }

        /// <summary>
        /// Method raising the event used when the folder structure analysis is about to start.
        /// </summary>
        /// <param name="e">The arguments for the event.</param>
        protected virtual void OnFolderStructureAnalysisStarting(OperationStartingArgs e)
        {
            Session.MessageLog.AddLogMessage(LogMessageType.OperationStarting, e);
            FolderStructureAnalysisStarting?.Invoke(this, e);
        }

        /// <summary>
        /// Method raising the event used when the analysis of a folder structure has progressed.
        /// </summary>
        /// <param name="runtimeInMilliseconds">The current runtime of the operation.</param>
        protected virtual void OnFolderStructureAnalysisProgressChanged(long runtimeInMilliseconds)
        {
            var progressArgs = new OperationRuntimeChangedArgs(LastStartedOperationID, AnalysisType, runtimeInMilliseconds);
            OnFolderStructureAnalysisProgressChanged(progressArgs);
        }

        /// <summary>
        /// Method raising the event used when the analysis of a folder structure has progressed.
        /// </summary>
        /// <param name="e">The arguments for the event.</param>
        protected virtual void OnFolderStructureAnalysisProgressChanged(OperationRuntimeChangedArgs e)
        {
            Session.MessageLog.AddLogMessage(LogMessageType.OperationRuntimeUpdate, e);
            FolderStructureAnalysisProgressChanged?.Invoke(this, e);
        }

        /// <summary>
        /// Method raising the event used when the folder structure analysis has finished.
        /// </summary>
        /// <param name="cancelled">Tells if the operation was cancelled.</param>
        /// <param name="result">The result from the operation.</param>
        protected virtual void OnFolderStructureAnalysisFinished(bool cancelled, object result)
        {
            var finishedArgs = new OperationFinishedArgs(LastStartedOperationID, AnalysisType, cancelled, result);
            OnFolderStructureAnalysisFinished(finishedArgs);
        }

        /// <summary>
        /// Method raising the event used when the folder structure analysis has finished.
        /// </summary>
        /// <param name="e">The arguments for the event.</param>
        protected virtual void OnFolderStructureAnalysisFinished(OperationFinishedArgs e)
        {
            Session.MessageLog.AddLogMessage(LogMessageType.OperationFinished, e);
            FolderStructureAnalysisFinished?.Invoke(this, e);
        }

        /// <summary>
        /// Method raising the event performing the the analysis.
        /// </summary>
        /// <param name="e">The arguments for the event.</param>
        protected virtual void OnDoFolderStructureAnalysis(DoWorkEventArgs e)
        {
            DoFolderStructureAnalysis?.Invoke(this, e);
        }
        
        public FolderStructureParentCtrl()
        {
            InitializeComponent();
        }

        public override void SetSession(Session session)
        {
            base.SetSession(session);
            
            LastKnownRootFormPosition = Session.RootForm.Location;
            LastKnownSize = Size;
            Session.RootForm.Move += RootForm_Move;
        }

        /// <summary>
        /// Lets the user select a folder.
        /// </summary>
        /// <param name="title">The title of the folder dialog.</param>
        /// <param name="description">The description within the folder dialog.</param>
        /// <returns>The full path to the selected folder, NULL if the user cancelled.</returns>
        public string ShowSelectFolderDialog(string title, string description)
        {
            xtraFolderBrowserDialogSelectFolder.Title = title;
            xtraFolderBrowserDialogSelectFolder.Description = description;

            var result = xtraFolderBrowserDialogSelectFolder.ShowDialog();

            return (result == DialogResult.OK) ? xtraFolderBrowserDialogSelectFolder.SelectedPath : null;
        }

        /// <summary>
        /// Lets the user select a folder.
        /// </summary>
        /// <param name="title">The title of the folder dialog.</param>
        /// <param name="description">The description within the folder dialog.</param>
        /// <param name="selectedPath">The path to the folder that should be preselected.</param>
        /// <returns>The full path to the selected folder, NULL if the user cancelled.</returns>
        public string ShowSelectFolderDialog(string title, string description, string selectedPath)
        {
            xtraFolderBrowserDialogSelectFolder.SelectedPath = selectedPath;

            return ShowSelectFolderDialog(title, description);
        }

        /// <summary>
        /// Shows a wait form.
        /// </summary>
        private void showWaitForm()
        {
            splashScreenManagerWaitForm.ShowWaitForm();
            splashScreenManagerWaitForm.SetWaitFormDescription(WaitFormDescription);
        }

        /// <summary>
        /// Closes the wait form shown.
        /// </summary>
        private void closeWaitForm()
        {
            splashScreenManagerWaitForm.CloseWaitForm();
        }

        /// <summary>
        /// Starts the analysis.
        /// </summary>
        /// <param name="path">The path that is to be included in the analysis.</param>
        public void StartAnalysis(string path)
        {
            StartAnalysis(new List<string>() { path });
        }

        /// <summary>
        /// Starts the analysis.
        /// </summary>
        /// <param name="paths">The paths that are to be included in the analysis.</param>
        public void StartAnalysis(IEnumerable<string> paths)
        {
            //Tell the user that the analysis is about to start.
            OnFolderStructureAnalysisStarting();

            //Store the paths requested for analysis.
            LastPathsRequestedForAnalysis = paths;

            //Send a first progress update to indicate 0 seconds progressed.
            OnFolderStructureAnalysisProgressChanged(0);

            //Start the timer keeping track of the progress.
            ElapsedTicks = 0;
            timerAnalysisProgress.Start();
            AnalysisRunningTime.Restart();

            //Show the wait form.
            showWaitForm();

            //Load the folder structure.
            backgroundWorkerTimeHeavyAnalysis.RunWorkerAsync(paths);
        }

        /// <summary>
        /// Cancel the analysis.
        /// </summary>
        public void CancelAnalysis()
        {
            backgroundWorkerTimeHeavyAnalysis.CancelAsync();
        }

        /// <summary>
        /// Refreshes the data in the control.
        /// </summary>
        public void RefreshData()
        {
            if (LastPathsAnalysed.Any())
            {
                StartAnalysis(LastPathsAnalysed);
            }
        }

        /// <summary>
        /// Checks if an analysis can be started.
        /// </summary>
        /// <returns>TRUE if the operation may start, else FALSE.</returns>
        public bool MayStartAnalysis()
        {
            if (AnalysisWorker.IsBusy)
            {
                MessageBoxes.ShowAnalyseInProgressMessage();
                return false;
            }
            return true;
        }

        /// <summary>
        /// Checks if an analysis can be started.
        /// </summary>
        /// <param name="path">The full path to the folder that is to be analysed.</param>
        /// <returns>TRUE if the operation may start, else FALSE.</returns>
        public bool MayStartAnalysis(string path)
        {
            return MayStartAnalysis(new List<string>() { path });
        }

        /// <summary>
        /// Checks if an analysis can be started.
        /// </summary>
        /// <param name="paths">The full paths to the folders that are to be analysed.</param>
        /// <returns>TRUE if an analysis may start, else FALSE.</returns>
        public bool MayStartAnalysis(IEnumerable<string> paths)
        {
            if (!MayStartAnalysis()) { return false; }

            foreach (var path in paths)
            {
                if (!PathIsValid(path)) { return false; }
            }

            return true;
        }

        /// <summary>
        /// Tests if a path is valid, i.e pointing to a folder that can be used in a folder structure analysis.
        /// </summary>
        /// <param name="path">The path to test.</param>
        /// <returns>TRUE if the path is valid, else FALSE.</returns>
        public bool PathIsValid(string path)
        {
            if (String.IsNullOrWhiteSpace(path)) { return false; }
            if (!Directory.Exists(path))
            {
                MessageBoxes.ShowDirectoryDoesNotExistMessage(path);
                return false;
            }
            return true;
        }

        public void DrawCellNodeIcon(CustomDrawNodeCellEventArgs e, int columnWidth, int imageIndex)
        {
            if (imageIndex >= 0)
            {
                e.CellText = null;
                drawCellNodeIcon(e.DefaultDraw, e.Bounds, e.Graphics, columnWidth, imageIndex);
                e.Handled = true;
            }
        }

        public void DrawCellNodeIcon(RowCellCustomDrawEventArgs e, int columnWidth, int imageIndex)
        {
            if (imageIndex >= 0)
            {
                e.DisplayText = null;
                drawCellNodeIcon(e.DefaultDraw, e.Bounds, e.Graphics, columnWidth, imageIndex);
                e.Handled = true;
            }
        }

        private void drawCellNodeIcon(Action defaultDraw, Rectangle bounds, Graphics graphics, int columnWidth, int imageIndex)
        {
            defaultDraw();

            var cellIcon = IconCollection.GetImage(imageIndex);

            var location = bounds.Location;
            int middleX = (columnWidth - cellIcon.Width) / 2;
            location.Offset(middleX, 1);

            graphics.DrawImage(cellIcon, location);
        }

        private void RootForm_Move(object sender, EventArgs e)
        {
            if (splashScreenManagerWaitForm.IsSplashFormVisible)
            {
                //Find out how the wait form should be moved.
                int diffX = ParentForm.Location.X - LastKnownRootFormPosition.X;
                int diffY = ParentForm.Location.Y - LastKnownRootFormPosition.Y;
                var vector = new int[] { diffX, diffY };

                //Move the wait form.
                splashScreenManagerWaitForm.SendCommand(WaitFormCommand.Move, vector);
            }

            //Update the known parent position.
            LastKnownRootFormPosition = Session.RootForm.Location;
        }

        private void FolderStructureParentCtrl_Resize(object sender, EventArgs e)
        {
            if (splashScreenManagerWaitForm.IsSplashFormVisible)
            {
                //Find out how the wait form should be moved.
                int diffX = (Size.Width - LastKnownSize.Width) / 2;
                int diffY = (Size.Height - LastKnownSize.Height) / 2;
                var vector = new int[] { diffX, diffY };

                //Move the waitform.
                splashScreenManagerWaitForm.SendCommand(WaitFormCommand.Move, vector);
            }

            //Update the known size.
            LastKnownSize = Size;
        }

        private void backgroundWorkerTimeHeavyAnalysis_DoWork(object sender, DoWorkEventArgs e)
        {
            //Tell the subscriber to start doing the analysis.
            OnDoFolderStructureAnalysis(e);
        }

        private void timerAnalysisProgress_Tick(object sender, EventArgs e)
        {
            //Tell the subscriber that the operation has progressed.
            OnFolderStructureAnalysisProgressChanged(AnalysisRunningTime.ElapsedMilliseconds);
        }

        private void backgroundWorkerTimeHeavyAnalysis_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (!e.Cancelled)
            {
                //Store the paths used in the analysis.
                LastPathsAnalysed = LastPathsRequestedForAnalysis;
            }

            //Stop components needed to handle the operation.
            closeWaitForm();
            timerAnalysisProgress.Stop();
            AnalysisRunningTime.Stop();

            //Make a last progress update.
            OnFolderStructureAnalysisProgressChanged(AnalysisRunningTime.ElapsedMilliseconds);

            //Tell the subscriber that the loading finished.
            OnFolderStructureAnalysisFinished(e.Cancelled, (e.Cancelled ? null : e.Result));
        }
    }
}
