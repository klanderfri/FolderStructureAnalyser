﻿using System;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraTreeMap;
using FolderStructureAnalyser.Components.AnalyserPanels;
using FolderStructureAnalyser.DataObjects;
using FolderStructureAnalyser.Enums;
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
        /// Menu item for opening a disk item in Windows Explorer.
        /// </summary>
        public ToolStripItem OpenInExplorer { get; private set; }

        /// <summary>
        /// Menu item for the set as root option.
        /// </summary>
        public ToolStripItem SetAsRoot { get; private set; }

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
            OpenInExplorer = Items.Add("Open in Explorer", icons.GetImage(3), new EventHandler(openInExplorerClicked));
            SetAsRoot = Items.Add("Set as root", icons.GetImage(9), new EventHandler(setItemAsRootClicked));

            setItemAsDefault(OpenInExplorer);
        }

        /// <summary>
        /// Sets a menu item as the default option.
        /// </summary>
        /// <param name="item">The menu item to set as default.</param>
        private void setItemAsDefault(ToolStripItem item)
        {
            item.Font = new Font(item.Font, item.Font.Style | FontStyle.Bold);
        }

        /// <summary>
        /// Gets the disk item that was last hit in the sunburst diagram.
        /// </summary>
        /// <returns>The last hit disk item.</returns>
        private DiskItemData getLastHitDiskItem()
        {
            return LastHitInfo.SunburstItem.Tag as DiskItemData;
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

        private void openInExplorerClicked(object sender, EventArgs e)
        {
            FileHandler.InvokeExplorer(getLastHitDiskItem().Info, OpenFolderBehaviour.OpenItself);
        }
        
        private void setItemAsRootClicked(object sender, EventArgs e)
        {
            ParentFolderAnalyser.SetDiskItemAsRoot(getLastHitDiskItem());
        }
    }
}
