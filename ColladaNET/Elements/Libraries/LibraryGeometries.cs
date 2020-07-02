using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace ColladaNET.Elements
{


    [Serializable()]

    [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
    [XmlRoot(Namespace = Collada.XMLNAMESPACE, IsNullable = false)]
    public partial class LibraryGeometries : LibraryBase<Geometry>
    {

        [XmlElement("geometry")]
        public List<Geometry> geometry
        {
            get { return this._items; }
            set { this._items = value; }
        }

        // constructors
        public LibraryGeometries() { }

        public LibraryGeometries(string id, string name)
            : base(id, name)
        { }

        public LibraryGeometries(string id, string name, Geometry[] geometries)
            : base(id, name)
        { this._items.AddRange(geometries); }

        public LibraryGeometries(Geometry[] geometries)
        { this._items.AddRange(geometries); }

    }

}
