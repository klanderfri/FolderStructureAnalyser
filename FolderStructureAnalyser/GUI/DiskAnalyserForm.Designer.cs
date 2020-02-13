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
            this.barEditItemBigFolderColour = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemColorPickEditBigFolderColour = new DevExpress.XtraEditors.Repository.RepositoryItemColorPickEdit();
            this.barEditItemBigFolderSize = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemSpinEditBigFolderSize = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.barButtonItemCancelAnalyse = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPageFolderStructureAnalyser = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroupAnalyse = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroupBigFolderSettings = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.analyserTreeListCtrlFolderStructure = new FolderStructureAnalyser.Components.AnalyserTreeListCtrl();
            this.folderBrowserDialogSelectRootFolder = new System.Windows.Forms.FolderBrowserDialog();
            this.statusStripRootPath.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemColorPickEditBigFolderColour)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSpinEditBigFolderSize)).BeginInit();
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
            this.ribbonControl1.AutoSizeItems = true;
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl1.ExpandCollapseItem,
            this.barButtonItemAnalyseStructure,
            this.barEditItemBigFolderColour,
            this.barEditItemBigFolderSize,
            this.barButtonItemCancelAnalyse});
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.MaxItemId = 6;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPageFolderStructureAnalyser});
            this.ribbonControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemColorPickEditBigFolderColour,
            this.repositoryItemSpinEditBigFolderSize});
            this.ribbonControl1.Size = new System.Drawing.Size(1359, 143);
            // 
            // barButtonItemAnalyseStructure
            // 
            this.barButtonItemAnalyseStructure.Caption = "Run Analyse";
            this.barButtonItemAnalyseStructure.Hint = "Analyses the selected root path and displays it.";
            this.barButtonItemAnalyseStructure.Id = 1;
            this.barButtonItemAnalyseStructure.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barButtonItemAnalyseStructure.ImageOptions.SvgImage")));
            this.barButtonItemAnalyseStructure.Name = "barButtonItemAnalyseStructure";
            this.barButtonItemAnalyseStructure.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemAnalyseStructure_ItemClick);
            // 
            // barEditItemBigFolderColour
            // 
            this.barEditItemBigFolderColour.Caption = "Colour";
            this.barEditItemBigFolderColour.Edit = this.repositoryItemColorPickEditBigFolderColour;
            this.barEditItemBigFolderColour.Hint = "The colour used to indicate a big folder.";
            this.barEditItemBigFolderColour.Id = 3;
            this.barEditItemBigFolderColour.Name = "barEditItemBigFolderColour";
            this.barEditItemBigFolderColour.EditValueChanged += new System.EventHandler(this.barEditItembigFolderColour_EditValueChanged);
            // 
            // repositoryItemColorPickEditBigFolderColour
            // 
            this.repositoryItemColorPickEditBigFolderColour.AutoHeight = false;
            this.repositoryItemColorPickEditBigFolderColour.AutomaticColor = System.Drawing.Color.Black;
            this.repositoryItemColorPickEditBigFolderColour.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemColorPickEditBigFolderColour.Name = "repositoryItemColorPickEditBigFolderColour";
            // 
            // barEditItemBigFolderSize
            // 
            this.barEditItemBigFolderSize.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.barEditItemBigFolderSize.Caption = "Size";
            this.barEditItemBigFolderSize.Edit = this.repositoryItemSpinEditBigFolderSize;
            this.barEditItemBigFolderSize.EditWidth = 80;
            this.barEditItemBigFolderSize.Hint = "Defines the size at which a folder should be considered big.";
            this.barEditItemBigFolderSize.Id = 4;
            this.barEditItemBigFolderSize.Name = "barEditItemBigFolderSize";
            this.barEditItemBigFolderSize.EditValueChanged += new System.EventHandler(this.barEditItemBigFolderSize_EditValueChanged);
            // 
            // repositoryItemSpinEditBigFolderSize
            // 
            this.repositoryItemSpinEditBigFolderSize.AutoHeight = false;
            this.repositoryItemSpinEditBigFolderSize.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemSpinEditBigFolderSize.Mask.EditMask = ",#######0 MB";
            this.repositoryItemSpinEditBigFolderSize.Mask.UseMaskAsDisplayFormat = true;
            this.repositoryItemSpinEditBigFolderSize.Name = "repositoryItemSpinEditBigFolderSize";
            // 
            // barButtonItemCancelAnalyse
            // 
            this.barButtonItemCancelAnalyse.Caption = "Cancel";
            this.barButtonItemCancelAnalyse.Hint = "Cancels the current analyse.";
            this.barButtonItemCancelAnalyse.Id = 5;
            this.barButtonItemCancelAnalyse.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barButtonItemCancelAnalyse.ImageOptions.SvgImage")));
            this.barButtonItemCancelAnalyse.Name = "barButtonItemCancelAnalyse";
            this.barButtonItemCancelAnalyse.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemCancelAnalyse_ItemClick);
            // 
            // ribbonPageFolderStructureAnalyser
            // 
            this.ribbonPageFolderStructureAnalyser.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroupAnalyse,
            this.ribbonPageGroupBigFolderSettings});
            this.ribbonPageFolderStructureAnalyser.Name = "ribbonPageFolderStructureAnalyser";
            this.ribbonPageFolderStructureAnalyser.Text = "Folder Structure";
            // 
            // ribbonPageGroupAnalyse
            // 
            this.ribbonPageGroupAnalyse.ItemLinks.Add(this.barButtonItemAnalyseStructure);
            this.ribbonPageGroupAnalyse.ItemLinks.Add(this.barButtonItemCancelAnalyse);
            this.ribbonPageGroupAnalyse.Name = "ribbonPageGroupAnalyse";
            this.ribbonPageGroupAnalyse.Text = "Analyse";
            // 
            // ribbonPageGroupBigFolderSettings
            // 
            this.ribbonPageGroupBigFolderSettings.ItemLinks.Add(this.barEditItemBigFolderColour);
            this.ribbonPageGroupBigFolderSettings.ItemLinks.Add(this.barEditItemBigFolderSize);
            this.ribbonPageGroupBigFolderSettings.Name = "ribbonPageGroupBigFolderSettings";
            this.ribbonPageGroupBigFolderSettings.Text = "Big Folder Settings";
            // 
            // analyserTreeListCtrlFolderStructure
            // 
            this.analyserTreeListCtrlFolderStructure.Dock = System.Windows.Forms.DockStyle.Fill;
            this.analyserTreeListCtrlFolderStructure.Location = new System.Drawing.Point(0, 143);
            this.analyserTreeListCtrlFolderStructure.Name = "analyserTreeListCtrlFolderStructure";
            this.analyserTreeListCtrlFolderStructure.Session = null;
            this.analyserTreeListCtrlFolderStructure.Size = new System.Drawing.Size(1359, 575);
            this.analyserTreeListCtrlFolderStructure.TabIndex = 3;
            this.analyserTreeListCtrlFolderStructure.FolderStructureLoadFinished += new FolderStructureAnalyser.Components.AnalyserTreeListCtrl.FolderStructureLoadFinishedHandler(this.analyserTreeListCtrlFolderStructure_FolderStructureLoadFinished);
            // 
            // folderBrowserDialogSelectRootFolder
            // 
            this.folderBrowserDialogSelectRootFolder.Description = "Select the root folder to analyse.";
            this.folderBrowserDialogSelectRootFolder.ShowNewFolderButton = false;
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
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemColorPickEditBigFolderColour)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSpinEditBigFolderSize)).EndInit();
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
        private Components.AnalyserTreeListCtrl analyserTreeListCtrlFolderStructure;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialogSelectRootFolder;
        private DevExpress.XtraBars.BarEditItem barEditItemBigFolderColour;
        private DevExpress.XtraEditors.Repository.RepositoryItemColorPickEdit repositoryItemColorPickEditBigFolderColour;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroupBigFolderSettings;
        private DevExpress.XtraBars.BarEditItem barEditItemBigFolderSize;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit repositoryItemSpinEditBigFolderSize;
        private DevExpress.XtraBars.BarButtonItem barButtonItemCancelAnalyse;
    }
}

