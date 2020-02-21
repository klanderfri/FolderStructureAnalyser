using System;
using System.ComponentModel;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using FolderStructureAnalyser.Events;
using FolderStructureAnalyser.SessionBound;

namespace FolderStructureAnalyser.Components
{
    public partial class DiskAnalyserForm : RibbonForm, ISessionBound
    {
        public Session Session { get; set; }

        /// <summary>
        /// The root path selected before the current one.
        /// </summary>
        private string LastRootPath { get; set; }

        public DiskAnalyserForm()
        {
            InitializeComponent();
        }

        public void SetSession(Session session)
        {
            Session = session;
            folderStructureAnalyserCtrl.SetSession(session);
            folderStructureComparerCtrl.SetSession(session);
            folderStructureSettingsCtrl.SetSession(session);
        }

        /// <summary>
        /// Updates the label telling the user how long the folder structure analysis has run.
        /// </summary>
        /// <param name="elapsedMilliseconds">The amount of milliseconds that has passed since the analysis started.</param>
        private void updateOperationTime(long elapsedMilliseconds)
        {
            //Find the amount of seconds.
            var seconds = (long)Math.Floor((decimal)elapsedMilliseconds / 1000);

            //Update the information panel.
            operationMessageLogCtrl.UpdateOperationRuntime(seconds);

            //Update the status bar label.
            var format = "{0} sec";
            var text = String.Format(format, seconds);
            barStaticItemOperationTime.Caption = text;
        }

        /// <summary>
        /// Updates the enable state for the buttons starting analysis operations.
        /// </summary>
        /// <param name="operationStarted">TRUE if an analysis just started, FALSE if an analysis just finished.</param>
        private void setOperationButtonStates(bool operationStarted)
        {
            barButtonItemCancelAnalyse.Enabled = operationStarted;
            barButtonItemAnalyseStructure.Enabled = !operationStarted;
            barButtonItemCompareStructures.Enabled = !operationStarted;
        }

        /// <summary>
        /// Enables the update data button.
        /// </summary>
        /// <param name="updateDataButton">The button to enable.</param>
        /// <param name="analysisWasCancelled">TRUE if the last analysis was cancelled, else FALSE.</param>
        private void enableUpdateDataButton(BarButtonItem updateDataButton, bool analysisWasCancelled)
        {
            if (!analysisWasCancelled)
            {
                updateDataButton.Enabled = true;
            }
        }

        private void barButtonItemAnalyseStructure_ItemClick(object sender, ItemClickEventArgs e)
        {
            folderStructureAnalyserCtrl.AnalyseFolderStructure();
        }

        private void barButtonItemCancelAnalyse_ItemClick(object sender, ItemClickEventArgs e)
        {
            folderStructureAnalyserCtrl.CancelAnalysis();
            folderStructureComparerCtrl.CancelAnalysis();
        }

        private void barButtonItemSetAsRoot_ItemClick(object sender, ItemClickEventArgs e)
        {
            folderStructureAnalyserCtrl.SetFocusedNodeAsRoot();
        }

        private void barButtonItemResetTreeView_ItemClick(object sender, ItemClickEventArgs e)
        {
            folderStructureAnalyserCtrl.ResetTreeToLastAnalyse();
        }

        private void barButtonItemCompareStructures_ItemClick(object sender, ItemClickEventArgs e)
        {
            folderStructureComparerCtrl.CompareFolderStructures();
        }

        private void folderStructureAnalyserCtrl_FolderStructureAnalysisStart(object sender, FolderStructureAnalysisStartArgs e)
        {
            setOperationButtonStates(true);
        }

        private void folderStructureComparerCtrl_FolderStructureAnalysisStart(object sender, FolderStructureAnalysisStartArgs e)
        {
            setOperationButtonStates(true);
        }

        private void folderStructureAnalyserCtrl_FolderStructureAnalysisFinished(object sender, RunWorkerCompletedEventArgs e)
        {
            setOperationButtonStates(false);
            enableUpdateDataButton(barButtonItemUpdateAnalyserData, e.Cancelled);
        }

        private void folderStructureComparerCtrl_FolderStructureAnalysisFinished(object sender, RunWorkerCompletedEventArgs e)
        {
            setOperationButtonStates(false);
            enableUpdateDataButton(barButtonItemUpdateComparerData, e.Cancelled);
        }

        private void folderStructureAnalyserCtrl_FolderStructureAnalysisProgressChanged(object sender, TimedProgressChangedEventArgs e)
        {
            updateOperationTime(e.ElapsedMilliseconds);
        }

        private void folderStructureComparerCtrl_FolderStructureAnalysisProgressChanged(object sender, TimedProgressChangedEventArgs e)
        {
            updateOperationTime(e.ElapsedMilliseconds);
        }

        private void barButtonItemUpdateTreeList_ItemClick(object sender, ItemClickEventArgs e)
        {
            folderStructureAnalyserCtrl.RefreshData();
        }

        private void barButtonItemUpdateComparer_ItemClick(object sender, ItemClickEventArgs e)
        {
            folderStructureComparerCtrl.RefreshData();
        }
    }
}
