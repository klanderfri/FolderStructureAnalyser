using System.Drawing;

namespace FolderStructureAnalyser.SessionBound
{
    /// <summary>
    /// Class for object holding the settings for the application.
    /// </summary>
    public class Settings : SessionBoundClass
    {
        /// <summary>
        /// The size in bytes of a folder that is to be considered big.
        /// </summary>
        public int BigFolderInMB { get; set; }

        /// <summary>
        /// The colour used to indicate a folder that is to be considered big.
        /// </summary>
        public Color BigFolderColour { get; set; }

        /// <summary>
        /// Tells if the hashes should be compared when comparing two files.
        /// </summary>
        public bool CompareFileHashes { get; set; }

        /// <summary>
        /// The colour used to indicate an error in a grid.
        /// </summary>
        public Color GridErrorColour { get; set; }

        /// <summary>
        /// Creates an object holding the settings for the application, using default values.
        /// </summary>
        /// <param name="session">The application session.</param>
        public Settings(Session session)
            : base(session)
        {
            BigFolderInMB = 10;
            BigFolderColour = Color.Red;
            CompareFileHashes = false;
            GridErrorColour = Color.Salmon;
        }
    }
}
