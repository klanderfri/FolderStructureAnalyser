using System;
using System.Collections.Generic;
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
        }

        public string RootPath { get; set; }
    }
}
