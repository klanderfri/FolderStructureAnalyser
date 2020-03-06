using System;
using System.Collections.Generic;
using System.Drawing;
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
            get { return sunburstControl.DataAdapter as SunburstHierarchicalDataAdapter; }
        }

        /// <summary>
        /// The context menu to show for the sunburst diagram.
        /// </summary>
        private SizeDiagramContextMenu DiagramContextMenu { get; set; }
        
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

        private void toolTipController_BeforeShow(object sender, ToolTipControllerShowEventArgs e)
        {
            var sunburstItem = (ISunburstItem)e.SelectedObject;
            var diskItem = sunburstItem.Tag as DiskItemData;
            var superToolTip = new SuperToolTip() { MaxWidth = 400 };
            superToolTip.Items.Add(new ToolTipTitleItem() { Text = diskItem.Name });
            superToolTip.Items.Add(new ToolTipSeparatorItem());
            superToolTip.Items.Add(new ToolTipItem() { Icon = getDiskItemIcon(diskItem.IsFolder), Text = getSizeText(sunburstItem) });

            e.SuperTip = superToolTip;
        }

        /// <summary>
        /// Gets the text describing the size of a disk item.
        /// </summary>
        /// <param name="sunburstItem">The sunburst item representing the disk item.</param>
        /// <returns>The text describing the size of a disk item.</returns>
        private string getSizeText(ISunburstItem sunburstItem)
        {
            var size = (long)sunburstItem.Value;
            var unit = Session.Settings.SizeDisplayUnit;
            return ByteSizeConverter.SizeStringFromByte(size, unit);
        }

        /// <summary>
        /// Gets the icon representing a disk item.
        /// </summary>
        /// <param name="isFolder">Tells if the disk item is a folder.</param>
        /// <returns>The icon representing a disk item.</returns>
        private Icon getDiskItemIcon(bool isFolder)
        {
            var index = isFolder ? 1 : 2;
            var image = new Bitmap(IconCollection.GetImage(index));
            return Icon.FromHandle(image.GetHicon());
        }

        private void sunburstControl_DoubleClick(object sender, EventArgs e)
        {
            var hitInfo = GridHandler.GetHitInfo(sender as SunburstControl, MousePosition);

            if (hitInfo.InSunburstItem)
            {
                var diskItem = hitInfo.SunburstItem.Tag as DiskItemData;
                FileHandler.OpenDiskItemInExplorer(diskItem.Info);
            }
        }

        private void Parent_ParentChanged(object sender, EventArgs e)
        {
            var ctrl = sender as Control;
            var highestParent = tryGetAnalyserParent(ctrl);

            if (highestParent != ctrl)
            {
                if (highestParent is FolderStructureAnalyserCtrl)
                {
                    createSunbrustDiagramMenu(highestParent as FolderStructureAnalyserCtrl);
                }
                else
                {
                    highestParent.ParentChanged += Parent_ParentChanged;
                }
            }
        }

        /// <summary>
        /// Tries to get the analyser control that is the parent of a specific control.
        /// </summary>
        /// <param name="ctrl">The control to get the analyser parent for.</param>
        /// <returns>The analyser parent or the highest possible parent.</returns>
        private Control tryGetAnalyserParent(Control ctrl)
        {
            if (ctrl is FolderStructureAnalyserCtrl || ctrl.Parent == null) { return ctrl; }
            return tryGetAnalyserParent(ctrl.Parent);
        }

        /// <summary>
        /// Creates the menu to show for the sunburst diagram.
        /// </summary>
        /// <param name="parentFolderAnalyserCtrl">The parent folder analyser control that is resposnible for the sunburst diagram.</param>
        private void createSunbrustDiagramMenu(FolderStructureAnalyserCtrl parentFolderAnalyserCtrl)
        {
            DiagramContextMenu = new SizeDiagramContextMenu(parentFolderAnalyserCtrl, sunburstControl);
        }
    }
}
