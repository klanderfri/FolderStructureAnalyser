using System.Collections.Generic;
using System.Windows.Forms;
using FolderStructureAnalyser.Enums;
using FolderStructureAnalyser.SessionBound;

namespace FolderStructureAnalyser.Components.Panels
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
    }
}
