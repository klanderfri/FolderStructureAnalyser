using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using FolderStructureAnalyser.DataObjects;
using FolderStructureAnalyser.Enums;
using FolderStructureAnalyser.SessionBound;

namespace FolderStructureAnalyser.Components.UserPanels
{
    public partial class OperationMessageLogCtrl : UserControl, ISessionBound
    {
        public Session Session { get; set; }

        /// <summary>
        /// The ID that will be assigned the next log message.
        /// </summary>
        private int NextLogID { get; set; }

        /// <summary>
        /// Gives the last log message in the grid.
        /// </summary>
        private LogMessage LastLog { get; set; }

        /// <summary>
        /// The data source holding the log messages to show in the grid.
        /// </summary>
        private BindingList<LogMessage> LogMessages { get; set; } = new BindingList<LogMessage>();

        public OperationMessageLogCtrl()
        {
            InitializeComponent();
        }

        public void SetSession(Session session)
        {
            Session = session;
            gridControlLogMessages.DataSource = LogMessages;
        }

        /// <summary>
        /// Updates the information about how long the current operation has run.
        /// </summary>
        /// <param name="runtimeInMilliseconds">The amount of milliseconds the current operation has run.</param>
        public void UpdateOperationRuntime(long runtimeInMilliseconds)
        {
            //Find the amount of seconds.
            var runtimeInSeconds = (long)Math.Floor((decimal)runtimeInMilliseconds / 1000);

            //Create message text..
            var format = "Last operation time: {0} sec";
            var message = String.Format(format, runtimeInSeconds);

            //Remove the previous time log of the operation.
            if (LastLog?.Type == LogMessageType.OperationTime)
            {
                removeLogMessage(LastLog.ID);
            }

            //Add the new operation time log.
            addLogMessage(LogMessageType.OperationTime, message);
        }

        /// <summary>
        /// Adds a log message to the control.
        /// </summary>
        /// <param name="message">The human readable log message.</param>
        public void AddLogMessage(string message)
        {
            addLogMessage(LogMessageType.Miscellaneous, message);
        }

        /// <summary>
        /// Adds a log message to the grid.
        /// </summary>
        /// <param name="type">The type of the log message.</param>
        /// <param name="message">The human readable log message.</param>
        /// <returns>The ID of the added log message.</returns>
        private int addLogMessage(LogMessageType type, string message)
        {
            //Create the log message.
            var log = new LogMessage()
            {
                ID = NextLogID++,
                Timestamp = DateTime.Now,
                Type = type,
                Message = message
            };
            
            //Add the log message to the grid.
            LogMessages.Add(log);
            LastLog = log;

            //Return the ID of the added log message.
            return log.ID;
        }

        /// <summary>
        /// Removes a log message from the grid.
        /// </summary>
        /// <param name="logID">The ID of the log message to remove.</param>
        /// <returns>TRUE if the log message was found and removed, else FALSE.</returns>
        private bool removeLogMessage(int logID)
        {
            //The log can not be in the grid if its ID hasn't been used yet.
            if (logID >= NextLogID) { return false; }

            //Try finding the old log.
            var oldLog = LogMessages.FirstOrDefault(l => l.ID == logID);

            //Check if the old log was found.
            if (oldLog == null) { return false; }

            //Remove the old log.
            LogMessages.Remove(oldLog);

            //Update the property holding the last log message.
            if (LastLog.ID == oldLog.ID)
            {
                LastLog = LogMessages.LastOrDefault();
            }

            //Return that the old log was found and removed.
            return true;
        }
    }
}
