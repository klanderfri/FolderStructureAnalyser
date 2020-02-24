using System.ComponentModel;
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
        /// Eventhandler for the event used when the runtime of an operation has been updated.
        /// </summary>
        /// <param name="sender">The mediator mediating the event.</param>
        /// <param name="e">The arguments for the event.</param>
        public delegate void OperationRuntimeChangedHandler(object sender, OperationRuntimeChangedArgs e);
        
        /// <summary>
        /// Updates the information about how long the current operation has run.
        /// </summary>
        /// <param name="runtimeInMilliseconds">The amount of milliseconds the current operation has run.</param>
        public void UpdateOperationRuntime(long runtimeInMilliseconds)
        {
            var args = new OperationRuntimeChangedArgs(runtimeInMilliseconds);
            OperationRuntimeChanged?.Invoke(this, args);
        }
    }
}
