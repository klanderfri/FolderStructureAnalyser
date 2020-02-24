using System.Windows.Forms;

namespace FolderStructureAnalyser.SessionBound
{
    public class Session
    {
        public Session(Form rootForm)
        {
            Settings = new Settings(this);
            Tools = new Tools(this);
            MessageLog = new MessageLog(this);
            RootForm = rootForm;
        }

        public Settings Settings { get; set; }
        public Tools Tools { get; set; }
        public MessageLog MessageLog { get; set; }
        public Form RootForm { get; set; }
    }
}
