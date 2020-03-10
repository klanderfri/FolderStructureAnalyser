using System.ComponentModel;
using System.IO;
using FolderStructureAnalyser.DataObjects;
using FolderStructureAnalyser.Enums;

namespace FolderStructureAnalyser.Helpers
{
    public class StructureComparer
    {
        /// <summary>
        /// Compares two folders to see if the clone is identical to the original.
        /// </summary>
        /// <param name="originalFolderPath">The full path to the original folder.</param>
        /// <param name="cloneFolderPath">The full path to the clone folder.</param>
        /// <param name="compareFileHashes">Tells if the comparer should compare file hashes.</param>
        /// <param name="worker">The worker responsible for the comparision.</param>
        /// <returns>The collection holding any differences found.</returns>
        public static BindingList<StructureDifference> CompareFolders(string originalFolderPath, string cloneFolderPath, bool compareFileHashes, BackgroundWorker worker)
        {
            //Create the collection holding the differences.
            var differences = new BindingList<StructureDifference>();

            //Compare the folders.
            compareFolders(originalFolderPath, cloneFolderPath, compareFileHashes, worker, differences);

            //Return the differences.
            return differences;
        }

        /// <summary>
        /// Compares two folders to see if the clone is identical to the original.
        /// </summary>
        /// <param name="originalFolderPath">The full path to the original folder.</param>
        /// <param name="cloneFolderPath">The full path to the clone folder.</param>
        /// <param name="compareFileHashes">Tells if the comparer should compare file hashes.</param>
        /// <param name="worker">The worker responsible for the comparision.</param>
        /// <param name="differences">The data source holding any differences found.</param>
        private static void compareFolders(string originalFolderPath, string cloneFolderPath, bool compareFileHashes, BackgroundWorker worker, BindingList<StructureDifference> differences)
        {
            //Check for cancellation.
            if (worker.CancellationPending) { return; }

            //Get the information about the folders.
            var originalFolder = new DirectoryInfo(originalFolderPath);
            var cloneFolder = new DirectoryInfo(cloneFolderPath);

            //Check if the clone folder exists.
            if (!cloneFolder.Exists)
            {
                addDifference(differences, originalFolder, cloneFolder, DifferenceType.SubfolderMissing);
                return;
            }

            //Compare the folders.
            if (originalFolder.Attributes != cloneFolder.Attributes)
            {
                addDifference(differences, originalFolder, cloneFolder, DifferenceType.SubfolderAttributesDiffer);
            }

            //Compare the files in the folders.
            compareFiles(originalFolderPath, cloneFolderPath, compareFileHashes, worker, differences);

            //Check if the clone has any folders the original does not.
            foreach (var cloneSubFolder in FileHandler.GetSubfolders(cloneFolderPath))
            {
                //Get the information about the original subfolder.
                var originalSubfolder = FileHandler.GetFolderInfo(originalFolderPath, cloneSubFolder.Name);

                //Check if the clone has a folder the original does not.
                if (!originalSubfolder.Exists)
                {
                    addDifference(differences, originalSubfolder, cloneSubFolder, DifferenceType.SubfolderAdditional);
                }
            }

            //Compare subfolders recursively
            foreach (var originalSubfolder in FileHandler.GetSubfolders(originalFolderPath))
            {
                //Get the paths of the subfolders.
                var originalSubfolderPath = originalSubfolder.FullName;
                var cloneSubfolderPath = Path.Combine(cloneFolderPath, originalSubfolder.Name);

                //Compare the folders.
                compareFolders(originalSubfolderPath, cloneSubfolderPath, compareFileHashes, worker, differences);
            }
        }

        /// <summary>
        /// Compares the files withing two folders to see if the clone has the same file content as the original.
        /// </summary>
        /// <param name="originalFolderPath">The full path to the original folder.</param>
        /// <param name="cloneFolderPath">The full path to the clone folder.</param>
        /// <param name="compareFileHashes">Tells if the comparer should compare file hashes.</param>
        /// <param name="worker">The worker responsible for the comparision.</param>
        /// <param name="differences">The data source holding any differences found.</param>
        private static void compareFiles(string originalFolderPath, string cloneFolderPath, bool compareFileHashes, BackgroundWorker worker, BindingList<StructureDifference> differences)
        {
            //Check if the clone has all the files the original has.
            foreach (var originalFile in FileHandler.GetFiles(originalFolderPath))
            {
                //Check for cancellation.
                if (worker.CancellationPending) { return; }

                //Get the information about the clone file.
                var cloneFile = FileHandler.GetFileInfo(cloneFolderPath, originalFile.Name);

                //Check if the clone file exists.
                if (!cloneFile.Exists)
                {
                    addDifference(differences, originalFile, cloneFile, DifferenceType.FileMissing);
                    continue;
                }

                //Compare the files.
                if (originalFile.Attributes != cloneFile.Attributes)
                {
                    addDifference(differences, originalFile, cloneFile, DifferenceType.FileAttributesDiffer);
                }
                if (originalFile.Length != cloneFile.Length)
                {
                    addDifference(differences, originalFile, cloneFile, DifferenceType.FileSizeDiffer);
                }
                else if (compareFileHashes && !FileHandler.HasIdenticalHashes(originalFile.FullName, cloneFile.FullName))
                {
                    addDifference(differences, originalFile, cloneFile, DifferenceType.FileHashDiffer);
                }
            }

            //Check if the clone has any files the original does not.
            foreach (var cloneFile in FileHandler.GetFiles(cloneFolderPath))
            {
                //Check for cancellation.
                if (worker.CancellationPending) { return; }

                //Get the information about the original file.
                var originalFile = FileHandler.GetFileInfo(originalFolderPath, cloneFile.Name);

                //Check if the clone has a file the original does not.
                if (!originalFile.Exists)
                {
                    addDifference(differences, originalFile, cloneFile, DifferenceType.FileAdditional);
                }
            }
        }

        /// <summary>
        /// Adds a difference to the list of differences to show the user.
        /// </summary>
        /// <param name="differences">The list of differences to show the user.</param>
        /// <param name="original">The original item.</param>
        /// <param name="clone">The clone item that differs from the original.</param>
        /// <param name="type">The type of difference difference.</param>
        private static void addDifference(BindingList<StructureDifference> differences, FileSystemInfo original, FileSystemInfo clone, DifferenceType type)
        {
            var diff = new StructureDifference(original, clone, type);
            differences.Add(diff);
        }
    }
}
