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

        public static void ShowUnhandledApplicationErrorMessage(Exception ex)
        {
            var format = "An unhandled error occured:{0}Message: {1}{0}Source: {2}{0}Stack trace:{0}{3}";
            var message = String.Format(format, Environment.NewLine, ex.Message, ex.Source, ex.StackTrace);
            MessageBox.Show(message, "Unhandled error occured", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static void ShowSameFolderSelectedForCompareMessage()
        {
            var message = "You have selected the same folder as both original and clone. Select different folders!";
            MessageBox.Show(message, "Same folder selected twice", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public static void ShowProblemOpeningDiskItemMessage(FileSystemInfo file, Exception ex)
        {
            var type = (file is DirectoryInfo) ? "subfolder" : "file";
            var format = "Problem opening the folder containing the {4} {1}.{0}Path: {2}{0}Error: {3}";
            var message = String.Format(format, Environment.NewLine, file.Name, file.FullName, ex.Message, type);
            MessageBox.Show(message, "Problem opening folder containing file.", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static void ShowDiskItemDoesNotExistMessage(FileSystemInfo file)
        {
            var type = (file is DirectoryInfo) ? "folder" : "file";
            var messageformat = "The {0} does not exist.";
            var captionFormat = "Non-existing {0}";
            var message = String.Format(messageformat, type);
            var caption = String.Format(captionFormat, type);
            MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static void ShowNoStructureDifferencesFoundMessage()
        {
            var message = "There are no found differences between the two selected folder structures.";
            MessageBox.Show(message, "No differences found", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
