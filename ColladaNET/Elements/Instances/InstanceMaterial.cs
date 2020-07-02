using System;
using System.Xml.Serialization;

namespace ColladaNET
{

    [Serializable()]
    [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
    [XmlRoot("instance_material", Namespace = Collada.XMLNAMESPACE, IsNullable = false)]
    public partial class InstanceMaterial : InstanceBase
    {
        [XmlElement("bind")]
        public Bind[] bind
        { get; set; }

        [XmlElement("bind_vertex_input")]
        public VertexInput[] bind_vertex_input
        { get; set; }

        [XmlAttribute(DataType = "NCName")]
        public string symbol
        { get; set; }

        [XmlAttribute(DataType = "anyURI")]
        public string target
        { get; set; }



        // constructors
        public InstanceMaterial() { }

        public InstanceMaterial(string symbol, string target)
        {
            this.symbol = symbol;
            this.target = target;
        }

        public InstanceMaterial(string symbol, string target, string sid, string name)
            : this(symbol, target)
        {
            this.sid = sid;
            this.name = name;
        }


        // member classes
        #region Bind
        [Serializable()]
        [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
        public partial class Bind
        {
            [XmlAttribute(DataType = "NCName")]
            public string semantic
            { get; set; }

            [XmlAttribute(DataType = "token")]
            public string target
            { get; set; }
        }
        #endregion

        #region VertexInput
        [Serializable()]
        [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
        public partial class VertexInput
        {
            [XmlAttribute(DataType = "NCName")]
            public string semantic
            { get; set; }

            [XmlAttribute(DataType = "NCName")]
            public string input_semantic
            { get; set; }

            [XmlAttribute()]
            public ulong input_set
            { get; set; }

            [XmlIgnoreAttribute()]
            public bool input_setSpecified
            { get; set; }
        }
        #endregion
    }

}
