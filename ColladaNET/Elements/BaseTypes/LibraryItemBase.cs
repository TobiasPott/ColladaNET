using ColladaNET.Elements;
using System.Xml.Serialization;

namespace ColladaNET
{

    public abstract class LibraryItemBase
    {

        [XmlAttribute(DataType = "ID")]
        public string id
        { get; set; } = string.Empty;

        [XmlAttribute(DataType = "NCName")]
        public string name
        { get; set; } = string.Empty;


        [XmlElement()]
        public Asset asset
        { get; set; } = null;

        [XmlElement("extra")]
        public Extra[] extra
        { get; set; } = null;

    }

}
