using System;
using System.Windows.Forms;
using DevExpress.XtraTreeMap;
using FolderStructureAnalyser.Components.AnalyserPanels;
using FolderStructureAnalyser.DataObjects;
using FolderStructureAnalyser.Helpers;

namespace FolderStructureAnalyser.Components.Support
{
    public class SizeDiagramContextMenu : ContextMenu
    {
        public readonly FolderStructureAnalyserCtrl ParentControl;
        public readonly SunburstControl ParentSunburst;
        public SunburstHitInfo HitInfo { get; private set; }

        public SizeDiagramContextMenu(FolderStructureAnalyserCtrl parentControl, SunburstControl sunburst)
        {
            ParentControl = parentControl;
            ParentSunburst = sunburst;
            
            setupMenu();
        }

        private void ParentSunburst_MouseDown(object sender, MouseEventArgs e)
        {
            //The helper uses screen location so convert the client point to screen point
            //so the helper then can convert that screen point back to a client point. Sigh!
            var location = ParentSunburst.PointToScreen(e.Location);

            //Find the hit info.
            HitInfo = GridHandler.GetHitInfo(ParentSunburst, location);

            if (e.Button == MouseButtons.Right && HitInfo.InSunburstItem)
            {
                Show(ParentSunburst, e.Location);
            }
        }

        private void setupMenu()
        {
            ParentSunburst.MouseDown += ParentSunburst_MouseDown;

            var setAsRoot = new MenuItem("Set as root", new EventHandler(setItemAsRoot));
            MenuItems.Add(setAsRoot);
        }

        private void setItemAsRoot(object sender, EventArgs e)
        {
            var root = HitInfo.SunburstItem.Tag as DiskItemData;
            ParentControl.SetDiskItemAsRoot(root);
        }
    }
}
