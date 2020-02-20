using FolderStructureAnalyser.Helpers;

namespace FolderStructureAnalyser.SessionBound
{
    public class Tools : SessionBoundClass
    {
        public Tools(Session session)
            : base(session) { }

        /// <summary>
        /// Tells if a folder is to be considered big.
        /// </summary>
        /// <param name="sizeInBytes">The size of the folder, in bytes.</param>
        /// <returns>TRUE if the folder is big, else FALSE.</returns>
        public bool IsBigFolder(long sizeInBytes)
        {
            var sizeLimitInMB = Session.Settings.BigFolderInMB;
            var sizeLimitInBytes = ByteSizeConverter.BytesFromMB(sizeLimitInMB);

            return sizeInBytes >= sizeLimitInBytes;
        }

        /// <summary>
        /// Converts a size in bytes to a descriptive string.
        /// </summary>
        /// <param name="sizeInBytes">The size to convert.</param>
        /// <returns>A string describing the size.</returns>
        public string SizeStringFromByte(long sizeInBytes)
        {
            return ByteSizeConverter.SizeStringFromByte(sizeInBytes, Session.Settings.SizeDisplayUnit);
        }
    }
}
