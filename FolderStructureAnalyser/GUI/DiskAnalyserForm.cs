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
            analyserTreeListCtrlFolderStructure.SessionSet(Session);
        }

        private void setRootPath(String rootPath)
        {
            toolStripStatusLabelCurrentRootPath.ParameterText = rootPath;
            Session.Settings.FolderStructureSettings.RootPath = rootPath;
        }

        private void barButtonItemAnalyseStructure_ItemClick(object sender, ItemClickEventArgs e)
        {
            analyserTreeListCtrlFolderStructure.BeginUpdate();
            backgroundWorkerAnalyseFolderStructure.RunWorkerAsync();
        }

        private void backgroundWorkerAnalyseFolderStructure_DoWork(object sender, DoWorkEventArgs e)
        {
            analyserTreeListCtrlFolderStructure.CreateFolderStructure(Session.Settings.FolderStructureSettings.RootPath);
        }

        private void backgroundWorkerAnalyseFolderStructure_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            analyserTreeListCtrlFolderStructure.EndUpdate();
        }

        private void barButtonItemSelectRoot_ItemClick(object sender, ItemClickEventArgs e)
        {

        }
    }
}
