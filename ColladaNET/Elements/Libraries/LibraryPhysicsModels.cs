using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace ColladaNET.Elements
{

    [Serializable()]

    [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
    [XmlRoot(Namespace = Collada.XMLNAMESPACE, IsNullable = false)]
    public partial class LibraryPhysicsModels : LibraryBase<PhysicsModel>
    {

        [XmlElement("physics_model")]
        public List<PhysicsModel> Physics_model
        {
            get { return this._items; }
            set { this._items = value; }
        }

        // constructors
        public LibraryPhysicsModels() { }

        public LibraryPhysicsModels(string id, string name)
            : base(id, name)
        { }

        public LibraryPhysicsModels(string id, string name, PhysicsModel[] physicsModels)
            : base(id, name)
        { this._items.AddRange(physicsModels); }

        public LibraryPhysicsModels(PhysicsModel[] physicsModels)
        { this._items.AddRange(physicsModels); }

    }
}