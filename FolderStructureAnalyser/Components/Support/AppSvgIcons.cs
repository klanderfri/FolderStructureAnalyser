using DevExpress.Utils;

namespace FolderStructureAnalyser.Components.Support
{
    public class AppSvgIcons : SvgImageCollection
    {
        private SvgImageCollection svgImageCollection;
        private System.ComponentModel.IContainer components;

        public AppSvgIcons()
        {
            InitializeComponent();
            AddRange(svgImageCollection);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.svgImageCollection = new DevExpress.Utils.SvgImageCollection(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.svgImageCollection)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // svgImageCollection
            // 
            this.svgImageCollection.Add("collapsedFolder", "image://svgimages/icon builder/actions_folderclose.svg");
            this.svgImageCollection.Add("expandedFolder", "image://svgimages/actions/open.svg");
            this.svgImageCollection.Add("file", "image://svgimages/actions/new.svg");
            this.svgImageCollection.Add("open", "image://svgimages/actions/open2.svg");
            this.svgImageCollection.Add("additional", "image://svgimages/icon builder/actions_addcircled.svg");
            this.svgImageCollection.Add("missing", "image://svgimages/icon builder/actions_deletecircled.svg");
            this.svgImageCollection.Add("size", "image://svgimages/outlook inspired/fittopage.svg");
            this.svgImageCollection.Add("attributes", "image://svgimages/setup/properties.svg");
            this.svgImageCollection.Add("hash", "image://svgimages/reports/barcodeshowtext.svg");
            ((System.ComponentModel.ISupportInitialize)(this.svgImageCollection)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
    }
}
