using System;
using System.Xml.Serialization;

namespace ColladaNET.Elements
{
    [Serializable()]
    [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
    [XmlRoot(Namespace = Collada.XMLNAMESPACE, IsNullable = false)]
    public partial class ConvexMesh : Mesh
    {
        [XmlAttribute(DataType = "anyURI")]
        public string convex_hull_of
        { get; set; }
    }

}
