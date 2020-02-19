using System;
using System.IO;
using System.Windows.Forms;

namespace FolderStructureAnalyser.Helpers
{
    /// <summary>
    /// Class holding dialogs with messages for the user.
    /// </summary>
    public static class MessageBoxes
    {
        public static void ShowAnalyseInProgressMessage()
        {
            var message = "An analysis is already in progress. Please wait for it to finish!";
            MessageBox.Show(message, "Analysis in progress...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public static void ShowDirectoryDoesNotExistMessage(string folderPath)
        {
            var folderName = new DirectoryInfo(folderPath).Name;
            var format = "The folder '{1}' does not exist.{0}Path: {2}";
            var message = String.Format(format, Environment.NewLine, folderName, folderPath);
            MessageBox.Show(message, "Folder does not exist", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static void ShowSameFolderSelectedForCompareMessage()
        {
            var message = "You have selected the same folder as both original and clone. Select different folders!";
            MessageBox.Show(message, "Same folder selected twice", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
