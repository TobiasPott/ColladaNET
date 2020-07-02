using System;
using System.Xml.Serialization;

namespace ColladaNET.Elements
{
    [Serializable()]
    [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
    [XmlRoot(Namespace = Collada.XMLNAMESPACE, IsNullable = false)]
    public partial class Animation : LibraryItemBase
    {

        [XmlElement("animation", typeof(Animation))]
        public Animation[] animations
        { get; set; } = null;
        [XmlElement("channel", typeof(Channel))]
        public Channel[] channels
        { get; set; } = null;
        [XmlElement("sampler", typeof(Sampler))]
        public Sampler[] samplers
        { get; set; } = null;
        [XmlElement("source", typeof(Source))]
        public Source[] sources
        { get; set; } = null;


        [XmlIgnore()]
        public int NumberOfAnimations
        { get { return animations != null ? animations.Length : 0; } }
        [XmlIgnore()]
        public int NumberOfChannels
        { get { return channels != null ? channels.Length : 0; } }
        [XmlIgnore()]
        public int NumberOfSamplers
        { get { return samplers != null ? samplers.Length : 0; } }
        [XmlIgnore()]
        public int NumberOfSources
        { get { return sources != null ? sources.Length : 0; } }

    }

}
