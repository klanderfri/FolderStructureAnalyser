using System.Collections.Generic;
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
            var folder = new DirectoryInfo(folderPath);
            var files = new Dictionary<string, FileInfo>();

            foreach (var file in folder.GetFiles())
            {
                files.Add(file.Name, file);
            }

            return files;
        }
    }
}
