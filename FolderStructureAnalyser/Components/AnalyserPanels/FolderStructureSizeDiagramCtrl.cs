using System.Collections.Generic;
using System.Windows.Forms;
using DevExpress.TreeMap;
using DevExpress.Utils;
using DevExpress.XtraTreeMap;
using FolderStructureAnalyser.DataObjects;

namespace FolderStructureAnalyser.Components.AnalyserPanels
{
    public partial class FolderStructureSizeDiagramCtrl : UserControl
    {
        private SunburstHierarchicalDataAdapter DataAdapter
        {
            get { return sunburstControl1.DataAdapter as SunburstHierarchicalDataAdapter; }
        }
        
        public FolderStructureSizeDiagramCtrl()
        {
            InitializeComponent();
            DataAdapter.Mappings[0].Type = typeof(FolderData);
        }

        public void UpdateData(FolderData root)
        {
            var diskItems = new List<FolderData>();
            diskItems.AddRange(root.SubFolders);

            DataAdapter.DataSource = diskItems;
        }

        private void toolTipController1_BeforeShow(object sender, ToolTipControllerShowEventArgs e)
        {
            var sunburstItem = (ISunburstItem)e.SelectedObject;
            var folder = sunburstItem.Tag as FolderData;
            var superToolTip = new SuperToolTip() { MaxWidth = 400 };
            superToolTip.Items.Add(new ToolTipTitleItem() { Text = folder.Name });
            superToolTip.Items.Add(new ToolTipSeparatorItem());
            superToolTip.Items.Add(new ToolTipItem() { Text = "Size in bytes: " + sunburstItem.Value });

            e.SuperTip = superToolTip;
        }
    }
}
