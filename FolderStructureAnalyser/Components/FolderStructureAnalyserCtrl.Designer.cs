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
    }
}
