using System;
using System.Xml.Serialization;

namespace ColladaNET.Elements
{
    [Serializable()]
    [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
    [XmlRoot(Namespace = Collada.XMLNAMESPACE, IsNullable = false)]
    public partial class Channel : AtomicBase
    {
        [XmlAttribute()]
        public string source
        { get; set; }

        [XmlAttribute(DataType = "token")]
        public string target
        { get; set; }
    }

}
