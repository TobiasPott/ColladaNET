using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace ColladaNET.Elements
{


    [Serializable()]

    [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
    [XmlRoot(Namespace = Collada.XMLNAMESPACE, IsNullable = false)]
    public partial class LibraryAnimations : LibraryBase<Animation>
    {

        [XmlElement("animation")]
        public List<Animation> animation
        {
            get { return this._items; }
            set { this._items = value; }
        }

        // constructors
        public LibraryAnimations() { }

        public LibraryAnimations(string id, string name)
            : base(id, name)
        { }

        public LibraryAnimations(string id, string name, Animation[] animations)
            : base(id, name)
        { this._items.AddRange(animations); }

        public LibraryAnimations(Animation[] animations)
        { this._items.AddRange(animations); }

    }
}