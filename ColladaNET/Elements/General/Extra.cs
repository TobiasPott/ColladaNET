using System;
using System.Xml.Serialization;

namespace ColladaNET.Elements
{

    [Serializable()]
    [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
    [XmlRoot(Namespace = Collada.XMLNAMESPACE, IsNullable = false)]
    public partial class Extra
    {
        [XmlElement()]
        public Asset asset
        { get; set; }

        [XmlElement("technique")]
        public Technique[] technique
        { get; set; }

        [XmlAttribute(DataType = "ID")]
        public string id
        { get; set; }

        [XmlAttribute(DataType = "NCName")]
        public string name
        { get; set; }

        [XmlAttribute(DataType = "NMTOKEN")]
        public string type
        { get; set; }
    }

}
