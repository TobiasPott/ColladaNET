using System;
using System.Xml.Serialization;

namespace ColladaNET.Elements
{

    [Serializable()]
    [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
    [XmlRoot(Namespace = Collada.XMLNAMESPACE, IsNullable = false)]
    public partial class NameArray : ArrayBase<string>
    {

        // constructors
        public NameArray() { }

        public NameArray(string[] values) : this()
        {
            this.count = (ulong)values.Length;
            this.values = values;
        }

        public NameArray(string id, string[] values) : this(values)
        { this.id = id; }


        // implementation of ArrayBase<T> class
        protected override string GetValuesAsString()
        { return Utilities.FromArray(values); }

        protected override void SetValuesFromString(string value)
        { values = Utilities.ToStringArray(value); }
    }

}
