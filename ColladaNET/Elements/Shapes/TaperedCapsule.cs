using System;
using System.Xml.Serialization;

namespace ColladaNET.Elements
{
    [Serializable()]
    [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
    [XmlRoot(Namespace = Collada.XMLNAMESPACE, IsNullable = false)]
    public partial class TaperedCapsule : Shape.Base
    {
        [XmlElement()]
        public float height
        { get; set; }

        [XmlElement()]
        public string radius1
        { get; set; }

        [XmlElement()]
        public string radius2
        { get; set; }

    }

}
