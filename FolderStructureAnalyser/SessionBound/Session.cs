using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FolderStructureAnalyser.SessionBound;

namespace FolderStructureAnalyser.SessionBound
{
    public class Session
    {
        public Session()
        {
            Settings = new Settings();
            Tools = new Tools();
        }

        public Settings Settings { get; set; }
        public Tools Tools { get; set; }
    }
}
