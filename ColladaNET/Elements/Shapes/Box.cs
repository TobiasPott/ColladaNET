using System;
using System.Xml.Serialization;

namespace ColladaNET.Elements
{

    [Serializable()]
    [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
    [XmlRoot(Namespace = Collada.XMLNAMESPACE, IsNullable = false)]
    public partial class Box : Shape.Base
    {
        [XmlElement()]
        public string half_extents
        { get; set; }
    }

}
