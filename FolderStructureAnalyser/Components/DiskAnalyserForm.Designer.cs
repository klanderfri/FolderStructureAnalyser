﻿namespace FolderStructureAnalyser.Components
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
            DevExpress.XtraBars.Docking2010.Views.Tabbed.DockingContainer dockingContainer2 = new DevExpress.XtraBars.Docking2010.Views.Tabbed.DockingContainer();
            this.documentGroup1 = new DevExpress.XtraBars.Docking2010.Views.Tabbed.DocumentGroup(this.components);
            this.document1 = new DevExpress.XtraBars.Docking2010.Views.Tabbed.Document(this.components);
            this.document2 = new DevExpress.XtraBars.Docking2010.Views.Tabbed.Document(this.components);
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.barButtonItemAnalyseStructure = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemCancelAnalyse = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemSetAsRoot = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemResetTreeView = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemCompareStructures = new DevExpress.XtraBars.BarButtonItem();
            this.barHeaderItemOperationTime = new DevExpress.XtraBars.BarHeaderItem();
            this.barStaticItemOperationTime = new DevExpress.XtraBars.BarStaticItem();
            this.barButtonItemUpdateComparerData = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemUpdateAnalyserData = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPageAnalyseFolderStructure = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroupAnalyse = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroupCompare = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroupStopOperations = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.repositoryItemColorPickEditBigFolderColour = new DevExpress.XtraEditors.Repository.RepositoryItemColorPickEdit();
            this.repositoryItemSpinEditBigFolderSize = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.ribbonStatusBar1 = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.folderStructureAnalyserCtrl = new FolderStructureAnalyser.Components.FolderStructureAnalyserCtrl();
            this.folderStructureComparerCtrl = new FolderStructureAnalyser.Components.FolderStructureComparerCtrl();
            this.folderStructureSettingsCtrl = new FolderStructureAnalyser.Components.FolderStructureSettingsCtrl();
            this.dockManagerApplicationContent = new DevExpress.XtraBars.Docking.DockManager(this.components);
            this.dockPanel1 = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel1_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.dockPanel2 = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel2_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.dockPanelSettings = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel3_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.dockPanelAnalyseStructure = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanelAnalyseStructure_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.dockPanelCompareStructures = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanelCompareStructures_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.documentManagerAnalyses = new DevExpress.XtraBars.Docking2010.DocumentManager(this.components);
            this.tabbedView1 = new DevExpress.XtraBars.Docking2010.Views.Tabbed.TabbedView(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.documentGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.document1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.document2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemColorPickEditBigFolderColour)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSpinEditBigFolderSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockManagerApplicationContent)).BeginInit();
            this.dockPanel1.SuspendLayout();
            this.dockPanel2.SuspendLayout();
            this.dockPanelSettings.SuspendLayout();
            this.dockPanel3_Container.SuspendLayout();
            this.dockPanelAnalyseStructure.SuspendLayout();
            this.dockPanelAnalyseStructure_Container.SuspendLayout();
            this.dockPanelCompareStructures.SuspendLayout();
            this.dockPanelCompareStructures_Container.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.documentManagerAnalyses)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabbedView1)).BeginInit();
            this.SuspendLayout();
            // 
            // documentGroup1
            // 
            this.documentGroup1.Items.AddRange(new DevExpress.XtraBars.Docking2010.Views.Tabbed.Document[] {
            this.document1,
            this.document2});
            // 
            // document1
            // 
            this.document1.Caption = "Analyse Structure";
            this.document1.ControlName = "dockPanelAnalyseStructure";
            this.document1.FloatLocation = new System.Drawing.Point(0, 0);
            this.document1.FloatSize = new System.Drawing.Size(200, 200);
            this.document1.Properties.AllowClose = DevExpress.Utils.DefaultBoolean.True;
            this.document1.Properties.AllowFloat = DevExpress.Utils.DefaultBoolean.True;
            this.document1.Properties.AllowFloatOnDoubleClick = DevExpress.Utils.DefaultBoolean.True;
            // 
            // document2
            // 
            this.document2.Caption = "Compare Structures";
            this.document2.ControlName = "dockPanelCompareStructures";
            this.document2.FloatLocation = new System.Drawing.Point(180, 277);
            this.document2.FloatSize = new System.Drawing.Size(200, 200);
            this.document2.Properties.AllowClose = DevExpress.Utils.DefaultBoolean.True;
            this.document2.Properties.AllowFloat = DevExpress.Utils.DefaultBoolean.True;
            this.document2.Properties.AllowFloatOnDoubleClick = DevExpress.Utils.DefaultBoolean.True;
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
            this.barStaticItemOperationTime,
            this.barButtonItemUpdateComparerData,
            this.barButtonItemUpdateAnalyserData});
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.MaxItemId = 13;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPageAnalyseFolderStructure});
            this.ribbonControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemColorPickEditBigFolderColour,
            this.repositoryItemSpinEditBigFolderSize});
            this.ribbonControl1.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2013;
            this.ribbonControl1.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.False;
            this.ribbonControl1.ShowDisplayOptionsMenuButton = DevExpress.Utils.DefaultBoolean.False;
            this.ribbonControl1.Size = new System.Drawing.Size(1278, 154);
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
            // ribbonStatusBar1
            // 
            this.ribbonStatusBar1.ItemLinks.Add(this.barHeaderItemOperationTime);
            this.ribbonStatusBar1.ItemLinks.Add(this.barStaticItemOperationTime);
            this.ribbonStatusBar1.Location = new System.Drawing.Point(0, 697);
            this.ribbonStatusBar1.Name = "ribbonStatusBar1";
            this.ribbonStatusBar1.Ribbon = this.ribbonControl1;
            this.ribbonStatusBar1.Size = new System.Drawing.Size(1278, 22);
            // 
            // folderStructureAnalyserCtrl
            // 
            this.folderStructureAnalyserCtrl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.folderStructureAnalyserCtrl.Location = new System.Drawing.Point(0, 0);
            this.folderStructureAnalyserCtrl.Name = "folderStructureAnalyserCtrl";
            this.folderStructureAnalyserCtrl.Session = null;
            this.folderStructureAnalyserCtrl.Size = new System.Drawing.Size(989, 512);
            this.folderStructureAnalyserCtrl.TabIndex = 4;
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
            this.folderStructureComparerCtrl.Size = new System.Drawing.Size(989, 512);
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
            this.dockManagerApplicationContent.Form = this;
            this.dockManagerApplicationContent.HiddenPanels.AddRange(new DevExpress.XtraBars.Docking.DockPanel[] {
            this.dockPanel1,
            this.dockPanel2});
            this.dockManagerApplicationContent.RootPanels.AddRange(new DevExpress.XtraBars.Docking.DockPanel[] {
            this.dockPanelSettings,
            this.dockPanelAnalyseStructure,
            this.dockPanelCompareStructures});
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
            // dockPanel1
            // 
            this.dockPanel1.Controls.Add(this.dockPanel1_Container);
            this.dockPanel1.Dock = DevExpress.XtraBars.Docking.DockingStyle.Fill;
            this.dockPanel1.FloatVertical = true;
            this.dockPanel1.ID = new System.Guid("083eb10c-c9e6-425a-b2f6-313fc0806274");
            this.dockPanel1.Location = new System.Drawing.Point(3, 46);
            this.dockPanel1.Name = "dockPanel1";
            this.dockPanel1.OriginalSize = new System.Drawing.Size(200, 200);
            this.dockPanel1.SavedDock = DevExpress.XtraBars.Docking.DockingStyle.Fill;
            this.dockPanel1.SavedIndex = 0;
            this.dockPanel1.SavedParent = this.dockPanel2;
            this.dockPanel1.SavedTabbed = true;
            this.dockPanel1.Size = new System.Drawing.Size(483, 465);
            this.dockPanel1.Text = "dockPanel1";
            this.dockPanel1.Visibility = DevExpress.XtraBars.Docking.DockVisibility.Hidden;
            // 
            // dockPanel1_Container
            // 
            this.dockPanel1_Container.Location = new System.Drawing.Point(0, 0);
            this.dockPanel1_Container.Name = "dockPanel1_Container";
            this.dockPanel1_Container.Size = new System.Drawing.Size(483, 465);
            this.dockPanel1_Container.TabIndex = 0;
            // 
            // dockPanel2
            // 
            this.dockPanel2.Controls.Add(this.dockPanel2_Container);
            this.dockPanel2.Dock = DevExpress.XtraBars.Docking.DockingStyle.Left;
            this.dockPanel2.FloatVertical = true;
            this.dockPanel2.ID = new System.Guid("57528ff4-fffa-41df-ac8a-438af8b79570");
            this.dockPanel2.Location = new System.Drawing.Point(0, 154);
            this.dockPanel2.Name = "dockPanel2";
            this.dockPanel2.OriginalSize = new System.Drawing.Size(490, 200);
            this.dockPanel2.SavedDock = DevExpress.XtraBars.Docking.DockingStyle.Left;
            this.dockPanel2.SavedIndex = 0;
            this.dockPanel2.Size = new System.Drawing.Size(490, 543);
            this.dockPanel2.Text = "dockPanel2";
            this.dockPanel2.Visibility = DevExpress.XtraBars.Docking.DockVisibility.Hidden;
            // 
            // dockPanel2_Container
            // 
            this.dockPanel2_Container.Location = new System.Drawing.Point(3, 46);
            this.dockPanel2_Container.Name = "dockPanel2_Container";
            this.dockPanel2_Container.Size = new System.Drawing.Size(483, 494);
            this.dockPanel2_Container.TabIndex = 0;
            // 
            // dockPanelSettings
            // 
            this.dockPanelSettings.Controls.Add(this.dockPanel3_Container);
            this.dockPanelSettings.Dock = DevExpress.XtraBars.Docking.DockingStyle.Right;
            this.dockPanelSettings.Hint = "Holds the settings used when analysing the disk.";
            this.dockPanelSettings.ID = new System.Guid("5b7bcb22-569b-4160-baef-020e1fea176a");
            this.dockPanelSettings.Location = new System.Drawing.Point(995, 154);
            this.dockPanelSettings.Name = "dockPanelSettings";
            this.dockPanelSettings.OriginalSize = new System.Drawing.Size(283, 291);
            this.dockPanelSettings.Size = new System.Drawing.Size(283, 543);
            this.dockPanelSettings.Text = "Settings";
            // 
            // dockPanel3_Container
            // 
            this.dockPanel3_Container.Controls.Add(this.folderStructureSettingsCtrl);
            this.dockPanel3_Container.Location = new System.Drawing.Point(4, 46);
            this.dockPanel3_Container.Name = "dockPanel3_Container";
            this.dockPanel3_Container.Size = new System.Drawing.Size(276, 494);
            this.dockPanel3_Container.TabIndex = 0;
            // 
            // dockPanelAnalyseStructure
            // 
            this.dockPanelAnalyseStructure.Controls.Add(this.dockPanelAnalyseStructure_Container);
            this.dockPanelAnalyseStructure.DockedAsTabbedDocument = true;
            this.dockPanelAnalyseStructure.Hint = "Holds the result from the last folder structure analysis.";
            this.dockPanelAnalyseStructure.ID = new System.Guid("232f3c55-45b1-4583-ba23-2308df83004b");
            this.dockPanelAnalyseStructure.Name = "dockPanelAnalyseStructure";
            this.dockPanelAnalyseStructure.OriginalSize = new System.Drawing.Size(200, 200);
            this.dockPanelAnalyseStructure.Text = "Analyse Structure";
            // 
            // dockPanelAnalyseStructure_Container
            // 
            this.dockPanelAnalyseStructure_Container.Controls.Add(this.folderStructureAnalyserCtrl);
            this.dockPanelAnalyseStructure_Container.Location = new System.Drawing.Point(0, 0);
            this.dockPanelAnalyseStructure_Container.Name = "dockPanelAnalyseStructure_Container";
            this.dockPanelAnalyseStructure_Container.Size = new System.Drawing.Size(989, 512);
            this.dockPanelAnalyseStructure_Container.TabIndex = 0;
            // 
            // dockPanelCompareStructures
            // 
            this.dockPanelCompareStructures.Controls.Add(this.dockPanelCompareStructures_Container);
            this.dockPanelCompareStructures.DockedAsTabbedDocument = true;
            this.dockPanelCompareStructures.FloatLocation = new System.Drawing.Point(180, 277);
            this.dockPanelCompareStructures.Hint = "Holds the result from the last folder structure comparison.";
            this.dockPanelCompareStructures.ID = new System.Guid("6062c61d-09ad-4a67-9aa7-9fff4d3058e6");
            this.dockPanelCompareStructures.Name = "dockPanelCompareStructures";
            this.dockPanelCompareStructures.OriginalSize = new System.Drawing.Size(200, 200);
            this.dockPanelCompareStructures.SavedIndex = 2;
            this.dockPanelCompareStructures.SavedMdiDocument = true;
            this.dockPanelCompareStructures.Text = "Compare Structures";
            // 
            // dockPanelCompareStructures_Container
            // 
            this.dockPanelCompareStructures_Container.Controls.Add(this.folderStructureComparerCtrl);
            this.dockPanelCompareStructures_Container.Location = new System.Drawing.Point(0, 0);
            this.dockPanelCompareStructures_Container.Name = "dockPanelCompareStructures_Container";
            this.dockPanelCompareStructures_Container.Size = new System.Drawing.Size(989, 512);
            this.dockPanelCompareStructures_Container.TabIndex = 0;
            // 
            // documentManagerAnalyses
            // 
            this.documentManagerAnalyses.ContainerControl = this;
            this.documentManagerAnalyses.View = this.tabbedView1;
            this.documentManagerAnalyses.ViewCollection.AddRange(new DevExpress.XtraBars.Docking2010.Views.BaseView[] {
            this.tabbedView1});
            // 
            // tabbedView1
            // 
            this.tabbedView1.DocumentGroups.AddRange(new DevExpress.XtraBars.Docking2010.Views.Tabbed.DocumentGroup[] {
            this.documentGroup1});
            this.tabbedView1.Documents.AddRange(new DevExpress.XtraBars.Docking2010.Views.BaseDocument[] {
            this.document1,
            this.document2});
            dockingContainer2.Element = this.documentGroup1;
            this.tabbedView1.RootContainer.Nodes.AddRange(new DevExpress.XtraBars.Docking2010.Views.Tabbed.DockingContainer[] {
            dockingContainer2});
            // 
            // DiskAnalyserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1278, 719);
            this.Controls.Add(this.dockPanelSettings);
            this.Controls.Add(this.ribbonStatusBar1);
            this.Controls.Add(this.ribbonControl1);
            this.MinimumSize = new System.Drawing.Size(640, 400);
            this.Name = "DiskAnalyserForm";
            this.Ribbon = this.ribbonControl1;
            this.StatusBar = this.ribbonStatusBar1;
            this.Text = "Disk Analyser";
            ((System.ComponentModel.ISupportInitialize)(this.documentGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.document1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.document2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemColorPickEditBigFolderColour)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSpinEditBigFolderSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockManagerApplicationContent)).EndInit();
            this.dockPanel1.ResumeLayout(false);
            this.dockPanel2.ResumeLayout(false);
            this.dockPanelSettings.ResumeLayout(false);
            this.dockPanel3_Container.ResumeLayout(false);
            this.dockPanelAnalyseStructure.ResumeLayout(false);
            this.dockPanelAnalyseStructure_Container.ResumeLayout(false);
            this.dockPanelCompareStructures.ResumeLayout(false);
            this.dockPanelCompareStructures_Container.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.documentManagerAnalyses)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabbedView1)).EndInit();
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
        private FolderStructureAnalyserCtrl folderStructureAnalyserCtrl;
        private FolderStructureComparerCtrl folderStructureComparerCtrl;
        private FolderStructureSettingsCtrl folderStructureSettingsCtrl;
        private DevExpress.XtraBars.BarButtonItem barButtonItemUpdateComparerData;
        private DevExpress.XtraBars.BarButtonItem barButtonItemUpdateAnalyserData;
        private DevExpress.XtraBars.Docking.DockManager dockManagerApplicationContent;
        private DevExpress.XtraBars.Docking.DockPanel dockPanelSettings;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanel3_Container;
        private DevExpress.XtraBars.Docking.DockPanel dockPanel1;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanel1_Container;
        private DevExpress.XtraBars.Docking.DockPanel dockPanel2;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanel2_Container;
        private DevExpress.XtraBars.Docking.DockPanel dockPanelAnalyseStructure;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanelAnalyseStructure_Container;
        private DevExpress.XtraBars.Docking.DockPanel dockPanelCompareStructures;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanelCompareStructures_Container;
        private DevExpress.XtraBars.Docking2010.DocumentManager documentManagerAnalyses;
        private DevExpress.XtraBars.Docking2010.Views.Tabbed.TabbedView tabbedView1;
        private DevExpress.XtraBars.Docking2010.Views.Tabbed.DocumentGroup documentGroup1;
        private DevExpress.XtraBars.Docking2010.Views.Tabbed.Document document1;
        private DevExpress.XtraBars.Docking2010.Views.Tabbed.Document document2;
    }
}

