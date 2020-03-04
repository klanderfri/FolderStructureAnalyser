namespace FolderStructureAnalyser.Components.AnalyserPanels
{
    partial class FolderStructureAnalyserCtrl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.treeListFolderStructure = new DevExpress.XtraTreeList.TreeList();
            this.treeListColumnName = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumnSize = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.repositoryItemTextEditFileSize = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.treeListColumnOpen = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.folderStructureSizeDiagramCtrl = new FolderStructureAnalyser.Components.AnalyserPanels.FolderStructureSizeDiagramCtrl();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.splitterItem1 = new DevExpress.XtraLayout.SplitterItem();
            ((System.ComponentModel.ISupportInitialize)(this.treeListFolderStructure)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEditFileSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitterItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // treeListFolderStructure
            // 
            this.treeListFolderStructure.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.treeListColumnName,
            this.treeListColumnSize,
            this.treeListColumnOpen});
            this.treeListFolderStructure.Cursor = System.Windows.Forms.Cursors.SizeWE;
            this.treeListFolderStructure.CustomizationFormBounds = new System.Drawing.Rectangle(654, 155, 260, 232);
            this.treeListFolderStructure.Location = new System.Drawing.Point(12, 12);
            this.treeListFolderStructure.Name = "treeListFolderStructure";
            this.treeListFolderStructure.OptionsView.AutoWidth = false;
            this.treeListFolderStructure.OptionsView.ShowColumns = true;
            this.treeListFolderStructure.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemTextEditFileSize});
            this.treeListFolderStructure.Size = new System.Drawing.Size(786, 617);
            this.treeListFolderStructure.StateImageList = this.IconCollection;
            this.treeListFolderStructure.TabIndex = 0;
            this.treeListFolderStructure.ViewStyle = DevExpress.XtraTreeList.TreeListViewStyle.TreeView;
            this.treeListFolderStructure.GetStateImage += new DevExpress.XtraTreeList.GetStateImageEventHandler(this.treeListFolderStructure_GetStateImage);
            this.treeListFolderStructure.BeforeExpand += new DevExpress.XtraTreeList.BeforeExpandEventHandler(this.treeListFolderStructure_BeforeExpand);
            this.treeListFolderStructure.BeforeCollapse += new DevExpress.XtraTreeList.BeforeCollapseEventHandler(this.treeListFolderStructure_BeforeCollapse);
            this.treeListFolderStructure.CustomDrawNodeCell += new DevExpress.XtraTreeList.CustomDrawNodeCellEventHandler(this.treeListFolderStructure_CustomDrawNodeCell);
            this.treeListFolderStructure.DoubleClick += new System.EventHandler(this.treeListFolderStructure_DoubleClick);
            // 
            // treeListColumnName
            // 
            this.treeListColumnName.Caption = "Name";
            this.treeListColumnName.FieldName = "Name";
            this.treeListColumnName.Name = "treeListColumnName";
            this.treeListColumnName.OptionsColumn.AllowEdit = false;
            this.treeListColumnName.ToolTip = "The name of the file/folder.";
            this.treeListColumnName.Visible = true;
            this.treeListColumnName.VisibleIndex = 0;
            this.treeListColumnName.Width = 300;
            // 
            // treeListColumnSize
            // 
            this.treeListColumnSize.Caption = "Size";
            this.treeListColumnSize.ColumnEdit = this.repositoryItemTextEditFileSize;
            this.treeListColumnSize.FieldName = "SizeInBytes";
            this.treeListColumnSize.Name = "treeListColumnSize";
            this.treeListColumnSize.OptionsColumn.AllowEdit = false;
            this.treeListColumnSize.ToolTip = "The size of the file or the total size of the folder, including files and subfold" +
    "ers.";
            this.treeListColumnSize.Visible = true;
            this.treeListColumnSize.VisibleIndex = 1;
            // 
            // repositoryItemTextEditFileSize
            // 
            this.repositoryItemTextEditFileSize.AutoHeight = false;
            this.repositoryItemTextEditFileSize.Name = "repositoryItemTextEditFileSize";
            this.repositoryItemTextEditFileSize.CustomDisplayText += new DevExpress.XtraEditors.Controls.CustomDisplayTextEventHandler(this.repositoryItemTextEditFileSize_CustomDisplayText);
            // 
            // treeListColumnOpen
            // 
            this.treeListColumnOpen.Caption = "Open";
            this.treeListColumnOpen.FieldName = "Open";
            this.treeListColumnOpen.Name = "treeListColumnOpen";
            this.treeListColumnOpen.OptionsColumn.AllowEdit = false;
            this.treeListColumnOpen.ToolTip = "Double click the icon to open the file/folder in Windows Explorer.";
            this.treeListColumnOpen.Visible = true;
            this.treeListColumnOpen.VisibleIndex = 2;
            this.treeListColumnOpen.Width = 50;
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.folderStructureSizeDiagramCtrl);
            this.layoutControl1.Controls.Add(this.treeListFolderStructure);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(1120, 386, 650, 400);
            this.layoutControl1.Root = this.Root;
            this.layoutControl1.Size = new System.Drawing.Size(1307, 641);
            this.layoutControl1.TabIndex = 1;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // folderStructureSizeDiagramCtrl
            // 
            this.folderStructureSizeDiagramCtrl.Location = new System.Drawing.Point(812, 12);
            this.folderStructureSizeDiagramCtrl.Name = "folderStructureSizeDiagramCtrl";
            this.folderStructureSizeDiagramCtrl.Size = new System.Drawing.Size(483, 617);
            this.folderStructureSizeDiagramCtrl.TabIndex = 4;
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.splitterItem1,
            this.layoutControlItem2});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(1307, 641);
            this.Root.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.treeListFolderStructure;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(790, 621);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.folderStructureSizeDiagramCtrl;
            this.layoutControlItem2.Location = new System.Drawing.Point(800, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(487, 621);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // splitterItem1
            // 
            this.splitterItem1.AllowHotTrack = true;
            this.splitterItem1.Location = new System.Drawing.Point(790, 0);
            this.splitterItem1.Name = "splitterItem1";
            this.splitterItem1.Size = new System.Drawing.Size(10, 621);
            // 
            // FolderStructureAnalyserCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.layoutControl1);
            this.Name = "FolderStructureAnalyserCtrl";
            this.Size = new System.Drawing.Size(1307, 641);
            this.WaitFormDescription = "Structure size analysis in progress...";
            this.FolderStructureAnalysisFinished += new FolderStructureAnalyser.Components.AnalyserPanels.FolderStructureParentCtrl.FolderStructureAnalysisFinishedHandler(this.FolderStructureAnalyserCtrl_FolderStructureAnalysisFinished);
            this.DoFolderStructureAnalysis += new FolderStructureAnalyser.Components.AnalyserPanels.FolderStructureParentCtrl.DoFolderStructureAnalysisHandler(this.FolderStructureAnalyserCtrl_DoFolderStructureAnalysis);
            ((System.ComponentModel.ISupportInitialize)(this.treeListFolderStructure)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEditFileSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitterItem1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraTreeList.TreeList treeListFolderStructure;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumnName;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumnSize;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEditFileSize;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumnOpen;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private FolderStructureSizeDiagramCtrl folderStructureSizeDiagramCtrl;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.SplitterItem splitterItem1;
    }
}
