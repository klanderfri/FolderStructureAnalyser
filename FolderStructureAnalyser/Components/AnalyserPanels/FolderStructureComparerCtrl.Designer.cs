namespace FolderStructureAnalyser.Components.AnalyserPanels
{
    partial class FolderStructureComparerCtrl
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
            this.gridControl = new DevExpress.XtraGrid.GridControl();
            this.advBandedGridView = new DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView();
            this.gridBandDifference = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.bandedGridColumnDescription = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumnProblemTypeIndex = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.repositoryItemTextEditProblemTypeIndex = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.bandedGridColumnItemTypeIndex = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.repositoryItemTextEditItemTypeIndex = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.gridBandDiskItems = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.bandedGridColumnOriginalName = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumnOriginalFullPath = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumnOriginalHash = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumnCloneName = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumnCloneFullPath = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumnCloneHash = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.advBandedGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEditProblemTypeIndex)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEditItemTypeIndex)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl
            // 
            this.gridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl.Location = new System.Drawing.Point(0, 0);
            this.gridControl.MainView = this.advBandedGridView;
            this.gridControl.Name = "gridControl";
            this.gridControl.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemTextEditItemTypeIndex,
            this.repositoryItemTextEditProblemTypeIndex});
            this.gridControl.Size = new System.Drawing.Size(1512, 676);
            this.gridControl.TabIndex = 0;
            this.gridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.advBandedGridView});
            this.gridControl.DoubleClick += new System.EventHandler(this.gridControl_DoubleClick);
            // 
            // advBandedGridView
            // 
            this.advBandedGridView.Bands.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] {
            this.gridBandDifference,
            this.gridBandDiskItems});
            this.advBandedGridView.Columns.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[] {
            this.bandedGridColumnOriginalName,
            this.bandedGridColumnOriginalFullPath,
            this.bandedGridColumnCloneName,
            this.bandedGridColumnCloneFullPath,
            this.bandedGridColumnDescription,
            this.bandedGridColumnItemTypeIndex,
            this.bandedGridColumnProblemTypeIndex,
            this.bandedGridColumnOriginalHash,
            this.bandedGridColumnCloneHash});
            this.advBandedGridView.GridControl = this.gridControl;
            this.advBandedGridView.Name = "advBandedGridView";
            this.advBandedGridView.RowSeparatorHeight = 7;
            this.advBandedGridView.CustomDrawCell += new DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventHandler(this.advBandedGridView_CustomDrawCell);
            // 
            // gridBandDifference
            // 
            this.gridBandDifference.Caption = "Difference";
            this.gridBandDifference.Columns.Add(this.bandedGridColumnDescription);
            this.gridBandDifference.Columns.Add(this.bandedGridColumnProblemTypeIndex);
            this.gridBandDifference.Columns.Add(this.bandedGridColumnItemTypeIndex);
            this.gridBandDifference.Name = "gridBandDifference";
            this.gridBandDifference.ToolTip = "Contains columns describing the difference between the original and the clone.";
            this.gridBandDifference.VisibleIndex = 0;
            this.gridBandDifference.Width = 320;
            // 
            // bandedGridColumnDescription
            // 
            this.bandedGridColumnDescription.Caption = "Description";
            this.bandedGridColumnDescription.FieldName = "DiffInfo.Description";
            this.bandedGridColumnDescription.Name = "bandedGridColumnDescription";
            this.bandedGridColumnDescription.OptionsColumn.AllowEdit = false;
            this.bandedGridColumnDescription.ToolTip = "A description of the difference between the original and the clone.";
            this.bandedGridColumnDescription.Visible = true;
            this.bandedGridColumnDescription.Width = 220;
            // 
            // bandedGridColumnProblemTypeIndex
            // 
            this.bandedGridColumnProblemTypeIndex.Caption = "Type";
            this.bandedGridColumnProblemTypeIndex.ColumnEdit = this.repositoryItemTextEditProblemTypeIndex;
            this.bandedGridColumnProblemTypeIndex.FieldName = "DiffInfo.DifferenceTypeImageIndex";
            this.bandedGridColumnProblemTypeIndex.Name = "bandedGridColumnProblemTypeIndex";
            this.bandedGridColumnProblemTypeIndex.OptionsColumn.AllowEdit = false;
            this.bandedGridColumnProblemTypeIndex.ToolTip = "The type of difference.";
            this.bandedGridColumnProblemTypeIndex.Visible = true;
            this.bandedGridColumnProblemTypeIndex.Width = 50;
            // 
            // repositoryItemTextEditProblemTypeIndex
            // 
            this.repositoryItemTextEditProblemTypeIndex.AutoHeight = false;
            this.repositoryItemTextEditProblemTypeIndex.Name = "repositoryItemTextEditProblemTypeIndex";
            this.repositoryItemTextEditProblemTypeIndex.CustomDisplayText += new DevExpress.XtraEditors.Controls.CustomDisplayTextEventHandler(this.repositoryItemTextEditProblemTypeIndex_CustomDisplayText);
            // 
            // bandedGridColumnItemTypeIndex
            // 
            this.bandedGridColumnItemTypeIndex.Caption = "Item";
            this.bandedGridColumnItemTypeIndex.ColumnEdit = this.repositoryItemTextEditItemTypeIndex;
            this.bandedGridColumnItemTypeIndex.FieldName = "DiffInfo.ItemTypeImageIndex";
            this.bandedGridColumnItemTypeIndex.Name = "bandedGridColumnItemTypeIndex";
            this.bandedGridColumnItemTypeIndex.OptionsColumn.AllowEdit = false;
            this.bandedGridColumnItemTypeIndex.ToolTip = "The type of item the difference is about (i.e file or folder).";
            this.bandedGridColumnItemTypeIndex.Visible = true;
            this.bandedGridColumnItemTypeIndex.Width = 50;
            // 
            // repositoryItemTextEditItemTypeIndex
            // 
            this.repositoryItemTextEditItemTypeIndex.AutoHeight = false;
            this.repositoryItemTextEditItemTypeIndex.Name = "repositoryItemTextEditItemTypeIndex";
            this.repositoryItemTextEditItemTypeIndex.CustomDisplayText += new DevExpress.XtraEditors.Controls.CustomDisplayTextEventHandler(this.repositoryItemTextEditItemTypeIndex_CustomDisplayText);
            // 
            // gridBandDiskItems
            // 
            this.gridBandDiskItems.Caption = "Disk Items";
            this.gridBandDiskItems.Columns.Add(this.bandedGridColumnOriginalName);
            this.gridBandDiskItems.Columns.Add(this.bandedGridColumnOriginalFullPath);
            this.gridBandDiskItems.Columns.Add(this.bandedGridColumnOriginalHash);
            this.gridBandDiskItems.Columns.Add(this.bandedGridColumnCloneName);
            this.gridBandDiskItems.Columns.Add(this.bandedGridColumnCloneFullPath);
            this.gridBandDiskItems.Columns.Add(this.bandedGridColumnCloneHash);
            this.gridBandDiskItems.Name = "gridBandDiskItems";
            this.gridBandDiskItems.ToolTip = "Contains columns holding information about the disk items";
            this.gridBandDiskItems.VisibleIndex = 1;
            this.gridBandDiskItems.Width = 1150;
            // 
            // bandedGridColumnOriginalName
            // 
            this.bandedGridColumnOriginalName.Caption = "Original Name";
            this.bandedGridColumnOriginalName.FieldName = "Original.Name";
            this.bandedGridColumnOriginalName.Name = "bandedGridColumnOriginalName";
            this.bandedGridColumnOriginalName.OptionsColumn.AllowEdit = false;
            this.bandedGridColumnOriginalName.ToolTip = "The name of the original item.";
            this.bandedGridColumnOriginalName.Visible = true;
            this.bandedGridColumnOriginalName.Width = 150;
            // 
            // bandedGridColumnOriginalFullPath
            // 
            this.bandedGridColumnOriginalFullPath.Caption = "Original Path";
            this.bandedGridColumnOriginalFullPath.FieldName = "Original.Info.FullName";
            this.bandedGridColumnOriginalFullPath.Name = "bandedGridColumnOriginalFullPath";
            this.bandedGridColumnOriginalFullPath.OptionsColumn.AllowEdit = false;
            this.bandedGridColumnOriginalFullPath.ToolTip = "The path to the original item.";
            this.bandedGridColumnOriginalFullPath.Visible = true;
            this.bandedGridColumnOriginalFullPath.Width = 550;
            // 
            // bandedGridColumnOriginalHash
            // 
            this.bandedGridColumnOriginalHash.Caption = "Original Hash";
            this.bandedGridColumnOriginalHash.FieldName = "Original.MD5";
            this.bandedGridColumnOriginalHash.Name = "bandedGridColumnOriginalHash";
            this.bandedGridColumnOriginalHash.Visible = true;
            this.bandedGridColumnOriginalHash.Width = 450;
            // 
            // bandedGridColumnCloneName
            // 
            this.bandedGridColumnCloneName.Caption = "Clone Name";
            this.bandedGridColumnCloneName.FieldName = "Clone.Name";
            this.bandedGridColumnCloneName.Name = "bandedGridColumnCloneName";
            this.bandedGridColumnCloneName.OptionsColumn.AllowEdit = false;
            this.bandedGridColumnCloneName.RowIndex = 1;
            this.bandedGridColumnCloneName.ToolTip = "The name of the cloned item.";
            this.bandedGridColumnCloneName.Visible = true;
            this.bandedGridColumnCloneName.Width = 150;
            // 
            // bandedGridColumnCloneFullPath
            // 
            this.bandedGridColumnCloneFullPath.Caption = "Clone Path";
            this.bandedGridColumnCloneFullPath.FieldName = "Clone.Info.FullName";
            this.bandedGridColumnCloneFullPath.Name = "bandedGridColumnCloneFullPath";
            this.bandedGridColumnCloneFullPath.OptionsColumn.AllowEdit = false;
            this.bandedGridColumnCloneFullPath.RowIndex = 1;
            this.bandedGridColumnCloneFullPath.ToolTip = "The path to the cloned item.";
            this.bandedGridColumnCloneFullPath.Visible = true;
            this.bandedGridColumnCloneFullPath.Width = 550;
            // 
            // bandedGridColumnCloneHash
            // 
            this.bandedGridColumnCloneHash.Caption = "Clone Hash";
            this.bandedGridColumnCloneHash.FieldName = "Clone.MD5";
            this.bandedGridColumnCloneHash.Name = "bandedGridColumnCloneHash";
            this.bandedGridColumnCloneHash.RowIndex = 1;
            this.bandedGridColumnCloneHash.Visible = true;
            this.bandedGridColumnCloneHash.Width = 450;
            // 
            // FolderStructureComparerCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridControl);
            this.Name = "FolderStructureComparerCtrl";
            this.Size = new System.Drawing.Size(1512, 676);
            this.WaitFormDescription = "Folder comparision in progress...";
            this.FolderStructureAnalysisFinished += new FolderStructureAnalyser.Components.AnalyserPanels.FolderStructureParentCtrl.FolderStructureAnalysisFinishedHandler(this.FolderStructureComparerCtrl_FolderStructureAnalysisFinished);
            this.DoFolderStructureAnalysis += new FolderStructureAnalyser.Components.AnalyserPanels.FolderStructureParentCtrl.DoFolderStructureAnalysisHandler(this.FolderStructureComparerCtrl_DoFolderStructureAnalysis);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.advBandedGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEditProblemTypeIndex)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEditItemTypeIndex)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl;
        private DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView advBandedGridView;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumnDescription;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumnProblemTypeIndex;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumnItemTypeIndex;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumnOriginalName;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumnOriginalFullPath;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumnOriginalHash;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumnCloneName;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumnCloneFullPath;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumnCloneHash;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBandDifference;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBandDiskItems;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEditProblemTypeIndex;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEditItemTypeIndex;
    }
}
