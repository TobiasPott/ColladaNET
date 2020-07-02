using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace ColladaNET.Elements
{
    [Serializable()]
    [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
    [XmlRoot(Namespace = Collada.XMLNAMESPACE, IsNullable = false)]
    public partial class LibraryImages : LibraryBase<Image>
    {

        [XmlElement("image")]
        public List<Image> image
        {
            get { return this._items; }
            set { this._items = value; }
        }

        // constructors
        public LibraryImages() { }

        public LibraryImages(string id, string name)
            : base(id, name)
        { }

        public LibraryImages(string id, string name, Image[] images)
            : base(id, name)
        { this._items.AddRange(images); }

        public LibraryImages(Image[] images)
        { this._items.AddRange(images); }

    }
}