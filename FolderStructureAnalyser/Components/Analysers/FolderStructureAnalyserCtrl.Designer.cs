namespace FolderStructureAnalyser.Components.Analysers
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
            ((System.ComponentModel.ISupportInitialize)(this.treeListFolderStructure)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEditFileSize)).BeginInit();
            this.SuspendLayout();
            // 
            // treeListFolderStructure
            // 
            this.treeListFolderStructure.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.treeListColumnName,
            this.treeListColumnSize,
            this.treeListColumnOpen});
            this.treeListFolderStructure.Cursor = System.Windows.Forms.Cursors.Default;
            this.treeListFolderStructure.CustomizationFormBounds = new System.Drawing.Rectangle(654, 155, 260, 232);
            this.treeListFolderStructure.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeListFolderStructure.Location = new System.Drawing.Point(0, 0);
            this.treeListFolderStructure.Name = "treeListFolderStructure";
            this.treeListFolderStructure.OptionsView.AutoWidth = false;
            this.treeListFolderStructure.OptionsView.ShowColumns = true;
            this.treeListFolderStructure.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemTextEditFileSize});
            this.treeListFolderStructure.Size = new System.Drawing.Size(570, 266);
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
            this.treeListColumnName.ToolTip = "The name of the folder.";
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
            this.treeListColumnSize.ToolTip = "The total size of the folder, including files and subfolders.";
            this.treeListColumnSize.Visible = true;
            this.treeListColumnSize.VisibleIndex = 1;
            // 
            // repositoryItemTextEditFileSize
            // 
            this.repositoryItemTextEditFileSize.AutoHeight = false;
            this.repositoryItemTextEditFileSize.Name = "repositoryItemTextEditFileSize";
            this.repositoryItemTextEditFileSize.CustomDisplayText += new DevExpress.XtraEditors.Controls.CustomDisplayTextEventHandler(this.repositoryItemTextEditFileSizeEdit_CustomDisplayText);
            // 
            // treeListColumnOpen
            // 
            this.treeListColumnOpen.Caption = "Open";
            this.treeListColumnOpen.FieldName = "Open";
            this.treeListColumnOpen.Name = "treeListColumnOpen";
            this.treeListColumnOpen.OptionsColumn.AllowEdit = false;
            this.treeListColumnOpen.ToolTip = "Double click the icon to open the folder in Windows Explorer.";
            this.treeListColumnOpen.Visible = true;
            this.treeListColumnOpen.VisibleIndex = 2;
            this.treeListColumnOpen.Width = 50;
            // 
            // FolderStructureAnalyserCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.treeListFolderStructure);
            this.Name = "FolderStructureAnalyserCtrl";
            this.Size = new System.Drawing.Size(570, 266);
            this.WaitFormDescription = "Structure size analysis in progress...";
            this.FolderStructureAnalysisFinished += new FolderStructureAnalyser.Components.Analysers.FolderStructureParentCtrl.FolderStructureAnalysisFinishedHandler(this.FolderStructureAnalyserCtrl_FolderStructureAnalysisFinished);
            this.DoFolderStructureAnalysis += new FolderStructureAnalyser.Components.Analysers.FolderStructureParentCtrl.DoFolderStructureAnalysisHandler(this.FolderStructureAnalyserCtrl_DoFolderStructureAnalysis);
            ((System.ComponentModel.ISupportInitialize)(this.treeListFolderStructure)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEditFileSize)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraTreeList.TreeList treeListFolderStructure;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumnName;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumnSize;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEditFileSize;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumnOpen;
    }
}
