using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FolderStructureAnalyser.SessionBound
{
    public class Settings
    {
        public Settings()
        {
            FolderStructureSettings = new FolderStructureSettings();
        }

        public FolderStructureSettings FolderStructureSettings { get; set; }
    }
}
