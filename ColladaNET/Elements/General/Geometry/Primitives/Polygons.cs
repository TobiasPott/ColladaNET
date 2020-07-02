using System;
using System.Xml.Serialization;

namespace ColladaNET.Elements
{

    [Serializable()]
    [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
    [XmlRoot(Namespace = Collada.XMLNAMESPACE, IsNullable = false)]
    public partial class Polygons : Primitive<Indices>
    {
        [XmlElement("ph", typeof(IndicesWithHoles))]
        public IndicesWithHoles[] ph
        { get; set; }
    }

}
