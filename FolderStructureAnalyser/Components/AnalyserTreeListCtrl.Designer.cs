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
            this.repositoryItemTextEditFileSize = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.treeListColumnOpen = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.svgImageCollectionTreeIcons = new DevExpress.Utils.SvgImageCollection(this.components);
            this.behaviorManager1 = new DevExpress.Utils.Behaviors.BehaviorManager(this.components);
            this.backgroundWorkerStructureAnalyser = new System.ComponentModel.BackgroundWorker();
            this.splashScreenManagerWaitForStructureAnalyse = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(global::FolderStructureAnalyser.Components.WaitForStructureAnalyseForm), true, true, typeof(System.Windows.Forms.UserControl));
            ((System.ComponentModel.ISupportInitialize)(this.treeListFolderStructure)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEditFileSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.svgImageCollectionTreeIcons)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.behaviorManager1)).BeginInit();
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
            this.treeListFolderStructure.StateImageList = this.svgImageCollectionTreeIcons;
            this.treeListFolderStructure.TabIndex = 0;
            this.treeListFolderStructure.ViewStyle = DevExpress.XtraTreeList.TreeListViewStyle.TreeView;
            this.treeListFolderStructure.GetStateImage += new DevExpress.XtraTreeList.GetStateImageEventHandler(this.treeListFolderStructure_GetStateImage);
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
            this.treeListColumnOpen.ToolTip = "Dobule click the icon to open the folder in Windows Explorer.";
            this.treeListColumnOpen.Visible = true;
            this.treeListColumnOpen.VisibleIndex = 2;
            // 
            // svgImageCollectionTreeIcons
            // 
            this.svgImageCollectionTreeIcons.Add("folder", "image://svgimages/actions/open.svg");
            this.svgImageCollectionTreeIcons.Add("file", "image://svgimages/dashboards/new.svg");
            this.svgImageCollectionTreeIcons.Add("open", "image://svgimages/dashboards/imageload.svg");
            // 
            // backgroundWorkerStructureAnalyser
            // 
            this.backgroundWorkerStructureAnalyser.WorkerSupportsCancellation = true;
            this.backgroundWorkerStructureAnalyser.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerStructureAnalyser_DoWork);
            this.backgroundWorkerStructureAnalyser.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerStructureAnalyser_RunWorkerCompleted);
            // 
            // splashScreenManagerWaitForStructureAnalyse
            // 
            this.splashScreenManagerWaitForStructureAnalyse.ClosingDelay = 500;
            // 
            // AnalyserTreeListCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.treeListFolderStructure);
            this.Name = "AnalyserTreeListCtrl";
            this.Size = new System.Drawing.Size(570, 266);
            this.Resize += new System.EventHandler(this.AnalyserTreeListCtrl_Resize);
            this.ParentChanged += new System.EventHandler(this.AnalyserTreeListCtrl_ParentChanged);
            ((System.ComponentModel.ISupportInitialize)(this.treeListFolderStructure)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEditFileSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.svgImageCollectionTreeIcons)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.behaviorManager1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraTreeList.TreeList treeListFolderStructure;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumnName;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumnSize;
        private DevExpress.Utils.Behaviors.BehaviorManager behaviorManager1;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEditFileSize;
        private System.ComponentModel.BackgroundWorker backgroundWorkerStructureAnalyser;
        private DevExpress.XtraSplashScreen.SplashScreenManager splashScreenManagerWaitForStructureAnalyse;
        private DevExpress.Utils.SvgImageCollection svgImageCollectionTreeIcons;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumnOpen;
    }
}
