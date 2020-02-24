namespace FolderStructureAnalyser.Events
{
    /// <summary>
    /// Class for object holding the arguments for the event used when an operation is about to start.
    /// </summary>
    public class OperationStartingArgs : OperationEventArgs
    {
        /// <summary>
        /// Creates an object holding the arguments for the event used when an operation is about to start.
        /// </summary>
        /// <param name="operationID">The ID for the operation.</param>
        public OperationStartingArgs(int operationID)
            : base(operationID) { }
    }
}
