using FolderStructureAnalyser.DataObjects;

namespace FolderStructureAnalyser.SessionBound
{
    public class Settings : SessionBoundClass
    {
        public Settings(Session session)
            : base(session)
        {
            FolderStructureSettings = new FolderStructureSettings();
        }

        public FolderStructureSettings FolderStructureSettings { get; set; }
    }
}
