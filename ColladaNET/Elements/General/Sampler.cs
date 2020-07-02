using System;
using System.Xml.Serialization;

namespace ColladaNET.Elements
{
    [Serializable()]
    [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
    [XmlRoot(Namespace = Collada.XMLNAMESPACE, IsNullable = false)]
    public partial class Sampler
    {
        [XmlElement("input")]
        public Input[] input
        { get; set; }

        [XmlAttribute(DataType = "ID")]
        public string id
        { get; set; }

    }

}
