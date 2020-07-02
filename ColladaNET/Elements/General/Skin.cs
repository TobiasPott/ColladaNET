using System;
using System.Xml.Serialization;

namespace ColladaNET.Elements
{
    [Serializable()]
    [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
    [XmlRoot(Namespace = Collada.XMLNAMESPACE, IsNullable = false)]
    public partial class Skin
    {
        [XmlElement()]
        public string bind_shape_matrix
        { get; set; }

        [XmlElement("source")]
        public Source[] sources
        { get; set; }

        [XmlElement()]
        public Joints joints
        { get; set; }

        [XmlElement()]
        public VertexWeights vertex_weights
        { get; set; }

        [XmlElement("extra")]
        public Extra[] extra
        { get; set; }

        [XmlAttribute("source", DataType = "anyURI")]
        public string source
        { get; set; }


        public Skin()
        { }

        public Skin(string source, Joints joints, VertexWeights vertexWeights)
        {
            this.source = source;
            this.joints = joints;
            this.vertex_weights = vertexWeights;
        }

        // member classes
        #region Joints
        [Serializable()]
        [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
        public partial class Joints
        {
            [XmlElement("input")]
            public Input[] input
            { get; set; }

            [XmlElement("extra")]
            public Extra[] extra
            { get; set; }



            public Joints()
            { }

            public Joints(Input[] inputs)
            { this.input = inputs; }

            public Joints(Input[] inputs, Extra[] extras)
                : this(inputs)
            { this.extra = extras; }


        }
        #endregion

        #region VertexWeights
        [Serializable()]
        [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
        public partial class VertexWeights
        {
            [XmlElement("input")]
            public InputOffset[] input
            { get; set; }

            [XmlElement()]
            public string vcount
            { get; set; }

            [XmlElement()]
            public string v
            { get; set; }

            [XmlElement("extra")]
            public Extra[] extra
            { get; set; }

            [XmlAttribute()]
            public ulong count
            { get; set; }



            public VertexWeights()
            { }
            public VertexWeights(InputOffset[] inputs)
            { this.input = inputs; }


        }
        #endregion

    }

}
