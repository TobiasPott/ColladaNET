using ColladaNET.Elements;
using System;
using System.Xml.Serialization;

namespace ColladaNET
{

    [Serializable()]
    [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
    [XmlRoot("instance_controller", Namespace = Collada.XMLNAMESPACE, IsNullable = false)]
    public partial class InstanceController : InstanceBase.WithUrl
    {

        [XmlElement("skeleton", DataType = "anyURI")]
        public string[] skeleton
        { get; set; }

        [XmlElement()]
        public BindMaterial bind_material
        { get; set; }


        // constructors
        public InstanceController() { }

        public InstanceController(string url)
        { this.url = url; }

        public InstanceController(string url, string name, string sid)
            : this(url)
        {
            this.name = name;
            this.sid = sid;
        }



    }

}
