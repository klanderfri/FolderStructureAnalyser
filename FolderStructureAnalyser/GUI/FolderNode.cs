using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FolderStructureAnalyser.BuisnessObjects;

namespace FolderStructureAnalyser.GUI
{
    /// <summary>
    /// Object representing a folder when viewed in a tree.
    /// </summary>
    public class FolderNode
    {
        /// <summary>
        /// The unique ID of the folder node.
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// The ID of the parent folder node.
        /// </summary>
        /// <remarks>Should be null for the root folder.</remarks>
        public int? ParentID { get; set; }

        /// <summary>
        /// The name of the folder.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The size of the folder.
        /// </summary>
        public double SizeInBytes { get; set; }

        /// <summary>
        /// The container holding information about the folder.
        /// </summary>
        public Folder FolderData { get; set; }
    }
}
