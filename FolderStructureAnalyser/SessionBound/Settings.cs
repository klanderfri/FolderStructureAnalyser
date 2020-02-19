using System.Drawing;

namespace FolderStructureAnalyser.SessionBound
{
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

        public Settings(Session session)
            : base(session)
        {
            BigFolderInMB = 10;
            BigFolderColour = Color.Red;
        }
    }
}
