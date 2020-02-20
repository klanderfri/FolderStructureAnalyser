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
        public string Description { get { return DiffInfo.Description; } }

        /// <summary>
        /// The index indicating the type of item the difference is about (i.e folder or file).
        /// </summary>
        public int ItemTypeIndex { get { return DiffInfo.ItemTypeImageIndex; } }

        /// <summary>
        /// The index indicating the type of difference encountered.
        /// </summary>
        public int ProblemTypeIndex { get { return DiffInfo.DifferenceTypeImageIndex; } }

        /// <summary>
        /// The type of difference.
        /// </summary>
        public DifferenceType DifferenceType { get { return DiffInfo.DifferenceType; } }

        /// <summary>
        /// The original item.
        /// </summary>
        private FileSystemInfo Original { get; set; }

        /// <summary>
        /// The item that is supposed to be a clone of the original.
        /// </summary>
        private FileSystemInfo Clone { get; set; }

        /// <summary>
        /// Information about the difference between the original and the clone.
        /// </summary>
        private DifferenceTypeDescription DiffInfo { get; set; }

        /// <summary>
        /// Creates an object holding data about a difference between two folder structures.
        /// </summary>
        /// <param name="original">The original item.</param>
        /// <param name="clone">The item that is supposed to be a clone of the original.</param>
        /// <param name="type">The type of difference.</param>
        public StructureDifference(FileSystemInfo original, FileSystemInfo clone, DifferenceType type)
        {
            Original = original;
            Clone = clone;
            DiffInfo = new DifferenceTypeDescription(type);
        }
    }
}
