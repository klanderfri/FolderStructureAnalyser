using System;
using System.ComponentModel;
using FolderStructureAnalyser.Enums;
using FolderStructureAnalyser.Events;
using FolderStructureAnalyser.Exceptions;

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
        /// <param name="e">The args for the event that caused the log message to be added.</param>
        public void AddLogMessage(LogMessageType type, EventArgs e = null)
        {
            var args = new LogMessageAddedArgs(type, e);
            LogMessageAdded?.Invoke(this, args);
        }

        /// <summary>
        /// Gets the message format for a log message type.
        /// </summary>
        /// <param name="type">The type of log message to get the message format for.</param>
        /// <returns>The message format.</returns>
        public static string GetMessageFormatFromType(LogMessageType type)
        {
            switch (type)
            {
                case LogMessageType.OperationStarting:
                    return "A new {0} was started.";
                case LogMessageType.OperationRuntimeUpdate:
                    return "Current {0} runtime: {1} seconds.";
                case LogMessageType.OperationFinished:
                    return "The {0} was finished.";
                default:
                    throw new UnhandledEnumException(typeof(LogMessageType), type);
            }
        }
    }
}
