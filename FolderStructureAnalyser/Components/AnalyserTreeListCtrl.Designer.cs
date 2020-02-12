namespace FolderStructureAnalyser.Components
{
    partial class AnalyserTreeListCtrl
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
            this.components = new System.ComponentModel.Container();
            this.treeListFolderStructure = new DevExpress.XtraTreeList.TreeList();
            this.treeListColumnName = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumnSize = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.behaviorManager1 = new DevExpress.Utils.Behaviors.BehaviorManager(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.treeListFolderStructure)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.behaviorManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // treeListFolderStructure
            // 
            this.treeListFolderStructure.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.treeListColumnName,
            this.treeListColumnSize});
            this.treeListFolderStructure.Cursor = System.Windows.Forms.Cursors.Default;
            this.treeListFolderStructure.CustomizationFormBounds = new System.Drawing.Rectangle(654, 155, 260, 232);
            this.treeListFolderStructure.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeListFolderStructure.Location = new System.Drawing.Point(0, 0);
            this.treeListFolderStructure.Name = "treeListFolderStructure";
            this.treeListFolderStructure.Size = new System.Drawing.Size(570, 266);
            this.treeListFolderStructure.TabIndex = 0;
            this.treeListFolderStructure.ViewStyle = DevExpress.XtraTreeList.TreeListViewStyle.TreeView;
            // 
            // treeListColumnName
            // 
            this.treeListColumnName.Caption = "Name";
            this.treeListColumnName.FieldName = "Name";
            this.treeListColumnName.Name = "treeListColumnName";
            this.treeListColumnName.Visible = true;
            this.treeListColumnName.VisibleIndex = 0;
            // 
            // treeListColumnSize
            // 
            this.treeListColumnSize.Caption = "Size";
            this.treeListColumnSize.FieldName = "SizeInMB";
            this.treeListColumnSize.Name = "treeListColumnSize";
            this.treeListColumnSize.Visible = true;
            this.treeListColumnSize.VisibleIndex = 1;
            // 
            // AnalyserTreeListCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.treeListFolderStructure);
            this.Name = "AnalyserTreeListCtrl";
            this.Size = new System.Drawing.Size(570, 266);
            ((System.ComponentModel.ISupportInitialize)(this.treeListFolderStructure)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.behaviorManager1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraTreeList.TreeList treeListFolderStructure;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumnName;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumnSize;
        private DevExpress.Utils.Behaviors.BehaviorManager behaviorManager1;
    }
}
