using System;

namespace FolderStructureAnalyser.Components
{
    /// <summary>
    /// Class for object holding the arguments for the event used when a folder structure has finished loading.
    /// </summary>
    public class FolderStructureLoadFinishedArgs : EventArgs
    {
        /// <summary>
        /// Tells if the loading was cancelled.
        /// </summary>
        public bool Cancelled { get; set; }
    }
}
