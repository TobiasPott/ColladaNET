using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace ColladaNET.Elements
{

    [Serializable()]

    [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
    [XmlRoot(Namespace = Collada.XMLNAMESPACE, IsNullable = false)]
    public partial class LibraryPhysicsMaterials : LibraryBase<PhysicsMaterial>
    {

        [XmlElement("physics_material")]
        public List<PhysicsMaterial> physics_material
        {
            get { return this._items; }
            set { this._items = value; }
        }

        // constructors
        public LibraryPhysicsMaterials() { }

        public LibraryPhysicsMaterials(string id, string name)
            : base(id, name)
        { }

        public LibraryPhysicsMaterials(string id, string name, PhysicsMaterial[] physicsMaterials)
            : base(id, name)
        { this._items.AddRange(physicsMaterials); }

        public LibraryPhysicsMaterials(PhysicsMaterial[] physicsMaterials)
        { this._items.AddRange(physicsMaterials); }

    }

}
