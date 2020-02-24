namespace FolderStructureAnalyser.Events
{
    /// <summary>
    /// Class for object holding the arguments for the event used when a folder structure is about to be loaded.
    /// </summary>
    public class FolderStructureAnalysisStartingArgs : NewOperationStartingArgs
    {
        /// <summary>
        /// Creates an object holding the arguments for the event used when a folder structure is about to be loaded.
        /// </summary>
        /// <param name="operationID">The ID for the operation.</param>
        public FolderStructureAnalysisStartingArgs(int operationID)
            : base(operationID) { }
    }
}
