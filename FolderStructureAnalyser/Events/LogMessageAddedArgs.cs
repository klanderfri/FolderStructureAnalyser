using System;
using FolderStructureAnalyser.Enums;

namespace FolderStructureAnalyser.Events
{
    /// <summary>
    /// Class for object holding the arguments for the event used when a control has requested a log message to be added.
    /// </summary>
    public class LogMessageAddedArgs : EventArgs
    {
        /// <summary>
        /// The human readable log message.
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// The type of the log message.
        /// </summary>
        public LogMessageType Type;

        /// <summary>
        /// Creates an object holding the arguments for the event used when a control has requested a log message to be added.
        /// </summary>
        /// <param name="message">The human readable log message.</param>
        /// <param name="type">The type of the log message.</param>
        public LogMessageAddedArgs(string message, LogMessageType type)
        {
            Message = message;
            Type = type;
        }
    }
}
