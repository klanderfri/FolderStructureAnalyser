using System.Windows.Forms;
using FolderStructureAnalyser.Enums;
using FolderStructureAnalyser.SessionBound;

namespace FolderStructureAnalyser.Components.UserPanels
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
            repositoryItemImageComboBoxSizeDisplayUnit.Items.AddEnum(typeof(SizeDisplayUnit));
        }

        private void propertyGridControlAnalysingSettings_CellValueChanged(object sender, DevExpress.XtraVerticalGrid.Events.CellValueChangedEventArgs e)
        {
            Session.MessageLog.AddLogMessage(LogMessageType.SettingChanged);
        }
    }
}
