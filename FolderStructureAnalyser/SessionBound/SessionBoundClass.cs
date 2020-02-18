namespace FolderStructureAnalyser.SessionBound
{
    public class SessionBoundClass : ISessionBound
    {
        public Session Session { get; set; }

        public void SetSession(Session session)
        {
            Session = session;
        }
    }
}
