using System;
using System.Xml.Serialization;

namespace ColladaNET.Elements
{

    [Serializable()]
    [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
    [XmlRoot(Namespace = Collada.XMLNAMESPACE, IsNullable = false)]
    public partial class IDREFArray : ArrayBase
    {
        [XmlTextAttribute(DataType = "IDREFS")]
        public string value
        { get; set; }


        // constructors
        public IDREFArray() { }

        public IDREFArray(ulong count, string val) : this()
        {
            this.count = count;
            this.value = val;
        }

        public IDREFArray(string id, ulong count, string val) : this(count, val)
        { this.id = id; }
    }
}