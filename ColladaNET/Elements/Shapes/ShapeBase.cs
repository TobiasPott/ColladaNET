using System;
using System.Xml.Serialization;

namespace ColladaNET.Elements
{

    public abstract class Shape
    {
        public const string XmlTypeNameBase = "Shape.";

        [Serializable()]
        [XmlType(Namespace = Collada.XMLNAMESPACE, TypeName = XmlTypeNameBase + "Base")]
        public abstract partial class Base
        {
            [XmlElement("extra")]
            public Extra[] extra
            { get; set; }

        }

    }
}
