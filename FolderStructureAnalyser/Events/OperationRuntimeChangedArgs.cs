using System;

namespace FolderStructureAnalyser.Events
{
    /// <summary>
    /// Class for object holding the arguments for the event used when the runtime of an operation has been updated.
    /// </summary>
    public class OperationRuntimeChangedArgs : OperationEventArgs
    {
        /// <summary>
        /// The current runtime of the operation.
        /// </summary>
        public long RuntimeInMilliseconds { get; private set; }

        /// <summary>
        /// Creates an object holding the arguments for the event used when the runtime of an operation has been updated.
        /// </summary>
        /// <param name="operationID">The ID for the operation.</param>
        /// <param name="operationTypeDescription">A short description of the type of the operation.</param>
        /// <param name="runtimeInMilliseconds">The current runtime of the operation.</param>
        public OperationRuntimeChangedArgs(int operationID, string operationTypeDescription, long runtimeInMilliseconds)
            : base(operationID, operationTypeDescription)
        {
            RuntimeInMilliseconds = runtimeInMilliseconds;
        }
    }
}
