using System;
using System.Drawing;
using DevExpress.XtraWaitForm;

namespace FolderStructureAnalyser.Components
{
    public partial class WaitForStructureAnalyseForm : WaitForm
    {
        //Wait Form handling implemented as suggested at:
        //https://supportcenter.devexpress.com/ticket/details/s38626/add-the-capability-to-move-waitform-together-with-the-main-form
        //https://supportcenter.devexpress.com/ticket/details/T575207/move-waitform-owned-by-a-user-control-with-main-form

        public WaitForStructureAnalyseForm()
        {
            InitializeComponent();
            progressPanel1.AutoHeight = true;
        }

        #region Overrides

        public override void SetCaption(string caption)
        {
            base.SetCaption(caption);
            progressPanel1.Caption = caption;
        }
        public override void SetDescription(string description)
        {
            base.SetDescription(description);
            progressPanel1.Description = description;
        }
        public override void ProcessCommand(Enum cmd, object arg)
        {
            base.ProcessCommand(cmd, arg);

            //Execute command.
            switch ((WaitFormCommand)cmd)
            {
                case WaitFormCommand.Position:
                    Location = (Point)arg;
                    break;
                case WaitFormCommand.Move:
                    var vector = (int[])arg;
                    Location = new Point(Location.X + vector[0], Location.Y + vector[1]);
                    break;
            }
        }

        #endregion
    }
}