using System;
using System.ComponentModel;
using System.Drawing;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using FolderStructureAnalyser.Events;
using FolderStructureAnalyser.Helpers;
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
            setBigFolderColour(Session.Settings.FolderStructureSettings.BigFolderColour);
            setBigFolderSize(Session.Settings.FolderStructureSettings.BigFolderInBytes);
            folderStructureAnalyserCtrl.SetSession(session);
            folderStructureComparerCtrl.SetSession(session);
        }

        /// <summary>
        /// Sets the colour used to indicate a big folder.
        /// </summary>
        /// <param name="bigFolderColour">The colour to use for big folders.</param>
        private void setBigFolderColour(Color bigFolderColour)
        {
            barEditItemBigFolderColour.EditValue = bigFolderColour;
            Session.Settings.FolderStructureSettings.BigFolderColour = bigFolderColour;
        }

        /// <summary>
        /// Sets the size at which a folder is to be considered big.
        /// </summary>
        /// <param name="bigFolderInBytes">The size limit in bytes.</param>
        private void setBigFolderSize(long bigFolderInBytes)
        {
            var bigFolderInMB = ByteSizeConverter.MbFromByte(bigFolderInBytes);
            var bigFolderSize = (int)Math.Round(bigFolderInMB, 0);
            setBigFolderSize(bigFolderSize);
        }

        /// <summary>
        /// Sets the size at which a folder is to be considered big.
        /// </summary>
        /// <param name="bigFolderInMB">The size limit in MB.</param>
        private void setBigFolderSize(int bigFolderInMB)
        {
            barEditItemBigFolderSize.EditValue = bigFolderInMB;
            Session.Settings.FolderStructureSettings.BigFolderInBytes = ByteSizeConverter.BytesFromMB(bigFolderInMB);
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

        private void barEditItembigFolderColour_EditValueChanged(object sender, EventArgs e)
        {
            var selectedColour = (Color)(sender as BarEditItem).EditValue;
            setBigFolderColour(selectedColour);
        }

        private void barEditItemBigFolderSize_EditValueChanged(object sender, EventArgs e)
        {
            var bigFolderSizeInMB = Convert.ToInt32((sender as BarEditItem).EditValue);
            setBigFolderSize(bigFolderSizeInMB);
        }
    }
}
