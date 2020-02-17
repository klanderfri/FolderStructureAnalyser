﻿using System;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using FolderStructureAnalyser.Components;
using FolderStructureAnalyser.SessionBound;

namespace FolderStructureAnalyser.gui
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

        public void SessionSet(Session session)
        {
            Session = session;
            setBigFolderColour(Session.Settings.FolderStructureSettings.BigFolderColour);
            setBigFolderSize(Session.Settings.FolderStructureSettings.BigFolderInBytes);
            analyserTreeListCtrlFolderStructure.SessionSet(Session);
            xtraTabControlAnalyserPages.ShowTabHeader = DefaultBoolean.False;
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
            var bigFolderInMB = Session.Tools.ByteSizeConverter.MbFromByte(bigFolderInBytes);
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
            Session.Settings.FolderStructureSettings.BigFolderInBytes = Session.Tools.ByteSizeConverter.BytesFromMB(bigFolderInMB);
        }

        /// <summary>
        /// Starts an analyse of a folder structure.
        /// </summary>
        private void startFolderStructureAnalyse()
        {
            if (analyserTreeListCtrlFolderStructure.IsBusy)
            {
                var message = "An analyse is already in progress. Please wait for it to finish!";
                MessageBox.Show(message, "Analyse in progress...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                folderBrowserDialogSelectRootFolder.ShowDialog();
                var path = folderBrowserDialogSelectRootFolder.SelectedPath;
                if (!String.IsNullOrWhiteSpace(path))
                {
                    barButtonItemCancelAnalyse.Enabled = true;
                    analyserTreeListCtrlFolderStructure.LoadFolderStructure(path);
                }
            }
        }

        /// <summary>
        /// Updates the content page shown to the user.
        /// </summary>
        /// <param name="currentRibbonPage">The currently selected page in the ribbon.</param>
        private void updateContentPage(RibbonPage currentRibbonPage)
        {
            if (currentRibbonPage == ribbonPageFolderStructureAnalyser)
            {
                xtraTabControlAnalyserPages.SelectedTabPage = xtraTabPageAnalyseStructure;
            }
            else if (currentRibbonPage == ribbonPageFolderStructureComparer)
            {
                xtraTabControlAnalyserPages.SelectedTabPage = xtraTabPageCompareStructures;
            }
            else
            {
                var format = "The ribbon page '{0}' has not been assigned a content page.";
                var message = String.Format(format, currentRibbonPage.Text);
                throw new NotImplementedException(message);
            }
        }

        private void barButtonItemAnalyseStructure_ItemClick(object sender, ItemClickEventArgs e)
        {
            startFolderStructureAnalyse();
        }

        private void barButtonItemCancelAnalyse_ItemClick(object sender, ItemClickEventArgs e)
        {
            analyserTreeListCtrlFolderStructure.CancelAnalyse();
        }

        private void barButtonItemSetAsRoot_ItemClick(object sender, ItemClickEventArgs e)
        {
            analyserTreeListCtrlFolderStructure.SetFocusedNodeAsRoot();
        }

        private void barButtonItemResetTreeView_ItemClick(object sender, ItemClickEventArgs e)
        {
            analyserTreeListCtrlFolderStructure.ResetTreeToLastAnalyse();
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

        private void analyserTreeListCtrlFolderStructure_FolderStructureLoadFinished(object sender, FolderStructureLoadFinishedArgs e)
        {
            barButtonItemCancelAnalyse.Enabled = false;
        }

        private void ribbonControl1_SelectedPageChanged(object sender, EventArgs e)
        {
            var ribbon = sender as RibbonControl;
            updateContentPage(ribbon.SelectedPage);
        }
    }
}
