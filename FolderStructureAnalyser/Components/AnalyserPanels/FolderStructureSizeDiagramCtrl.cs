using System.Collections.Generic;
using System.Windows.Forms;
using DevExpress.TreeMap;
using DevExpress.Utils;
using DevExpress.XtraTreeMap;
using FolderStructureAnalyser.Components.Support;
using FolderStructureAnalyser.DataObjects;
using FolderStructureAnalyser.Helpers;
using FolderStructureAnalyser.SessionBound;

namespace FolderStructureAnalyser.Components.AnalyserPanels
{
    public partial class FolderStructureSizeDiagramCtrl : AnalyserUserControl
    {
        /// <summary>
        /// The data adapter of the diagram control.
        /// </summary>
        private SunburstHierarchicalDataAdapter DataAdapter
        {
            get { return sunburstControl1.DataAdapter as SunburstHierarchicalDataAdapter; }
        }
        
        public FolderStructureSizeDiagramCtrl()
        {
            InitializeComponent();
            DataAdapter.Mappings[0].Type = typeof(DiskItemData);
        }

        /// <summary>
        /// Updates the diagram and its data.
        /// </summary>
        /// <param name="root">The folder the diagram should use as root.</param>
        public void UpdateData(DiskItemData root)
        {
            var diskItems = new List<DiskItemData>();
            diskItems.AddRange(root.SubItems);
            DataAdapter.DataSource = diskItems;
        }

        private void toolTipController1_BeforeShow(object sender, ToolTipControllerShowEventArgs e)
        {
            var sunburstItem = (ISunburstItem)e.SelectedObject;
            var diskItem = sunburstItem.Tag as DiskItemData;
            var superToolTip = new SuperToolTip() { MaxWidth = 400 };
            superToolTip.Items.Add(new ToolTipTitleItem() { Text = diskItem.Name });
            superToolTip.Items.Add(new ToolTipSeparatorItem());
            superToolTip.Items.Add(new ToolTipItem() { Text = diskItem.IsFolder ? "Folder" : "File" });
            superToolTip.Items.Add(new ToolTipItem() { Text = "Size: " + ByteSizeConverter.SizeStringFromByte((long)sunburstItem.Value, Session.Settings.SizeDisplayUnit) });

            e.SuperTip = superToolTip;
        }
    }
}
