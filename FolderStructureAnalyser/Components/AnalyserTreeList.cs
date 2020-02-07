using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.XtraTreeList;
using FolderStructureAnalyser.SessionBound;

namespace FolderStructureAnalyser.Components
{
    public partial class AnalyserTreeList : TreeList, ISessionBound
    {
        public Session Session { get; set; }

        public AnalyserTreeList()
        {
            InitializeComponent();
        }

        public void SessionSet(Session session)
        {
            Session = session;
        }

        public AnalyserTreeList(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
    }
}
