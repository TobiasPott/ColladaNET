using System;
using System.Xml.Serialization;

namespace ColladaNET
{

    [Serializable()]
    [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
    [XmlRoot("instance_rigid_constraint", Namespace = Collada.XMLNAMESPACE, IsNullable = false)]
    public partial class InstanceRigidConstraint : InstanceBase
    {
        [XmlAttribute(DataType = "NCName")]
        public string constraint
        { get; set; }
    }
}