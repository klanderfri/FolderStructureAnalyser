using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FolderStructureAnalyser.SessionBound
{
    public class FolderStructureSettings
    {
        public FolderStructureSettings()
        {
            RootPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            BigFolderInBytes = 10485760; //10 MB.
            BigFolderColour = Color.Red;
        }

        /// <summary>
        /// The full path to the root folder of the folder structure.
        /// </summary>
        public string RootPath { get; set; }

        /// <summary>
        /// The size in bytes of a folder that is to be considered big.
        /// </summary>
        public long BigFolderInBytes { get; set; }

        /// <summary>
        /// The colour used to indicate afolder that is to be considered big.
        /// </summary>
        public Color BigFolderColour { get; set; }
    }
}
