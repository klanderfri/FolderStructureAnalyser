namespace FolderStructureAnalyser.SessionBound
{
    public class Session
    {
        public Session()
        {
            Settings = new Settings();
            Tools = new Tools();
        }

        public Settings Settings { get; set; }
        public Tools Tools { get; set; }
    }
}
