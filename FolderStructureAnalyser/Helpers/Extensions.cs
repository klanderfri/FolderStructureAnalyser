using System.Collections.Generic;
using System.Linq;

namespace FolderStructureAnalyser.Helpers
{
    /// <summary>
    /// Class for method extending existing framwork classes.
    /// </summary>
    public static class Extensions
    {
        /// <summary>
        /// Checks if a sequence contains a single item, no more, no less.
        /// </summary>
        /// <typeparam name="T">The type of items the sequence contains.</typeparam>
        /// <param name="sequence">The sequence to test.</param>
        /// <returns>TRUE if the sequence contains a single item, else FALSE.</returns>
        public static bool HasSingleItem<T>(this IEnumerable<T> sequence)
        {
            if (!sequence.Any()) { return false; } //Has 0 items.
            if (sequence.Skip(1).Any()) { return false; } //Has more than 1 item.
            return true; //Has exactly 1 item.
        }
    }
}
