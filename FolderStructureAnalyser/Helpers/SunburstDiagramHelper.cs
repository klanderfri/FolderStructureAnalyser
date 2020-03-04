using System.Collections.Generic;
using DevExpress.TreeMap;
using DevExpress.Utils;
using DevExpress.XtraTreeMap;
using FolderStructureAnalyser.DataObjects;

namespace FolderStructureAnalyser.Helpers
{
    public static class SunburstDiagramHelper
    {
        public static void SetupSunburstCtrl(SunburstControl sunburstCtrl, FolderData root)
        {
            sunburstCtrl.BorderOptions.Color = System.Drawing.Color.FromArgb(((int)(((byte)(157)))), ((int)(((byte)(160)))), ((int)(((byte)(170)))));
            sunburstCtrl.CenterLabel.TextPattern = "Root: {TV}";
            sunburstCtrl.Colorizer = new SunburstPaletteColorizer();
            sunburstCtrl.DataAdapter = new SunburstHierarchicalDataAdapter();
            sunburstCtrl.HoleRadiusPercent = 25;
            sunburstCtrl.Location = new System.Drawing.Point(2, 2);
            sunburstCtrl.Name = "sunburstCtrl";
            sunburstCtrl.Size = new System.Drawing.Size(542, 567);
            sunburstCtrl.TabIndex = 0;
            sunburstCtrl.ToolTipController = new ToolTipController();

            setupDataAdapter(sunburstCtrl, root);
            setupColorizer(sunburstCtrl);
            setupToolTip(sunburstCtrl);
        }

        private static void setupToolTip(SunburstControl sunburstCtrl)
        {
            var tooltip = sunburstCtrl.ToolTipController;
            tooltip.BeforeShow += Tooltip_BeforeShow;
        }

        private static void Tooltip_BeforeShow(object sender, ToolTipControllerShowEventArgs e)
        {
            var sunburstItem = (ISunburstItem)e.SelectedObject;
            var folder = sunburstItem.Tag as FolderData;
            var superToolTip = new SuperToolTip() { MaxWidth = 400 };
            superToolTip.Items.Add(new ToolTipTitleItem() { Text = folder.Name });
            superToolTip.Items.Add(new ToolTipSeparatorItem());
            superToolTip.Items.Add(new ToolTipItem() { Text = "Size in bytes: " + sunburstItem.Value });

            e.SuperTip = superToolTip;
        }

        private static void setupColorizer(SunburstControl sunburstCtrl)
        {
            var colorizer = (SunburstPaletteColorizer)sunburstCtrl.Colorizer;
            colorizer.Palette = Palette.BlueGreenPalette;
        }

        private static void setupDataAdapter(SunburstControl sunburstCtrl, FolderData root)
        {
            var adapter = (SunburstHierarchicalDataAdapter)sunburstCtrl.DataAdapter;
            loadData(adapter, root);
            addMappings(adapter);
        }

        private static void addMappings(SunburstHierarchicalDataAdapter adapter)
        {
            var mapping = new SunburstHierarchicalDataMapping()
            {
                ChildrenDataMember = "SubFolders",
                LabelDataMember = "Name",
                ValueDataMember = "SizeInBytes",
                Type = typeof(FolderData)
            };
            adapter.Mappings.Add(mapping);
        }

        private static void loadData(SunburstHierarchicalDataAdapter adapter, FolderData root)
        {
            var datas = new List<FolderData>();
            datas.AddRange(root.SubFolders);

            adapter.DataSource = datas;
        }
    }
}
