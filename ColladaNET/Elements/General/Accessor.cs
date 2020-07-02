using System;
using System.ComponentModel;
using System.Xml.Serialization;

namespace ColladaNET.Elements
{

    [Serializable()]
    [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
    [XmlRoot(Namespace = Collada.XMLNAMESPACE, IsNullable = false)]
    public partial class Accessor
    {

        [XmlElement("param")]
        public Param[] param
        { get; set; }

        [XmlAttribute()]
        public ulong count
        { get; set; }

        [XmlAttribute()]
        [DefaultValueAttribute(typeof(ulong), "0")]
        public ulong offset
        { get; set; } = 0;

        [XmlAttribute(DataType = "anyURI")]
        public string source
        { get; set; }

        [XmlAttribute()]
        [DefaultValueAttribute(typeof(ulong), "1")]
        public ulong stride
        { get; set; } = 1;


        // constructors
        public Accessor()
        {
            this.offset = 0;
            this.stride = 0;
        }

        public Accessor(ulong count, string source)
            : this()
        {
            this.count = count;
            this.source = source;
        }

        public Accessor(ulong count, string source, Param[] param)
            : this(count, source)
        { this.param = param; }

        public Accessor(ulong count, string source, ulong offset, ulong stride)
            : this(count, source)
        {
            this.offset = offset;
            this.stride = stride;
        }

        public Accessor(ulong count, string source, ulong offset, ulong stride, Param[] param)
            : this(count, source, offset, stride)
        { this.param = param; }

    }

}
