using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using FolderStructureAnalyser.GUI;
using FolderStructureAnalyser.SessionBound;

namespace FolderStructureAnalyser.gui
{
    public partial class DiskAnalyserForm : RibbonForm, ISessionBound
    {
        public Session Session { get; set; }

        public DiskAnalyserForm()
        {
            InitializeComponent();
        }

        public void SessionSet(Session session)
        {
            Session = session;
            setRootPath(Session.Settings.FolderStructureSettings.RootPath);
            setBigFolderColour(Session.Settings.FolderStructureSettings.BigFolderColour);
            setBigFolderSize(Session.Settings.FolderStructureSettings.BigFolderInBytes);
            analyserTreeListCtrlFolderStructure.SessionSet(Session);
        }

        /// <summary>
        /// Sets the path that are pointing to the root folder.
        /// </summary>
        /// <param name="rootPath">The full root folder path.</param>
        private void setRootPath(String rootPath)
        {
            var format = "Current root path: {0}";
            toolStripStatusLabelCurrentRootPath.Text = String.Format(format, rootPath);
            Session.Settings.FolderStructureSettings.RootPath = rootPath;
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

        private void barButtonItemAnalyseStructure_ItemClick(object sender, ItemClickEventArgs e)
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
                if (String.IsNullOrWhiteSpace(path))
                {
                    var format = "You have selected an invalid folder path:{0}{1}";
                    var message = String.Format(format, Environment.NewLine, path);
                    MessageBox.Show(message, "Invalid folder path.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    setRootPath(path);
                    analyserTreeListCtrlFolderStructure.LoadFolderStructure(Session.Settings.FolderStructureSettings.RootPath);
                }
            }
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
