using System;
using System.ComponentModel;
using FolderStructureAnalyser.Enums;
using FolderStructureAnalyser.Events;

namespace FolderStructureAnalyser.SessionBound
{
    /// <summary>
    /// Class for object handling a message log in the application.
    /// </summary>
    public class MessageLog : SessionBoundClass
    {
        /// <summary>
        /// Holds the ID for the next operation to be started.
        /// </summary>
        private int NextOperationID { get; set; }

        /// <summary>
        /// Creates an object handling a message log in the application.
        /// </summary>
        /// <param name="session">The application session.</param>
        public MessageLog(Session session)
            : base(session) { }

        /// <summary>
        /// Creates an operation ID for a new operation.
        /// </summary>
        /// <returns>The ID for the new operation.</returns>
        public int CreateNewOperationID()
        {
            return NextOperationID++;
        }

        /// <summary>
        /// Event raised when a log message has been added to the log.
        /// </summary>
        [Category("Messages")]
        [Description("Occurs when a log message has been added to the log.")]
        public event LogMessageAddedHandler LogMessageAdded;

        /// <summary>
        /// Event raised when an operation is about to start.
        /// </summary>
        [Category("Messages")]
        [Description("Occurs when an operation is about to start.")]
        public event NewOperationStartingHandler NewOperationStarting;

        /// <summary>
        /// Event raised when the runtime of an operation has been updated.
        /// </summary>
        [Category("Messages")]
        [Description("Occurs when the runtime of an operation has been updated.")]
        public event OperationRuntimeChangedHandler OperationRuntimeChanged;

        /// <summary>
        /// Event raised when an operation has finished.
        /// </summary>
        [Category("Messages")]
        [Description("Occurs when an operation has finished.")]
        public event OperationFinishedHandler OperationFinished;

        /// <summary>
        /// Eventhandler for the event used when a log message has been added to the log.
        /// </summary>
        /// <param name="sender">The mediator mediating the event.</param>
        /// <param name="e">The arguments for the event.</param>
        public delegate void LogMessageAddedHandler(object sender, LogMessageAddedArgs e);

        /// <summary>
        /// Eventhandler for the event used when an operation is about to start.
        /// </summary>
        /// <param name="sender">The mediator mediating the event.</param>
        /// <param name="e">The arguments for the event.</param>
        public delegate void NewOperationStartingHandler(object sender, OperationStartingArgs e);

        /// <summary>
        /// Eventhandler for the event used when the runtime of an operation has been updated.
        /// </summary>
        /// <param name="sender">The mediator mediating the event.</param>
        /// <param name="e">The arguments for the event.</param>
        public delegate void OperationRuntimeChangedHandler(object sender, OperationRuntimeChangedArgs e);

        /// <summary>
        /// Eventhandler for the event used when an operation has finished.
        /// </summary>
        /// <param name="sender">The mediator mediating the event.</param>
        /// <param name="e">The arguments for the event.</param>
        public delegate void OperationFinishedHandler(object sender, OperationFinishedArgs e);

        /// <summary>
        /// Adds a log message to the log.
        /// </summary>
        /// <param name="message">The human readable log message.</param>
        public void AddLogMessage(string message)
        {
            var args = new LogMessageAddedArgs(message, LogMessageType.Miscellaneous);
            LogMessageAdded?.Invoke(this, args);
        }

        /// <summary>
        /// Informs the log that a new operation is about to start.
        /// </summary>
        /// <param name="operationID">The ID for the operation.</param>
        public void StartingNewOperation(int operationID)
        {
            var args = new OperationStartingArgs(operationID);
            NewOperationStarting?.Invoke(this, args);
        }

        /// <summary>
        /// Updates the information about how long the current operation has run.
        /// </summary>
        /// <param name="operationID">The ID for the operation.</param>
        /// <param name="runtimeInMilliseconds">The amount of milliseconds the current operation has run.</param>
        public void UpdateOperationRuntime(int operationID, long runtimeInMilliseconds)
        {
            var args = new OperationRuntimeChangedArgs(operationID, runtimeInMilliseconds);
            OperationRuntimeChanged?.Invoke(this, args);
        }

        /// <summary>
        /// Informs the log that an operation has finished.
        /// </summary>
        /// <param name="operationID">The ID for the operation.</param>
        /// <param name="cancelled">Tells if the operation was cancelled.</param>
        /// <param name="result">The result from the operation.</param>
        public void OperationHasFinished(int operationID, bool cancelled, object result)
        {
            var args = new OperationFinishedArgs(operationID, cancelled, result);
            OperationFinished?.Invoke(this, args);
        }
    }
}
