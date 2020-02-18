using System;
using System.Drawing;

namespace FolderStructureAnalyser.DataObjects
{
    /// <summary>
    /// Class for object holding the settings for a folder structure.
    /// </summary>
    public class FolderStructureSettings
    {
        /// <summary>
        /// Creates an object holding the settings for a folder structure.
        /// </summary>
        public FolderStructureSettings()
        {
            BigFolderInBytes = 10485760; //10 MB.
            BigFolderColour = Color.Red;
        }

        /// <summary>
        /// The size in bytes of a folder that is to be considered big.
        /// </summary>
        public long BigFolderInBytes { get; set; }

        /// <summary>
        /// The colour used to indicate afolder that is to be considered big.
        /// </summary>
        public Color BigFolderColour { get; set; }
    }
}
