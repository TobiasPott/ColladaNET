using System;
using System.ComponentModel;
using System.Xml.Serialization;

namespace ColladaNET.Elements
{

    [Serializable()]
    [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
    [XmlRoot(Namespace = Collada.XMLNAMESPACE, IsNullable = false)]
    public partial class FloatArray : ArrayBase<float>
    {

        [XmlAttribute()]
        [DefaultValueAttribute(typeof(short), "1")]
        public short digits
        { get; set; }

        [XmlAttribute()]
        [DefaultValueAttribute(typeof(short), "38")]
        public short magnitude
        { get; set; }


        // constructors
        public FloatArray()
        {
            this.digits = ((short)(1));
            this.magnitude = ((short)(38));
        }

        public FloatArray(float[] values) : this()
        {
            this.count = (ulong)values.Length;
            this.values = values;
        }

        public FloatArray(string id, float[] values) : this(values)
        { this.id = id; }


        // implementation of ArrayBase<T> class
        protected override string GetValuesAsString()
        { return Utilities.FromArray(values); }

        protected override void SetValuesFromString(string value)
        { values = Utilities.ToFloatArray(value); }
    }

}
