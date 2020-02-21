using System.Windows.Forms;

namespace FolderStructureAnalyser.SessionBound
{
    public class Session
    {
        public Session(Form rootForm)
        {
            Settings = new Settings(this);
            Tools = new Tools(this);
            RootForm = rootForm;
        }

        public Settings Settings { get; set; }
        public Tools Tools { get; set; }
        public Form RootForm { get; set; }
    }
}
