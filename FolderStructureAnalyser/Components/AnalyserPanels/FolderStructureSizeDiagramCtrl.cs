﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FolderStructureAnalyser.Helpers;

namespace FolderStructureAnalyser.Components.AnalyserPanels
{
    public partial class FolderStructureSizeDiagramCtrl : UserControl
    {
        public FolderStructureSizeDiagramCtrl()
        {
            InitializeComponent();
        }

        public void UpdateData(string rootPath)
        {
            SunburstDiagramHelper.SetupSunburstCtrl(sunburstControl1, rootPath);
        }
    }
}
