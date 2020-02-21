using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FolderStructureAnalyser.SessionBound;

namespace FolderStructureAnalyser.Components
{
    public partial class OperationMessageLogCtrl : UserControl, ISessionBound
    {
        public Session Session { get; set; }

        public OperationMessageLogCtrl()
        {
            InitializeComponent();
        }

        public void SetSession(Session session)
        {
            Session = session;
        }

        /// <summary>
        /// Updates the information about how long the current operation has run.
        /// </summary>
        /// <param name="runtimeInSeconds">The amount of seconds the current operation has run.</param>
        public void UpdateOperationRuntime(long runtimeInSeconds)
        {
            var format = "Last operation time: {0} sec";
            var message = String.Format(format, runtimeInSeconds);
            labelLastOperationTime.Text = message;
        }
    }
}
