using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using FolderStructureAnalyser.SessionBound;

namespace FolderStructureAnalyser.BuisnessObjects
{
    /// <summary>
    /// Class for object representing a folder in a file-folder tree structure.
    /// </summary>
    public class FolderData : SessionBoundClass
    {
        /// <summary>
        /// The information about the folder.
        /// </summary>
        public DirectoryInfo Info { get; private set; }

        /// <summary>
        /// The byte size of the folder and its content.
        /// </summary>
        public long SizeInBytes { get; private set; }

        /// <summary>
        /// The subfolders of the folder.
        /// </summary>
        public List<FolderData> SubFolders { get; private set; } = new List<FolderData>();

        /// <summary>
        /// The subfolders that are not available for the application.
        /// </summary>
        public List<string> UnavailableFolders { get; private set; } = new List<string>();

        /// <summary>
        /// Creates an object representing a folder in a file-folder tree structure.
        /// </summary>
        /// <param name="session">The application session.</param>
        /// <param name="worker">The background worker responsible for the folder object creation.</param>
        /// <param name="folderpath">The physical path to the folder.</param>
        public FolderData(Session session, BackgroundWorker worker, string folderpath)
        {
            SessionSet(session);

            Info = new DirectoryInfo(folderpath);
            
            fillSubfolders(worker);
            calculateSize(worker);
        }

        /// <summary>
        /// Adds the subfolder structure to the subfolder list.
        /// </summary>
        /// <param name="worker">The background worker responsible for the folder object creation.</param>
        private void fillSubfolders(BackgroundWorker worker)
        {
            foreach (var child in Info.GetDirectories())
            {
                if (worker.CancellationPending) { return; }

                try
                {
                    //The recursion happens when the child folder is created.
                    SubFolders.Add(new FolderData(Session, worker, child.FullName));
                }
                catch (UnauthorizedAccessException)
                {
                    UnavailableFolders.Add(child.FullName);
                }
            }
        }

        /// <summary>
        /// Calculates the size of the folder and its content.
        /// </summary>
        /// <param name="worker">The background worker responsible for the folder object creation.</param>
        private void calculateSize(BackgroundWorker worker)
        {
            //The bottom folders finish the creation first and therefore
            //have their size when the top folders continue their creation.

            SizeInBytes = 0;

            foreach (var child in SubFolders)
            {
                if (worker.CancellationPending) { return; }
                SizeInBytes += child.SizeInBytes;
            }

            foreach (var file in Info.GetFiles())
            {
                if (worker.CancellationPending) { return; }
                SizeInBytes += file.Length;
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

            foreach (var folder in SubFolders)
            {
                unavailableFolders.AddRange(folder.GetAllUnavailableFoldersInTree());
            }

            return unavailableFolders;
        }
    }
}
