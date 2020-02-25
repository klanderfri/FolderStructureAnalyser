using FolderStructureAnalyser.Helpers;

namespace FolderStructureAnalyser.SessionBound
{
    /// <summary>
    /// Class for object containing state based tool methods.
    /// </summary>
    public class Tools : SessionBoundClass
    {
        /// <summary>
        /// Holds the ID for the next operation to be started.
        /// </summary>
        private int NextOperationID { get; set; }

        /// <summary>
        /// Creates an object containing state based tool methods.
        /// </summary>
        /// <param name="session">The application session.</param>
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
        
        /// <summary>
        /// Creates an operation ID for a new operation.
        /// </summary>
        /// <returns>The ID for the new operation.</returns>
        public int CreateNewOperationID()
        {
            return NextOperationID++;
        }
    }
}
