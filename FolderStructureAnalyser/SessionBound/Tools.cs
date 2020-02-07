using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FolderStructureAnalyser.SessionBound
{
    public class Tools
    {
        public Tools()
        {
            ByteSizeConverter = new ByteSizeConverter();
        }

        public ByteSizeConverter ByteSizeConverter { get; set; }
    }
}
