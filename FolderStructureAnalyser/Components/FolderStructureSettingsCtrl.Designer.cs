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
            this.categoryBigFolder = new DevExpress.XtraVerticalGrid.Rows.CategoryRow();
            this.rowSize = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowColour = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.repositoryItemColorPickEdit = new DevExpress.XtraEditors.Repository.RepositoryItemColorPickEdit();
            ((System.ComponentModel.ISupportInitialize)(this.propertyGridControlAnalysingSettings)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSpinEditBigFolderSizeLimit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemColorPickEdit)).BeginInit();
            this.SuspendLayout();
            // 
            // propertyGridControlAnalysingSettings
            // 
            this.propertyGridControlAnalysingSettings.Cursor = System.Windows.Forms.Cursors.Hand;
            this.propertyGridControlAnalysingSettings.Dock = System.Windows.Forms.DockStyle.Left;
            this.propertyGridControlAnalysingSettings.Location = new System.Drawing.Point(0, 0);
            this.propertyGridControlAnalysingSettings.Name = "propertyGridControlAnalysingSettings";
            this.propertyGridControlAnalysingSettings.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemSpinEditBigFolderSizeLimit,
            this.repositoryItemColorPickEdit});
            this.propertyGridControlAnalysingSettings.Rows.AddRange(new DevExpress.XtraVerticalGrid.Rows.BaseRow[] {
            this.categoryBigFolder});
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
            // categoryBigFolder
            // 
            this.categoryBigFolder.ChildRows.AddRange(new DevExpress.XtraVerticalGrid.Rows.BaseRow[] {
            this.rowSize,
            this.rowColour});
            this.categoryBigFolder.Name = "categoryBigFolder";
            this.categoryBigFolder.Properties.Caption = "Big folder";
            // 
            // rowSize
            // 
            this.rowSize.Name = "rowSize";
            this.rowSize.Properties.Caption = "Size";
            this.rowSize.Properties.FieldName = "BigFolderInBytes";
            this.rowSize.Properties.RowEdit = this.repositoryItemSpinEditBigFolderSizeLimit;
            // 
            // rowColour
            // 
            this.rowColour.Name = "rowColour";
            this.rowColour.Properties.Caption = "Colour";
            this.rowColour.Properties.FieldName = "BigFolderColour";
            this.rowColour.Properties.RowEdit = this.repositoryItemColorPickEdit;
            // 
            // repositoryItemColorPickEdit
            // 
            this.repositoryItemColorPickEdit.AutoHeight = false;
            this.repositoryItemColorPickEdit.AutomaticColor = System.Drawing.Color.Black;
            this.repositoryItemColorPickEdit.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemColorPickEdit.Name = "repositoryItemColorPickEdit";
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
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemColorPickEdit)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraVerticalGrid.PropertyGridControl propertyGridControlAnalysingSettings;
        private DevExpress.XtraVerticalGrid.Rows.CategoryRow categoryBigFolder;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowSize;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowColour;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit repositoryItemSpinEditBigFolderSizeLimit;
        private DevExpress.XtraEditors.Repository.RepositoryItemColorPickEdit repositoryItemColorPickEdit;
    }
}
