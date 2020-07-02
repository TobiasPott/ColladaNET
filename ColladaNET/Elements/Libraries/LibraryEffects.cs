using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace ColladaNET.Elements
{

    [Serializable()]

    [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
    [XmlRoot(Namespace = Collada.XMLNAMESPACE, IsNullable = false)]
    public partial class LibraryEffects : LibraryBase<Effect>
    {

        [XmlElement("effect")]
        public List<Effect> effect
        {
            get { return this._items; }
            set { this._items = value; }
        }

        // constructors
        public LibraryEffects() { }

        public LibraryEffects(string id, string name)
            : base(id, name)
        { }

        public LibraryEffects(string id, string name, Effect[] effects)
            : base(id, name)
        { this._items.AddRange(effects); }

        public LibraryEffects(Effect[] effects)
        { this._items.AddRange(effects); }

    }
}