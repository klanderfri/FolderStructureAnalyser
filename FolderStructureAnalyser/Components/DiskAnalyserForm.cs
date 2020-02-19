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
            var seconds = (long)Math.Floor((decimal)elapsedMilliseconds / 1000);
            var format = "{0} sec";
            var text = String.Format(format, seconds);
            barStaticItemOperationTime.Caption = text;
        }

        private void barButtonItemAnalyseStructure_ItemClick(object sender, ItemClickEventArgs e)
        {
            folderStructureAnalyserCtrl.LoadFolderStructure();
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
            barButtonItemCancelAnalyse.Enabled = true;
        }

        private void folderStructureComparerCtrl_FolderStructureAnalysisStart(object sender, FolderStructureAnalysisStartArgs e)
        {
            barButtonItemCancelAnalyse.Enabled = true;
        }

        private void folderStructureAnalyserCtrl_FolderStructureAnalysisFinished(object sender, RunWorkerCompletedEventArgs e)
        {
            barButtonItemCancelAnalyse.Enabled = false;
            xtraTabControlAnalyserPages.SelectedTabPage = xtraTabPageAnalyseStructure;
        }

        private void folderStructureComparerCtrl_FolderStructureAnalysisFinished(object sender, RunWorkerCompletedEventArgs e)
        {
            barButtonItemCancelAnalyse.Enabled = false;
            xtraTabControlAnalyserPages.SelectedTabPage = xtraTabPageCompareStructures;
        }

        private void folderStructureAnalyserCtrl_FolderStructureAnalysisProgressChanged(object sender, TimedProgressChangedEventArgs e)
        {
            updateOperationTime(e.ElapsedMilliseconds);
        }

        private void folderStructureComparerCtrl_FolderStructureAnalysisProgressChanged(object sender, TimedProgressChangedEventArgs e)
        {
            updateOperationTime(e.ElapsedMilliseconds);
        }
    }
}
