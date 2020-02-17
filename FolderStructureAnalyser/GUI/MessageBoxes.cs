using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FolderStructureAnalyser.GUI
{
    public class MessageBoxes
    {
        public static void ShowAnalyseInProgressMessage()
        {
            var message = "An analyse is already in progress. Please wait for it to finish!";
            MessageBox.Show(message, "Analyse in progress...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
