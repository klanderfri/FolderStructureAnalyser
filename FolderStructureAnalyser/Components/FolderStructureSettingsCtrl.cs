using System.Collections.Generic;
using System.Windows.Forms;
using FolderStructureAnalyser.Enums;
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
            setupSizeUnitCombobox();
        }

        /// <summary>
        /// Sets up the combobox selecting how sizes should be shown.
        /// </summary>
        private void setupSizeUnitCombobox()
        {
            var items = new List<SizeDisplayUnit>()
            {
                SizeDisplayUnit.Dynamic,
                SizeDisplayUnit.OnlyMB,
                SizeDisplayUnit.OnlyBytes
            };
            repositoryItemComboBoxSizeDisplayUnit.Items.AddRange(items);
        }
    }
}
