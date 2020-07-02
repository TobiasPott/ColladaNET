using ColladaNET.Elements;
using System;
using System.Xml.Serialization;

namespace ColladaNET
{

    [Serializable()]
    [XmlType(Namespace = Collada.XMLNAMESPACE, TypeName = XmlTypeNameBase + "Base")]
    public abstract class InstanceBase
    {
        public const string XmlTypeNameBase = "Instance.";


        [XmlAttribute(DataType = "NCName")]
        public string sid
        { get; set; } = string.Empty;

        [XmlAttribute(DataType = "NCName")]
        public string name
        { get; set; } = string.Empty;

        [XmlElement("extra")]
        public Extra[] extra
        { get; set; }

        // constructors
        public InstanceBase() { }

        public InstanceBase(string name, string sid)
        {
            this.name = name;
            this.sid = sid;
        }



        [Serializable()]
        [XmlType(Namespace = Collada.XMLNAMESPACE, TypeName = XmlTypeNameBase + "WithUrl")]
        public abstract partial class WithUrl : InstanceBase
        {
            [XmlAttribute(DataType = "anyURI")]
            public string url // url contain references to other local object like #[id] or the absolute uri for external objects
            { get; set; } = string.Empty;


            // constructors
            public WithUrl() { }

            public WithUrl(string name, string sid, string url)
            {
                this.name = name;
                this.sid = sid;
                this.url = url;
            }
        }
    }

}
