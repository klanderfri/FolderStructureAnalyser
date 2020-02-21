using System;
using System.ComponentModel;
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

            //Add the log message.
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
        private void addLogMessage(LogMessageType type, string message)
        {
            var log = new LogMessage()
            {
                ID = NextLogID++,
                Timestamp = DateTime.Now,
                Type = type,
                Message = message
            };
            LogMessages.Add(log);
        }
    }
}
