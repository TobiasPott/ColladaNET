using System;
using System.Xml.Serialization;

namespace ColladaNET.Elements
{
    [Serializable()]
    [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
    [XmlRoot(Namespace = Collada.XMLNAMESPACE, IsNullable = false)]
    public partial class Translate : TransformationBase
    {
        [XmlIgnore()]
        public float X => this.values[0];
        [XmlIgnore()]
        public float Y => this.values[1];
        [XmlIgnore()]
        public float Z => this.values[2];

        // constructors 
        public Translate()
        { }
        public Translate(string sid = "translate", float x = 0.0f, float y = 0.0f, float z = 0.0f) : base(sid, x, y, z)
        { }


        public override string ToString()
        { return string.Format("{0}, {1}, {2}", this.values[0], this.values[1], this.values[2]); }

    }


    [Serializable()]
    [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
    [XmlRoot(Namespace = Collada.XMLNAMESPACE, IsNullable = false)]
    public partial class Rotate : TransformationBase
    {
        // constructors
        public Rotate()
        { }
        public Rotate(string sid = "rotate", float x = 0.0f, float y = 1.0f, float z = 0.0f, float w = 0.0f) : base(sid, x, y, z, w)
        { }

    }


    [Serializable()]
    [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
    [XmlRoot(Namespace = Collada.XMLNAMESPACE, IsNullable = false)]
    public partial class Scale : TransformationBase
    {
        [XmlIgnore()]
        public float X => this.values[0];
        [XmlIgnore()]
        public float Y => this.values[1];
        [XmlIgnore()]
        public float Z => this.values[2];

        // constructors  
        public Scale()
        { }
        public Scale(string sid = "scale", float x = 1.0f, float y = 1.0f, float z = 1.0f) : base(sid, x, y, z)
        { }
        public Scale(string sid = "scale", float xyz = 1.0f) : base(sid, xyz, xyz, xyz)
        { }
    }


    [Serializable()]
    [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
    [XmlRoot(Namespace = Collada.XMLNAMESPACE, IsNullable = false)]
    public partial class Skew : TransformationBase
    {
        // constructors
        public Skew()
        { }
        public Skew(string sid = "skew", float angle = 0.0f, float rotationX = 0.0f, float rotationY = 1.0f, float rotationZ = 0.0f, float translateX = 0.0f, float translateY = 0.0f, float translateZ = 0.0f)
            : base(sid, angle, rotationX, rotationY, rotationZ, translateX, translateY, translateZ)
        { }
    }


    [Serializable()]
    [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
    [XmlRoot(Namespace = Collada.XMLNAMESPACE, IsNullable = false)]
    public partial class Matrix : TransformationBase
    {
        private static readonly float[] IdentityMatrixValues = new float[] {/*row1*/1, 0, 0, 0, /*row2*/0, 1, 0, 0, /*row3*/0, 0, 1, 0, /*row4*/0, 0, 0, 1 };
        // ! ! ! !
        // add identity matrix field to class

        // constructors
        public Matrix()
        { }
        public Matrix(string sid = "matrix") : base(sid, IdentityMatrixValues)
        { }
        public Matrix(string sid = "matrix", float[] values = null) : base(sid)
        {
            if (values == null)
                this.SetValues(IdentityMatrixValues);
            else
                this.SetValues(values);
        }

    }


    [Serializable()]
    [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
    [XmlRoot(Namespace = Collada.XMLNAMESPACE, IsNullable = false)]
    public partial class LookAt : TransformationBase
    {
        [XmlIgnore()]
        public float X => this.values[0];
        [XmlIgnore()]
        public float Y => this.values[1];
        [XmlIgnore()]
        public float Z => this.values[2];

        [XmlIgnore()]
        public float LookAtX => this.values[3];
        [XmlIgnore()]
        public float LookAtY => this.values[4];
        [XmlIgnore()]
        public float LookAtZ => this.values[5];

        [XmlIgnore()]
        public float UpX => this.values[6];
        [XmlIgnore()]
        public float UpY => this.values[7];
        [XmlIgnore()]
        public float UpZ => this.values[8];


        // constructors        
        public LookAt()
        { }
        public LookAt(string sid = "lookat", float x = 0.0f, float y = 0.0f, float z = 0.0f, float lookAtX = 0.0f, float lookAtY = 1.0f, float lookAtZ = 0.0f, float upX = 0.0f, float upY = 1.0f, float upZ = 0.0f)
            : base(sid, x, y, z, lookAtX, lookAtY, lookAtZ, upX, upY, upZ)
        { }

    }

    [Serializable()]
    [XmlType(Namespace = Collada.XMLNAMESPACE)]
    //[XmlRoot("scale", Namespace = Collada.XMLNAMESPACE, IsNullable = false)]
    [XmlRoot(Namespace = Collada.XMLNAMESPACE, IsNullable = false)]
    public partial class TargetableFloat3 : TransformationBase
    {
        // constructors        
        public TargetableFloat3()
        { }
        public TargetableFloat3(string sid = "", float x = 0.0f, float y = 0.0f, float z = 0.0f) : base(sid, x, y, z)
        { }
        public TargetableFloat3(string sid = "", float xyz = 0.0f) : base(sid, xyz, xyz, xyz)
        { }



        public override string ToString()
        { return string.Format("{0}, {1}, {2}", this.values[0], this.values[1], this.values[2]); }

    }

}
