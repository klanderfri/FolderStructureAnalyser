using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Xml.Serialization;
using FolderStructureAnalyser.Enums;

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
        /// Checks if a disk item is an existing file.
        /// </summary>
        /// <param name="diskItem">The disk item to test.</param>
        /// <returns>TRUE if the disk item is an existing file, else FALSE.</returns>
        public static bool IsExistingFile(FileSystemInfo diskItem)
        {
            return diskItem.Exists && !(diskItem is DirectoryInfo);
        }

        /// <summary>
        /// Checks if a disk item is an existing folder.
        /// </summary>
        /// <param name="diskItem">The disk item to test.</param>
        /// <returns>TRUE if the disk item is an existing folder, else FALSE.</returns>
        public static bool IsExistingFolder(FileSystemInfo diskItem)
        {
            return diskItem.Exists && diskItem is DirectoryInfo;
        }

        /// <summary>
        /// Shows, in the Windows Explorer, the disk item, markerd in the folder containing it.
        /// </summary>
        /// <param name="diskItem">The disk item to show.</param>
        /// <param name="folderBehaviour">Tells how a folder should behave when opened.</param>
        public static void InvokeExplorer(FileSystemInfo diskItem, OpenFolderBehaviour folderBehaviour)
        {
            if (!diskItem.Exists)
            {
                MessageBoxes.ShowDiskItemDoesNotExistMessage(diskItem);
                return;
            }

            try
            {
                if (folderBehaviour == OpenFolderBehaviour.OpenItself
                    && diskItem is DirectoryInfo)
                {
                    //Open the folder itself.
                    Process.Start(diskItem.FullName);
                }
                else
                {
                    //Open the parent folder and mark the disk item in it.
                    var format = "/select, \"{0}\"";
                    var args = String.Format(format, diskItem.FullName);
                    Process.Start("explorer.exe", args);
                }
            }
            catch (Exception ex)
            {
                MessageBoxes.ShowProblemOpeningDiskItemMessage(diskItem, ex, folderBehaviour);
            }
        }

        /// <summary>
        /// Gets the information about the parent folder.
        /// </summary>
        /// <param name="fullPath">The full path to the disk item of whom we are to get the parent folder.</param>
        /// <returns>The information about the parent folder.</returns>
        public static DirectoryInfo GetParentFolder(string fullPath)
        {
            return (new FileInfo(fullPath)).Directory;
        }

        /// <summary>
        /// Gives the hash code for a file.
        /// </summary>
        /// <param name="fullFilePath">The full path to the file to get the hash code for.</param>
        /// <returns>The hash code of the file.</returns>
        public static byte[] GetHash(string fullFilePath)
        {
            using (var md5 = MD5.Create())
            {
                using (var stream = File.OpenRead(fullFilePath))
                {
                    return md5.ComputeHash(stream);
                }
            }
        }

        /// <summary>
        /// Gives the hash string for a file.
        /// </summary>
        /// <param name="fullFilePath">The full path to the file to get the hash string for.</param>
        /// <returns>The hash string of the file.</returns>
        public static string GetHashString(string fullFilePath)
        {
            //Get the hash code.
            var hash = GetHash(fullFilePath);

            //Convert the hash code to a string.
            var checksum = new StringBuilder("Byte [");
            foreach (var part in hash)
            {
                var format = "{0}, ";
                checksum.AppendFormat(format, part);
            }

            //Remove the last comma and whitespace.
            if (hash.Length > 0)
            {
                checksum.Remove(checksum.Length - 2, 2);
            }

            //Add character marking the end of the hash string.
            checksum.Append("]");

            return checksum.ToString();
        }

        /// <summary>
        /// Tells if two files has identical hashes.
        /// </summary>
        /// <param name="firstFilePath">The full path to the first file.</param>
        /// <param name="secondFilePath">The full path to the second file.</param>
        /// <returns>TRUE if the hashes are identical, else FALSE.</returns>
        public static bool HasIdenticalHashes(string firstFilePath, string secondFilePath)
        {
            var firstHash = GetHash(firstFilePath);
            var secondHash = GetHash(secondFilePath);

            return firstHash.SequenceEqual(secondHash);
        }

        /// <summary>
        /// Stores an object as a XML file on disk.
        /// </summary>
        /// <typeparam name="T">The type of the object.</typeparam>
        /// <param name="objectToStore">The object to store on disk.</param>
        /// <param name="xmlFileName">The name of the file to store the object in.</param>
        public static void SaveObjectAsXML<T>(object objectToStore, string xmlFileName)
        {
            var serializer = new XmlSerializer(typeof(T));
            using (var writer = new StreamWriter(xmlFileName))
            {
                serializer.Serialize(writer, objectToStore);
            }
        }

        /// <summary>
        /// Loads an object from a XML file on disk.
        /// </summary>
        /// <typeparam name="T">The type of the object.</typeparam>
        /// <param name="xmlFileName">The name of the file to fetch the object from.</param>
        /// <returns>The object loaded from disk.</returns>
        public static T LoadObjectFromXML<T>(string xmlFileName)
        {
            if (!File.Exists(xmlFileName)) { return default(T); }

            var serializer = new XmlSerializer(typeof(T));
            using (var reader = new StreamReader(xmlFileName))
            {
                return (T)serializer.Deserialize(reader);
            }
        }
    }
}
