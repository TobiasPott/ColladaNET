using System;
using System.Xml.Serialization;

namespace ColladaNET
{
    [Serializable()]
    [XmlType(Namespace = Collada.XMLNAMESPACE)]
    [XmlRoot("instance_force_field", Namespace = Collada.XMLNAMESPACE, IsNullable = false)]
    public partial class InstanceForceField : InstanceBase.WithUrl
    { }

}
