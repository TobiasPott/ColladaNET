using System.Xml.Serialization;

namespace ColladaNET.Elements
{
    public abstract partial class ElementBase
    {
        public const string XmlTypeNameBase = "Element.";


        [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE, TypeName = XmlTypeNameBase + "Id")]
        public abstract class Id : ElementBase
        {
            [XmlAttribute(DataType = "ID")]
            public string id
            { get; set; } = string.Empty;
        }

        [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE, TypeName = XmlTypeNameBase + "IdName")]
        public abstract class IdName : Id
        {
            [XmlAttribute(DataType = "NCName")]
            public string name
            { get; set; } = string.Empty;
        }

        [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE, TypeName = XmlTypeNameBase + "IdNameType")]
        public abstract class IdNameType : IdName
        {
            [XmlAttribute(DataType = "NMTOKEN")]
            public string type
            { get; set; }
        }

        /*
        {
            [XmlElement("extra")]
            public Extra[] extra
            { get; set; } = null;
        }
        {
            [XmlElement("input")] // LocalInput or LocalInputOffset
            public T[] input
            { get; set; }
        }
        {
            [XmlElement()]
            public Asset asset
            { get; set; } = null;
        }
        {
            [XmlElement("technique")]
            public Technique[] technique
            { get; set; } = null;
        }
        */

    }

}
