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
        /// Event raised when the runtime of an operation has been updated.
        /// </summary>
        [Category("Messages")]
        [Description("Occurs when the runtime of an operation has been updated.")]
        public event OperationRuntimeChangedHandler OperationRuntimeChanged;

        /// <summary>
        /// Event raised when a log message has been added to the log.
        /// </summary>
        [Category("Messages")]
        [Description("Occurs when a log message has been added to the log.")]
        public event LogMessageAddedHandler LogMessageAdded;

        /// <summary>
        /// Event raised when a new operation is about to start.
        /// </summary>
        [Category("Messages")]
        [Description("Occurs when a new operation is about to start.")]
        public event NewOperationStartingHandler NewOperationStarting;

        /// <summary>
        /// Eventhandler for the event used when the runtime of an operation has been updated.
        /// </summary>
        /// <param name="sender">The mediator mediating the event.</param>
        /// <param name="e">The arguments for the event.</param>
        public delegate void OperationRuntimeChangedHandler(object sender, OperationRuntimeChangedArgs e);

        /// <summary>
        /// Eventhandler for the event used when a log message has been added to the log.
        /// </summary>
        /// <param name="sender">The mediator mediating the event.</param>
        /// <param name="e">The arguments for the event.</param>
        public delegate void LogMessageAddedHandler(object sender, LogMessageAddedArgs e);

        /// <summary>
        /// Eventhandler for the event used when a new operation is about to start.
        /// </summary>
        /// <param name="sender">The mediator mediating the event.</param>
        /// <param name="e">The arguments for the event.</param>
        public delegate void NewOperationStartingHandler(object sender, NewOperationStartingArgs e);

        /// <summary>
        /// Updates the information about how long the current operation has run.
        /// </summary>
        /// <param name="runtimeInMilliseconds">The amount of milliseconds the current operation has run.</param>
        public void UpdateOperationRuntime(long runtimeInMilliseconds)
        {
            var args = new OperationRuntimeChangedArgs(runtimeInMilliseconds);
            OperationRuntimeChanged?.Invoke(this, args);
        }

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
        /// <returns>The ID of the operation about to start.</returns>
        public int StartingNewOperation()
        {
            var operationID = NextOperationID++;
            var args = new NewOperationStartingArgs(operationID);
            NewOperationStarting?.Invoke(this, args);
            return operationID;
        }
    }
}
