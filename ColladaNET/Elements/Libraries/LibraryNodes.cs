using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace ColladaNET.Elements
{

    [Serializable()]
    [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
    [XmlRoot(Namespace = Collada.XMLNAMESPACE, IsNullable = false)]
    public partial class LibraryNodes : LibraryBase<Node>
    {

        [XmlElement("node")]
        public List<Node> Node
        {
            get { return this._items; }
            set { this._items = value; }
        }

        // constructors
        public LibraryNodes() { }

        public LibraryNodes(string id, string name)
            : base(id, name)
        { }

        public LibraryNodes(string id, string name, Node[] nodes)
            : base(id, name)
        { this._items.AddRange(nodes); }

        public LibraryNodes(Node[] nodes)
        { this._items.AddRange(nodes); }

    }

}
