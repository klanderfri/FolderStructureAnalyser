﻿using System;

namespace FolderStructureAnalyser.Events
{
    /// <summary>
    /// Class for object holding the arguments for the event used when an operation raised an update.
    /// </summary>
    public abstract class OperationEventArgs : EventArgs
    {
        /// <summary>
        /// The ID for the operation.
        /// </summary>
        public int OperationID { get; private set; }

        /// <summary>
        /// A short description of the type of the operation.
        /// </summary>
        public string OperationTypeDescription { get; private set; }

        /// <summary>
        /// Creates an object holding the arguments for an event used when an operation raised an update.
        /// </summary>
        /// <param name="operationID">The ID for the operation.</param>
        /// <param name="operationTypeDescription">A short description of the type of the operation.</param>
        public OperationEventArgs(int operationID, string operationTypeDescription)
        {
            OperationID = operationID;
            OperationTypeDescription = operationTypeDescription;
        }
    }
}
