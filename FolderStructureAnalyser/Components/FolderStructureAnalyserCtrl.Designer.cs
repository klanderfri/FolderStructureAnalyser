namespace FolderStructureAnalyser.Components
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
            this.components = new System.ComponentModel.Container();
            this.xtraFolderBrowserDialogSelectFolder = new DevExpress.XtraEditors.XtraFolderBrowserDialog(this.components);
            this.splashScreenManagerWaitForm = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(global::FolderStructureAnalyser.Components.WaitForStructureAnalyseForm), true, true, typeof(System.Windows.Forms.UserControl));
            this.backgroundWorkerTimeHeavyAnalysis = new System.ComponentModel.BackgroundWorker();
            this.timerAnalysisProgress = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // xtraFolderBrowserDialogSelectFolder
            // 
            this.xtraFolderBrowserDialogSelectFolder.ShowNewFolderButton = false;
            // 
            // splashScreenManagerWaitForm
            // 
            this.splashScreenManagerWaitForm.ClosingDelay = 500;
            // 
            // backgroundWorkerTimeHeavyAnalysis
            // 
            this.backgroundWorkerTimeHeavyAnalysis.WorkerSupportsCancellation = true;
            this.backgroundWorkerTimeHeavyAnalysis.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerTimeHeavyAnalysis_DoWork);
            this.backgroundWorkerTimeHeavyAnalysis.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerTimeHeavyAnalysis_RunWorkerCompleted);
            // 
            // timerAnalysisProgress
            // 
            this.timerAnalysisProgress.Tick += new System.EventHandler(this.timerAnalysisProgress_Tick);
            // 
            // FolderStructureAnalyserCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "FolderStructureAnalyserCtrl";
            this.Resize += new System.EventHandler(this.FolderStructureAnalyserCtrl_Resize);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.XtraFolderBrowserDialog xtraFolderBrowserDialogSelectFolder;
        private DevExpress.XtraSplashScreen.SplashScreenManager splashScreenManagerWaitForm;
        private System.ComponentModel.BackgroundWorker backgroundWorkerTimeHeavyAnalysis;
        private System.Windows.Forms.Timer timerAnalysisProgress;
    }
}
