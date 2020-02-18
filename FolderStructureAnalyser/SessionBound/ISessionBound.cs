namespace FolderStructureAnalyser.SessionBound
{
    interface ISessionBound
    {
        Session Session { get; set; }

        void SetSession(Session session);
    }
}
