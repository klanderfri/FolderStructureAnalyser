using System;
using System.IO;
using System.Windows.Forms;

namespace FolderStructureAnalyser.Helpers
{
    /// <summary>
    /// Class for handling user message dialogs.
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

        public static void ShowProblemOpeningFolderMessage(DirectoryInfo folder, Exception ex)
        {
            var format = "Problem opening folder {1}.{0}Path: {2}{0}Error: {3}";
            var message = String.Format(format, Environment.NewLine, folder.Name, folder.FullName, ex.Message);
            MessageBox.Show(message, "Problem opening folder.", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static void ShowFolderNoLongerExistMessage()
        {
            var message = "The folder does no longer exist.";
            MessageBox.Show(message, "Non-existing folder", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
