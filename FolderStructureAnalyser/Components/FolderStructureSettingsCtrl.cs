using System.Windows.Forms;
using FolderStructureAnalyser.SessionBound;

namespace FolderStructureAnalyser.Components
{
    public partial class FolderStructureSettingsCtrl : UserControl, ISessionBound
    {
        public Session Session { get; set; }

        public FolderStructureSettingsCtrl()
        {
            InitializeComponent();
        }
        
        public void SetSession(Session session)
        {
            Session = session;
            propertyGridControlAnalysingSettings.SelectedObject = Session.Settings;
        }
    }
}
