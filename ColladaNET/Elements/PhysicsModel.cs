using ColladaNET.Elements;
using System;
using System.Xml.Serialization;

namespace ColladaNET
{

    [Serializable()]
    [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
    [XmlRoot(Namespace = Collada.XMLNAMESPACE, IsNullable = false)]
    public partial class PhysicsModel : LibraryItemBase
    {
        [XmlElement("rigid_body")]
        public RigidBody[] rigid_body
        { get; set; }

        [XmlElement("rigid_constraint")]
        public RigidConstraint[] rigid_constraint
        { get; set; }

        [XmlElement("instance_physics_model")]
        public InstancePhysicsModel[] instance_physics_model
        { get; set; }

    }

}
