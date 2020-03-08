using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FolderStructureAnalyser.DataObjects
{
    public class DiskItemInfo
    {
        /// <summary>
        /// 
        /// </summary>
        /// TODO: Why do we get a System.Reflection.TargetInvocationException when setting Info.Name as grid field name directly?
        public string Name => Info.Name;

        public FileSystemInfo Info { get; private set; }

        public DiskItemInfo(FileSystemInfo diskItem)
        {
            Info = diskItem;
        }
    }
}
