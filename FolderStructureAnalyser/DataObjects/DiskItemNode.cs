using System;
using System.IO;

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
        /// The container holding information about the file.
        /// </summary>
        public FileInfo FileData { get; set; }
        
        /// <summary>
        /// The container holding information about the folder.
        /// </summary>
        public FolderData FolderData { get; set; }

        /// <summary>
        /// Tells if the node represents a folder.
        /// </summary>
        public bool IsFolder
        {
            get
            {
                //Tell the caller if the node represents a folder or not.
                if (FolderData != null) { return true; }
                if (FileData != null) { return false; }

                //Oops! Someone forgot to set the data the node is representing.
                var format = "Neither the folder data nor the file data is set for node '{0}', ID {1}";
                var message = String.Format(format, Name, ID);
                throw new InvalidOperationException(message);
            }
        }
    }
}
