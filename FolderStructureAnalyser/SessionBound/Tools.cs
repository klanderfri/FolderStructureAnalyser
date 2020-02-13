namespace FolderStructureAnalyser.SessionBound
{
    public class Tools
    {
        public Tools()
        {
            ByteSizeConverter = new ByteSizeConverter();
        }

        public ByteSizeConverter ByteSizeConverter { get; set; }
    }
}
