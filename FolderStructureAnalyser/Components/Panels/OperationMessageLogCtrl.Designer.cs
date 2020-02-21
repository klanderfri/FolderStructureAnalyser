namespace FolderStructureAnalyser.Components.Panels
{
    partial class OperationMessageLogCtrl
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
            this.labelLastOperationTime = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelLastOperationTime
            // 
            this.labelLastOperationTime.AutoSize = true;
            this.labelLastOperationTime.Location = new System.Drawing.Point(32, 25);
            this.labelLastOperationTime.Name = "labelLastOperationTime";
            this.labelLastOperationTime.Size = new System.Drawing.Size(128, 13);
            this.labelLastOperationTime.TabIndex = 0;
            this.labelLastOperationTime.Text = "Last operation time: 0 sec";
            // 
            // OperationMessageLogCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labelLastOperationTime);
            this.Name = "OperationMessageLogCtrl";
            this.Size = new System.Drawing.Size(403, 250);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelLastOperationTime;
    }
}
