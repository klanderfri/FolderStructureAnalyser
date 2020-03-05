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
            this.components = new System.ComponentModel.Container();
            DevExpress.XtraTreeMap.SunburstPaletteColorizer sunburstPaletteColorizer1 = new DevExpress.XtraTreeMap.SunburstPaletteColorizer();
            DevExpress.XtraTreeMap.SunburstHierarchicalDataAdapter sunburstHierarchicalDataAdapter1 = new DevExpress.XtraTreeMap.SunburstHierarchicalDataAdapter();
            DevExpress.XtraTreeMap.SunburstHierarchicalDataMapping sunburstHierarchicalDataMapping1 = new DevExpress.XtraTreeMap.SunburstHierarchicalDataMapping();
            this.sunburstControl1 = new DevExpress.XtraTreeMap.SunburstControl();
            this.toolTipController1 = new DevExpress.Utils.ToolTipController(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.sunburstControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // sunburstControl1
            // 
            this.sunburstControl1.CenterLabel.TextPattern = "Root: {TV}";
            sunburstPaletteColorizer1.Palette = DevExpress.XtraTreeMap.Palette.GreenPalette;
            this.sunburstControl1.Colorizer = sunburstPaletteColorizer1;
            sunburstHierarchicalDataMapping1.ChildrenDataMember = "SubItems";
            sunburstHierarchicalDataMapping1.LabelDataMember = "Name";
            sunburstHierarchicalDataMapping1.ValueDataMember = "SizeInBytes";
            sunburstHierarchicalDataAdapter1.Mappings.Add(sunburstHierarchicalDataMapping1);
            this.sunburstControl1.DataAdapter = sunburstHierarchicalDataAdapter1;
            this.sunburstControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sunburstControl1.HoleRadiusPercent = 25;
            this.sunburstControl1.Location = new System.Drawing.Point(0, 0);
            this.sunburstControl1.Name = "sunburstControl1";
            this.sunburstControl1.ShowCenterLabel = false;
            this.sunburstControl1.Size = new System.Drawing.Size(527, 391);
            this.sunburstControl1.TabIndex = 0;
            this.sunburstControl1.ToolTipController = this.toolTipController1;
            this.sunburstControl1.DoubleClick += new System.EventHandler(this.sunburstControl1_DoubleClick);
            // 
            // toolTipController1
            // 
            this.toolTipController1.BeforeShow += new DevExpress.Utils.ToolTipControllerBeforeShowEventHandler(this.toolTipController1_BeforeShow);
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
        private DevExpress.Utils.ToolTipController toolTipController1;
    }
}
