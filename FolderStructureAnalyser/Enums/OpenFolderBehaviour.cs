namespace FolderStructureAnalyser.Enums
{
    /// <summary>
    /// Tells how a folder should behave when opened in the Windows Explorer.
    /// </summary>
    public enum OpenFolderBehaviour
    {
        /// <summary>
        /// The folder parent should be opened with the folder selected.
        /// </summary>
        SelectInParent,

        /// <summary>
        /// The folder itself should be opened.
        /// </summary>
        OpenItself
    }
}
