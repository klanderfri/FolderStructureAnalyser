using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using FolderStructureAnalyser.gui;
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
            form.SessionSet(new Session());
            Application.Run(form);
        }
    }
}
