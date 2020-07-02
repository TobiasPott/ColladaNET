using ColladaNET.Elements;
using System;
using System.Xml.Serialization;

namespace ColladaNET
{
    [Serializable()]
    [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
    [XmlRoot(Namespace = Collada.XMLNAMESPACE, IsNullable = false)]
    public partial class ForceField : LibraryItemBase
    {
        [XmlElement("technique")]
        public Technique[] technique
        { get; set; }
    }

}
