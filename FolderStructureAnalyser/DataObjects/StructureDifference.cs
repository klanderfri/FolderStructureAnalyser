using System.IO;

namespace FolderStructureAnalyser.DataObjects
{
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
        /// The description of the difference.
        /// </summary>
        public string Description { get; private set; }

        /// <summary>
        /// Information about the original folder.
        /// </summary>
        private DirectoryInfo Original;

        public StructureDifference(string originalFullPath, string description)
        {
            Original = new DirectoryInfo(originalFullPath);
            Description = description;
        }
    }
}
