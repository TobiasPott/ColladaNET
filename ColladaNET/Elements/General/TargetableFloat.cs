using System;
using System.Xml.Serialization;

namespace ColladaNET.Elements
{
    [Serializable()]
    [XmlType(Namespace = Collada.XMLNAMESPACE)]
    [XmlRoot(Namespace = Collada.XMLNAMESPACE, IsNullable = true)]
    public partial class TargetableFloat
    {

        [XmlAttribute(DataType = "NCName")]
        public string sid
        { get; set; }

        [XmlTextAttribute()]
        public float value
        { get; set; }


        public TargetableFloat()
        { }
        public TargetableFloat(string sid, float value)
        {
            this.sid = sid;
            this.value = value;
        }


        // implicit operator overloading
        public static implicit operator float(TargetableFloat f)  // implicit digit to byte conversion operator
        { return f.value; }

    }
}