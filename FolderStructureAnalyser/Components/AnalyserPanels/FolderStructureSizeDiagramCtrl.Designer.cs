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
            this.sunburstControl = new DevExpress.XtraTreeMap.SunburstControl();
            this.toolTipController = new DevExpress.Utils.ToolTipController(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.sunburstControl)).BeginInit();
            this.SuspendLayout();
            // 
            // sunburstControl
            // 
            this.sunburstControl.CenterLabel.TextPattern = "Root: {TV}";
            sunburstPaletteColorizer1.Palette = DevExpress.XtraTreeMap.Palette.GreenPalette;
            this.sunburstControl.Colorizer = sunburstPaletteColorizer1;
            sunburstHierarchicalDataMapping1.ChildrenDataMember = "SubItems";
            sunburstHierarchicalDataMapping1.LabelDataMember = "Name";
            sunburstHierarchicalDataMapping1.ValueDataMember = "SizeInBytes";
            sunburstHierarchicalDataAdapter1.Mappings.Add(sunburstHierarchicalDataMapping1);
            this.sunburstControl.DataAdapter = sunburstHierarchicalDataAdapter1;
            this.sunburstControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sunburstControl.HoleRadiusPercent = 25;
            this.sunburstControl.Location = new System.Drawing.Point(0, 0);
            this.sunburstControl.Name = "sunburstControl";
            this.sunburstControl.ShowCenterLabel = false;
            this.sunburstControl.Size = new System.Drawing.Size(527, 391);
            this.sunburstControl.TabIndex = 0;
            this.sunburstControl.ToolTipController = this.toolTipController;
            this.sunburstControl.DoubleClick += new System.EventHandler(this.sunburstControl_DoubleClick);
            // 
            // toolTipController
            // 
            this.toolTipController.BeforeShow += new DevExpress.Utils.ToolTipControllerBeforeShowEventHandler(this.toolTipController_BeforeShow);
            // 
            // FolderStructureSizeDiagramCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.sunburstControl);
            this.Name = "FolderStructureSizeDiagramCtrl";
            this.Size = new System.Drawing.Size(527, 391);
            ((System.ComponentModel.ISupportInitialize)(this.sunburstControl)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraTreeMap.SunburstControl sunburstControl;
        private DevExpress.Utils.ToolTipController toolTipController;
    }
}
