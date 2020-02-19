namespace FolderStructureAnalyser.SessionBound
{
    public class Session
    {
        public Session()
        {
            Settings = new Settings(this);
            Tools = new Tools(this);
        }

        public Settings Settings { get; set; }
        public Tools Tools { get; set; }
    }
}
