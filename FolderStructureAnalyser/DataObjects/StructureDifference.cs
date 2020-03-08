using System.IO;
using FolderStructureAnalyser.Enums;

namespace FolderStructureAnalyser.DataObjects
{
    /// <summary>
    /// Class for object holding data about a difference between two folder structures.
    /// </summary>
    public class StructureDifference
    {
        /// <summary>
        /// The original item.
        /// </summary>
        public DiskItemInfo Original { get; private set; }

        /// <summary>
        /// The item that is supposed to be a clone of the original.
        /// </summary>
        public DiskItemInfo Clone { get; private set; }

        /// <summary>
        /// Information about the difference between the original and the clone.
        /// </summary>
        public DifferenceTypeDescription DiffInfo { get; private set; }

        /// <summary>
        /// Creates an object holding data about a difference between two folder structures.
        /// </summary>
        /// <param name="original">The original item.</param>
        /// <param name="clone">The item that is supposed to be a clone of the original.</param>
        /// <param name="type">The type of difference.</param>
        public StructureDifference(FileSystemInfo original, FileSystemInfo clone, DifferenceType type)
        {
            Original = new DiskItemInfo(original);
            Clone = new DiskItemInfo(clone);
            DiffInfo = new DifferenceTypeDescription(type);
        }
    }
}
