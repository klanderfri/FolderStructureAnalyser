﻿using System;
using FolderStructureAnalyser.Enums;

namespace FolderStructureAnalyser.DataObjects
{
    /// <summary>
    /// Class for object holding data about a log message.
    /// </summary>
    public class LogMessage
    {
        /// <summary>
        /// The unique identifier of the log message.
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// The time for the log message.
        /// </summary>
        public DateTime Timestamp { get; set; }

        /// <summary>
        /// The type of log message.
        /// </summary>
        public LogMessageType Type { get; set; }

        /// <summary>
        /// The actual (human readable) log message.
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// The args for the event that caused the log message to be added.
        /// </summary>
        public EventArgs EventArgs { get; set; }
    }
}
