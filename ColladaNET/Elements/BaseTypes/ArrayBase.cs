using System;
using System.Xml.Serialization;

namespace ColladaNET.Elements
{

    [Serializable()]
    [XmlRoot(Namespace = Collada.XMLNAMESPACE, IsNullable = false)]
    public abstract class ArrayBase : AtomicBase
    {
        [XmlAttribute(DataType = "ID")]
        public string id
        { get; set; }

        [XmlAttribute(DataType = "NCName")]
        public string name
        { get; set; }

        [XmlAttribute()]
        public ulong count
        { get; set; }

    }

    public abstract class ArrayBase<T> : ArrayBase
    {
        [XmlText()]
        public string text
        {
            get { return GetValuesAsString(); }
            set { SetValuesFromString(value); }
        }

        [XmlIgnore]
        public T[] values
        { get; set; } = null;


        protected abstract string GetValuesAsString();
        protected abstract void SetValuesFromString(string value);

    }


    public abstract class TransformationBase : ArrayBase<float>
    {
        [XmlAttribute(DataType = "NCName")]
        public string sid
        { get; set; }

        public int Count
        { get { return values != null ? values.Length : 0; } }

        public float this[int index]
        {
            get { return values[index]; }
            set { values[index] = value; }
        }


        // constructors
        protected TransformationBase()
        { }
        protected TransformationBase(string sid, params float[] values)
        {
            this.sid = sid;
            this.SetValues(values);
        }


        protected void SetValues(params float[] values)
        {
            float[] valArray = this.values;
            if (valArray == null)
                valArray = new float[values.Length];
            else if (valArray.Length != values.Length)
                Array.Resize(ref valArray, values.Length);
            Array.Copy(values, valArray, valArray.Length);
            this.values = valArray;
        }


        // implicit operator overloading
        public static implicit operator float[] (TransformationBase f)  // implicit digit to byte conversion operator
        { return f.values; }


        // implementation of ArrayBase<T> class
        protected override string GetValuesAsString()
        { return Utilities.FromArray(values); }

        protected override void SetValuesFromString(string value)
        { values = Utilities.ToFloatArray(value); }

    }
}
