namespace FolderStructureAnalyser.SessionBound
{
    public class Settings
    {
        public Settings()
        {
            FolderStructureSettings = new FolderStructureSettings();
        }

        public FolderStructureSettings FolderStructureSettings { get; set; }
    }
}
