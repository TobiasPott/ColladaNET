using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace ColladaNET.Elements
{


    [Serializable()]

    [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
    [XmlRoot(Namespace = Collada.XMLNAMESPACE, IsNullable = false)]
    public partial class LibraryPhysicsScenes : LibraryBase<PhysicsScene>
    {

        [XmlElement("physics_scene")]
        public List<PhysicsScene> Physics_scene
        {
            get { return this._items; }
            set { this._items = value; }
        }

        // constructors
        public LibraryPhysicsScenes() { }

        public LibraryPhysicsScenes(string id, string name)
            : base(id, name)
        { }

        public LibraryPhysicsScenes(string id, string name, PhysicsScene[] physicsScenes)
            : base(id, name)
        { this._items.AddRange(physicsScenes); }

        public LibraryPhysicsScenes(PhysicsScene[] physicsScenes)
        { this._items.AddRange(physicsScenes); }

    }

}
