using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace ColladaNET.Elements
{


    [Serializable()]

    [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
    [XmlRoot(Namespace = Collada.XMLNAMESPACE, IsNullable = false)]
    public partial class LibraryForceFields : LibraryBase<ForceField>
    {

        [XmlElement("force_field")]
        public List<ForceField> Force_field
        {
            get { return this._items; }
            set { this._items = value; }
        }

        // constructors
        public LibraryForceFields() { }

        public LibraryForceFields(string id, string name)
            : base(id, name)
        { }

        public LibraryForceFields(string id, string name, ForceField[] forceFields)
            : base(id, name)
        { this._items.AddRange(forceFields); }

        public LibraryForceFields(ForceField[] forceFields)
        { this._items.AddRange(forceFields); }

    }
}