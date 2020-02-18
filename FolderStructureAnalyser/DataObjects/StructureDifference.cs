using System;
using System.IO;

namespace FolderStructureAnalyser.DataObjects
{
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
        /// The name of the original folder.
        /// </summary>
        public string CloneName { get; private set; }

        /// <summary>
        /// The full path of the original folder.
        /// </summary>
        public string CloneFullPath { get; private set; }

        /// <summary>
        /// The description of the difference.
        /// </summary>
        public string Description { get; private set; }

        public StructureDifference(string originalFullPath, string cloneFullPath, string description)
        {
            OriginalName = Path.GetDirectoryName(originalFullPath);
            OriginalFullPath = originalFullPath;

            if (!String.IsNullOrWhiteSpace(cloneFullPath))
            {
                CloneName = Path.GetDirectoryName(cloneFullPath);
                CloneFullPath = cloneFullPath;
            }

            Description = description;
        }
    }
}
