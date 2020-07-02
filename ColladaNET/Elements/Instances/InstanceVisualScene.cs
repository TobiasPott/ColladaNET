using System;
using System.Xml.Serialization;

namespace ColladaNET
{
    [Serializable()]
    [XmlType(Namespace = Collada.XMLNAMESPACE)]
    [XmlRoot("instance_visual_scene", Namespace = Collada.XMLNAMESPACE, IsNullable = false)]
    public partial class InstanceVisualScene : InstanceBase.WithUrl
    {
        public InstanceVisualScene()
        { }
        public InstanceVisualScene(string name, string sid, string url) : base (name, sid, url)
        { }
    }

}
