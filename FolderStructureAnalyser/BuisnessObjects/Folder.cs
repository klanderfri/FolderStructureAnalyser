using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.XtraTreeList.Nodes;
using FolderStructureAnalyser.SessionBound;

namespace FolderStructureAnalyser.BuisnessObjects
{
    /// <summary>
    /// Class for object representing a folder in a file-folder tree structure.
    /// </summary>
    public class Folder : SessionBoundClass
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
        /// The MB size of the folder and its content.
        /// </summary>
        public double SizeInMB
        {
            get { return Session.Tools.ByteSizeConverter.MbFromByte(SizeInBytes); }
        }

        /// <summary>
        /// The subfolders of the folder.
        /// </summary>
        public List<Folder> SubFolders { get; private set; } = new List<Folder>();

        /// <summary>
        /// The subfolders that are not available for the application.
        /// </summary>
        public List<string> UnavailableFolders { get; private set; } = new List<string>();

        /// <summary>
        /// Creates an object representing a folder in a file-folder tree structure.
        /// </summary>
        /// <param name="folderpath">The physical path to the folder.</param>
        public Folder(Session session, string folderpath)
        {
            SessionSet(session);

            Info = new DirectoryInfo(folderpath);
            
            fillSubfolders();
            calculateSize();
        }

        /// <summary>
        /// Adds the subfolder structure to the subfolder list.
        /// </summary>
        private void fillSubfolders()
        {
            foreach (var child in Info.GetDirectories())
            {
                try
                {
                    //The recursion happens when the child folder is created.
                    SubFolders.Add(new Folder(Session, child.FullName));
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
        private void calculateSize()
        {
            //The bottom folders finish the creation first and therefore
            //have their size when the top folders continue their creation.

            SizeInBytes = 0;

            foreach (var child in SubFolders)
            {
                SizeInBytes += child.SizeInBytes;
            }

            foreach (var file in Info.GetFiles())
            {
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
