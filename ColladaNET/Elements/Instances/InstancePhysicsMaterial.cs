using System;
using System.Xml.Serialization;

namespace ColladaNET
{

    [Serializable()]
    [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
    [XmlRoot("instance_physics_material", Namespace = Collada.XMLNAMESPACE, IsNullable = false)]
    public partial class InstancePhysicsMaterial : InstanceBase.WithUrl
    { }

}
