using System;
using System.Collections.Generic;

namespace FolderStructureAnalyser.Helpers
{
    /// <summary>
    /// Class for converting byte sizes.
    /// </summary>
    public static class ByteSizeConverter
    {
        /// <summary>
        /// Converts a size in bytes to a descriptive string.
        /// </summary>
        /// <param name="sizeInBytes">The size to convert.</param>
        /// <returns>A string describing the size.</returns>
        public static string SizeStringFromByte(long sizeInBytes)
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

        /// <summary>
        /// Concatenates the size and unit into a string.
        /// </summary>
        /// <param name="size">The size to put into the string.</param>
        /// <param name="unit">The unit of the size.</param>
        /// <returns>The concatenated string.</returns>
        private static string getSizeText(double size, string unit)
        {
            var numberOfDecimals = getNumberOfDecimals(size);
            var format = "{0:N" + numberOfDecimals + "}";

            var sizeString = String.Format(format, size);
            return String.Format("{0} {1}", sizeString, unit);
        }

        /// <summary>
        /// Finds the number of decimals suitable for a size.
        /// </summary>
        /// <param name="size">The size to use when deciding the number of decimals.</param>
        /// <returns>The number of decimals suitable for a size.</returns>
        private static int getNumberOfDecimals(double size)
        {
            if (size < 10) { return 2; }
            if (size < 100) { return 1; }
            return 0;
        }

        /// <summary>
        /// Converts a size in bytes to a size in MB.
        /// </summary>
        /// <param name="sizeInBytes">The size to convert.</param>
        /// <returns>The size in MB.</returns>
        public static double MbFromByte(long sizeInBytes)
        {
            return sizeInBytes / Math.Pow(1024, 2);
        }

        /// <summary>
        /// Converts a size in MB to a size in bytes.
        /// </summary>
        /// <param name="sizeInMB">The size to convert.</param>
        /// <returns>The size in bytes.</returns>
        public static long BytesFromMB(int sizeInMB)
        {
            return sizeInMB * (int)Math.Pow(1024, 2);
        }
    }
}
