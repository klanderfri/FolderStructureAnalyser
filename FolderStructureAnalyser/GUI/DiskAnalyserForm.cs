using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraBars.Ribbon;
using FolderStructureAnalyser.SessionBound;
using DevExpress.XtraBars;
using System.Diagnostics;
using FolderStructureAnalyser.BuisnessObjects;
using FolderStructureAnalyser.GUI;

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
            barEditItembigFolderColour.EditValue = bigFolderColour;
            Session.Settings.FolderStructureSettings.BigFolderColour = bigFolderColour;
        }

        private void barButtonItemAnalyseStructure_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (backgroundWorkerAnalyseFolderStructure.IsBusy)
            {
                MessageBox.Show("An analyse is already in progress. Please wait for it to finish!", "Analyse in progress...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                backgroundWorkerAnalyseFolderStructure.RunWorkerAsync();
            }
        }

        private void barButtonItemSelectRoot_ItemClick(object sender, ItemClickEventArgs e)
        {
            folderBrowserDialogSelectRootFolder.ShowDialog();
            var path = folderBrowserDialogSelectRootFolder.SelectedPath;
            if (!String.IsNullOrWhiteSpace(path))
            {
                setRootPath(path);
            }
        }

        private void backgroundWorkerAnalyseFolderStructure_DoWork(object sender, DoWorkEventArgs e)
        {
            e.Result = analyserTreeListCtrlFolderStructure.CreateFolderStructure(Session.Settings.FolderStructureSettings.RootPath);
        }

        private void backgroundWorkerAnalyseFolderStructure_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            analyserTreeListCtrlFolderStructure.SetDataSource(e.Result as BindingList<FolderNode>);
        }

        private void barEditItembigFolderColour_EditValueChanged(object sender, EventArgs e)
        {
            setBigFolderColour((Color)(sender as BarEditItem).EditValue);
        }
    }
}
