namespace FolderStructureAnalyser.Events
{
    /// <summary>
    /// Class for object holding the arguments for the event used when an operation has finished.
    /// </summary>
    public class OperationFinishedArgs : OperationEventArgs
    {
        /// <summary>
        /// Tells if the operation was cancelled.
        /// </summary>
        public bool Cancelled { get; private set; }

        /// <summary>
        /// The result from the operation.
        /// </summary>
        public object Result { get; private set; }

        /// <summary>
        /// Creates an object holding the arguments for the event used when an operation has finished.
        /// </summary>
        /// <param name="operationID">The ID for the operation.</param>
        /// <param name="operationTypeDescription">A short description of the type of the operation.</param>
        /// <param name="cancelled">Tells if the operation was cancelled.</param>
        /// <param name="result">The result from the operation.</param>
        public OperationFinishedArgs(int operationID, string operationTypeDescription, bool cancelled, object result)
            : base(operationID, operationTypeDescription)
        {
            Cancelled = cancelled;
            Result = result;
        }
    }
}
