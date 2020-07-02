using System;
using System.Xml.Serialization;

namespace ColladaNET
{
    [Serializable()]
    [XmlType(Namespace = Collada.XMLNAMESPACE)]
    [XmlRoot("instance_node", Namespace = Collada.XMLNAMESPACE, IsNullable = false)]
    public partial class InstanceNode : InstanceBase.WithUrl
    { }

}
