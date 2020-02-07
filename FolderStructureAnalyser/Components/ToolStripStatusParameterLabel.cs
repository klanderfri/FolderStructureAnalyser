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
            set { Text = String.Format(FormatText ?? "{0}", value); }
        }

        private String FormatText { get; set; }

        public ToolStripStatusParameterLabel()
        {
            InitializeComponent();

            //Let the user enter the format in the text property in the editor and use it as format.
            FormatText = Text;
        }

        public ToolStripStatusParameterLabel(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
    }
}
