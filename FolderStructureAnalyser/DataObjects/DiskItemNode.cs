namespace FolderStructureAnalyser.DataObjects
{
    /// <summary>
    /// Object representing a disk item when viewed in a tree.
    /// </summary>
    public class DiskItemNode
    {
        /// <summary>
        /// The unique ID of the disk item node.
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// The ID of the parent disk item node.
        /// </summary>
        /// <remarks>Should be null for the root folder.</remarks>
        public int? ParentID { get; set; }

        /// <summary>
        /// The name of the disk item.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The size of the disk item.
        /// </summary>
        public double SizeInBytes { get; set; }

        /// <summary>
        /// The index of the image the tree should use as state image for the disk item when it is collapsed.
        /// </summary>
        public int CollapsedStateImageIndex { get; set; }

        /// <summary>
        /// The index of the image the tree should use as state image for the disk item when it is expanded.
        /// </summary>
        public int ExpandedStateImageIndex { get; set; }
        
        /// <summary>
        /// The container holding information about the folder.
        /// </summary>
        public DiskItemData DiskItem { get; set; }
    }
}
