using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;

namespace ColladaNET.Elements
{
    
    [Serializable()]
    [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
    [XmlRoot(Namespace = Collada.XMLNAMESPACE, IsNullable = false)]
    public partial class LibraryCameras : LibraryBase<Camera>
    {

        [XmlElement("camera")]
        public List<Camera> camera
        {
            get { return this._items; }
            set { this._items = value; }
        }

        // constructors
        public LibraryCameras() { }

        public LibraryCameras(string id, string name)
            : base(id, name)
        { }

        public LibraryCameras(string id, string name, Camera[] cameras)
            : base(id, name)
        { this._items.AddRange(cameras); }

        public LibraryCameras(Camera[] cameras)
        { this._items.AddRange(cameras); }

    }

}
