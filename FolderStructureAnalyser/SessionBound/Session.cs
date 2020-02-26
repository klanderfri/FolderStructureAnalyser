using System.Windows.Forms;

namespace FolderStructureAnalyser.SessionBound
{
    public class Session
    {
        public Session(Form rootForm)
        {
            //Operation helpers.
            Tools = new Tools(this);
            MessageLog = new MessageLog(this);

            //Data holders.
            Settings = new Settings();
            Settings.LoadSettings();
            RootForm = rootForm;
        }

        public Tools Tools { get; set; }
        public MessageLog MessageLog { get; set; }
        public Settings Settings { get; set; }
        public Form RootForm { get; set; }
    }
}
