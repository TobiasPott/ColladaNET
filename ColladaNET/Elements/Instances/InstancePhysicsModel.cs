using System;
using System.Xml.Serialization;

namespace ColladaNET
{

    [Serializable()]
    [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
    [XmlRoot("instance_physics_model", Namespace = Collada.XMLNAMESPACE, IsNullable = false)]
    public partial class InstancePhysicsModel : InstanceBase.WithUrl
    {
        [XmlElement("instance_force_field")]
        public InstanceForceField[] instance_force_field
        { get; set; }

        [XmlElement("instance_rigid_body")]
        public InstanceRigidBody[] instance_rigid_body
        { get; set; }

        [XmlElement("instance_rigid_constraint")]
        public InstanceRigidConstraint[] instance_rigid_constraint
        { get; set; }


        [XmlAttribute(DataType = "anyURI")]
        public string parent
        { get; set; }
    }

}
