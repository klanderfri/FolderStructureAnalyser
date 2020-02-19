namespace FolderStructureAnalyser.Components
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
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.barButtonItemAnalyseStructure = new DevExpress.XtraBars.BarButtonItem();
            this.repositoryItemColorPickEditBigFolderColour = new DevExpress.XtraEditors.Repository.RepositoryItemColorPickEdit();
            this.repositoryItemSpinEditBigFolderSize = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.barButtonItemCancelAnalyse = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemSetAsRoot = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemResetTreeView = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemCompareStructures = new DevExpress.XtraBars.BarButtonItem();
            this.barHeaderItemOperationTime = new DevExpress.XtraBars.BarHeaderItem();
            this.barStaticItemOperationTime = new DevExpress.XtraBars.BarStaticItem();
            this.ribbonPageAnalyseFolderStructure = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroupAnalyse = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroupCompare = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroupStopOperations = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonStatusBar1 = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.xtraTabControlAnalyserPages = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPageAnalyseStructure = new DevExpress.XtraTab.XtraTabPage();
            this.folderStructureAnalyserCtrl = new FolderStructureAnalyser.Components.FolderStructureAnalyserCtrl();
            this.xtraTabPageCompareStructures = new DevExpress.XtraTab.XtraTabPage();
            this.folderStructureComparerCtrl = new FolderStructureAnalyser.Components.FolderStructureComparerCtrl();
            this.xtraTabPageSettings = new DevExpress.XtraTab.XtraTabPage();
            this.folderStructureSettingsCtrl = new FolderStructureAnalyser.Components.FolderStructureSettingsCtrl();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemColorPickEditBigFolderColour)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSpinEditBigFolderSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControlAnalyserPages)).BeginInit();
            this.xtraTabControlAnalyserPages.SuspendLayout();
            this.xtraTabPageAnalyseStructure.SuspendLayout();
            this.xtraTabPageCompareStructures.SuspendLayout();
            this.xtraTabPageSettings.SuspendLayout();
            this.SuspendLayout();
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.AutoSizeItems = true;
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl1.ExpandCollapseItem,
            this.barButtonItemAnalyseStructure,
            this.barButtonItemCancelAnalyse,
            this.barButtonItemSetAsRoot,
            this.barButtonItemResetTreeView,
            this.barButtonItemCompareStructures,
            this.barHeaderItemOperationTime,
            this.barStaticItemOperationTime});
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.MaxItemId = 11;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPageAnalyseFolderStructure});
            this.ribbonControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemColorPickEditBigFolderColour,
            this.repositoryItemSpinEditBigFolderSize});
            this.ribbonControl1.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2013;
            this.ribbonControl1.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.False;
            this.ribbonControl1.ShowDisplayOptionsMenuButton = DevExpress.Utils.DefaultBoolean.False;
            this.ribbonControl1.Size = new System.Drawing.Size(1367, 154);
            this.ribbonControl1.StatusBar = this.ribbonStatusBar1;
            // 
            // barButtonItemAnalyseStructure
            // 
            this.barButtonItemAnalyseStructure.Caption = "Run Analysis";
            this.barButtonItemAnalyseStructure.Hint = "Analyses the selected root path and displays it.";
            this.barButtonItemAnalyseStructure.Id = 1;
            this.barButtonItemAnalyseStructure.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barButtonItemAnalyseStructure.ImageOptions.SvgImage")));
            this.barButtonItemAnalyseStructure.Name = "barButtonItemAnalyseStructure";
            this.barButtonItemAnalyseStructure.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemAnalyseStructure_ItemClick);
            // 
            // repositoryItemColorPickEditBigFolderColour
            // 
            this.repositoryItemColorPickEditBigFolderColour.AutoHeight = false;
            this.repositoryItemColorPickEditBigFolderColour.AutomaticColor = System.Drawing.Color.Black;
            this.repositoryItemColorPickEditBigFolderColour.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemColorPickEditBigFolderColour.Name = "repositoryItemColorPickEditBigFolderColour";
            // 
            // repositoryItemSpinEditBigFolderSize
            // 
            this.repositoryItemSpinEditBigFolderSize.AutoHeight = false;
            this.repositoryItemSpinEditBigFolderSize.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemSpinEditBigFolderSize.Mask.EditMask = ",#######0 MB";
            this.repositoryItemSpinEditBigFolderSize.Mask.UseMaskAsDisplayFormat = true;
            this.repositoryItemSpinEditBigFolderSize.MaxValue = new decimal(new int[] {
            1073741824,
            0,
            0,
            0});
            this.repositoryItemSpinEditBigFolderSize.MinValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.repositoryItemSpinEditBigFolderSize.Name = "repositoryItemSpinEditBigFolderSize";
            // 
            // barButtonItemCancelAnalyse
            // 
            this.barButtonItemCancelAnalyse.Caption = "Cancel operation";
            this.barButtonItemCancelAnalyse.Enabled = false;
            this.barButtonItemCancelAnalyse.Hint = "Cancels the current operation.";
            this.barButtonItemCancelAnalyse.Id = 5;
            this.barButtonItemCancelAnalyse.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barButtonItemCancelAnalyse.ImageOptions.SvgImage")));
            this.barButtonItemCancelAnalyse.Name = "barButtonItemCancelAnalyse";
            this.barButtonItemCancelAnalyse.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemCancelAnalyse_ItemClick);
            // 
            // barButtonItemSetAsRoot
            // 
            this.barButtonItemSetAsRoot.Caption = "Set as Root";
            this.barButtonItemSetAsRoot.Hint = "Sets the current focused node as the root of the folder structure.";
            this.barButtonItemSetAsRoot.Id = 6;
            this.barButtonItemSetAsRoot.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barButtonItemSetAsRoot.ImageOptions.SvgImage")));
            this.barButtonItemSetAsRoot.Name = "barButtonItemSetAsRoot";
            this.barButtonItemSetAsRoot.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText;
            this.barButtonItemSetAsRoot.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemSetAsRoot_ItemClick);
            // 
            // barButtonItemResetTreeView
            // 
            this.barButtonItemResetTreeView.Caption = "Reset Tree View";
            this.barButtonItemResetTreeView.Hint = "Resets the folder structure to the state after the last finished analysis.";
            this.barButtonItemResetTreeView.Id = 7;
            this.barButtonItemResetTreeView.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barButtonItemResetTreeView.ImageOptions.SvgImage")));
            this.barButtonItemResetTreeView.Name = "barButtonItemResetTreeView";
            this.barButtonItemResetTreeView.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText;
            this.barButtonItemResetTreeView.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemResetTreeView_ItemClick);
            // 
            // barButtonItemCompareStructures
            // 
            this.barButtonItemCompareStructures.Caption = "Run Comparison";
            this.barButtonItemCompareStructures.Hint = "Compares the selected structures and displays any differences.";
            this.barButtonItemCompareStructures.Id = 8;
            this.barButtonItemCompareStructures.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barButtonItemCompareStructures.ImageOptions.SvgImage")));
            this.barButtonItemCompareStructures.Name = "barButtonItemCompareStructures";
            this.barButtonItemCompareStructures.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemCompareStructures_ItemClick);
            // 
            // barHeaderItemOperationTime
            // 
            this.barHeaderItemOperationTime.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.barHeaderItemOperationTime.Appearance.Options.UseFont = true;
            this.barHeaderItemOperationTime.Caption = "Last operation time:";
            this.barHeaderItemOperationTime.Id = 9;
            this.barHeaderItemOperationTime.Name = "barHeaderItemOperationTime";
            // 
            // barStaticItemOperationTime
            // 
            this.barStaticItemOperationTime.Caption = "0 sec";
            this.barStaticItemOperationTime.Id = 10;
            this.barStaticItemOperationTime.Name = "barStaticItemOperationTime";
            // 
            // ribbonPageAnalyseFolderStructure
            // 
            this.ribbonPageAnalyseFolderStructure.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroupAnalyse,
            this.ribbonPageGroupCompare,
            this.ribbonPageGroupStopOperations});
            this.ribbonPageAnalyseFolderStructure.Name = "ribbonPageAnalyseFolderStructure";
            this.ribbonPageAnalyseFolderStructure.Text = "Analyse";
            // 
            // ribbonPageGroupAnalyse
            // 
            this.ribbonPageGroupAnalyse.ItemLinks.Add(this.barButtonItemAnalyseStructure);
            this.ribbonPageGroupAnalyse.ItemLinks.Add(this.barButtonItemSetAsRoot);
            this.ribbonPageGroupAnalyse.ItemLinks.Add(this.barButtonItemResetTreeView);
            this.ribbonPageGroupAnalyse.Name = "ribbonPageGroupAnalyse";
            this.ribbonPageGroupAnalyse.ShowCaptionButton = false;
            this.ribbonPageGroupAnalyse.Text = "Analyse";
            // 
            // ribbonPageGroupCompare
            // 
            this.ribbonPageGroupCompare.ItemLinks.Add(this.barButtonItemCompareStructures);
            this.ribbonPageGroupCompare.Name = "ribbonPageGroupCompare";
            this.ribbonPageGroupCompare.ShowCaptionButton = false;
            this.ribbonPageGroupCompare.Text = "Compare";
            // 
            // ribbonPageGroupStopOperations
            // 
            this.ribbonPageGroupStopOperations.ItemLinks.Add(this.barButtonItemCancelAnalyse);
            this.ribbonPageGroupStopOperations.Name = "ribbonPageGroupStopOperations";
            this.ribbonPageGroupStopOperations.ShowCaptionButton = false;
            this.ribbonPageGroupStopOperations.Text = "Stop";
            // 
            // ribbonStatusBar1
            // 
            this.ribbonStatusBar1.ItemLinks.Add(this.barHeaderItemOperationTime);
            this.ribbonStatusBar1.ItemLinks.Add(this.barStaticItemOperationTime);
            this.ribbonStatusBar1.Location = new System.Drawing.Point(0, 722);
            this.ribbonStatusBar1.Name = "ribbonStatusBar1";
            this.ribbonStatusBar1.Ribbon = this.ribbonControl1;
            this.ribbonStatusBar1.Size = new System.Drawing.Size(1367, 22);
            // 
            // xtraTabControlAnalyserPages
            // 
            this.xtraTabControlAnalyserPages.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTabControlAnalyserPages.Location = new System.Drawing.Point(0, 154);
            this.xtraTabControlAnalyserPages.Name = "xtraTabControlAnalyserPages";
            this.xtraTabControlAnalyserPages.SelectedTabPage = this.xtraTabPageAnalyseStructure;
            this.xtraTabControlAnalyserPages.Size = new System.Drawing.Size(1367, 568);
            this.xtraTabControlAnalyserPages.TabIndex = 7;
            this.xtraTabControlAnalyserPages.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPageAnalyseStructure,
            this.xtraTabPageCompareStructures,
            this.xtraTabPageSettings});
            // 
            // xtraTabPageAnalyseStructure
            // 
            this.xtraTabPageAnalyseStructure.Controls.Add(this.folderStructureAnalyserCtrl);
            this.xtraTabPageAnalyseStructure.Name = "xtraTabPageAnalyseStructure";
            this.xtraTabPageAnalyseStructure.Size = new System.Drawing.Size(1365, 545);
            this.xtraTabPageAnalyseStructure.Text = "Analyse Structure";
            // 
            // folderStructureAnalyserCtrl
            // 
            this.folderStructureAnalyserCtrl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.folderStructureAnalyserCtrl.Location = new System.Drawing.Point(0, 0);
            this.folderStructureAnalyserCtrl.Name = "folderStructureAnalyserCtrl";
            this.folderStructureAnalyserCtrl.Session = null;
            this.folderStructureAnalyserCtrl.Size = new System.Drawing.Size(1365, 545);
            this.folderStructureAnalyserCtrl.TabIndex = 4;
            this.folderStructureAnalyserCtrl.WaitFormDescription = "Structure size analysis in progress...";
            this.folderStructureAnalyserCtrl.FolderStructureAnalysisStart += new FolderStructureAnalyser.Components.FolderStructureParentCtrl.FolderStructureAnalysisStartHandler(this.folderStructureAnalyserCtrl_FolderStructureAnalysisStart);
            this.folderStructureAnalyserCtrl.FolderStructureAnalysisProgressChanged += new FolderStructureAnalyser.Components.FolderStructureParentCtrl.FolderStructureAnalysisProgressChangedHandler(this.folderStructureAnalyserCtrl_FolderStructureAnalysisProgressChanged);
            this.folderStructureAnalyserCtrl.FolderStructureAnalysisFinished += new FolderStructureAnalyser.Components.FolderStructureParentCtrl.FolderStructureAnalysisFinishedHandler(this.folderStructureAnalyserCtrl_FolderStructureAnalysisFinished);
            // 
            // xtraTabPageCompareStructures
            // 
            this.xtraTabPageCompareStructures.Controls.Add(this.folderStructureComparerCtrl);
            this.xtraTabPageCompareStructures.Name = "xtraTabPageCompareStructures";
            this.xtraTabPageCompareStructures.Size = new System.Drawing.Size(1365, 545);
            this.xtraTabPageCompareStructures.Text = "Compare Structures";
            // 
            // folderStructureComparerCtrl
            // 
            this.folderStructureComparerCtrl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.folderStructureComparerCtrl.Location = new System.Drawing.Point(0, 0);
            this.folderStructureComparerCtrl.Name = "folderStructureComparerCtrl";
            this.folderStructureComparerCtrl.Session = null;
            this.folderStructureComparerCtrl.Size = new System.Drawing.Size(1365, 545);
            this.folderStructureComparerCtrl.TabIndex = 0;
            this.folderStructureComparerCtrl.WaitFormDescription = "Folder comparision in progress...";
            this.folderStructureComparerCtrl.FolderStructureAnalysisStart += new FolderStructureAnalyser.Components.FolderStructureParentCtrl.FolderStructureAnalysisStartHandler(this.folderStructureComparerCtrl_FolderStructureAnalysisStart);
            this.folderStructureComparerCtrl.FolderStructureAnalysisProgressChanged += new FolderStructureAnalyser.Components.FolderStructureParentCtrl.FolderStructureAnalysisProgressChangedHandler(this.folderStructureComparerCtrl_FolderStructureAnalysisProgressChanged);
            this.folderStructureComparerCtrl.FolderStructureAnalysisFinished += new FolderStructureAnalyser.Components.FolderStructureParentCtrl.FolderStructureAnalysisFinishedHandler(this.folderStructureComparerCtrl_FolderStructureAnalysisFinished);
            // 
            // xtraTabPageSettings
            // 
            this.xtraTabPageSettings.Controls.Add(this.folderStructureSettingsCtrl);
            this.xtraTabPageSettings.Name = "xtraTabPageSettings";
            this.xtraTabPageSettings.Size = new System.Drawing.Size(1365, 545);
            this.xtraTabPageSettings.Text = "Settings";
            // 
            // folderStructureSettingsCtrl
            // 
            this.folderStructureSettingsCtrl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.folderStructureSettingsCtrl.Location = new System.Drawing.Point(0, 0);
            this.folderStructureSettingsCtrl.Name = "folderStructureSettingsCtrl";
            this.folderStructureSettingsCtrl.Session = null;
            this.folderStructureSettingsCtrl.Size = new System.Drawing.Size(1365, 545);
            this.folderStructureSettingsCtrl.TabIndex = 0;
            // 
            // DiskAnalyserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1367, 744);
            this.Controls.Add(this.xtraTabControlAnalyserPages);
            this.Controls.Add(this.ribbonStatusBar1);
            this.Controls.Add(this.ribbonControl1);
            this.Name = "DiskAnalyserForm";
            this.Ribbon = this.ribbonControl1;
            this.StatusBar = this.ribbonStatusBar1;
            this.Text = "Disk Analyser";
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemColorPickEditBigFolderColour)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSpinEditBigFolderSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControlAnalyserPages)).EndInit();
            this.xtraTabControlAnalyserPages.ResumeLayout(false);
            this.xtraTabPageAnalyseStructure.ResumeLayout(false);
            this.xtraTabPageCompareStructures.ResumeLayout(false);
            this.xtraTabPageSettings.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPageAnalyseFolderStructure;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroupAnalyse;
        private DevExpress.XtraBars.BarButtonItem barButtonItemAnalyseStructure;
        private DevExpress.XtraEditors.Repository.RepositoryItemColorPickEdit repositoryItemColorPickEditBigFolderColour;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit repositoryItemSpinEditBigFolderSize;
        private DevExpress.XtraBars.BarButtonItem barButtonItemCancelAnalyse;
        private DevExpress.XtraBars.BarButtonItem barButtonItemSetAsRoot;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroupStopOperations;
        private DevExpress.XtraBars.BarButtonItem barButtonItemResetTreeView;
        private DevExpress.XtraBars.BarButtonItem barButtonItemCompareStructures;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroupCompare;
        private DevExpress.XtraBars.BarHeaderItem barHeaderItemOperationTime;
        private DevExpress.XtraBars.BarStaticItem barStaticItemOperationTime;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar1;
        private DevExpress.XtraTab.XtraTabControl xtraTabControlAnalyserPages;
        private DevExpress.XtraTab.XtraTabPage xtraTabPageAnalyseStructure;
        private FolderStructureAnalyserCtrl folderStructureAnalyserCtrl;
        private DevExpress.XtraTab.XtraTabPage xtraTabPageCompareStructures;
        private FolderStructureComparerCtrl folderStructureComparerCtrl;
        private DevExpress.XtraTab.XtraTabPage xtraTabPageSettings;
        private FolderStructureSettingsCtrl folderStructureSettingsCtrl;
    }
}

