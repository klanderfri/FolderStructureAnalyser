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
            this.bandedGridColumnOriginalParentFolderName = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumnOriginalParentFolderFullPath = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBandClone = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.bandedGridColumnCloneParentFolderName = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumnCloneParentFolderFullPath = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBandDifference = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.bandedGridColumnDescription = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumnItemName = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
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
            this.gridBandOriginal,
            this.gridBandClone,
            this.gridBandDifference});
            this.bandedGridView1.Columns.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[] {
            this.bandedGridColumnOriginalParentFolderName,
            this.bandedGridColumnOriginalParentFolderFullPath,
            this.bandedGridColumnCloneParentFolderName,
            this.bandedGridColumnCloneParentFolderFullPath,
            this.bandedGridColumnDescription,
            this.bandedGridColumnItemName});
            this.bandedGridView1.GridControl = this.gridControl1;
            this.bandedGridView1.Name = "bandedGridView1";
            this.bandedGridView1.OptionsView.ColumnAutoWidth = false;
            // 
            // gridBandOriginal
            // 
            this.gridBandOriginal.Caption = "Original";
            this.gridBandOriginal.Columns.Add(this.bandedGridColumnOriginalParentFolderName);
            this.gridBandOriginal.Columns.Add(this.bandedGridColumnOriginalParentFolderFullPath);
            this.gridBandOriginal.Name = "gridBandOriginal";
            this.gridBandOriginal.VisibleIndex = 0;
            this.gridBandOriginal.Width = 400;
            // 
            // bandedGridColumnOriginalParentFolderName
            // 
            this.bandedGridColumnOriginalParentFolderName.Caption = "Parent Folder";
            this.bandedGridColumnOriginalParentFolderName.FieldName = "OriginalParentFolderName";
            this.bandedGridColumnOriginalParentFolderName.Name = "bandedGridColumnOriginalParentFolderName";
            this.bandedGridColumnOriginalParentFolderName.OptionsColumn.AllowEdit = false;
            this.bandedGridColumnOriginalParentFolderName.Visible = true;
            this.bandedGridColumnOriginalParentFolderName.Width = 250;
            // 
            // bandedGridColumnOriginalParentFolderFullPath
            // 
            this.bandedGridColumnOriginalParentFolderFullPath.Caption = "Parent Folder Path";
            this.bandedGridColumnOriginalParentFolderFullPath.FieldName = "OriginalParentFolderFullPath";
            this.bandedGridColumnOriginalParentFolderFullPath.Name = "bandedGridColumnOriginalParentFolderFullPath";
            this.bandedGridColumnOriginalParentFolderFullPath.OptionsColumn.AllowEdit = false;
            this.bandedGridColumnOriginalParentFolderFullPath.Visible = true;
            this.bandedGridColumnOriginalParentFolderFullPath.Width = 150;
            // 
            // gridBandClone
            // 
            this.gridBandClone.Caption = "Clone";
            this.gridBandClone.Columns.Add(this.bandedGridColumnCloneParentFolderName);
            this.gridBandClone.Columns.Add(this.bandedGridColumnCloneParentFolderFullPath);
            this.gridBandClone.Name = "gridBandClone";
            this.gridBandClone.VisibleIndex = 1;
            this.gridBandClone.Width = 400;
            // 
            // bandedGridColumnCloneParentFolderName
            // 
            this.bandedGridColumnCloneParentFolderName.Caption = "Parent Folder";
            this.bandedGridColumnCloneParentFolderName.FieldName = "CloneParentFolderName";
            this.bandedGridColumnCloneParentFolderName.Name = "bandedGridColumnCloneParentFolderName";
            this.bandedGridColumnCloneParentFolderName.OptionsColumn.AllowEdit = false;
            this.bandedGridColumnCloneParentFolderName.Visible = true;
            this.bandedGridColumnCloneParentFolderName.Width = 250;
            // 
            // bandedGridColumnCloneParentFolderFullPath
            // 
            this.bandedGridColumnCloneParentFolderFullPath.Caption = "Parent Folder Path";
            this.bandedGridColumnCloneParentFolderFullPath.FieldName = "CloneParentFolderFullPath";
            this.bandedGridColumnCloneParentFolderFullPath.Name = "bandedGridColumnCloneParentFolderFullPath";
            this.bandedGridColumnCloneParentFolderFullPath.OptionsColumn.AllowEdit = false;
            this.bandedGridColumnCloneParentFolderFullPath.Visible = true;
            this.bandedGridColumnCloneParentFolderFullPath.Width = 150;
            // 
            // gridBandDifference
            // 
            this.gridBandDifference.Caption = "Difference";
            this.gridBandDifference.Columns.Add(this.bandedGridColumnDescription);
            this.gridBandDifference.Columns.Add(this.bandedGridColumnItemName);
            this.gridBandDifference.Name = "gridBandDifference";
            this.gridBandDifference.VisibleIndex = 2;
            this.gridBandDifference.Width = 500;
            // 
            // bandedGridColumnDescription
            // 
            this.bandedGridColumnDescription.Caption = "Description";
            this.bandedGridColumnDescription.FieldName = "Description";
            this.bandedGridColumnDescription.Name = "bandedGridColumnDescription";
            this.bandedGridColumnDescription.OptionsColumn.AllowEdit = false;
            this.bandedGridColumnDescription.Visible = true;
            this.bandedGridColumnDescription.Width = 300;
            // 
            // bandedGridColumnItemName
            // 
            this.bandedGridColumnItemName.Caption = "Item";
            this.bandedGridColumnItemName.FieldName = "ItemName";
            this.bandedGridColumnItemName.Name = "bandedGridColumnItemName";
            this.bandedGridColumnItemName.OptionsColumn.AllowEdit = false;
            this.bandedGridColumnItemName.Visible = true;
            this.bandedGridColumnItemName.Width = 200;
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
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumnOriginalParentFolderName;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumnDescription;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumnOriginalParentFolderFullPath;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumnCloneParentFolderName;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumnCloneParentFolderFullPath;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBandOriginal;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBandClone;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBandDifference;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumnItemName;
    }
}
