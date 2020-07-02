using System;
using System.Xml.Serialization;

namespace ColladaNET.Elements
{
    [Serializable()]
    [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
    [XmlRoot(Namespace = Collada.XMLNAMESPACE, IsNullable = false)]
    public abstract partial class PrimitiveBase
    {
        [XmlElement("input")]
        public InputOffset[] input
        { get; set; }

        [XmlElement("extra")]
        public Extra[] extra
        { get; set; }

        [XmlAttribute(DataType = "NCName")]
        public string name
        { get; set; }

        [XmlAttribute()]
        public ulong count
        { get; set; }

        [XmlAttribute(DataType = "NCName")]
        public string material
        { get; set; }

    }

    [Serializable()]
    [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
    [XmlRoot(Namespace = Collada.XMLNAMESPACE, IsNullable = false)]
    public abstract partial class Primitive<T> : PrimitiveBase where T : Indices
    {
        [XmlElement("p")]
        public T p
        { get; set; }
    }
    [Serializable()]
    [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
    [XmlRoot(Namespace = Collada.XMLNAMESPACE, IsNullable = false)]
    public abstract partial class PrimitiveArray<T> : PrimitiveBase where T : Indices
    {
        [XmlElement("p")]
        public T[] p
        { get; set; }
    }
    [Serializable()]
    [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
    public partial class Indices
    {
        [XmlText()]
        public string rawIndices
        {
            get { return indices?.ToString(); }
            set
            {
                indices.Clear();
                indices.Append(value);
            }
        }

        [XmlIgnore]
        public System.Text.StringBuilder indices
        { get; set; } = new System.Text.StringBuilder();

    }
    [Serializable()]
    [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
    public partial class IndicesWithHoles
    {
        [XmlElement("p")]
        public string rawIndices
        {
            get { return indices?.ToString(); }
            set
            {
                indices.Clear();
                indices.Append(value);
            }
        }

        [XmlIgnore]
        public System.Text.StringBuilder indices
        { get; set; } = new System.Text.StringBuilder();

        [XmlElement("h")]
        public Indices[] holes
        { get; set; }

    }

}