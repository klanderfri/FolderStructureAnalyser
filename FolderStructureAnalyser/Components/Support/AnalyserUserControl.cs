using System.Windows.Forms;
using DevExpress.Utils;
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
        public SvgImageCollection IconCollection { get { return svgImageCollectionIcons; } }

        public AnalyserUserControl()
        {
            InitializeComponent();
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
