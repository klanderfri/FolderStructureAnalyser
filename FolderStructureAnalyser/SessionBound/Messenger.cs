using System.ComponentModel;
using FolderStructureAnalyser.Enums;
using FolderStructureAnalyser.Events;

namespace FolderStructureAnalyser.SessionBound
{
    /// <summary>
    /// Class for object handling messages between components within the application.
    /// </summary>
    public class Messenger : SessionBoundClass
    {
        public Messenger(Session session)
            : base(session) { }

        /// <summary>
        /// Event raised when the runtime of an operation has been updated.
        /// </summary>
        [Category("Messages")]
        [Description("Occurs when the runtime of an operation has been updated.")]
        public event OperationRuntimeChangedHandler OperationRuntimeChanged;

        /// <summary>
        /// Event raised when a control has requested a log message to be added.
        /// </summary>
        [Category("Messages")]
        [Description("Occurs when a request to add a log message has been done.")]
        public event AddLogMessageRequestedHandler AddLogMessageRequested;

        /// <summary>
        /// Eventhandler for the event used when the runtime of an operation has been updated.
        /// </summary>
        /// <param name="sender">The mediator mediating the event.</param>
        /// <param name="e">The arguments for the event.</param>
        public delegate void OperationRuntimeChangedHandler(object sender, OperationRuntimeChangedArgs e);

        /// <summary>
        /// Eventhandler for the event used when a control has requested a log message to be added.
        /// </summary>
        /// <param name="sender">The mediator mediating the event.</param>
        /// <param name="e">The arguments for the event.</param>
        public delegate void AddLogMessageRequestedHandler(object sender, AddLogMessageRequestedArgs e);
        
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
            var args = new AddLogMessageRequestedArgs(message, LogMessageType.Miscellaneous);
            AddLogMessageRequested?.Invoke(this, args);
        }
    }
}
