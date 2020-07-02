using System;
using System.Xml;
using System.Xml.Serialization;

namespace ColladaNET.Elements
{

    [Serializable()]
    [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
    [XmlRoot(Namespace = Collada.XMLNAMESPACE, IsNullable = false)]
    public partial class Technique : AtomicBase
    {

        [XmlAnyElementAttribute()]
        public XmlElement[] any // changed from upper case Any to lower case
        { get; set; }

        [XmlAttribute(DataType = "NMTOKEN")]
        public string profile
        { get; set; }
    }

}
