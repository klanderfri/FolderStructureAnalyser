using System.Windows.Forms;
using FolderStructureAnalyser.SessionBound;

namespace FolderStructureAnalyser.Components
{
    public partial class FolderStructureAnalyserCtrl : UserControl, ISessionBound
    {
        public Session Session { get; set; }

        public FolderStructureAnalyserCtrl()
        {
            InitializeComponent();
        }

        public virtual void SessionSet(Session session)
        {
            Session = session;
        }

        /// <summary>
        /// Lets the user select a folder.
        /// </summary>
        /// <param name="title">The title of the folder dialog.</param>
        /// <param name="description">The description within the folder dialog.</param>
        /// <returns>The full path to the selected folder, NULL if the user cancelled.</returns>
        public string ShowSelectFolderDialog(string title, string description)
        {
            xtraFolderBrowserDialogSelectFolder.Title = title;
            xtraFolderBrowserDialogSelectFolder.Description = description;

            var result = xtraFolderBrowserDialogSelectFolder.ShowDialog();

            return (result == DialogResult.OK) ? xtraFolderBrowserDialogSelectFolder.SelectedPath : null;
        }
    }
}
