namespace FolderStructureAnalyser.SessionBound
{
    public class Session
    {
        public Session()
        {
            Settings = new Settings();
        }

        public Settings Settings { get; set; }
    }
}
