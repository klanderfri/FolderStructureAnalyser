using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FolderStructureAnalyser.SessionBound
{
    interface ISessionBound
    {
        Session Session { get; set; }

        void SessionSet(Session session);
    }
}
