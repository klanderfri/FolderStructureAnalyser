namespace FolderStructureAnalyser.Components.AnalyserPanels
{
    partial class FolderStructureSizeDiagramCtrl
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
            this.sunburstControl1 = new DevExpress.XtraTreeMap.SunburstControl();
            ((System.ComponentModel.ISupportInitialize)(this.sunburstControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // sunburstControl1
            // 
            this.sunburstControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sunburstControl1.Location = new System.Drawing.Point(0, 0);
            this.sunburstControl1.Name = "sunburstControl1";
            this.sunburstControl1.Size = new System.Drawing.Size(527, 391);
            this.sunburstControl1.TabIndex = 0;
            // 
            // FolderStructureSizeDiagramCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.sunburstControl1);
            this.Name = "FolderStructureSizeDiagramCtrl";
            this.Size = new System.Drawing.Size(527, 391);
            ((System.ComponentModel.ISupportInitialize)(this.sunburstControl1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraTreeMap.SunburstControl sunburstControl1;
    }
}
