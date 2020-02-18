using System;
using System.IO;

namespace FolderStructureAnalyser.DataObjects
{
    /// <summary>
    /// Class for object holding data about a difference between two folder structures.
    /// </summary>
    public class StructureDifference
    {
        /// <summary>
        /// The name of the original folder.
        /// </summary>
        public string OriginalParentFolderName { get; private set; }

        /// <summary>
        /// The full path of the original folder.
        /// </summary>
        public string OriginalParentFolderFullPath { get; private set; }

        /// <summary>
        /// The name of the clone folder.
        /// </summary>
        public string CloneParentFolderName { get; private set; }

        /// <summary>
        /// The full path of the clone folder.
        /// </summary>
        public string CloneParentFolderFullPath { get; private set; }

        /// <summary>
        /// The description of the difference.
        /// </summary>
        public string Description { get; private set; }

        /// <summary>
        /// The name of the item in question.
        /// </summary>
        public string ItemName { get; private set; }

        /// <summary>
        /// Creates an object holding data about a difference between two folder structures.
        /// </summary>
        /// <param name="originalFullPath">The full path of the original folder.</param>
        /// <param name="cloneFullPath">The full path of the clone folder.</param>
        /// <param name="description">The description of the difference.</param>
        /// <param name="itemName">The name of the item in question.</param>
        public StructureDifference(string originalFullPath, string cloneFullPath, string description, string itemName)
        {
            var original = new DirectoryInfo(originalFullPath);
            OriginalParentFolderName = original.Name;
            OriginalParentFolderFullPath = original.FullName;

            var clone = new DirectoryInfo(cloneFullPath);
            CloneParentFolderName = clone.Name;
            CloneParentFolderFullPath = clone.FullName;

            Description = description;
            ItemName = itemName;
        }
    }
}
