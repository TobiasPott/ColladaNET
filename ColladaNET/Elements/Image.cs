using System;
using System.ComponentModel;
using System.Xml.Serialization;

namespace ColladaNET
{
    [Serializable()]
    [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
    [XmlRoot(Namespace = Collada.XMLNAMESPACE, IsNullable = false)]
    public partial class Image : LibraryItemBase
    {
        public enum ImageSources
        {
            Data,
            Init_From
        }


        [XmlElement("data", typeof(byte[]), DataType = "hexBinary")]
        public byte[] data
        { get; set; } = null;

        [XmlElement("init_from", typeof(string), DataType = "anyURI")]
        public string init_from
        { get; set; } = "";

        [XmlAttribute(DataType = "token")]
        public string format
        { get; set; }

        [XmlAttribute()]
        public ulong height
        { get; set; }

        [XmlAttribute()]
        public ulong width
        { get; set; }

        [XmlAttribute()]
        [DefaultValueAttribute(typeof(ulong), "1")]
        public ulong depth
        { get; set; }


        [XmlIgnore()]
        public ImageSources ImageSource
        { get { return data == null ? ImageSources.Init_From : ImageSources.Data; } }





        // constructors
        public Image()
        { this.depth = 1ul; }

        public Image(string id, string name, string init_from)
            : this()
        {
            this.id = id;
            this.name = name;
            this.init_from = init_from;
        }

    }

}
