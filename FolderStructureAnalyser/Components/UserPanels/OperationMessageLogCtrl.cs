﻿using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using FolderStructureAnalyser.DataObjects;
using FolderStructureAnalyser.Enums;
using FolderStructureAnalyser.Events;
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
            Session.MessageLog.LogMessageAdded += MessageLog_LogMessageAdded;
        }

        private void MessageLog_LogMessageAdded(object sender, LogMessageAddedArgs e)
        {
            addLogMessage(e);
        }

        /// <summary>
        /// Adds a log message to the grid.
        /// </summary>
        /// <param name="e">Information about the new log message to add.</param>
        private void addLogMessage(LogMessageAddedArgs e)
        {
            switch (e.Type)
            {
                case LogMessageType.OperationRuntimeUpdate:
                    //Update the last runtime log instead of adding a new each time the runtime changes.
                    updateOperationRuntime(e);
                    break;

                default:
                    //Just add the message to the grid.
                    addLogMessage(e, e.MessageFormat);
                    break;
            }
        }

        /// <summary>
        /// Adds a log message to the grid.
        /// </summary>
        /// <param name="e">Container holding the information about the log message to add.</param>
        /// <param name="message">The human readable log message.</param>
        private void addLogMessage(LogMessageAddedArgs e, string message)
        {
            //Create the log message.
            var log = new LogMessage()
            {
                ID = NextLogID++,
                Timestamp = DateTime.Now,
                Type = e.Type,
                Message = message,
                Data = e.Data
            };
            
            //Add the log message to the grid.
            LogMessages.Add(log);
            LastLog = log;
        }

        /// <summary>
        /// Updates the log message informing about the operation runtime.
        /// </summary>
        /// <param name="e">Container holding information about the new operation runtime.</param>
        private void updateOperationRuntime(LogMessageAddedArgs e)
        {
            //Create message text.
            var runtimeInMilliseconds = (e.Data as OperationRuntimeChangedArgs).RuntimeInMilliseconds;
            var runtimeInSeconds = (long)Math.Floor((decimal)runtimeInMilliseconds / 1000);
            var message = String.Format(e.MessageFormat, runtimeInSeconds);

            //Find the last operation time log for the operation.
            var lastOperationTimeLog = LogMessages.FirstOrDefault(m => gridLogNeedsUpdate(m, e));
            if (lastOperationTimeLog != null)
            {
                //Remove the previous time log of the operation.
                removeLogMessage(lastOperationTimeLog.ID);
            }

            //Add the new operation time log.
            addLogMessage(e, message);
        }

        /// <summary>
        /// Checks if a grid log needs updating due to a new message log.
        /// </summary>
        /// <param name="gridLog">The grid log to test.</param>
        /// <param name="receivedLogUpdate">The new message log recieved.</param>
        /// <returns>TRUE if the grid log needs update, else FALSE.</returns>
        private static bool gridLogNeedsUpdate(LogMessage gridLog, LogMessageAddedArgs receivedLogUpdate)
        {
            //If the grid log type differs then the new message log is about something else.
            if (gridLog.Type != receivedLogUpdate.Type) { return false; }

            //If the grid log operation differs then the new message log is about another operation.
            var operationToUpdate = (receivedLogUpdate.Data as OperationEventArgs).OperationID;
            var logOperation = (gridLog.Data as OperationEventArgs)?.OperationID;
            if (logOperation != operationToUpdate) { return false; }

            //The grid log is affected by the new message log.
            return true;
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
