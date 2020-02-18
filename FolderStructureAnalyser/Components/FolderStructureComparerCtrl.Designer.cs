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
            this.backgroundWorkerCompareFolders = new System.ComponentModel.BackgroundWorker();
            this.xtraFolderBrowserDialogOriginalFolder = new DevExpress.XtraEditors.XtraFolderBrowserDialog(this.components);
            this.xtraFolderBrowserDialogCloneFolder = new DevExpress.XtraEditors.XtraFolderBrowserDialog(this.components);
            this.bandedGridView1 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridView();
            this.gridBand1 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.gridColumnOriginalName = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridColumnDescription = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridColumnOriginalFullPath = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
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
            // bandedGridView1
            // 
            this.bandedGridView1.Bands.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] {
            this.gridBand1});
            this.bandedGridView1.Columns.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[] {
            this.gridColumnOriginalName,
            this.gridColumnDescription,
            this.gridColumnOriginalFullPath});
            this.bandedGridView1.GridControl = this.gridControl1;
            this.bandedGridView1.Name = "bandedGridView1";
            this.bandedGridView1.OptionsView.ColumnAutoWidth = false;
            // 
            // gridBand1
            // 
            this.gridBand1.Caption = "gridBand1";
            this.gridBand1.Columns.Add(this.gridColumnOriginalName);
            this.gridBand1.Columns.Add(this.gridColumnDescription);
            this.gridBand1.Columns.Add(this.gridColumnOriginalFullPath);
            this.gridBand1.Name = "gridBand1";
            this.gridBand1.VisibleIndex = 0;
            this.gridBand1.Width = 1230;
            // 
            // gridColumnOriginalName
            // 
            this.gridColumnOriginalName.Caption = "Original Name";
            this.gridColumnOriginalName.FieldName = "OriginalName";
            this.gridColumnOriginalName.Name = "gridColumnOriginalName";
            this.gridColumnOriginalName.Visible = true;
            this.gridColumnOriginalName.Width = 230;
            // 
            // gridColumnDescription
            // 
            this.gridColumnDescription.Caption = "Description";
            this.gridColumnDescription.FieldName = "Description";
            this.gridColumnDescription.Name = "gridColumnDescription";
            this.gridColumnDescription.Visible = true;
            this.gridColumnDescription.Width = 500;
            // 
            // gridColumnOriginalFullPath
            // 
            this.gridColumnOriginalFullPath.Caption = "Original Full Path";
            this.gridColumnOriginalFullPath.FieldName = "OriginalFullPath";
            this.gridColumnOriginalFullPath.Name = "gridColumnOriginalFullPath";
            this.gridColumnOriginalFullPath.Visible = true;
            this.gridColumnOriginalFullPath.Width = 500;
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
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand1;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridColumnOriginalName;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridColumnDescription;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridColumnOriginalFullPath;
    }
}
