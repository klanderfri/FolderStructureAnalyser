using System.Windows.Forms;
using DevExpress.XtraEditors;
using FolderStructureAnalyser.Enums;
using FolderStructureAnalyser.Events;
using FolderStructureAnalyser.SessionBound;

namespace FolderStructureAnalyser.Components.Support
{
    public partial class AnalyserUserControl : XtraUserControl, ISessionBound
    {
        /// <summary>
        /// The application session.
        /// </summary>
        public Session Session { get; set; }

        /// <summary>
        /// The collection of icons to use in components.
        /// </summary>
        public AppSvgIcons IconCollection { get; private set; }

        public AnalyserUserControl()
        {
            InitializeComponent();
            IconCollection = new AppSvgIcons();
        }

        public virtual void SetSession(Session session)
        {
            Session = session;

            Session.MessageLog.LogMessageAdded += MessageLog_LogMessageAdded;
        }

        private void MessageLog_LogMessageAdded(object sender, LogMessageAddedArgs e)
        {
            if (e.Type == LogMessageType.SettingChanged)
            {
                foreach (var child in Controls)
                {
                    (child as Control).Refresh();
                }
            }
        }
    }
}
