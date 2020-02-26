using System.Drawing;

namespace FolderStructureAnalyser.Helpers
{
    /// <summary>
    /// Class for handling colours.
    /// </summary>
    public static class ColourHandler
    {
        /// <summary>
        /// Converts a colour to a HTML format.
        /// </summary>
        /// <param name="colour">The colour to convert.</param>
        /// <returns>The color as HTML format.</returns>
        public static string ToHtml(this Color colour)
        {
            return ColorTranslator.ToHtml(colour);
        }

        /// <summary>
        /// Converts a string to a colour.
        /// </summary>
        /// <param name="str">The string holding the colour HTML format.</param>
        /// <returns>The colour fetched from the HTML format.</returns>
        public static Color ColourFromHtml(this string str)
        {
            return ColorTranslator.FromHtml(str);
        }
    }
}
