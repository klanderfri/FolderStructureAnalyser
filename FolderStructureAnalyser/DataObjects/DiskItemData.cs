using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;

namespace FolderStructureAnalyser.DataObjects
{
    /// <summary>
    /// Class for object representing a disk item in a file-folder tree structure.
    /// </summary>
    public class DiskItemData
    {
        /// <summary>
        /// The name of the disk item.
        /// </summary>
        public string Name { get { return Info.Name; } }

        /// <summary>
        /// The information about the disk item.
        /// </summary>
        public FileSystemInfo Info { get; private set; }

        /// <summary>
        /// The byte size of the disk item and its content.
        /// </summary>
        public long SizeInBytes { get; private set; }

        /// <summary>
        /// Tells if the disk item is a folder.
        /// </summary>
        public bool IsFolder { get; private set; }

        /// <summary>
        /// The subitems within the disk item.
        /// </summary>
        public List<DiskItemData> SubItems { get; private set; } = new List<DiskItemData>();

        /// <summary>
        /// The paths to the subfolders that are not available for the application.
        /// </summary>
        private List<string> UnavailableFolders { get; set; } = new List<string>();

        /// <summary>
        /// Creates an object representing a disk item in a file-folder tree structure.
        /// </summary>
        /// <param name="worker">The background worker responsible for the disk item object creation.</param>
        /// <param name="diskItemPath">The physical path to the disk item.</param>
        public DiskItemData(BackgroundWorker worker, string diskItemPath)
        {
            if (Directory.Exists(diskItemPath))
            {
                Info = new DirectoryInfo(diskItemPath);
                IsFolder = true;
                
                findSubItems(worker);
            }
            else
            {
                Info = new FileInfo(diskItemPath);
                IsFolder = false;
            }

            SizeInBytes = calculateSize(worker);
        }

        /// <summary>
        /// Adds the subitems within the folder structure to the subitem list.
        /// </summary>
        /// <param name="worker">The background worker responsible for the disk item object creation.</param>
        private void findSubItems(BackgroundWorker worker)
        {
            //One should only look for subitems in folders, so consider the info as folder info.
            //I.E, we shouldn't be here unless the disk item is a folder.
            var info = Info as DirectoryInfo;

            //Get a collection of the disk item children.
            var children = new List<FileSystemInfo>();
            children.AddRange(info.GetDirectories());
            children.AddRange(info.GetFiles());

            //Find all subitems recursively.
            foreach (var child in children)
            {
                if (worker.CancellationPending) { return; }

                try
                {
                    //The recursion happens when the child is created.
                    SubItems.Add(new DiskItemData(worker, child.FullName));
                }
                catch (UnauthorizedAccessException)
                {
                    UnavailableFolders.Add(child.FullName);
                }
            }
        }

        /// <summary>
        /// Calculates the size of the disk item and its content.
        /// </summary>
        /// <param name="worker">The background worker responsible for the disk item object creation.</param>
        /// <returns>The size of the disk item and its content in bytes, -1 if the calculation was cancelled.</returns>
        private long calculateSize(BackgroundWorker worker)
        {
            //The bottom folders finish the creation first and therefore
            //have their size when the top folders continue their creation.

            if (IsFolder)
            {
                long sizeInBytes = 0;

                foreach (var child in SubItems)
                {
                    if (worker.CancellationPending) { return -1; }
                    sizeInBytes += child.SizeInBytes;
                }

                return sizeInBytes;
            }
            else
            {
                return (Info as FileInfo).Length;
            }
        }

        /// <summary>
        /// Finds all the unavailable subfolders withing the folder.
        /// </summary>
        /// <returns>The unavailable subfolders.</returns>
        public List<string> GetAllUnavailableFoldersInTree()
        {
            var unavailableFolders = new List<string>();
            unavailableFolders.AddRange(UnavailableFolders);

            foreach (var item in SubItems)
            {
                if (item.IsFolder)
                {
                    unavailableFolders.AddRange(item.GetAllUnavailableFoldersInTree());
                }
            }

            return unavailableFolders;
        }
    }
}
