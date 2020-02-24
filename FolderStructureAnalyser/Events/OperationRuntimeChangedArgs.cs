﻿using System;

namespace FolderStructureAnalyser.Events
{
    /// <summary>
    /// Class for object holding the arguments for the event used when the runtime of an operation has been updated.
    /// </summary>
    public class OperationRuntimeChangedArgs : EventArgs
    {
        /// <summary>
        /// The current runtime of the operation.
        /// </summary>
        public long RuntimeInMilliseconds { get; private set; }

        /// <summary>
        /// Creates an object holding the arguments for the event used when the runtime of an operation has been updated.
        /// </summary>
        /// <param name="runtimeInMilliseconds">The current runtime of the operation.</param>
        public OperationRuntimeChangedArgs(long runtimeInMilliseconds)
        {
            RuntimeInMilliseconds = runtimeInMilliseconds;
        }
    }
}
