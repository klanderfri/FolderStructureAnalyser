using System.Drawing;
using System.Xml.Serialization;
using FolderStructureAnalyser.Enums;
using FolderStructureAnalyser.Helpers;

namespace FolderStructureAnalyser.SessionBound
{
    /// <summary>
    /// Class for object holding the settings for the application.
    /// </summary>
    public class Settings
    {
        /// <summary>
        /// The file name of the XML file storing the settings on disk.
        /// </summary>
        private static string StoreFileName { get; } = "ApplicationSettings.xml";

        /// <summary>
        /// The size in bytes of a folder that is to be considered big.
        /// </summary>
        public int BigFolderInMB { get; set; }

        /// <summary>
        /// The colour used to indicate a folder that is to be considered big.
        /// </summary>
        [XmlIgnore]
        public Color BigFolderColour { get; set; }

        /// <summary>
        /// The colour used to indicate a folder that is to be considered big, in HTML format.
        /// </summary>
        public string BigFolderColourHtml
        {
            get { return BigFolderColour.ToHtml(); }
            set { BigFolderColour = ColorTranslator.FromHtml(value); }
        }

        /// <summary>
        /// Tells if the hashes should be compared when comparing two files.
        /// </summary>
        public bool CompareFileHashes { get; set; }

        /// <summary>
        /// The colour used to indicate an error within a grid.
        /// </summary>
        [XmlIgnore]
        public Color GridErrorColour { get; set; }

        /// <summary>
        /// The colour used to indicate an error within a grid, in HTML format.
        /// </summary>
        public string GridErrorColourHtml
        {
            get { return GridErrorColour.ToHtml(); }
            set { GridErrorColour = ColorTranslator.FromHtml(value); }
        }

        /// <summary>
        /// Tells which unit a size should be displayed as.
        /// </summary>
        public SizeDisplayUnit SizeDisplayUnit { get; set; }

        /// <summary>
        /// Loads the settings stored on disk.
        /// </summary>
        public void LoadSettings()
        {
            //Fetch the settings.
            var settings = FileHandler.LoadObjectFromXML<Settings>(StoreFileName);
            if (settings == null)
            {
                settings = getDefaultValues();
            }

            //Load the settings.
            BigFolderInMB = settings.BigFolderInMB;
            BigFolderColour = settings.BigFolderColour;
            CompareFileHashes = settings.CompareFileHashes;
            GridErrorColour = settings.GridErrorColour;
            SizeDisplayUnit = settings.SizeDisplayUnit;
        }

        /// <summary>
        /// Saves the settings to disk.
        /// </summary>
        public void SaveSettings()
        {
            FileHandler.SaveObjectAsXML<Settings>(this, StoreFileName);
        }

        /// <summary>
        /// Creates a settings object containing the default values.
        /// </summary>
        /// <returns>A settings object containing the default values.</returns>
        private Settings getDefaultValues()
        {
            return new Settings()
            {
                BigFolderInMB = 10,
                BigFolderColour = Color.Red,
                CompareFileHashes = false,
                GridErrorColour = Color.Salmon,
                SizeDisplayUnit = SizeDisplayUnit.Dynamic,
            };
        }
    }
}
