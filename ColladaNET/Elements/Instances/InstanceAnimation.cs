using System;
using System.Xml.Serialization;

namespace ColladaNET
{
    [Serializable()]
    [XmlType(Namespace = Collada.XMLNAMESPACE)]
    [XmlRoot("instance_animation", Namespace = Collada.XMLNAMESPACE, IsNullable = false)]
    public partial class InstanceAnimation : InstanceBase.WithUrl
    { }

}
