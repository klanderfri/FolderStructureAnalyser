namespace FolderStructureAnalyser.SessionBound
{
    public class SessionBoundClass : ISessionBound
    {
        public Session Session { get; set; }

        public SessionBoundClass(Session session)
        {
            SetSession(session);
        }

        public void SetSession(Session session)
        {
            Session = session;
        }
    }
}
