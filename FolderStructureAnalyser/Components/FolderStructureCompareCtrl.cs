using System;
using System.IO;
using System.Windows.Forms;
using FolderStructureAnalyser.GUI;
using FolderStructureAnalyser.SessionBound;

namespace FolderStructureAnalyser.Components
{
    public partial class FolderStructureCompareCtrl : FolderStructureAnalyserCtrl
    {
        public FolderStructureCompareCtrl()
        {
            InitializeComponent();
        }

        public void CompareFolderStructures()
        {
            if (mayStartCompare())
            {
                var paths = askUserForFoldersToCompare();
                CompareFolderStructures(paths);
            }
        }

        private void CompareFolderStructures(Tuple<string, string> paths)
        {
            if (mayStartCompare(paths))
            {
                throw new NotImplementedException();
            }
        }

        private Tuple<string, string> askUserForFoldersToCompare()
        {
            var result = xtraFolderBrowserDialogOriginalFolder.ShowDialog();
            var originalFolder = (result == DialogResult.OK) ? xtraFolderBrowserDialogOriginalFolder.SelectedPath : null;

            xtraFolderBrowserDialogCloneFolder.ShowDialog();
            var clonedFolder = (result == DialogResult.OK) ? xtraFolderBrowserDialogCloneFolder.SelectedPath : null;

            return new Tuple<string, string>(originalFolder, clonedFolder);
        }

        private bool mayStartCompare()
        {
            if (backgroundWorkerCompareFolders.IsBusy)
            {
                MessageBoxes.ShowAnalyseInProgressMessage();
                return false;
            }
            return true;
        }

        private bool mayStartCompare(Tuple<string, string> paths)
        {
            if (!mayStartCompare()) { return false; }
            if (!pathIsValid(paths.Item1)) { return false; }
            if (!pathIsValid(paths.Item2)) { return false; }
            return true;
        }

        private bool pathIsValid(string path)
        {
            if (String.IsNullOrWhiteSpace(path)) { return false; }
            if (!Directory.Exists(path))
            {
                MessageBoxes.ShowDirectoryDoesNotExistMessage(path);
                return false;
            }
            return true;
        }
    }
}
