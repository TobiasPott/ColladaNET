using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Xml.Serialization;

namespace ColladaNET.Elements
{
    [Serializable()]
    [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
    [XmlRoot(Namespace = Collada.XMLNAMESPACE, IsNullable = false)]
    public partial class AnimationClip : LibraryItemBase
    {
        [XmlElement("instance_animation")]
        public InstanceAnimation[] instance_animation
        { get; set; }

        [XmlAttribute()]
        [DefaultValueAttribute(0)]
        public float start
        { get; set; }

        [XmlAttribute()]
        public float end
        { get; set; }

        [XmlIgnoreAttribute()]
        public bool endSpecified
        { get; set; }


        // constructors
        public AnimationClip()
        {
            this.start = 0f;
        }

    }

}
