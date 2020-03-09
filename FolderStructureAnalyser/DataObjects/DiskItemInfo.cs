﻿using System.IO;
using FolderStructureAnalyser.Helpers;

namespace FolderStructureAnalyser.DataObjects
{
    /// <summary>
    /// Class for object holding information about a disk item.
    /// </summary>
    public class DiskItemInfo
    {
        /// <summary>
        /// The name of the disk item.
        /// </summary>
        public string Name => Info.Name;

        /// <summary>
        /// Base information about the disk item.
        /// </summary>
        public FileSystemInfo Info { get; private set; }

        /// <summary>
        /// The string representing the MD5 checksum for the disk item.
        /// </summary>
        public string MD5 { get; private set; }

        /// <summary>
        /// Creates an object holding information about a disk item.
        /// </summary>
        /// <param name="diskItem">Base information about the disk item.</param>
        public DiskItemInfo(FileSystemInfo diskItem)
        {
            Info = diskItem;
            MD5 = getHashString(diskItem);
        }

        /// <summary>
        /// Gets the hash code for the disk item as a string.
        /// </summary>
        /// <param name="diskItem">The disk item to get the hash string for.</param>
        /// <returns>The hash string for the disk item, NULL if no such string can be fetched.</returns>
        private static string getHashString(FileSystemInfo diskItem)
        {
            if (!FileHandler.IsExistingFile(diskItem)) { return null; }
            return FileHandler.GetHashString(diskItem.FullName);
        }
    }
}
