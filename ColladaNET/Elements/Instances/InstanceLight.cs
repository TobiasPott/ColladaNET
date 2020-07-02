using System;
using System.Xml.Serialization;

namespace ColladaNET
{
    [Serializable()]
    [XmlType(Namespace = Collada.XMLNAMESPACE)]
    [XmlRoot("instance_light", Namespace = Collada.XMLNAMESPACE, IsNullable = false)]
    public partial class InstanceLight : InstanceBase.WithUrl
    { }

}
