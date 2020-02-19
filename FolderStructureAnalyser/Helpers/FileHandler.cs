using System;
using System.Collections.Generic;
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
        /// Gets the information of a file.
        /// </summary>
        /// <param name="parentFolderPath">The full path to the parent folder of the file.</param>
        /// <param name="fileName">The name of the file.</param>
        /// <returns>An object holding the information about the file.</returns>
        public static FileInfo GetFileInfo(string parentFolderPath, string fileName)
        {
            return getDiskItemInfo<FileInfo>(parentFolderPath, fileName);
        }

        /// <summary>
        /// Gets the information of a folder.
        /// </summary>
        /// <param name="parentFolderPath">The full path to the parent folder of the folder.</param>
        /// <param name="folderName">The name of the folder.</param>
        /// <returns>An object holding the information about the folder.</returns>
        public static DirectoryInfo GetFolderInfo(string parentFolderPath, string folderName)
        {
            return getDiskItemInfo<DirectoryInfo>(parentFolderPath, folderName);
        }

        /// <summary>
        /// Gets the information of a disk item.
        /// </summary>
        /// <typeparam name="T">The type of information to get.</typeparam>
        /// <param name="parentFolderPath">The full path to the parent folder of the disk item.</param>
        /// <param name="folderName">The name of the disk item.</param>
        /// <returns>An object holding the information about the disk item.</returns>
        private static T getDiskItemInfo<T>(string parentFolderPath, string itemName)
        {
            return (T)Activator.CreateInstance(typeof(T), Path.Combine(parentFolderPath, itemName));
        }

        /// <summary>
        /// Gives a list of the files within a folder.
        /// </summary>
        /// <param name="folderPath">The full path to the folder containing the files.</param>
        /// <returns>A dictionary containing the file names and the files themselves.</returns>
        public static List<FileInfo> GetFiles(string folderPath)
        {
            Func<DirectoryInfo, IEnumerable<FileSystemInfo>> getSubItems = delegate (DirectoryInfo folder) { return folder.GetFiles(); };
            return getDiskItemList<FileInfo>(folderPath, getSubItems);
        }

        /// <summary>
        /// Gives a list of the subfolders within a folder.
        /// </summary>
        /// <param name="folderPath">The full path to the folder containing the subfolders.</param>
        /// <returns>A dictionary containing the folder names and the folders themselves.</returns>
        public static List<DirectoryInfo> GetSubfolders(string folderPath)
        {
            Func<DirectoryInfo, IEnumerable<FileSystemInfo>> getSubItems = delegate (DirectoryInfo folder) { return folder.GetDirectories(); };
            return getDiskItemList<DirectoryInfo>(folderPath, getSubItems);
        }

        /// <summary>
        /// Gives an index of the subitems within a folder.
        /// </summary>
        /// <typeparam name="T">The type of item info to return.</typeparam>
        /// <param name="folderPath">The full path to the folder containing the subitems.</param>
        /// <param name="getSubItems">A method fetching the subitems from the folder.</param>
        /// <returns>A dictionary containing the subitem names and the subitems themselves.</returns>
        private static List<T> getDiskItemList<T>(string folderPath, Func<DirectoryInfo, IEnumerable<FileSystemInfo>> getSubItems) where T : FileSystemInfo
        {
            var folder = new DirectoryInfo(folderPath);
            var subItems = new List<T>();

            try
            {
                foreach (var subItem in getSubItems(folder))
                {
                    if ((subItem as T) == null)
                    {
                        //Crash now instead of later.
                        throw new NullReferenceException("The subitem cannot be null");
                    }

                    subItems.Add(subItem as T);
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
                catch (Exception ex)
                {
                    MessageBoxes.ShowProblemOpeningFolderMessage(folder, ex);
                }
            }
            else
            {
                MessageBoxes.ShowFolderDoesNotExistMessage();
            }
        }

        /// <summary>
        /// Gets the information about the parent folder.
        /// </summary>
        /// <param name="fullPath">The full path to the item of whom we are to get the parent folder.</param>
        /// <returns>The information about the parent folder.</returns>
        public static DirectoryInfo GetParentFolder(string fullPath)
        {
            return (new FileInfo(fullPath)).Directory;
        }
    }
}
