namespace FolderStructureAnalyser.SessionBound
{
    interface ISessionBound
    {
        Session Session { get; set; }

        void SessionSet(Session session);
    }
}
