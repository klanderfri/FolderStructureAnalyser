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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DiskAnalyserForm));
            this.treeListFolderStructure = new FolderStructureAnalyser.Components.AnalyserTreeList();
            this.statusStripRootPath = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabelCurrentRootPath = new FolderStructureAnalyser.Components.ToolStripStatusParameterLabel(this.components);
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.barButtonItemAnalyseStructure = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemSelectRoot = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPageFolderStructureAnalyser = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroupAnalyse = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.backgroundWorkerAnalyseFolderStructure = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.treeListFolderStructure)).BeginInit();
            this.statusStripRootPath.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            this.SuspendLayout();
            // 
            // treeListFolderStructure
            // 
            this.treeListFolderStructure.Location = new System.Drawing.Point(12, 12);
            this.treeListFolderStructure.Name = "treeListFolderStructure";
            this.treeListFolderStructure.Size = new System.Drawing.Size(293, 551);
            this.treeListFolderStructure.TabIndex = 0;
            // 
            // statusStripRootPath
            // 
            this.statusStripRootPath.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelCurrentRootPath});
            this.statusStripRootPath.Location = new System.Drawing.Point(0, 718);
            this.statusStripRootPath.Name = "statusStripRootPath";
            this.statusStripRootPath.Size = new System.Drawing.Size(1359, 22);
            this.statusStripRootPath.TabIndex = 1;
            this.statusStripRootPath.Text = "statusStrip1";
            // 
            // toolStripStatusLabelCurrentRootPath
            // 
            this.toolStripStatusLabelCurrentRootPath.Name = "toolStripStatusLabelCurrentRootPath";
            this.toolStripStatusLabelCurrentRootPath.ParameterText = "Current root path: {0}";
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
            this.barButtonItemAnalyseStructure.Id = 1;
            this.barButtonItemAnalyseStructure.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barButtonItemAnalyseStructure.ImageOptions.SvgImage")));
            this.barButtonItemAnalyseStructure.Name = "barButtonItemAnalyseStructure";
            this.barButtonItemAnalyseStructure.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemAnalyseStructure_ItemClick);
            // 
            // barButtonItemSelectRoot
            // 
            this.barButtonItemSelectRoot.Caption = "Select Root";
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
            // gridControl1
            // 
            this.gridControl1.Location = new System.Drawing.Point(309, 12);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.MenuManager = this.ribbonControl1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1038, 551);
            this.gridControl1.TabIndex = 2;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.gridControl1);
            this.layoutControl1.Controls.Add(this.treeListFolderStructure);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 143);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.Root;
            this.layoutControl1.Size = new System.Drawing.Size(1359, 575);
            this.layoutControl1.TabIndex = 4;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(1359, 575);
            this.Root.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.treeListFolderStructure;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(297, 555);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.gridControl1;
            this.layoutControlItem2.Location = new System.Drawing.Point(297, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(1042, 555);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // backgroundWorkerAnalyseFolderStructure
            // 
            this.backgroundWorkerAnalyseFolderStructure.WorkerReportsProgress = true;
            this.backgroundWorkerAnalyseFolderStructure.WorkerSupportsCancellation = true;
            this.backgroundWorkerAnalyseFolderStructure.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerAnalyseFolderStructure_DoWork);
            this.backgroundWorkerAnalyseFolderStructure.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerAnalyseFolderStructure_RunWorkerCompleted);
            // 
            // DiskAnalyserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1359, 740);
            this.Controls.Add(this.layoutControl1);
            this.Controls.Add(this.statusStripRootPath);
            this.Controls.Add(this.ribbonControl1);
            this.Name = "DiskAnalyserForm";
            this.Ribbon = this.ribbonControl1;
            this.Text = "Disk Analyser";
            ((System.ComponentModel.ISupportInitialize)(this.treeListFolderStructure)).EndInit();
            this.statusStripRootPath.ResumeLayout(false);
            this.statusStripRootPath.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private FolderStructureAnalyser.Components.AnalyserTreeList treeListFolderStructure;
        private System.Windows.Forms.StatusStrip statusStripRootPath;
        private Components.ToolStripStatusParameterLabel toolStripStatusLabelCurrentRootPath;
        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPageFolderStructureAnalyser;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroupAnalyse;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraBars.BarButtonItem barButtonItemAnalyseStructure;
        private DevExpress.XtraBars.BarButtonItem barButtonItemSelectRoot;
        private System.ComponentModel.BackgroundWorker backgroundWorkerAnalyseFolderStructure;
    }
}

