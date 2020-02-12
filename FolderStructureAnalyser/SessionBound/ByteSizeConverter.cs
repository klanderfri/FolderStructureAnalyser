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
        public string SizeStringFromByte(long sizeInBytes)
        {
            var units = new List<string> { "B", "kB", "MB", "GB", "TB", "PB", "EB", "ZB", "YB" };

            for (int power = 0; power < units.Count; power++)
            {
                if (sizeInBytes < Math.Pow(1024, power + 1))
                {
                    return getSizeText(sizeInBytes / Math.Pow(1024, power), units[power]);
                }
            }

            //Really? The size was so big even yottabytes couldn't do it?
            var format = "Unhandled size, {0} bytes.";
            var message = String.Format(format, sizeInBytes);
            throw new InvalidOperationException(message);
        }

        private string getSizeText(double size, string unit)
        {
            var numberOfDecimals = getNumberOfDecimals(size);
            var format = "{0:N" + numberOfDecimals + "}";

            var sizeString = String.Format(format, size);
            return String.Format("{0} {1}", sizeString, unit);
        }

        private int getNumberOfDecimals(double size)
        {
            if (size < 10) { return 2; }
            if (size < 100) { return 1; }
            return 0;
        }

        public double MbFromByte(long sizeInBytes)
        {
            return sizeInBytes / Math.Pow(1024, 2);
        }

        public long BytesFromMB(int sizeInMB)
        {
            return sizeInMB * (int)Math.Pow(1024, 2);
        }
    }
}
