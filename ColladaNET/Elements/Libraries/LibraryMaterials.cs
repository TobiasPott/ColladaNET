using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace ColladaNET.Elements
{

    [Serializable()]
    [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
    [XmlRoot(Namespace = Collada.XMLNAMESPACE, IsNullable = false)]
    public partial class LibraryMaterials : LibraryBase<Material>
    {

        [XmlElement("material")]
        public List<Material> material
        {
            get { return this._items; }
            set { this._items = value; }
        }

        // constructors
        public LibraryMaterials() { }

        public LibraryMaterials(string id, string name)
            : base(id, name)
        { }

        public LibraryMaterials(string id, string name, Material[] materials)
            : base(id, name)
        { this._items.AddRange(materials); }

        public LibraryMaterials(Material[] materials)
        { this._items.AddRange(materials); }

    }

}
