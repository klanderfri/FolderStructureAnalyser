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
            toolStripStatusLabelCurrentRootPath.ParameterText = Session.Settings.FolderStructureSettings.RootPath;
        }

        private void barButtonItemAnalyseStructure_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!backgroundWorkerAnalyseFolderStructure.IsBusy)
            {
                treeListFolderStructure.Nodes.Clear();
                backgroundWorkerAnalyseFolderStructure.RunWorkerAsync();
            }
        }

        private void barButtonItemSelectRoot_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void backgroundWorkerAnalyseFolderStructure_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        private void backgroundWorkerAnalyseFolderStructure_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (!e.Cancelled)
            {
                treeListFolderStructure.Nodes[0].Expand();
            }
        }
    }
}
