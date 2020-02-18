using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace FolderStructureAnalyser.Components
{
    public partial class FolderStructureComparerCtrl : FolderStructureParentCtrl
    {
        public FolderStructureComparerCtrl()
        {
            InitializeComponent();
        }

        public void CompareFolderStructures()
        {
            if (MayStartAnalysis())
            {
                var paths = askUserForFoldersToCompare();

                if (paths != null)
                {
                    StartAnalysis(paths);
                }
            }
        }

        private List<string> askUserForFoldersToCompare()
        {
            var originalFolder = ShowSelectFolderDialog("Select original", "Select the folder that are to act as original.");
            if (!PathIsValid(originalFolder)) { return null; }

            var clonedFolder = ShowSelectFolderDialog("Select clone", "Select the folder that are to act as clone.");
            if (!PathIsValid(clonedFolder)) { return null; }

            return new List<string>() { originalFolder, clonedFolder };
        }

        private void FolderStructureComparerCtrl_DoFolderStructureAnalysis(object sender, DoWorkEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void FolderStructureComparerCtrl_FolderStructureAnalysisFinished(object sender, RunWorkerCompletedEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
