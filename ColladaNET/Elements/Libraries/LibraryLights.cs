using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace ColladaNET.Elements
{

    [Serializable()]
    [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
    [XmlRoot(Namespace = Collada.XMLNAMESPACE, IsNullable = false)]
    public partial class LibraryLights : LibraryBase<Light>
    {

        [XmlElement("light")]
        public List<Light> light
        {
            get { return this._items; }
            set { this._items = value; }
        }

        // constructors
        public LibraryLights() { }

        public LibraryLights(string id, string name)
            : base(id, name)
        { }

        public LibraryLights(string id, string name, Light[] lights)
            : base(id, name)
        { this._items.AddRange(lights); }

        public LibraryLights(Light[] lights)
        { this._items.AddRange(lights); }

    }

}