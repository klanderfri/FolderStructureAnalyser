using System;
using FolderStructureAnalyser.Enums;
using FolderStructureAnalyser.Exceptions;

namespace FolderStructureAnalyser.Events
{
    /// <summary>
    /// Class for object holding the arguments for the event used when a control has requested a log message to be added.
    /// </summary>
    public class LogMessageAddedArgs : EventArgs
    {
        /// <summary>
        /// The type of log message.
        /// </summary>
        public LogMessageType Type { get; private set; }

        /// <summary>
        /// The args for the event that caused the log message to be added.
        /// </summary>
        public EventArgs OriginalEventArgs { get; private set; }
        
        /// <summary>
        /// The message format to use when creating a log message.
        /// </summary>
        public string MessageFormat { get; set; }

        /// <summary>
        /// Creates an object holding the arguments for the event used when a control has requested a log message to be added.
        /// </summary>
        /// <param name="type">The type of log message.</param>
        /// <param name="e">The args for the event that caused the log message to be added.</param>
        public LogMessageAddedArgs(LogMessageType type, EventArgs e = null)
        {
            //Store message log information.
            Type = type;
            OriginalEventArgs = e;
            MessageFormat = getMessageFormat(type);
        }

        /// <summary>
        /// Gets the message format for a log type.
        /// </summary>
        /// <param name="type">The message log type to get the message format for.</param>
        /// <returns>The message format for the log type.</returns>
        private static string getMessageFormat(LogMessageType type)
        {
            switch (type)
            {
                case LogMessageType.OperationStarting:
                    return "A new {0} was started.";
                case LogMessageType.OperationRuntimeUpdate:
                    return "Current {0} runtime: {1} seconds.";
                case LogMessageType.OperationFinished:
                    return "The {0} was finished.";
                case LogMessageType.SettingChanged:
                    return "The application settings were changed.";
                default:
                    throw new UnhandledEnumException(typeof(LogMessageType), type);
            }
        }
    }
}
