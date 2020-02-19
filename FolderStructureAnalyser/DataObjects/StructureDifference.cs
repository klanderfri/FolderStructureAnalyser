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
        public string OriginalName { get { return Original.Name; } }

        /// <summary>
        /// The full path of the original folder.
        /// </summary>
        public string OriginalFullPath { get { return Original.FullName; } }

        /// <summary>
        /// The name of the clone folder.
        /// </summary>
        public string CloneName { get { return Clone.Name; } }

        /// <summary>
        /// The full path of the clone folder.
        /// </summary>
        public string CloneFullPath { get { return Clone.FullName; } }

        /// <summary>
        /// The description of the difference.
        /// </summary>
        public string Description { get; private set; }


        private FileSystemInfo Original { get; set; }


        private FileSystemInfo Clone { get; set; }


        public string ItemType
        {
            get
            {
                var isDirectory = (Original.Attributes & FileAttributes.Directory) == FileAttributes.Directory;
                return isDirectory ? "Directory" : "File";
            }
        }

        public StructureDifference(FileSystemInfo original, FileSystemInfo clone, string description)
        {
            Original = original;
            Clone = clone;
            Description = description;
        }
    }
}
