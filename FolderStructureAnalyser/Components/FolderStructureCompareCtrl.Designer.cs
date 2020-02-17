namespace FolderStructureAnalyser.Components
{
    partial class FolderStructureCompareCtrl
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
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.backgroundWorkerCompareFolders = new System.ComponentModel.BackgroundWorker();
            this.xtraFolderBrowserDialogOriginalFolder = new DevExpress.XtraEditors.XtraFolderBrowserDialog(this.components);
            this.xtraFolderBrowserDialogCloneFolder = new DevExpress.XtraEditors.XtraFolderBrowserDialog(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(522, 316);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            // 
            // xtraFolderBrowserDialogOriginalFolder
            // 
            this.xtraFolderBrowserDialogOriginalFolder.Description = "Select the folder that should act as the original folder.";
            this.xtraFolderBrowserDialogOriginalFolder.SelectedPath = "xtraFolderBrowserDialog1";
            this.xtraFolderBrowserDialogOriginalFolder.Title = "Select original folder";
            // 
            // xtraFolderBrowserDialogCloneFolder
            // 
            this.xtraFolderBrowserDialogCloneFolder.Description = "Select the folder that should be considered a clone of the original folder.";
            this.xtraFolderBrowserDialogCloneFolder.SelectedPath = "xtraFolderBrowserDialog1";
            this.xtraFolderBrowserDialogCloneFolder.Title = "Select cloned folder";
            // 
            // splashScreenManagerWaitForStructureCompare
            // 
            splashScreenManagerWaitForStructureCompare.ClosingDelay = 500;
            // 
            // FolderStructureCompareCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridControl1);
            this.Name = "FolderStructureCompareCtrl";
            this.Size = new System.Drawing.Size(522, 316);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.ComponentModel.BackgroundWorker backgroundWorkerCompareFolders;
        private DevExpress.XtraEditors.XtraFolderBrowserDialog xtraFolderBrowserDialogOriginalFolder;
        private DevExpress.XtraEditors.XtraFolderBrowserDialog xtraFolderBrowserDialogCloneFolder;
    }
}
