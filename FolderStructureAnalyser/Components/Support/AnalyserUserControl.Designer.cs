namespace FolderStructureAnalyser.Components.Support
{
    partial class AnalyserUserControl
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
            this.svgImageCollectionIcons = new DevExpress.Utils.SvgImageCollection(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.svgImageCollectionIcons)).BeginInit();
            this.SuspendLayout();
            // 
            // svgImageCollectionIcons
            // 
            this.svgImageCollectionIcons.Add("collapsedFolder", "image://svgimages/icon builder/actions_folderclose.svg");
            this.svgImageCollectionIcons.Add("expandedFolder", "image://svgimages/actions/open.svg");
            this.svgImageCollectionIcons.Add("file", "image://svgimages/actions/new.svg");
            this.svgImageCollectionIcons.Add("open", "image://svgimages/actions/open2.svg");
            this.svgImageCollectionIcons.Add("additional", "image://svgimages/icon builder/actions_addcircled.svg");
            this.svgImageCollectionIcons.Add("missing", "image://svgimages/icon builder/actions_deletecircled.svg");
            this.svgImageCollectionIcons.Add("size", "image://svgimages/outlook inspired/fittopage.svg");
            this.svgImageCollectionIcons.Add("attributes", "image://svgimages/setup/properties.svg");
            this.svgImageCollectionIcons.Add("hash", "image://svgimages/reports/barcodeshowtext.svg");
            // 
            // AnalyserUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "AnalyserUserControl";
            ((System.ComponentModel.ISupportInitialize)(this.svgImageCollectionIcons)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.Utils.SvgImageCollection svgImageCollectionIcons;
    }
}
