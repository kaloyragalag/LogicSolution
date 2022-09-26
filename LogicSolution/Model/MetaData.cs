using System.ComponentModel;

namespace LogicSolution.Model
{
    public class MetaData
    {
        public string Title { get; set; }
        public string Link { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
    }
    public enum METATYPE
    {
        LINK = 0,
        TITLE = 1,
        DESCRIPTION = 2,
        IMAGE = 3
    }
}
