using System;
using System.Drawing;
using System.Windows.Forms;
using FolderStructureAnalyser.SessionBound;

namespace FolderStructureAnalyser.Components
{
    public partial class FolderStructureAnalyserCtrl : UserControl, ISessionBound
    {
        public Session Session { get; set; }

        /// <summary>
        /// Keeps the last known position of the parent of the control.
        /// </summary>
        private Point LastKnownParentPosition { get; set; }

        /// <summary>
        /// Keeps the last known size of the control.
        /// </summary>
        private Size LastKnownSize { get; set; }

        public FolderStructureAnalyserCtrl()
        {
            InitializeComponent();
        }

        public virtual void SessionSet(Session session)
        {
            Session = session;
            LastKnownParentPosition = ParentForm.Location;
            LastKnownSize = Size;
            ParentForm.Move += ParentForm_Move;
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

        /// <summary>
        /// Shows a wait form.
        /// </summary>
        /// <param name="description">The desription to show in the wait form.</param>
        public void ShowWaitForm(string description)
        {
            splashScreenManagerWaitForm.ShowWaitForm();
            splashScreenManagerWaitForm.SetWaitFormDescription(description);
        }

        /// <summary>
        /// Closes the wait form shown.
        /// </summary>
        public void CloseWaitForm()
        {
            splashScreenManagerWaitForm.CloseWaitForm();
        }

        private void ParentForm_Move(object sender, EventArgs e)
        {
            if (splashScreenManagerWaitForm.IsSplashFormVisible)
            {
                //Find out how the wait form should be moved.
                int diffX = ParentForm.Location.X - LastKnownParentPosition.X;
                int diffY = ParentForm.Location.Y - LastKnownParentPosition.Y;
                var vector = new int[] { diffX, diffY };

                //Move the waitform.
                splashScreenManagerWaitForm.SendCommand(WaitFormCommand.Move, vector);
            }

            //Update the known parent position.
            LastKnownParentPosition = ParentForm.Location;
        }

        private void FolderStructureAnalyserCtrl_Resize(object sender, EventArgs e)
        {
            if (splashScreenManagerWaitForm.IsSplashFormVisible)
            {
                //Find out how the wait form should be moved.
                int diffX = (Size.Width - LastKnownSize.Width) / 2;
                int diffY = (Size.Height - LastKnownSize.Height) / 2;
                var vector = new int[] { diffX, diffY };

                //Move the waitform.
                splashScreenManagerWaitForm.SendCommand(WaitFormCommand.Move, vector);
            }

            //Update the known size.
            LastKnownSize = Size;
        }
    }
}
