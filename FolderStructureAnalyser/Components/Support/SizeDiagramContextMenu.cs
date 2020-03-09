using System;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.Utils.Svg;
using DevExpress.XtraTreeMap;
using FolderStructureAnalyser.Components.AnalyserPanels;
using FolderStructureAnalyser.DataObjects;
using FolderStructureAnalyser.Helpers;

namespace FolderStructureAnalyser.Components.Support
{
    /// <summary>
    /// Class for object representing a context menu within a sunburst diagram in a folder analyser control.
    /// </summary>
    public class SizeDiagramContextMenu : ContextMenuStrip
    {
        /// <summary>
        /// The parent folder analyser control containing the sunburst diagram.
        /// </summary>
        public readonly FolderStructureAnalyserCtrl ParentFolderAnalyser;

        /// <summary>
        /// The parent sunburst diagram that is to show the context menu.
        /// </summary>
        public readonly SunburstControl ParentSunburst;

        /// <summary>
        /// The hit info caught last time the menu was requested.
        /// </summary>
        public SunburstHitInfo LastHitInfo { get; private set; }

        /// <summary>
        /// Menu item for the set as root option.
        /// </summary>
        private ToolStripItem SetAsRoot { get; set; }

        /// <summary>
        /// Creates an object representing a context menu within a sunburst diagram in a folder analyser control.
        /// </summary>
        /// <param name="parentFolderAnalyser">The parent folder analyser control containing the sunburst diagram.</param>
        /// <param name="parentSunburst">The parent sunburst diagram that is to show the context menu.</param>
        public SizeDiagramContextMenu(FolderStructureAnalyserCtrl parentFolderAnalyser, SunburstControl parentSunburst)
        {
            ParentFolderAnalyser = parentFolderAnalyser;
            ParentSunburst = parentSunburst;
            
            setupMenu();
        }

        /// <summary>
        /// Sets up the menu and its items.
        /// </summary>
        private void setupMenu()
        {
            ParentSunburst.MouseDown += ParentSunburst_MouseDown;

            var icons = new AppSvgIcons();
            SetAsRoot = Items.Add("Set as root", icons.GetImage(8), new EventHandler(setItemAsRootClicked));
        }

        private void ParentSunburst_MouseDown(object sender, MouseEventArgs e)
        {
            //Only show the menu for right clicks.
            if (e.Button != MouseButtons.Right) { return; }

            //The helper uses screen location so convert the client point to screen point
            //so the helper then can convert that screen point back to a client point. Sigh!
            var location = ParentSunburst.PointToScreen(e.Location);

            //Find the hit info.
            LastHitInfo = GridHandler.GetHitInfo(ParentSunburst, location);
            
            //Only show the menu when a sunburst item was hit.
            if (!LastHitInfo.InSunburstItem) { return; }

            //Only show the set as root option if a folder was hit.
            var diskItem = LastHitInfo.SunburstItem.Tag as DiskItemData;
            SetAsRoot.Enabled = diskItem.IsFolder;

            //Show the menu.
            Show(ParentSunburst, e.Location);
        }

        /// <summary>
        /// Method handling the event raised when the user clicks the option to set a disk item as root.
        /// </summary>
        /// <param name="sender">The menu item clicked.</param>
        /// <param name="e">The arguments for the click event.</param>
        private void setItemAsRootClicked(object sender, EventArgs e)
        {
            var root = LastHitInfo.SunburstItem.Tag as DiskItemData;
            ParentFolderAnalyser.SetDiskItemAsRoot(root);
        }
    }
}
