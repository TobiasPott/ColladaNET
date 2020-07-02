using System;
using System.ComponentModel;
using System.Xml.Serialization;

namespace ColladaNET.Elements
{

    [Serializable()]
    [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
    [XmlRoot(Namespace = Collada.XMLNAMESPACE, IsNullable = false)]
    public partial class IntArray : ArrayBase<int>
    {

        [XmlAttribute(DataType = "integer")]
        [DefaultValueAttribute("-2147483648")]
        public string minInclusive
        { get; set; }

        [XmlAttribute(DataType = "integer")]
        [DefaultValueAttribute("2147483647")]
        public string maxInclusive
        { get; set; }


        // constructors
        public IntArray()
        {
            this.minInclusive = "-2147483648";
            this.maxInclusive = "2147483647";
        }

        public IntArray(int[] values) : this()
        {
            this.count = (ulong)values.Length;
            this.values = values;
        }

        public IntArray(string id, int[] values) : this(values)
        { this.id = id; }


        // implementation of ArrayBase<T> class
        protected override string GetValuesAsString()
        { return Utilities.FromArray(values); }

        protected override void SetValuesFromString(string value)
        { values = Utilities.ToIntArray(value); }
    }


}
