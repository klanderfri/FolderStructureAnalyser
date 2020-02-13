namespace FolderStructureAnalyser.SessionBound
{
    public class SessionBoundClass : ISessionBound
    {
        public Session Session { get; set; }

        public void SessionSet(Session session)
        {
            Session = session;
        }
    }
}
