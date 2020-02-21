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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DiskAnalyserForm));
            DevExpress.XtraBars.Docking2010.Views.Tabbed.DockingContainer dockingContainer1 = new DevExpress.XtraBars.Docking2010.Views.Tabbed.DockingContainer();
            this.documentGroupAnalyses = new DevExpress.XtraBars.Docking2010.Views.Tabbed.DocumentGroup(this.components);
            this.documentAnalyseStructure = new DevExpress.XtraBars.Docking2010.Views.Tabbed.Document(this.components);
            this.documentCompareStructures = new DevExpress.XtraBars.Docking2010.Views.Tabbed.Document(this.components);
            this.ribbonControlAnalyserApplication = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.barButtonItemAnalyseStructure = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemCancelAnalyse = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemSetAsRoot = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemResetTreeView = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemCompareStructures = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemUpdateComparerData = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemUpdateAnalyserData = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPageAnalyseFolderStructure = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroupAnalyse = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroupCompare = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroupStopOperations = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.repositoryItemColorPickEditBigFolderColour = new DevExpress.XtraEditors.Repository.RepositoryItemColorPickEdit();
            this.repositoryItemSpinEditBigFolderSize = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.folderStructureAnalyserCtrl = new FolderStructureAnalyser.Components.FolderStructureAnalyserCtrl();
            this.folderStructureComparerCtrl = new FolderStructureAnalyser.Components.FolderStructureComparerCtrl();
            this.folderStructureSettingsCtrl = new FolderStructureAnalyser.Components.FolderStructureSettingsCtrl();
            this.dockManagerApplicationContent = new DevExpress.XtraBars.Docking.DockManager(this.components);
            this.hideContainerRight = new DevExpress.XtraBars.Docking.AutoHideContainer();
            this.dockPanelSettings = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanelSettings_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.dockPanelCompareStructures = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanelCompareStructures_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.dockPanelAnalyseStructure = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanelAnalyseStructure_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.dockPanelInformation = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel1_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.operationMessageLogCtrl = new FolderStructureAnalyser.Components.OperationMessageLogCtrl();
            this.documentManagerAnalyses = new DevExpress.XtraBars.Docking2010.DocumentManager(this.components);
            this.tabbedViewAnalyses = new DevExpress.XtraBars.Docking2010.Views.Tabbed.TabbedView(this.components);
            this.hideContainerBottom = new DevExpress.XtraBars.Docking.AutoHideContainer();
            ((System.ComponentModel.ISupportInitialize)(this.documentGroupAnalyses)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.documentAnalyseStructure)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.documentCompareStructures)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControlAnalyserApplication)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemColorPickEditBigFolderColour)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSpinEditBigFolderSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockManagerApplicationContent)).BeginInit();
            this.hideContainerRight.SuspendLayout();
            this.dockPanelSettings.SuspendLayout();
            this.dockPanelSettings_Container.SuspendLayout();
            this.dockPanelCompareStructures.SuspendLayout();
            this.dockPanelCompareStructures_Container.SuspendLayout();
            this.dockPanelAnalyseStructure.SuspendLayout();
            this.dockPanelAnalyseStructure_Container.SuspendLayout();
            this.dockPanelInformation.SuspendLayout();
            this.dockPanel1_Container.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.documentManagerAnalyses)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabbedViewAnalyses)).BeginInit();
            this.hideContainerBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // documentGroupAnalyses
            // 
            this.documentGroupAnalyses.Items.AddRange(new DevExpress.XtraBars.Docking2010.Views.Tabbed.Document[] {
            this.documentAnalyseStructure,
            this.documentCompareStructures});
            // 
            // documentAnalyseStructure
            // 
            this.documentAnalyseStructure.Caption = "Analyse Structure";
            this.documentAnalyseStructure.ControlName = "dockPanelAnalyseStructure";
            this.documentAnalyseStructure.FloatLocation = new System.Drawing.Point(51, 282);
            this.documentAnalyseStructure.FloatSize = new System.Drawing.Size(200, 200);
            this.documentAnalyseStructure.Properties.AllowClose = DevExpress.Utils.DefaultBoolean.False;
            this.documentAnalyseStructure.Properties.AllowFloat = DevExpress.Utils.DefaultBoolean.True;
            this.documentAnalyseStructure.Properties.AllowFloatOnDoubleClick = DevExpress.Utils.DefaultBoolean.True;
            // 
            // documentCompareStructures
            // 
            this.documentCompareStructures.Caption = "Compare Structures";
            this.documentCompareStructures.ControlName = "dockPanelCompareStructures";
            this.documentCompareStructures.FloatLocation = new System.Drawing.Point(254, 276);
            this.documentCompareStructures.FloatSize = new System.Drawing.Size(200, 200);
            this.documentCompareStructures.Properties.AllowClose = DevExpress.Utils.DefaultBoolean.False;
            this.documentCompareStructures.Properties.AllowFloat = DevExpress.Utils.DefaultBoolean.True;
            this.documentCompareStructures.Properties.AllowFloatOnDoubleClick = DevExpress.Utils.DefaultBoolean.True;
            // 
            // ribbonControlAnalyserApplication
            // 
            this.ribbonControlAnalyserApplication.AutoSizeItems = true;
            this.ribbonControlAnalyserApplication.ExpandCollapseItem.Id = 0;
            this.ribbonControlAnalyserApplication.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControlAnalyserApplication.ExpandCollapseItem,
            this.barButtonItemAnalyseStructure,
            this.barButtonItemCancelAnalyse,
            this.barButtonItemSetAsRoot,
            this.barButtonItemResetTreeView,
            this.barButtonItemCompareStructures,
            this.barButtonItemUpdateComparerData,
            this.barButtonItemUpdateAnalyserData});
            this.ribbonControlAnalyserApplication.Location = new System.Drawing.Point(0, 0);
            this.ribbonControlAnalyserApplication.MaxItemId = 13;
            this.ribbonControlAnalyserApplication.Name = "ribbonControlAnalyserApplication";
            this.ribbonControlAnalyserApplication.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPageAnalyseFolderStructure});
            this.ribbonControlAnalyserApplication.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemColorPickEditBigFolderColour,
            this.repositoryItemSpinEditBigFolderSize});
            this.ribbonControlAnalyserApplication.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2013;
            this.ribbonControlAnalyserApplication.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.False;
            this.ribbonControlAnalyserApplication.ShowDisplayOptionsMenuButton = DevExpress.Utils.DefaultBoolean.False;
            this.ribbonControlAnalyserApplication.Size = new System.Drawing.Size(1278, 154);
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
            // barButtonItemUpdateComparerData
            // 
            this.barButtonItemUpdateComparerData.Caption = "Update";
            this.barButtonItemUpdateComparerData.Enabled = false;
            this.barButtonItemUpdateComparerData.Id = 11;
            this.barButtonItemUpdateComparerData.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barButtonItemUpdateComparerData.ImageOptions.SvgImage")));
            this.barButtonItemUpdateComparerData.Name = "barButtonItemUpdateComparerData";
            this.barButtonItemUpdateComparerData.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText;
            this.barButtonItemUpdateComparerData.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemUpdateComparer_ItemClick);
            // 
            // barButtonItemUpdateAnalyserData
            // 
            this.barButtonItemUpdateAnalyserData.Caption = "Update";
            this.barButtonItemUpdateAnalyserData.Enabled = false;
            this.barButtonItemUpdateAnalyserData.Id = 12;
            this.barButtonItemUpdateAnalyserData.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barButtonItemUpdateAnalyserData.ImageOptions.SvgImage")));
            this.barButtonItemUpdateAnalyserData.Name = "barButtonItemUpdateAnalyserData";
            this.barButtonItemUpdateAnalyserData.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText;
            this.barButtonItemUpdateAnalyserData.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemUpdateTreeList_ItemClick);
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
            this.ribbonPageGroupAnalyse.ItemLinks.Add(this.barButtonItemUpdateAnalyserData);
            this.ribbonPageGroupAnalyse.Name = "ribbonPageGroupAnalyse";
            this.ribbonPageGroupAnalyse.ShowCaptionButton = false;
            this.ribbonPageGroupAnalyse.Text = "Analyse";
            // 
            // ribbonPageGroupCompare
            // 
            this.ribbonPageGroupCompare.ItemLinks.Add(this.barButtonItemCompareStructures);
            this.ribbonPageGroupCompare.ItemLinks.Add(this.barButtonItemUpdateComparerData);
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
            // folderStructureAnalyserCtrl
            // 
            this.folderStructureAnalyserCtrl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.folderStructureAnalyserCtrl.Location = new System.Drawing.Point(0, 0);
            this.folderStructureAnalyserCtrl.Name = "folderStructureAnalyserCtrl";
            this.folderStructureAnalyserCtrl.Session = null;
            this.folderStructureAnalyserCtrl.Size = new System.Drawing.Size(1244, 507);
            this.folderStructureAnalyserCtrl.TabIndex = 1;
            this.folderStructureAnalyserCtrl.WaitFormDescription = "Structure size analysis in progress...";
            this.folderStructureAnalyserCtrl.FolderStructureAnalysisStart += new FolderStructureAnalyser.Components.FolderStructureParentCtrl.FolderStructureAnalysisStartHandler(this.folderStructureAnalyserCtrl_FolderStructureAnalysisStart);
            this.folderStructureAnalyserCtrl.FolderStructureAnalysisProgressChanged += new FolderStructureAnalyser.Components.FolderStructureParentCtrl.FolderStructureAnalysisProgressChangedHandler(this.folderStructureAnalyserCtrl_FolderStructureAnalysisProgressChanged);
            this.folderStructureAnalyserCtrl.FolderStructureAnalysisFinished += new FolderStructureAnalyser.Components.FolderStructureParentCtrl.FolderStructureAnalysisFinishedHandler(this.folderStructureAnalyserCtrl_FolderStructureAnalysisFinished);
            // 
            // folderStructureComparerCtrl
            // 
            this.folderStructureComparerCtrl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.folderStructureComparerCtrl.Location = new System.Drawing.Point(0, 0);
            this.folderStructureComparerCtrl.Name = "folderStructureComparerCtrl";
            this.folderStructureComparerCtrl.Session = null;
            this.folderStructureComparerCtrl.Size = new System.Drawing.Size(1244, 334);
            this.folderStructureComparerCtrl.TabIndex = 0;
            this.folderStructureComparerCtrl.WaitFormDescription = "Folder comparision in progress...";
            this.folderStructureComparerCtrl.FolderStructureAnalysisStart += new FolderStructureAnalyser.Components.FolderStructureParentCtrl.FolderStructureAnalysisStartHandler(this.folderStructureComparerCtrl_FolderStructureAnalysisStart);
            this.folderStructureComparerCtrl.FolderStructureAnalysisProgressChanged += new FolderStructureAnalyser.Components.FolderStructureParentCtrl.FolderStructureAnalysisProgressChangedHandler(this.folderStructureComparerCtrl_FolderStructureAnalysisProgressChanged);
            this.folderStructureComparerCtrl.FolderStructureAnalysisFinished += new FolderStructureAnalyser.Components.FolderStructureParentCtrl.FolderStructureAnalysisFinishedHandler(this.folderStructureComparerCtrl_FolderStructureAnalysisFinished);
            // 
            // folderStructureSettingsCtrl
            // 
            this.folderStructureSettingsCtrl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.folderStructureSettingsCtrl.Location = new System.Drawing.Point(0, 0);
            this.folderStructureSettingsCtrl.Name = "folderStructureSettingsCtrl";
            this.folderStructureSettingsCtrl.Session = null;
            this.folderStructureSettingsCtrl.Size = new System.Drawing.Size(276, 494);
            this.folderStructureSettingsCtrl.TabIndex = 0;
            // 
            // dockManagerApplicationContent
            // 
            this.dockManagerApplicationContent.AutoHideContainers.AddRange(new DevExpress.XtraBars.Docking.AutoHideContainer[] {
            this.hideContainerRight,
            this.hideContainerBottom});
            this.dockManagerApplicationContent.Form = this;
            this.dockManagerApplicationContent.RootPanels.AddRange(new DevExpress.XtraBars.Docking.DockPanel[] {
            this.dockPanelCompareStructures,
            this.dockPanelAnalyseStructure});
            this.dockManagerApplicationContent.TopZIndexControls.AddRange(new string[] {
            "DevExpress.XtraBars.BarDockControl",
            "DevExpress.XtraBars.StandaloneBarDockControl",
            "System.Windows.Forms.StatusBar",
            "System.Windows.Forms.MenuStrip",
            "System.Windows.Forms.StatusStrip",
            "DevExpress.XtraBars.Ribbon.RibbonStatusBar",
            "DevExpress.XtraBars.Ribbon.RibbonControl",
            "DevExpress.XtraBars.Navigation.OfficeNavigationBar",
            "DevExpress.XtraBars.Navigation.TileNavPane",
            "DevExpress.XtraBars.TabFormControl",
            "DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormControl"});
            // 
            // hideContainerRight
            // 
            this.hideContainerRight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.hideContainerRight.Controls.Add(this.dockPanelSettings);
            this.hideContainerRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.hideContainerRight.Location = new System.Drawing.Point(1250, 154);
            this.hideContainerRight.Name = "hideContainerRight";
            this.hideContainerRight.Size = new System.Drawing.Size(28, 565);
            // 
            // dockPanelSettings
            // 
            this.dockPanelSettings.Controls.Add(this.dockPanelSettings_Container);
            this.dockPanelSettings.Dock = DevExpress.XtraBars.Docking.DockingStyle.Right;
            this.dockPanelSettings.Hint = "Holds the settings used when analysing the disk.";
            this.dockPanelSettings.ID = new System.Guid("5b7bcb22-569b-4160-baef-020e1fea176a");
            this.dockPanelSettings.Location = new System.Drawing.Point(0, 0);
            this.dockPanelSettings.Name = "dockPanelSettings";
            this.dockPanelSettings.Options.ShowCloseButton = false;
            this.dockPanelSettings.OriginalSize = new System.Drawing.Size(283, 291);
            this.dockPanelSettings.SavedDock = DevExpress.XtraBars.Docking.DockingStyle.Right;
            this.dockPanelSettings.Size = new System.Drawing.Size(283, 543);
            this.dockPanelSettings.Text = "Settings";
            this.dockPanelSettings.Visibility = DevExpress.XtraBars.Docking.DockVisibility.AutoHide;
            // 
            // dockPanelSettings_Container
            // 
            this.dockPanelSettings_Container.Controls.Add(this.folderStructureSettingsCtrl);
            this.dockPanelSettings_Container.Location = new System.Drawing.Point(4, 46);
            this.dockPanelSettings_Container.Name = "dockPanelSettings_Container";
            this.dockPanelSettings_Container.Size = new System.Drawing.Size(276, 494);
            this.dockPanelSettings_Container.TabIndex = 0;
            // 
            // dockPanelCompareStructures
            // 
            this.dockPanelCompareStructures.Controls.Add(this.dockPanelCompareStructures_Container);
            this.dockPanelCompareStructures.DockedAsTabbedDocument = true;
            this.dockPanelCompareStructures.FloatLocation = new System.Drawing.Point(254, 276);
            this.dockPanelCompareStructures.Hint = "Holds the result from the last folder structure comparison.";
            this.dockPanelCompareStructures.ID = new System.Guid("6062c61d-09ad-4a67-9aa7-9fff4d3058e6");
            this.dockPanelCompareStructures.Name = "dockPanelCompareStructures";
            this.dockPanelCompareStructures.Options.ShowCloseButton = false;
            this.dockPanelCompareStructures.OriginalSize = new System.Drawing.Size(200, 200);
            this.dockPanelCompareStructures.SavedIndex = 1;
            this.dockPanelCompareStructures.SavedMdiDocument = true;
            this.dockPanelCompareStructures.Text = "Compare Structures";
            // 
            // dockPanelCompareStructures_Container
            // 
            this.dockPanelCompareStructures_Container.Controls.Add(this.folderStructureComparerCtrl);
            this.dockPanelCompareStructures_Container.Location = new System.Drawing.Point(0, 0);
            this.dockPanelCompareStructures_Container.Name = "dockPanelCompareStructures_Container";
            this.dockPanelCompareStructures_Container.Size = new System.Drawing.Size(1244, 334);
            this.dockPanelCompareStructures_Container.TabIndex = 0;
            // 
            // dockPanelAnalyseStructure
            // 
            this.dockPanelAnalyseStructure.Controls.Add(this.dockPanelAnalyseStructure_Container);
            this.dockPanelAnalyseStructure.DockedAsTabbedDocument = true;
            this.dockPanelAnalyseStructure.FloatLocation = new System.Drawing.Point(51, 282);
            this.dockPanelAnalyseStructure.Hint = "Holds the result from the last folder structure analysis.";
            this.dockPanelAnalyseStructure.ID = new System.Guid("1f51260b-7412-4d37-98c0-bba58130fbd5");
            this.dockPanelAnalyseStructure.Name = "dockPanelAnalyseStructure";
            this.dockPanelAnalyseStructure.Options.ShowCloseButton = false;
            this.dockPanelAnalyseStructure.OriginalSize = new System.Drawing.Size(200, 200);
            this.dockPanelAnalyseStructure.SavedIndex = 2;
            this.dockPanelAnalyseStructure.SavedMdiDocument = true;
            this.dockPanelAnalyseStructure.Text = "Analyse Structure";
            // 
            // dockPanelAnalyseStructure_Container
            // 
            this.dockPanelAnalyseStructure_Container.Controls.Add(this.folderStructureAnalyserCtrl);
            this.dockPanelAnalyseStructure_Container.Location = new System.Drawing.Point(0, 0);
            this.dockPanelAnalyseStructure_Container.Name = "dockPanelAnalyseStructure_Container";
            this.dockPanelAnalyseStructure_Container.Size = new System.Drawing.Size(1244, 507);
            this.dockPanelAnalyseStructure_Container.TabIndex = 0;
            // 
            // dockPanelInformation
            // 
            this.dockPanelInformation.Controls.Add(this.dockPanel1_Container);
            this.dockPanelInformation.Dock = DevExpress.XtraBars.Docking.DockingStyle.Bottom;
            this.dockPanelInformation.Hint = "Information messages raised during operations.";
            this.dockPanelInformation.ID = new System.Guid("e0d2d156-9a3e-42e5-b82b-62464aed10d8");
            this.dockPanelInformation.Location = new System.Drawing.Point(0, 0);
            this.dockPanelInformation.Name = "dockPanelInformation";
            this.dockPanelInformation.OriginalSize = new System.Drawing.Size(200, 200);
            this.dockPanelInformation.SavedDock = DevExpress.XtraBars.Docking.DockingStyle.Bottom;
            this.dockPanelInformation.SavedIndex = 2;
            this.dockPanelInformation.Size = new System.Drawing.Size(1250, 200);
            this.dockPanelInformation.Text = "Information";
            this.dockPanelInformation.Visibility = DevExpress.XtraBars.Docking.DockVisibility.AutoHide;
            // 
            // dockPanel1_Container
            // 
            this.dockPanel1_Container.Controls.Add(this.operationMessageLogCtrl);
            this.dockPanel1_Container.Location = new System.Drawing.Point(3, 47);
            this.dockPanel1_Container.Name = "dockPanel1_Container";
            this.dockPanel1_Container.Size = new System.Drawing.Size(1244, 150);
            this.dockPanel1_Container.TabIndex = 0;
            // 
            // operationMessageLogCtrl
            // 
            this.operationMessageLogCtrl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.operationMessageLogCtrl.Location = new System.Drawing.Point(0, 0);
            this.operationMessageLogCtrl.Name = "operationMessageLogCtrl";
            this.operationMessageLogCtrl.Session = null;
            this.operationMessageLogCtrl.Size = new System.Drawing.Size(1244, 150);
            this.operationMessageLogCtrl.TabIndex = 0;
            // 
            // documentManagerAnalyses
            // 
            this.documentManagerAnalyses.ContainerControl = this;
            this.documentManagerAnalyses.View = this.tabbedViewAnalyses;
            this.documentManagerAnalyses.ViewCollection.AddRange(new DevExpress.XtraBars.Docking2010.Views.BaseView[] {
            this.tabbedViewAnalyses});
            // 
            // tabbedViewAnalyses
            // 
            this.tabbedViewAnalyses.DocumentGroups.AddRange(new DevExpress.XtraBars.Docking2010.Views.Tabbed.DocumentGroup[] {
            this.documentGroupAnalyses});
            this.tabbedViewAnalyses.Documents.AddRange(new DevExpress.XtraBars.Docking2010.Views.BaseDocument[] {
            this.documentAnalyseStructure,
            this.documentCompareStructures});
            dockingContainer1.Element = this.documentGroupAnalyses;
            this.tabbedViewAnalyses.RootContainer.Nodes.AddRange(new DevExpress.XtraBars.Docking2010.Views.Tabbed.DockingContainer[] {
            dockingContainer1});
            // 
            // hideContainerBottom
            // 
            this.hideContainerBottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.hideContainerBottom.Controls.Add(this.dockPanelInformation);
            this.hideContainerBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.hideContainerBottom.Location = new System.Drawing.Point(0, 692);
            this.hideContainerBottom.Name = "hideContainerBottom";
            this.hideContainerBottom.Size = new System.Drawing.Size(1250, 27);
            // 
            // DiskAnalyserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1278, 719);
            this.Controls.Add(this.hideContainerBottom);
            this.Controls.Add(this.hideContainerRight);
            this.Controls.Add(this.ribbonControlAnalyserApplication);
            this.MinimumSize = new System.Drawing.Size(640, 400);
            this.Name = "DiskAnalyserForm";
            this.Ribbon = this.ribbonControlAnalyserApplication;
            this.Text = "Disk Analyser";
            ((System.ComponentModel.ISupportInitialize)(this.documentGroupAnalyses)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.documentAnalyseStructure)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.documentCompareStructures)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControlAnalyserApplication)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemColorPickEditBigFolderColour)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSpinEditBigFolderSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockManagerApplicationContent)).EndInit();
            this.hideContainerRight.ResumeLayout(false);
            this.dockPanelSettings.ResumeLayout(false);
            this.dockPanelSettings_Container.ResumeLayout(false);
            this.dockPanelCompareStructures.ResumeLayout(false);
            this.dockPanelCompareStructures_Container.ResumeLayout(false);
            this.dockPanelAnalyseStructure.ResumeLayout(false);
            this.dockPanelAnalyseStructure_Container.ResumeLayout(false);
            this.dockPanelInformation.ResumeLayout(false);
            this.dockPanel1_Container.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.documentManagerAnalyses)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabbedViewAnalyses)).EndInit();
            this.hideContainerBottom.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControlAnalyserApplication;
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
        private FolderStructureAnalyserCtrl folderStructureAnalyserCtrl;
        private FolderStructureComparerCtrl folderStructureComparerCtrl;
        private FolderStructureSettingsCtrl folderStructureSettingsCtrl;
        private DevExpress.XtraBars.BarButtonItem barButtonItemUpdateComparerData;
        private DevExpress.XtraBars.BarButtonItem barButtonItemUpdateAnalyserData;
        private DevExpress.XtraBars.Docking.DockManager dockManagerApplicationContent;
        private DevExpress.XtraBars.Docking.DockPanel dockPanelSettings;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanelSettings_Container;
        private DevExpress.XtraBars.Docking.DockPanel dockPanelAnalyseStructure;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanelAnalyseStructure_Container;
        private DevExpress.XtraBars.Docking.DockPanel dockPanelCompareStructures;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanelCompareStructures_Container;
        private DevExpress.XtraBars.Docking2010.DocumentManager documentManagerAnalyses;
        private DevExpress.XtraBars.Docking2010.Views.Tabbed.TabbedView tabbedViewAnalyses;
        private DevExpress.XtraBars.Docking2010.Views.Tabbed.DocumentGroup documentGroupAnalyses;
        private DevExpress.XtraBars.Docking2010.Views.Tabbed.Document documentAnalyseStructure;
        private DevExpress.XtraBars.Docking2010.Views.Tabbed.Document documentCompareStructures;
        private DevExpress.XtraBars.Docking.AutoHideContainer hideContainerRight;
        private DevExpress.XtraBars.Docking.DockPanel dockPanelInformation;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanel1_Container;
        private OperationMessageLogCtrl operationMessageLogCtrl;
        private DevExpress.XtraBars.Docking.AutoHideContainer hideContainerBottom;
    }
}

