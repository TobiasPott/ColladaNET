using System;
using System.Xml.Serialization;

namespace ColladaNET
{
    [Serializable()]
    [XmlType(Namespace = Collada.XMLNAMESPACE)]
    [XmlRoot("instance_camera", Namespace = Collada.XMLNAMESPACE, IsNullable = false)]
    public partial class InstanceCamera : InstanceBase.WithUrl
    { }

}
