using System;
using System.Windows.Forms;
using FolderStructureAnalyser.Components;
using FolderStructureAnalyser.Helpers;
using FolderStructureAnalyser.SessionBound;

namespace FolderStructureAnalyser
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            try
            {
                //Run application.
                var form = new DiskAnalyserForm();
                var session = new Session(form);
                form.SetSession(session);
                Application.Run(form);
            }
            catch (Exception ex)
            {
                MessageBoxes.ShowUnhandledApplicationErrorMessage(ex);
            }
        }
    }
}
