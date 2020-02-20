using System;
using FolderStructureAnalyser.Enums;

namespace FolderStructureAnalyser.DataObjects
{
    /// <summary>
    /// Class for object describing a type of difference between two folders.
    /// </summary>
    public class DifferenceTypeDescription
    {
        /// <summary>
        /// The index for the image representing the type of item the difference is about (i.e folder or file).
        /// </summary>
        public int ItemTypeImageIndex { get; private set; }

        /// <summary>
        /// The index for the image representing the type of difference.
        /// </summary>
        public int DifferenceTypeImageIndex { get; private set; }

        /// <summary>
        /// A human-readable text describing the difference.
        /// </summary>
        public string Description { get; private set; }

        /// <summary>
        /// Creates an object describing a type of difference between two folders.
        /// </summary>
        /// <param name="diffType">The type of difference.</param>
        public DifferenceTypeDescription(DifferenceType diffType)
        {
            switch (diffType)
            {
                case DifferenceType.SubfolderMissing:
                    ItemTypeImageIndex = 0;
                    DifferenceTypeImageIndex = 4;
                    Description = "The clone is missing a folder.";
                    break;

                case DifferenceType.SubfolderAdditional:
                    ItemTypeImageIndex = 0;
                    DifferenceTypeImageIndex = 3;
                    Description = "The clone has an additional folder.";
                    break;

                case DifferenceType.SubfolderAttributesDiffer:
                    ItemTypeImageIndex = 0;
                    DifferenceTypeImageIndex = 6;
                    Description = "The clone folder has different attributes.";
                    break;

                case DifferenceType.FileMissing:
                    ItemTypeImageIndex = 1;
                    DifferenceTypeImageIndex = 4;
                    Description = "The clone is missing a file.";
                    break;

                case DifferenceType.FileAdditional:
                    ItemTypeImageIndex = 1;
                    DifferenceTypeImageIndex = 3;
                    Description = "The clone has an additional file.";
                    break;

                case DifferenceType.FileAttributesDiffer:
                    ItemTypeImageIndex = 1;
                    DifferenceTypeImageIndex = 6;
                    Description = "The clone file has different attributes.";
                    break;

                case DifferenceType.FileSizeDiffer:
                    ItemTypeImageIndex = 1;
                    DifferenceTypeImageIndex = 5;
                    Description = "The clone file has a different size.";
                    break;

                default:
                    var format = "Unhandled folder structure difference: {0}";
                    var message = String.Format(format, diffType);
                    throw new NotImplementedException();
            }
        }
    }
}
