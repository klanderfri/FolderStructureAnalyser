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
        /// The format for the human readable log message.
        /// </summary>
        public string MessageFormat { get; private set; }

        /// <summary>
        /// The type of log message.
        /// </summary>
        public LogMessageType Type { get; private set; }

        /// <summary>
        /// The args for the event that caused the log message to be added.
        /// </summary>
        public EventArgs OriginalEventArgs { get; private set; }

        /// <summary>
        /// Creates an object holding the arguments for the event used when a control has requested a log message to be added.
        /// </summary>
        /// <param name="type">The type of log message.</param>
        /// <param name="messageFormat">The format for the human readable log message.</param>
        /// <param name="e">The args for the event that caused the log message to be added.</param>
        public LogMessageAddedArgs(LogMessageType type, string messageFormat, EventArgs e = null)
        {
            //Store message log information.
            Type = type;
            MessageFormat = messageFormat;
            OriginalEventArgs = e;
        }
    }
}
