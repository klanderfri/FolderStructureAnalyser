using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FolderStructureAnalyser.SessionBound;

namespace FolderStructureAnalyser.Components
{
    public partial class FolderStructureCompareCtrl : UserControl, ISessionBound
    {
        public Session Session { get; set; }

        public FolderStructureCompareCtrl()
        {
            InitializeComponent();
        }

        public void SessionSet(Session session)
        {
            Session = session;
        }
    }
}
