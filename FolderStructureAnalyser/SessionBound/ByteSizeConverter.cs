using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FolderStructureAnalyser.SessionBound
{
    /// <summary>
    /// Class for converting byte sizes.
    /// </summary>
    public class ByteSizeConverter
    {
        /// <summary>
        /// Converts bytes into MB.
        /// </summary>
        /// <param name="sizeInBytes">The size, in bytes, to convert to MB.</param>
        /// <returns>The size in MB.</returns>
        public double MbFromByte(long sizeInBytes)
        {
            return Math.Round(sizeInBytes / Math.Pow(1024, 2), 1);
        }
    }
}
