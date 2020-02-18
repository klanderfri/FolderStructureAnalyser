using System;
using System.Windows.Forms;
using FolderStructureAnalyser.Components;
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

            //Run application.
            var form = new DiskAnalyserForm();
            form.SetSession(new Session());
            Application.Run(form);
        }
    }
}
