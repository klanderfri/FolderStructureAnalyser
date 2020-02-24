using System;

namespace FolderStructureAnalyser.Events
{
    /// <summary>
    /// Class for object holding the arguments for the event used when a new operation is about to start.
    /// </summary>
    public class NewOperationStartingArgs : EventArgs
    {
        /// <summary>
        /// The ID for the operation.
        /// </summary>
        public int OperationID { get; private set; }

        /// <summary>
        /// Creates an object holding the arguments for the event used when a new operation is about to start.
        /// </summary>
        /// <param name="operationID">The ID for the operation.</param>
        public NewOperationStartingArgs(int operationID)
        {
            OperationID = operationID;
        }
    }
}
