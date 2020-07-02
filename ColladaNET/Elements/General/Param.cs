using System;
using System.Xml.Serialization;

namespace ColladaNET.Elements
{
    [Serializable()]
    [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
    [XmlRoot(Namespace = Collada.XMLNAMESPACE, IsNullable = false)]
    public partial class Param : AtomicBase
    {
        [XmlAttribute(DataType = "NCName")]
        public string name
        { get; set; }

        [XmlAttribute(DataType = "NCName")]
        public string sid
        { get; set; }

        [XmlAttribute(DataType = "NMTOKEN")]
        public string semantic
        { get; set; }

        [XmlAttribute(DataType = "NMTOKEN")]
        public string type
        { get; set; }

        [XmlTextAttribute()]
        public string value
        { get; set; }



        // constructors
        public Param() { }

        public Param(string type)
        { this.type = type; }

        public Param(string type, string name)
            : this(type)
        { this.name = name; }

        public Param(string type, string name, string sid)
            : this(type, name)
        { this.sid = sid; }

        public Param(string type, string name, string sid, string semantic)
            : this(type, name, sid)
        { this.semantic = semantic; }

        public Param(string sid, string name, string semantic, string type, string val)
            : this(type, name, sid, semantic)
        { this.value = val; }
    }

}
