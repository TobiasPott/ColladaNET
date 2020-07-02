using System;
using System.Xml.Serialization;

namespace ColladaNET.Elements
{
    [Serializable()]
    [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
    public partial class MorphTargets
    {
        [XmlElement("input")]
        public Input[] input
        { get; set; }

        [XmlElement("extra")]
        public Extra[] extra
        { get; set; }
    }

}
