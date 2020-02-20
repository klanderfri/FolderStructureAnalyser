namespace FolderStructureAnalyser.Enums
{
    /// <summary>
    /// Tells how two folders are different.
    /// </summary>
    public enum DifferenceType
    {
        /// <summary>
        /// The clone is missing a subfolder.
        /// </summary>
        SubfolderMissing,

        /// <summary>
        /// The clone has a subfolder the original does not.
        /// </summary>
        SubfolderAdditional,

        /// <summary>
        /// The clone subfolder has other attributes than the original.
        /// </summary>
        SubfolderAttributesDiffer,

        /// <summary>
        /// The clone is missing a file.
        /// </summary>
        FileMissing,

        /// <summary>
        /// The clone has a file the original does not.
        /// </summary>
        FileAdditional,

        /// <summary>
        /// The clone file has other attributes than the original.
        /// </summary>
        FileAttributesDiffer,

        /// <summary>
        /// The clone file has a different size than the original.
        /// </summary>
        FileSizeDiffer,

        /// <summary>
        /// The clone file has a different hash than the original. 
        /// </summary>
        FileHashDiffer
    }
}
