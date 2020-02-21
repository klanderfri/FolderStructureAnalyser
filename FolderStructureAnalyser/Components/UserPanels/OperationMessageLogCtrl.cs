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

            //Update the label.
            var format = "Last operation time: {0} sec";
            var message = String.Format(format, runtimeInSeconds);
            labelLastOperationTime.Text = message;
        }

        /// <summary>
        /// Adds a log message to the control.
        /// </summary>
        /// <param name="message">The human readable log message.</param>
        public void AddLogMessage(string message)
        {
            var log = new LogMessage()
            {
                Timestamp = DateTime.Now,
                Type = LogMessageType.Miscellaneous,
                Message = message
            };
            LogMessages.Add(log);
        }
    }
}
