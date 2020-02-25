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
        /// Creates an object handling a message log in the application.
        /// </summary>
        /// <param name="session">The application session.</param>
        public MessageLog(Session session)
            : base(session) { }

        /// <summary>
        /// Event raised when a log message has been added to the log.
        /// </summary>
        [Category("Messages")]
        [Description("Occurs when a log message has been added to the log.")]
        public event LogMessageAddedHandler LogMessageAdded;

        /// <summary>
        /// Eventhandler for the event used when a log message has been added to the log.
        /// </summary>
        /// <param name="sender">The mediator mediating the event.</param>
        /// <param name="e">The arguments for the event.</param>
        public delegate void LogMessageAddedHandler(object sender, LogMessageAddedArgs e);

        /// <summary>
        /// Adds a log message to the log.
        /// </summary>
        /// <param name="type">The type of log message.</param>
        /// <param name="messageFormat">The format for the human readable log message.</param>
        /// <param name="e">The args for the event that caused the log message to be added.</param>
        public void AddLogMessage(LogMessageType type, string messageFormat, EventArgs e = null)
        {
            var args = new LogMessageAddedArgs(type, messageFormat, e);
            LogMessageAdded?.Invoke(this, args);
        }
    }
}
