using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Xml.Serialization;

namespace ColladaNET.Elements
{

    [Serializable()]
    [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
    [XmlRoot(Namespace = Collada.XMLNAMESPACE, IsNullable = false)]
    public partial class Morph
    {
        public Morph()
        {
            this.method = MorphMethodType.NORMALIZED;
        }

        [XmlElement("source")]
        public Source[] source
        { get; set; }

        [XmlElement()]
        public MorphTargets targets
        { get; set; }

        [XmlElement("extra")]
        public Extra[] extra
        { get; set; }

        [XmlAttribute()]
        [DefaultValueAttribute(MorphMethodType.NORMALIZED)]
        public MorphMethodType method
        { get; set; }

        [XmlAttribute("source", DataType = "anyURI")]
        public string source1
        { get; set; }
    }
}
