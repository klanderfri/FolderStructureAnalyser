using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;

namespace FolderStructureAnalyser.Helpers
{
    /// <summary>
    /// Class for handling files.
    /// </summary>
    public static class FileHandler
    {
        /// <summary>
        /// Gives an index of the files within a folder.
        /// </summary>
        /// <param name="folderPath">The full path to the folder containing the files.</param>
        /// <returns>A dictionary containing the file names and the files themselves.</returns>
        public static Dictionary<string, FileInfo> GetFileIndex(string folderPath)
        {
            Func<DirectoryInfo, IEnumerable<FileSystemInfo>> getSubItems = delegate (DirectoryInfo folder) { return folder.GetFiles(); };
            return getDiskItemIndex<FileInfo>(folderPath, getSubItems);
        }

        /// <summary>
        /// Gives an index of the subfolders within a folder.
        /// </summary>
        /// <param name="folderPath">The full path to the folder containing the subfolders.</param>
        /// <returns>A dictionary containing the folder names and the folders themselves.</returns>
        public static Dictionary<string, DirectoryInfo> GetDirectoryIndex(string folderPath)
        {
            Func<DirectoryInfo, IEnumerable<FileSystemInfo>> getSubItems = delegate (DirectoryInfo folder) { return folder.GetDirectories(); };
            return getDiskItemIndex<DirectoryInfo>(folderPath, getSubItems);
        }

        /// <summary>
        /// Gives an index of the subitems within a folder.
        /// </summary>
        /// <typeparam name="T">The type of item info to return.</typeparam>
        /// <param name="folderPath">The full path to the folder containing the subitems.</param>
        /// <param name="getSubItems">A method fetching the subitems from the folder.</param>
        /// <returns>A dictionary containing the subitem names and the subitems themselves.</returns>
        private static Dictionary<string, T> getDiskItemIndex<T>(string folderPath, Func<DirectoryInfo, IEnumerable<FileSystemInfo>> getSubItems) where T : FileSystemInfo
        {
            var folder = new DirectoryInfo(folderPath);
            var subItems = new Dictionary<string, T>();

            try
            {
                foreach (var subItem in getSubItems(folder))
                {
                    if ((subItem as T) == null)
                    {
                        //Crash now instead of later.
                        throw new NullReferenceException("The subitem cannot be null");
                    }

                    subItems.Add(subItem.Name, subItem as T);
                }
            }
            catch (UnauthorizedAccessException)
            {
                //Oops! Well, just skip disk items we don't have access to.
            }

            return subItems;
        }
        /// <summary>
        /// Opens a specific folder in the Windows Explorer.
        /// </summary>
        /// <param name="folderPath">The full path to the folder to open.</param>
        public static void OpenFolderInExplorer(string folderPath)
        {
            var folder = new DirectoryInfo(folderPath);
            OpenFolderInExplorer(folder);
        }

        /// <summary>
        /// Opens a specific folder in the Windows Explorer.
        /// </summary>
        /// <param name="folder">The folder to open.</param>
        public static void OpenFolderInExplorer(DirectoryInfo folder)
        {
            if (folder.Exists)
            {
                try
                {
                    Process.Start(folder.FullName);
                }
                catch (Win32Exception ex)
                {
                    MessageBoxes.ShowProblemOpeningFolderMessage(folder, ex);
                }
            }
            else
            {
                MessageBoxes.ShowFolderNoLongerExistMessage();
            }
        }
    }
}
