using System;
using System.Globalization;
using System.Windows.Forms;
using DevExpress.XtraEditors;
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
            //By setting the default thread culture to English, the exceptions
            //raised will be in English and not in Swedish (or whatever
            //language the local computer has), making error researching
            //(aka googling) easier.
            CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("en-US");
            CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo("en-US");

            WindowsFormsSettings.ScrollUIMode = ScrollUIMode.Fluent;
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
