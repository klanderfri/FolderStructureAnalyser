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
        public string OriginalName { get; private set; }

        /// <summary>
        /// The full path of the original folder.
        /// </summary>
        public string OriginalFullPath { get; private set; }

        /// <summary>
        /// The name of the clone folder.
        /// </summary>
        public string CloneName { get; private set; }

        /// <summary>
        /// The full path of the clone folder.
        /// </summary>
        public string CloneFullPath { get; private set; }

        /// <summary>
        /// The description of the difference.
        /// </summary>
        public string Description { get; private set; }

        /// <summary>
        /// Creates an object holding data about a difference between two folder structures.
        /// </summary>
        /// <param name="originalFullPath">The full path of the original folder.</param>
        /// <param name="cloneFullPath">The full path of the clone folder.</param>
        /// <param name="description">The description of the difference.</param>
        public StructureDifference(string originalFullPath, string cloneFullPath, string description)
        {
            var original = new DirectoryInfo(originalFullPath);
            OriginalName = original.Name;
            OriginalFullPath = original.FullName;

            if (!String.IsNullOrWhiteSpace(cloneFullPath))
            {
                var clone = new DirectoryInfo(cloneFullPath);
                CloneName = clone.Name;
                CloneFullPath = clone.FullName;
            }

            Description = description;
        }
    }
}
