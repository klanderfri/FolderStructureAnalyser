namespace FolderStructureAnalyser.Components
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
            this.components = new System.ComponentModel.Container();
            DevExpress.XtraSplashScreen.SplashScreenManager splashScreenManagerWaitForStructureCompare = new DevExpress.XtraSplashScreen.SplashScreenManager(this, null, true, true, typeof(System.Windows.Forms.UserControl));
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.bandedGridView1 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridView();
            this.gridBandOriginal = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.bandedGridColumnOriginalName = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumnOriginalFullPath = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBandClone = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.bandedGridColumnCloneName = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumnCloneFullPath = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBandDifference = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.bandedGridColumnDescription = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumnItemType = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.backgroundWorkerCompareFolders = new System.ComponentModel.BackgroundWorker();
            this.xtraFolderBrowserDialogOriginalFolder = new DevExpress.XtraEditors.XtraFolderBrowserDialog(this.components);
            this.xtraFolderBrowserDialogCloneFolder = new DevExpress.XtraEditors.XtraFolderBrowserDialog(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bandedGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // splashScreenManagerWaitForStructureCompare
            // 
            splashScreenManagerWaitForStructureCompare.ClosingDelay = 500;
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.bandedGridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1512, 676);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.bandedGridView1});
            this.gridControl1.DoubleClick += new System.EventHandler(this.gridControl1_DoubleClick);
            // 
            // bandedGridView1
            // 
            this.bandedGridView1.Bands.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] {
            this.gridBandDifference,
            this.gridBandOriginal,
            this.gridBandClone});
            this.bandedGridView1.Columns.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[] {
            this.bandedGridColumnOriginalName,
            this.bandedGridColumnOriginalFullPath,
            this.bandedGridColumnCloneName,
            this.bandedGridColumnCloneFullPath,
            this.bandedGridColumnDescription,
            this.bandedGridColumnItemType});
            this.bandedGridView1.GridControl = this.gridControl1;
            this.bandedGridView1.Name = "bandedGridView1";
            this.bandedGridView1.OptionsView.ColumnAutoWidth = false;
            // 
            // gridBandOriginal
            // 
            this.gridBandOriginal.Caption = "Original";
            this.gridBandOriginal.Columns.Add(this.bandedGridColumnOriginalName);
            this.gridBandOriginal.Columns.Add(this.bandedGridColumnOriginalFullPath);
            this.gridBandOriginal.Name = "gridBandOriginal";
            this.gridBandOriginal.VisibleIndex = 1;
            this.gridBandOriginal.Width = 670;
            // 
            // bandedGridColumnOriginalName
            // 
            this.bandedGridColumnOriginalName.Caption = "Name";
            this.bandedGridColumnOriginalName.FieldName = "OriginalName";
            this.bandedGridColumnOriginalName.Name = "bandedGridColumnOriginalName";
            this.bandedGridColumnOriginalName.OptionsColumn.AllowEdit = false;
            this.bandedGridColumnOriginalName.Visible = true;
            this.bandedGridColumnOriginalName.Width = 150;
            // 
            // bandedGridColumnOriginalFullPath
            // 
            this.bandedGridColumnOriginalFullPath.Caption = "Path";
            this.bandedGridColumnOriginalFullPath.FieldName = "OriginalFullPath";
            this.bandedGridColumnOriginalFullPath.Name = "bandedGridColumnOriginalFullPath";
            this.bandedGridColumnOriginalFullPath.OptionsColumn.AllowEdit = false;
            this.bandedGridColumnOriginalFullPath.Visible = true;
            this.bandedGridColumnOriginalFullPath.Width = 520;
            // 
            // gridBandClone
            // 
            this.gridBandClone.Caption = "Clone";
            this.gridBandClone.Columns.Add(this.bandedGridColumnCloneName);
            this.gridBandClone.Columns.Add(this.bandedGridColumnCloneFullPath);
            this.gridBandClone.Name = "gridBandClone";
            this.gridBandClone.VisibleIndex = 2;
            this.gridBandClone.Width = 670;
            // 
            // bandedGridColumnCloneName
            // 
            this.bandedGridColumnCloneName.Caption = "Name";
            this.bandedGridColumnCloneName.FieldName = "CloneName";
            this.bandedGridColumnCloneName.Name = "bandedGridColumnCloneName";
            this.bandedGridColumnCloneName.OptionsColumn.AllowEdit = false;
            this.bandedGridColumnCloneName.Visible = true;
            this.bandedGridColumnCloneName.Width = 150;
            // 
            // bandedGridColumnCloneFullPath
            // 
            this.bandedGridColumnCloneFullPath.Caption = "Path";
            this.bandedGridColumnCloneFullPath.FieldName = "CloneFullPath";
            this.bandedGridColumnCloneFullPath.Name = "bandedGridColumnCloneFullPath";
            this.bandedGridColumnCloneFullPath.OptionsColumn.AllowEdit = false;
            this.bandedGridColumnCloneFullPath.Visible = true;
            this.bandedGridColumnCloneFullPath.Width = 520;
            // 
            // gridBandDifference
            // 
            this.gridBandDifference.Caption = "Difference";
            this.gridBandDifference.Columns.Add(this.bandedGridColumnDescription);
            this.gridBandDifference.Columns.Add(this.bandedGridColumnItemType);
            this.gridBandDifference.Name = "gridBandDifference";
            this.gridBandDifference.VisibleIndex = 0;
            this.gridBandDifference.Width = 280;
            // 
            // bandedGridColumnDescription
            // 
            this.bandedGridColumnDescription.Caption = "Description";
            this.bandedGridColumnDescription.FieldName = "Description";
            this.bandedGridColumnDescription.Name = "bandedGridColumnDescription";
            this.bandedGridColumnDescription.OptionsColumn.AllowEdit = false;
            this.bandedGridColumnDescription.Visible = true;
            this.bandedGridColumnDescription.Width = 220;
            // 
            // bandedGridColumnItemType
            // 
            this.bandedGridColumnItemType.Caption = "Type";
            this.bandedGridColumnItemType.FieldName = "ItemType";
            this.bandedGridColumnItemType.Name = "bandedGridColumnItemType";
            this.bandedGridColumnItemType.OptionsColumn.AllowEdit = false;
            this.bandedGridColumnItemType.Visible = true;
            this.bandedGridColumnItemType.Width = 60;
            // 
            // xtraFolderBrowserDialogOriginalFolder
            // 
            this.xtraFolderBrowserDialogOriginalFolder.Description = "Select the folder that should act as the original folder.";
            this.xtraFolderBrowserDialogOriginalFolder.SelectedPath = "xtraFolderBrowserDialog1";
            this.xtraFolderBrowserDialogOriginalFolder.ShowNewFolderButton = false;
            this.xtraFolderBrowserDialogOriginalFolder.Title = "Select original folder";
            // 
            // xtraFolderBrowserDialogCloneFolder
            // 
            this.xtraFolderBrowserDialogCloneFolder.Description = "Select the folder that should be considered a clone of the original folder.";
            this.xtraFolderBrowserDialogCloneFolder.SelectedPath = "xtraFolderBrowserDialog1";
            this.xtraFolderBrowserDialogCloneFolder.ShowNewFolderButton = false;
            this.xtraFolderBrowserDialogCloneFolder.Title = "Select cloned folder";
            // 
            // FolderStructureComparerCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridControl1);
            this.Name = "FolderStructureComparerCtrl";
            this.Size = new System.Drawing.Size(1512, 676);
            this.WaitFormDescription = "Folder comparision in progress...";
            this.FolderStructureAnalysisFinished += new FolderStructureAnalyser.Components.FolderStructureParentCtrl.FolderStructureAnalysisFinishedHandler(this.FolderStructureComparerCtrl_FolderStructureAnalysisFinished);
            this.DoFolderStructureAnalysis += new FolderStructureAnalyser.Components.FolderStructureParentCtrl.DoFolderStructureAnalysisHandler(this.FolderStructureComparerCtrl_DoFolderStructureAnalysis);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bandedGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private System.ComponentModel.BackgroundWorker backgroundWorkerCompareFolders;
        private DevExpress.XtraEditors.XtraFolderBrowserDialog xtraFolderBrowserDialogOriginalFolder;
        private DevExpress.XtraEditors.XtraFolderBrowserDialog xtraFolderBrowserDialogCloneFolder;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridView bandedGridView1;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumnOriginalName;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumnDescription;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumnOriginalFullPath;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumnCloneName;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumnCloneFullPath;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBandOriginal;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBandClone;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBandDifference;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumnItemType;
    }
}
