namespace FolderStructureAnalyser.gui
{
    partial class DiskAnalyserForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DiskAnalyserForm));
            this.statusStripRootPath = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabelCurrentRootPath = new System.Windows.Forms.ToolStripStatusLabel();
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.barButtonItemAnalyseStructure = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemSelectRoot = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPageFolderStructureAnalyser = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroupAnalyse = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.backgroundWorkerAnalyseFolderStructure = new System.ComponentModel.BackgroundWorker();
            this.analyserTreeListCtrlFolderStructure = new FolderStructureAnalyser.Components.AnalyserTreeListCtrl();
            this.folderBrowserDialogSelectRootFolder = new System.Windows.Forms.FolderBrowserDialog();
            this.statusStripRootPath.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // statusStripRootPath
            // 
            this.statusStripRootPath.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelCurrentRootPath});
            this.statusStripRootPath.Location = new System.Drawing.Point(0, 718);
            this.statusStripRootPath.Name = "statusStripRootPath";
            this.statusStripRootPath.Size = new System.Drawing.Size(1359, 22);
            this.statusStripRootPath.TabIndex = 1;
            // 
            // toolStripStatusLabelCurrentRootPath
            // 
            this.toolStripStatusLabelCurrentRootPath.Name = "toolStripStatusLabelCurrentRootPath";
            this.toolStripStatusLabelCurrentRootPath.Size = new System.Drawing.Size(119, 17);
            this.toolStripStatusLabelCurrentRootPath.Text = "Current root path: {0}";
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl1.ExpandCollapseItem,
            this.barButtonItemAnalyseStructure,
            this.barButtonItemSelectRoot});
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.MaxItemId = 3;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPageFolderStructureAnalyser});
            this.ribbonControl1.Size = new System.Drawing.Size(1359, 143);
            // 
            // barButtonItemAnalyseStructure
            // 
            this.barButtonItemAnalyseStructure.Caption = "Analyse Structure";
            this.barButtonItemAnalyseStructure.Hint = "Analyses the selected root path and displays it.";
            this.barButtonItemAnalyseStructure.Id = 1;
            this.barButtonItemAnalyseStructure.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barButtonItemAnalyseStructure.ImageOptions.SvgImage")));
            this.barButtonItemAnalyseStructure.Name = "barButtonItemAnalyseStructure";
            this.barButtonItemAnalyseStructure.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemAnalyseStructure_ItemClick);
            // 
            // barButtonItemSelectRoot
            // 
            this.barButtonItemSelectRoot.Caption = "Select Root";
            this.barButtonItemSelectRoot.Hint = "Selects which folder path that are to be used as the root path.";
            this.barButtonItemSelectRoot.Id = 2;
            this.barButtonItemSelectRoot.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barButtonItemSelectRoot.ImageOptions.SvgImage")));
            this.barButtonItemSelectRoot.Name = "barButtonItemSelectRoot";
            this.barButtonItemSelectRoot.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText;
            this.barButtonItemSelectRoot.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemSelectRoot_ItemClick);
            // 
            // ribbonPageFolderStructureAnalyser
            // 
            this.ribbonPageFolderStructureAnalyser.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroupAnalyse});
            this.ribbonPageFolderStructureAnalyser.Name = "ribbonPageFolderStructureAnalyser";
            this.ribbonPageFolderStructureAnalyser.Text = "Folder Structure";
            // 
            // ribbonPageGroupAnalyse
            // 
            this.ribbonPageGroupAnalyse.ItemLinks.Add(this.barButtonItemAnalyseStructure);
            this.ribbonPageGroupAnalyse.ItemLinks.Add(this.barButtonItemSelectRoot);
            this.ribbonPageGroupAnalyse.Name = "ribbonPageGroupAnalyse";
            this.ribbonPageGroupAnalyse.Text = "Analyse";
            // 
            // backgroundWorkerAnalyseFolderStructure
            // 
            this.backgroundWorkerAnalyseFolderStructure.WorkerReportsProgress = true;
            this.backgroundWorkerAnalyseFolderStructure.WorkerSupportsCancellation = true;
            this.backgroundWorkerAnalyseFolderStructure.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerAnalyseFolderStructure_DoWork);
            this.backgroundWorkerAnalyseFolderStructure.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerAnalyseFolderStructure_RunWorkerCompleted);
            // 
            // analyserTreeListCtrlFolderStructure
            // 
            this.analyserTreeListCtrlFolderStructure.Dock = System.Windows.Forms.DockStyle.Fill;
            this.analyserTreeListCtrlFolderStructure.Location = new System.Drawing.Point(0, 143);
            this.analyserTreeListCtrlFolderStructure.Name = "analyserTreeListCtrlFolderStructure";
            this.analyserTreeListCtrlFolderStructure.Session = null;
            this.analyserTreeListCtrlFolderStructure.Size = new System.Drawing.Size(1359, 575);
            this.analyserTreeListCtrlFolderStructure.TabIndex = 3;
            // 
            // DiskAnalyserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1359, 740);
            this.Controls.Add(this.analyserTreeListCtrlFolderStructure);
            this.Controls.Add(this.statusStripRootPath);
            this.Controls.Add(this.ribbonControl1);
            this.Name = "DiskAnalyserForm";
            this.Ribbon = this.ribbonControl1;
            this.Text = "Disk Analyser";
            this.statusStripRootPath.ResumeLayout(false);
            this.statusStripRootPath.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.StatusStrip statusStripRootPath;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelCurrentRootPath;
        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPageFolderStructureAnalyser;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroupAnalyse;
        private DevExpress.XtraBars.BarButtonItem barButtonItemAnalyseStructure;
        private DevExpress.XtraBars.BarButtonItem barButtonItemSelectRoot;
        private System.ComponentModel.BackgroundWorker backgroundWorkerAnalyseFolderStructure;
        private Components.AnalyserTreeListCtrl analyserTreeListCtrlFolderStructure;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialogSelectRootFolder;
    }
}

