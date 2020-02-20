namespace FolderStructureAnalyser.Components
{
    partial class FolderStructureSettingsCtrl
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
            this.propertyGridControlAnalysingSettings = new DevExpress.XtraVerticalGrid.PropertyGridControl();
            this.repositoryItemSpinEditBigFolderSizeLimit = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.repositoryItemColorPickEditBigFolderColour = new DevExpress.XtraEditors.Repository.RepositoryItemColorPickEdit();
            this.repositoryItemCheckEditCompareHashes = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.repositoryItemColorPickEditGridErrorColour = new DevExpress.XtraEditors.Repository.RepositoryItemColorPickEdit();
            this.categoryBigFolder = new DevExpress.XtraVerticalGrid.Rows.CategoryRow();
            this.rowSize = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowColour = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.categoryComparison = new DevExpress.XtraVerticalGrid.Rows.CategoryRow();
            this.rowCompareHashes = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.categoryApplication = new DevExpress.XtraVerticalGrid.Rows.CategoryRow();
            this.rowErrorColour = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.categoryAnalysis = new DevExpress.XtraVerticalGrid.Rows.CategoryRow();
            ((System.ComponentModel.ISupportInitialize)(this.propertyGridControlAnalysingSettings)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSpinEditBigFolderSizeLimit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemColorPickEditBigFolderColour)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEditCompareHashes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemColorPickEditGridErrorColour)).BeginInit();
            this.SuspendLayout();
            // 
            // propertyGridControlAnalysingSettings
            // 
            this.propertyGridControlAnalysingSettings.Cursor = System.Windows.Forms.Cursors.SizeNS;
            this.propertyGridControlAnalysingSettings.Dock = System.Windows.Forms.DockStyle.Left;
            this.propertyGridControlAnalysingSettings.Location = new System.Drawing.Point(0, 0);
            this.propertyGridControlAnalysingSettings.Name = "propertyGridControlAnalysingSettings";
            this.propertyGridControlAnalysingSettings.OptionsBehavior.PropertySort = DevExpress.XtraVerticalGrid.PropertySort.NoSort;
            this.propertyGridControlAnalysingSettings.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemSpinEditBigFolderSizeLimit,
            this.repositoryItemColorPickEditBigFolderColour,
            this.repositoryItemCheckEditCompareHashes,
            this.repositoryItemColorPickEditGridErrorColour});
            this.propertyGridControlAnalysingSettings.Rows.AddRange(new DevExpress.XtraVerticalGrid.Rows.BaseRow[] {
            this.categoryApplication,
            this.categoryAnalysis,
            this.categoryComparison});
            this.propertyGridControlAnalysingSettings.Size = new System.Drawing.Size(400, 336);
            this.propertyGridControlAnalysingSettings.TabIndex = 0;
            // 
            // repositoryItemSpinEditBigFolderSizeLimit
            // 
            this.repositoryItemSpinEditBigFolderSizeLimit.AutoHeight = false;
            this.repositoryItemSpinEditBigFolderSizeLimit.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemSpinEditBigFolderSizeLimit.Mask.EditMask = ",#######0 MB";
            this.repositoryItemSpinEditBigFolderSizeLimit.Mask.UseMaskAsDisplayFormat = true;
            this.repositoryItemSpinEditBigFolderSizeLimit.MaxValue = new decimal(new int[] {
            1073741824,
            0,
            0,
            0});
            this.repositoryItemSpinEditBigFolderSizeLimit.MinValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.repositoryItemSpinEditBigFolderSizeLimit.Name = "repositoryItemSpinEditBigFolderSizeLimit";
            // 
            // repositoryItemColorPickEditBigFolderColour
            // 
            this.repositoryItemColorPickEditBigFolderColour.AutoHeight = false;
            this.repositoryItemColorPickEditBigFolderColour.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemColorPickEditBigFolderColour.Name = "repositoryItemColorPickEditBigFolderColour";
            // 
            // repositoryItemCheckEditCompareHashes
            // 
            this.repositoryItemCheckEditCompareHashes.AutoHeight = false;
            this.repositoryItemCheckEditCompareHashes.Name = "repositoryItemCheckEditCompareHashes";
            // 
            // repositoryItemColorPickEditGridErrorColour
            // 
            this.repositoryItemColorPickEditGridErrorColour.AutoHeight = false;
            this.repositoryItemColorPickEditGridErrorColour.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemColorPickEditGridErrorColour.Name = "repositoryItemColorPickEditGridErrorColour";
            // 
            // categoryBigFolder
            // 
            this.categoryBigFolder.ChildRows.AddRange(new DevExpress.XtraVerticalGrid.Rows.BaseRow[] {
            this.rowColour,
            this.rowSize});
            this.categoryBigFolder.Name = "categoryBigFolder";
            this.categoryBigFolder.Properties.Caption = "Big folder";
            this.categoryBigFolder.Properties.ToolTip = "Settings related to how big folders are shown.";
            // 
            // rowSize
            // 
            this.rowSize.Name = "rowSize";
            this.rowSize.Properties.Caption = "Size";
            this.rowSize.Properties.FieldName = "BigFolderInMB";
            this.rowSize.Properties.RowEdit = this.repositoryItemSpinEditBigFolderSizeLimit;
            this.rowSize.Properties.ToolTip = "Defines the size at which a folder should be considered big.";
            // 
            // rowColour
            // 
            this.rowColour.Name = "rowColour";
            this.rowColour.Properties.Caption = "Colour";
            this.rowColour.Properties.FieldName = "BigFolderColour";
            this.rowColour.Properties.RowEdit = this.repositoryItemColorPickEditBigFolderColour;
            this.rowColour.Properties.ToolTip = "The colour used to indicate a big folder.";
            // 
            // categoryComparison
            // 
            this.categoryComparison.ChildRows.AddRange(new DevExpress.XtraVerticalGrid.Rows.BaseRow[] {
            this.rowCompareHashes});
            this.categoryComparison.Name = "categoryComparison";
            this.categoryComparison.Properties.Caption = "Comparison";
            this.categoryComparison.Properties.ToolTip = "Settings related to how comparisons are done.";
            // 
            // rowCompareHashes
            // 
            this.rowCompareHashes.Name = "rowCompareHashes";
            this.rowCompareHashes.Properties.Caption = "Compare hashes";
            this.rowCompareHashes.Properties.FieldName = "CompareFileHashes";
            this.rowCompareHashes.Properties.RowEdit = this.repositoryItemCheckEditCompareHashes;
            this.rowCompareHashes.Properties.ToolTip = "Tells if the folder structure comparison should compare file hashes. Activating t" +
    "his results in more precise, but slower, comparisons.";
            // 
            // categoryApplication
            // 
            this.categoryApplication.ChildRows.AddRange(new DevExpress.XtraVerticalGrid.Rows.BaseRow[] {
            this.rowErrorColour});
            this.categoryApplication.Name = "categoryApplication";
            this.categoryApplication.Properties.Caption = "Application";
            this.categoryApplication.Properties.ToolTip = "General settings for the application";
            // 
            // rowErrorColour
            // 
            this.rowErrorColour.Name = "rowErrorColour";
            this.rowErrorColour.Properties.Caption = "Grid Error Colour";
            this.rowErrorColour.Properties.FieldName = "GridErrorColour";
            this.rowErrorColour.Properties.RowEdit = this.repositoryItemColorPickEditGridErrorColour;
            this.rowErrorColour.Properties.ToolTip = "The colour used to indicate an error within a grid.";
            // 
            // categoryAnalysis
            // 
            this.categoryAnalysis.ChildRows.AddRange(new DevExpress.XtraVerticalGrid.Rows.BaseRow[] {
            this.categoryBigFolder});
            this.categoryAnalysis.Name = "categoryAnalysis";
            this.categoryAnalysis.Properties.Caption = "Analysis";
            this.categoryAnalysis.Properties.ToolTip = "Settings related to how analysis are done.";
            // 
            // FolderStructureSettingsCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.propertyGridControlAnalysingSettings);
            this.Name = "FolderStructureSettingsCtrl";
            this.Size = new System.Drawing.Size(618, 336);
            ((System.ComponentModel.ISupportInitialize)(this.propertyGridControlAnalysingSettings)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSpinEditBigFolderSizeLimit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemColorPickEditBigFolderColour)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEditCompareHashes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemColorPickEditGridErrorColour)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraVerticalGrid.PropertyGridControl propertyGridControlAnalysingSettings;
        private DevExpress.XtraVerticalGrid.Rows.CategoryRow categoryBigFolder;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowColour;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowSize;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit repositoryItemSpinEditBigFolderSizeLimit;
        private DevExpress.XtraEditors.Repository.RepositoryItemColorPickEdit repositoryItemColorPickEditBigFolderColour;
        private DevExpress.XtraVerticalGrid.Rows.CategoryRow categoryComparison;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowCompareHashes;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEditCompareHashes;
        private DevExpress.XtraEditors.Repository.RepositoryItemColorPickEdit repositoryItemColorPickEditGridErrorColour;
        private DevExpress.XtraVerticalGrid.Rows.CategoryRow categoryApplication;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowErrorColour;
        private DevExpress.XtraVerticalGrid.Rows.CategoryRow categoryAnalysis;
    }
}
