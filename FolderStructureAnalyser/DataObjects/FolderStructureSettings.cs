﻿using System.Drawing;

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
            BigFolderInMB = 10;
            BigFolderColour = Color.Red;
        }

        /// <summary>
        /// The size in bytes of a folder that is to be considered big.
        /// </summary>
        public int BigFolderInMB { get; set; }

        /// <summary>
        /// The colour used to indicate a folder that is to be considered big.
        /// </summary>
        public Color BigFolderColour { get; set; }
    }
}
