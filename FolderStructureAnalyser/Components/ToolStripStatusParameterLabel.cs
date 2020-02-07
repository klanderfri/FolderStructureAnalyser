using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FolderStructureAnalyser.Components
{
    public partial class ToolStripStatusParameterLabel : ToolStripStatusLabel
    {
        public String ParameterText
        {
            get { return base.Text; }
            set { Text = String.Format(base.ToString(), value); }
        }

        public ToolStripStatusParameterLabel()
        {
            InitializeComponent();
        }

        public ToolStripStatusParameterLabel(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
    }
}
