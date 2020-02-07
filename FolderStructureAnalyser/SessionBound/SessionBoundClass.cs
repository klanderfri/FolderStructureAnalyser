using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
