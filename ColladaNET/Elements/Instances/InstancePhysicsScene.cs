using System;
using System.Xml.Serialization;

namespace ColladaNET
{
    [Serializable()]
    [XmlType(Namespace = Collada.XMLNAMESPACE)]
    [XmlRoot("instance_physics_scene", Namespace = Collada.XMLNAMESPACE, IsNullable = false)]
    public partial class InstancePhysicsScene : InstanceBase.WithUrl
    { }

}
