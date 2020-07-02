using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace ColladaNET.Elements
{


    [Serializable()]

    [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
    [XmlRoot(Namespace = Collada.XMLNAMESPACE, IsNullable = false)]
    public partial class LibraryControllers : LibraryBase<Controller>
    {

        [XmlElement("controller")]
        public List<Controller> controller
        {
            get { return this._items; }
            set { this._items = value; }
        }

        // constructors
        public LibraryControllers() { }

        public LibraryControllers(string id, string name)
            : base(id, name)
        { }

        public LibraryControllers(string id, string name, Controller[] controllers)
            : base(id, name)
        { this._items.AddRange(controllers); }

        public LibraryControllers(Controller[] controllers)
        { this._items.AddRange(controllers); }

    }
}