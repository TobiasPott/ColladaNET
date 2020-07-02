using System;
using System.Xml.Serialization;

namespace ColladaNET.Elements
{
    [Serializable()]
    [XmlType(Namespace = Collada.XMLNAMESPACE)]
    [XmlRoot(Namespace = Collada.XMLNAMESPACE, IsNullable = true)]
    public partial class Input : AtomicBase
    {
        [XmlAttribute(DataType = "NMTOKEN")]
        public string semantic
        { get; set; }

        [XmlAttribute()]
        public string source
        { get; set; }

        // constructors
        public Input() { }

        public Input(string semantic, string source)
        {
            this.semantic = semantic;
            this.source = source;
        }


        public static Input CreateWithSemantic(string name, Semantic semantic)
        {
            switch (semantic)
            {
                case Semantic.JOINT:
                    return new Input("JOINT", "#" + name + "-Joints");
                case Semantic.WEIGHT:
                    return new Input("WEIGHT", "#" + name + "-Weights");
                case Semantic.INV_BIND_MATRIX:
                    return new Input("INV_BIND_MATRIX", "#" + name + "-Matrices");
            }

            return null;
        }

    }

    [Serializable()]
    [XmlType(Namespace = Collada.XMLNAMESPACE)]
    [XmlRoot(Namespace = Collada.XMLNAMESPACE, IsNullable = true)]
    public partial class InputOffset : Input
    {
        [XmlAttribute()]
        public ulong offset
        { get; set; } = 0;

        [XmlAttribute()]
        public ulong set
        { get; set; }

        [XmlIgnoreAttribute()]
        public bool setSpecified
        { get; set; }


        // constructors
        public InputOffset()
        { }
        public InputOffset(string semantic, string source, ulong offset = 0) : base(semantic, source)
        {
            this.offset = offset;
        }
        public InputOffset(string semantic, string source, ulong offset, ulong set)
            : this(semantic, source, offset)
        {
            this.set = set;
            this.setSpecified = true;
        }


        public static InputOffset CreateWithSemantic(string name, Semantic semantic, ulong dataSource, ulong set = 0, ulong offset = 0)
        {
            switch (semantic)
            {
                case Semantic.VERTEX:
                    return new InputOffset("VERTEX", "#" + name + "-VERTEX", offset);
                case Semantic.NORMAL:
                    return new InputOffset("NORMAL", "#" + name + "-Normal" + dataSource, offset);
                case Semantic.TEXCOORD:
                    return new InputOffset("TEXCOORD", "#" + name + "-UV" + dataSource, offset, set);
                case Semantic.COLOR:
                    return new InputOffset("COLOR", "#" + name + "-VERTEX_COLOR" + dataSource, offset, set);
                case Semantic.JOINT:
                    return new InputOffset("JOINT", "#" + name + "-Joints", offset);
                case Semantic.WEIGHT:
                    return new InputOffset("WEIGHT", "#" + name + "-Weights", offset);
                case Semantic.INV_BIND_MATRIX:
                    return new InputOffset("INV_BIND_MATRIX", "#" + name + "-Matrices", offset);
            }

            return null;
        }
    }

}
