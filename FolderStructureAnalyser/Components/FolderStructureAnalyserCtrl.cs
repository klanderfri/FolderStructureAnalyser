using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using FolderStructureAnalyser.GUI;
using FolderStructureAnalyser.SessionBound;

namespace FolderStructureAnalyser.Components
{
    public partial class FolderStructureAnalyserCtrl : UserControl, ISessionBound, ICancellable
    {
        public Session Session { get; set; }

        /// <summary>
        /// Tells if the control is busy analysing a folder structure.
        /// </summary>
        public bool IsBusy
        {
            get { return backgroundWorkerTimeHeavyAnalysis.IsBusy; }
        }

        /// <summary>
        /// Tells if the analysis the control is doing is to be cancelled.
        /// </summary>
        public bool CancellationPending
        {
            get { return backgroundWorkerTimeHeavyAnalysis.CancellationPending; }
        }

        /// <summary>
        /// The description used for the analysis handled by the control.
        /// </summary>
        [Category("Analyse")]
        [Description("The description used for the analysis handled by the control.")]
        public string WaitFormDescription { get; set; }

        /// <summary>
        /// Keeps the last known position of the parent of the control.
        /// </summary>
        private Point LastKnownParentPosition { get; set; }

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
        /// Event raised when the control is about to start analysing a folder structure.
        /// </summary>
        [Category("Analyse")]
        [Description("Occurs when the control is about to start analysing a folder structure.")]
        public event FolderStructureAnalysisStartHandler FolderStructureAnalysisStart;

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
        public delegate void FolderStructureAnalysisStartHandler(object sender, FolderStructureAnalysisStartArgs e);

        /// <summary>
        /// Eventhandler for the event used when the analysis of a folder structure has progressed.
        /// </summary>
        /// <param name="sender">The user control raising the event.</param>
        /// <param name="e">The arguments for the event.</param>
        public delegate void FolderStructureAnalysisProgressChangedHandler(object sender, TimedProgressChangedEventArgs e);

        /// <summary>
        /// Eventhandler for the event used when the control has finished analysing the folder structure.
        /// </summary>
        /// <param name="sender">The user control raising the event.</param>
        /// <param name="e">The arguments for the event.</param>
        public delegate void FolderStructureAnalysisFinishedHandler(object sender, RunWorkerCompletedEventArgs e);

        /// <summary>
        /// Eventhandler for the event used when the analysis is called to be done.
        /// </summary>
        /// <param name="sender">The user control raising the event.</param>
        /// <param name="e">The arguments for the event.</param>
        public delegate void DoFolderStructureAnalysisHandler(object sender, DoWorkEventArgs e);

        /// <summary>
        /// Method raising the event used when the folder structure analysis has finished.
        /// </summary>
        /// <param name="e">The arguments for the event.</param>
        protected virtual void OnFolderStructureAnalysisStart(FolderStructureAnalysisStartArgs e)
        {
            FolderStructureAnalysisStart?.Invoke(this, e);
        }

        /// <summary>
        /// Method raising the event used when the analysis of a folder structure has progressed.
        /// </summary>
        /// <param name="e">The arguments for the event.</param>
        protected virtual void OnFolderStructureAnalysisProgressChanged(TimedProgressChangedEventArgs e)
        {
            FolderStructureAnalysisProgressChanged?.Invoke(this, e);
        }

        /// <summary>
        /// Method raising the event used when the folder structure analysis has finished.
        /// </summary>
        /// <param name="e">The arguments for the event.</param>
        protected virtual void OnFolderStructureAnalysisFinished(RunWorkerCompletedEventArgs e)
        {
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

        public FolderStructureAnalyserCtrl()
        {
            InitializeComponent();
        }

        public virtual void SessionSet(Session session)
        {
            Session = session;
            LastKnownParentPosition = ParentForm.Location;
            LastKnownSize = Size;
            ParentForm.Move += ParentForm_Move;
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
        /// Shows a wait form.
        /// </summary>
        /// <param name="description">The desription to show in the wait form.</param>
        public void ShowWaitForm(string description)
        {
            splashScreenManagerWaitForm.ShowWaitForm();
            splashScreenManagerWaitForm.SetWaitFormDescription(description);
        }

        /// <summary>
        /// Closes the wait form shown.
        /// </summary>
        public void CloseWaitForm()
        {
            splashScreenManagerWaitForm.CloseWaitForm();
        }

        public void StartAnalysis(object argument)
        {
            //Tell the user that the loading has started.
            OnFolderStructureAnalysisStart(new FolderStructureAnalysisStartArgs());

            //Send a first progress update to indicate 0 seconds progressed.
            var progressArgs = new TimedProgressChangedEventArgs(0);
            OnFolderStructureAnalysisProgressChanged(progressArgs);

            //Start the timer keeping track of the progress.
            ElapsedTicks = 0;
            timerAnalysisProgress.Start();
            AnalysisRunningTime.Restart();

            //Show the wait form.
            ShowWaitForm(WaitFormDescription);

            //Load the folder structure.
            backgroundWorkerTimeHeavyAnalysis.RunWorkerAsync(argument);
        }

        /// <summary>
        /// Cancel the analysis.
        /// </summary>
        public void CancelAnalysis()
        {
            backgroundWorkerTimeHeavyAnalysis.CancelAsync();
        }

        /// <summary>
        /// Cancel the analysis.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void CancelAsync()
        {
            CancelAnalysis();
        }

        /// <summary>
        /// Checks if an analysis can be started.
        /// </summary>
        /// <returns>TRUE if the operation may start, else FALSE.</returns>
        public bool MayStartAnalysis()
        {
            if (IsBusy)
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
        /// <returns>TRUE if an analyse may start, else FALSE.</returns>
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

        private void ParentForm_Move(object sender, EventArgs e)
        {
            if (splashScreenManagerWaitForm.IsSplashFormVisible)
            {
                //Find out how the wait form should be moved.
                int diffX = ParentForm.Location.X - LastKnownParentPosition.X;
                int diffY = ParentForm.Location.Y - LastKnownParentPosition.Y;
                var vector = new int[] { diffX, diffY };

                //Move the waitform.
                splashScreenManagerWaitForm.SendCommand(WaitFormCommand.Move, vector);
            }

            //Update the known parent position.
            LastKnownParentPosition = ParentForm.Location;
        }

        private void FolderStructureAnalyserCtrl_Resize(object sender, EventArgs e)
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
            var args = new TimedProgressChangedEventArgs(AnalysisRunningTime.ElapsedMilliseconds);
            OnFolderStructureAnalysisProgressChanged(args);
        }

        private void backgroundWorkerTimeHeavyAnalysis_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //Stop components needed to handle the operation.
            CloseWaitForm();
            timerAnalysisProgress.Stop();
            AnalysisRunningTime.Stop();
            
            //Make a last progress update.
            var progressArgs = new TimedProgressChangedEventArgs(AnalysisRunningTime.ElapsedMilliseconds);
            OnFolderStructureAnalysisProgressChanged(progressArgs);

            //Tell the subscriber that the loading finished.
            OnFolderStructureAnalysisFinished(e);
        }
    }
}
