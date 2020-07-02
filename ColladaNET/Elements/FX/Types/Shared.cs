using ColladaNET.Elements;
using ColladaNET.FX.Profiles;
using System;
using System.ComponentModel;
using System.Xml.Serialization;

namespace ColladaNET.FX.Types
{

    [Serializable()]
    [XmlType(Namespace = Collada.XMLNAMESPACE)]
    [XmlRoot(Namespace = Collada.XMLNAMESPACE, IsNullable = true)]
    public abstract class ValueBase<T>
    {
        public ValueBase()
        { this.index = 0; }

        [XmlAttribute(DataType = "unsignedInt")]
        [DefaultValueAttribute(typeof(uint), "0U")]
        public uint index
        { get; set; }

        [XmlTextAttribute(DataType = "string")]
        protected virtual string innervalue // actually float[] type
        { get; set; }

        public T TMPValue
        { get; set; }
    }

    [Serializable()]
    [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
    public partial class Float
    {
        [XmlAttribute(DataType = "NCName")]
        public string sid
        { get; set; }

        [XmlTextAttribute()]
        public float value
        { get; set; }

        // constructors
        public Float() { }

        public Float(string sid, float val)
        {
            this.sid = sid;
            this.value = val;
        }

        // implicit operator overloading
        public static implicit operator float(Float f)  // implicit digit to byte conversion operator
        { return f.value; }
    }

    // member classes
    [Serializable()]
    [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
    public partial class Color
    {
        [XmlAttribute(DataType = "NCName")]
        public string sid
        { get; set; }

        [XmlText()]
        public string text
        {
            get { return Utilities.FromArray(values); }
            set { values = Utilities.ToFloatArray(value); }
        }

        [XmlIgnore()]
        public float[] values
        { get; set; }


        // constructors
        public Color() { }

        public Color(string sid, params float[] rgba)
        {
            this.sid = sid;
            this.values = rgba;
        }
        public Color(string sid, string values)
        {
            this.sid = sid;
            this.values = Utilities.ToFloatArray(values);
        }


        // implicit operator overloading
        public static implicit operator float[] (Color f)  // implicit digit to byte conversion operator
        { return f.values; }

    }
    [Serializable()]
    [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
    public partial class Texture
    {
        [XmlElement()]
        public Extra extra
        { get; set; }

        [XmlAttribute(DataType = "NCName")]
        public string texture
        { get; set; }

        [XmlAttribute(DataType = "NCName")]
        public string texcoord
        { get; set; }


        // constructors
        public Texture() { }

        public Texture(string texture, string texcoord)
        {
            this.texture = texture;
            this.texcoord = texcoord;
        }

        public Texture(string texture, string texcoord, Extra extra)
            : this(texture, texcoord)
        {
            this.extra = extra;
        }

        // implicit operator overloading
        public static implicit operator string(Texture t)  // implicit digit to byte conversion operator
        { return t.texture; }

    }

    [Serializable()]
    [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
    public partial class Param
    {
        [XmlAttribute(DataType = "NCName")]
        public string @ref
        { get; set; }

        // constructors
        public Param() { }

        public Param(string refVal)
        { this.@ref = refVal; }

        // implicit operator overloading
        public static implicit operator string(Param p)  // implicit digit to byte conversion operator
        { return p.@ref; }
    }

    [XmlIncludeAttribute(typeof(Transparent))]
    [Serializable()]
    [XmlType(Namespace = Collada.XMLNAMESPACE)]
    [XmlRoot(Namespace = Collada.XMLNAMESPACE, IsNullable = true)]
    public partial class ColorOrTexture
    {
        public enum ItemTypes
        {
            None,
            Color,
            Param,
            Texture
        }


        [XmlElement("color", typeof(Color))]
        public Color color
        { get; set; }
        [XmlElement("param", typeof(Param))]
        public Param param
        { get; set; }
        [XmlElement("texture", typeof(Texture))]
        public Texture texture
        { get; set; }


        public ItemTypes ItemType
        {
            get
            {
                if (texture != null) return ItemTypes.Texture;
                if (param != null) return ItemTypes.Param;
                if (color != null) return ItemTypes.Color;
                return ItemTypes.None;
            }
        }


        // constructors
        public ColorOrTexture() { }

        public ColorOrTexture(string paramRef)
        { this.param = new Param(paramRef); }

        public ColorOrTexture(string texture, string texcoord)
        { this.texture = new Texture(texture, texcoord); }

        public ColorOrTexture(string sid, float[] values)
        { this.color = new Color(sid, values); }

        public ColorOrTexture(string sid, float rgba)
            : this(sid, rgba, rgba, rgba, rgba)
        { }

        public ColorOrTexture(string sid, float rgb, float a)
            : this(sid, rgb, rgb, rgb, a)
        { }

        public ColorOrTexture(string sid, float r, float g, float b)
            : this(sid, r, g, b, 1.0f)
        { }

        public ColorOrTexture(string sid, float r, float g, float b, float a)
            : this(sid, new float[] { r, g, b, a })
        { }
        public ColorOrTexture(Color item) { this.color = item; }
        public ColorOrTexture(Param item) { this.param = item; }
        public ColorOrTexture(Texture item) { this.texture = item; }




        // implicit operator overloading
        public static implicit operator Color(ColorOrTexture value)
        { return value.color; }
        public static implicit operator Texture(ColorOrTexture value)
        { return value.texture; }
        public static implicit operator string(ColorOrTexture value)
        { return value.param; }



    }

    [Serializable()]
    [XmlType(Namespace = Collada.XMLNAMESPACE)]
    [XmlRoot(Namespace = Collada.XMLNAMESPACE, IsNullable = true)]
    public partial class FloatOrParam
    {
        public enum ItemTypes
        {
            None,
            Float,
            Param,
        }


        [XmlElement("param", typeof(Param))]
        public Param param
        { get; set; }
        [XmlElement("float", typeof(Float))]
        public Float @float
        { get; set; }



        public ItemTypes ItemType
        {
            get
            {
                if (@float != null) return ItemTypes.Float;
                if (param != null) return ItemTypes.Param;
                return ItemTypes.None;
            }
        }

        // constructors
        public FloatOrParam() { }

        public FloatOrParam(Float item)
        { this.@float = item; }

        public FloatOrParam(Param item)
        { this.param = item; }

        public FloatOrParam(string paramRef) : this(new Param(paramRef))
        { }

        public FloatOrParam(string sid, float val) : this(new Float(sid, val))
        { }




        // implicit operator overloading
        public static implicit operator Float(FloatOrParam value)  // implicit digit to byte conversion operator
        { return value.@float; }
        public static implicit operator string(FloatOrParam value)  // implicit digit to byte conversion operator
        { return value.param; }


        // member classes


    }

    [Serializable()]
    [XmlType(Namespace = Collada.XMLNAMESPACE)]
    [XmlRoot(Namespace = Collada.XMLNAMESPACE, IsNullable = true)]
    public partial class Transparent : ColorOrTexture
    {
        [XmlAttribute()]
        [DefaultValueAttribute(Opaque.A_ONE)]
        public Opaque opaque
        { get; set; }


        // constructors
        public Transparent()
        { this.opaque = Opaque.A_ONE; }

        public Transparent(Opaque opaque)
        { this.opaque = opaque; }

        public Transparent(Opaque opaque, Color item)
            : base(item)
        { this.opaque = opaque; }
    }

    [Serializable()]
    [XmlType(Namespace = Collada.XMLNAMESPACE)]
    [XmlRoot(Namespace = Collada.XMLNAMESPACE, IsNullable = true)]
    public partial class StencilTarget : ValueBase<string>
    {
        public StencilTarget() : base()
        {
            this.face = SurfaceFace.POSITIVE_X;
            this.mip = 0;
            this.slice = 0;
        }

        [XmlAttribute()]
        [DefaultValueAttribute(SurfaceFace.POSITIVE_X)]
        public SurfaceFace face
        { get; set; }

        [XmlAttribute(DataType = "unsignedInt")]
        [DefaultValueAttribute(typeof(uint), "0U")]
        public uint mip
        { get; set; }

        [XmlAttribute(DataType = "unsignedInt")]
        [DefaultValueAttribute(typeof(uint), "0U")]
        public uint slice
        { get; set; }

        [XmlTextAttribute(DataType = "string")]
        public string value
        { get; set; }
    }

    [Serializable()]
    [XmlType(Namespace = Collada.XMLNAMESPACE)]
    [XmlRoot(Namespace = Collada.XMLNAMESPACE, IsNullable = true)]
    public partial class DepthTarget : ValueBase<string>
    {
        public DepthTarget() : base()
        {
            this.face = SurfaceFace.POSITIVE_X;
            this.mip = 0;
            this.slice = 0;
        }

        [XmlAttribute()]
        [DefaultValueAttribute(SurfaceFace.POSITIVE_X)]
        public SurfaceFace face
        { get; set; }

        [XmlAttribute(DataType = "unsignedInt")]
        [DefaultValueAttribute(typeof(uint), "0U")]
        public uint mip
        { get; set; }

        [XmlAttribute(DataType = "unsignedInt")]
        [DefaultValueAttribute(typeof(uint), "0U")]
        public uint slice
        { get; set; }

        [XmlTextAttribute(DataType = "string")]
        public string value
        { get; set; }
    }

    [Serializable()]
    [XmlType(Namespace = Collada.XMLNAMESPACE)]
    [XmlRoot(Namespace = Collada.XMLNAMESPACE, IsNullable = true)]
    public partial class ColorTarget : ValueBase<string>
    {

        public ColorTarget() : base()
        {
            this.face = SurfaceFace.POSITIVE_X;
            this.mip = 0;
            this.slice = 0;
        }

        [XmlAttribute()]
        [DefaultValueAttribute(SurfaceFace.POSITIVE_X)]
        public SurfaceFace face
        { get; set; }

        [XmlAttribute(DataType = "unsignedInt")]
        [DefaultValueAttribute(typeof(uint), "0U")]
        public uint mip
        { get; set; }

        [XmlAttribute(DataType = "unsignedInt")]
        [DefaultValueAttribute(typeof(uint), "0U")]
        public uint slice
        { get; set; }

        [XmlTextAttribute(DataType = "string")]
        public string value
        { get; set; }
    }

    [Serializable()]
    [XmlType(Namespace = Collada.XMLNAMESPACE)]
    [XmlRoot(Namespace = Collada.XMLNAMESPACE, IsNullable = true)]
    public partial class Annotate
    {
        [XmlElement()]
        public bool @bool
        { get; set; }

        [XmlElement()]
        public string bool2
        { get; set; }

        [XmlElement()]
        public string bool3
        { get; set; }

        [XmlElement()]
        public string bool4
        { get; set; }

        [XmlElement()]
        public long @int
        { get; set; }

        [XmlElement()]
        public string int2
        { get; set; }

        [XmlElement()]
        public string int3
        { get; set; }

        [XmlElement()]
        public string int4
        { get; set; }

        [XmlElement()]
        public float @float
        { get; set; }

        [XmlElement()]
        public string float2
        { get; set; }

        [XmlElement()]
        public string float3
        { get; set; }

        [XmlElement()]
        public string float4
        { get; set; }

        [XmlElement()]
        public string float2x2
        { get; set; }

        [XmlElement()]
        public string float3x3
        { get; set; }

        [XmlElement()]
        public string float4x4
        { get; set; }

        [XmlElement()]
        public string @string
        { get; set; }

        [XmlAttribute(DataType = "NCName")]
        public string name
        { get; set; }
    }

    [Serializable()]
    [XmlType(Namespace = Collada.XMLNAMESPACE)]
    [XmlRoot(Namespace = Collada.XMLNAMESPACE, IsNullable = true)]
    public partial class SurfaceFormatHint
    {
        [XmlElement()]
        public SurfaceFormatHintChannels channels
        { get; set; }

        [XmlElement()]
        public SurfaceFormatHintRange range
        { get; set; }

        [XmlElement()]
        public SurfaceFormatHintPrecision precision
        { get; set; }

        [XmlIgnoreAttribute()]
        public bool precisionSpecified
        { get; set; }

        [XmlElement("option")]
        public SurfaceFormatHintOption[] option
        { get; set; }

        [XmlElement("extra")]
        public Extra[] extra
        { get; set; }
    }

    [Serializable()]
    [XmlType(Namespace = Collada.XMLNAMESPACE)]
    [XmlRoot(Namespace = Collada.XMLNAMESPACE, IsNullable = true)]
    public partial class CodeProfile
    {
        [XmlAttribute(DataType = "NCName")]
        public string sid
        { get; set; }

        [XmlTextAttribute()]
        public string value
        { get; set; }
    }

    [Serializable()]
    [XmlType(Namespace = Collada.XMLNAMESPACE)]
    [XmlRoot(Namespace = Collada.XMLNAMESPACE, IsNullable = true)]
    public partial class Include
    {
        [XmlAttribute(DataType = "NCName")]
        public string sid
        { get; set; }

        [XmlAttribute(DataType = "anyURI")]
        public string url
        { get; set; }

    }



    [XmlIncludeAttribute(typeof(CG_Surface))]
    [XmlIncludeAttribute(typeof(GLSL_Surface))]
    [Serializable()]
    [XmlType(Namespace = Collada.XMLNAMESPACE)]
    [XmlRoot(Namespace = Collada.XMLNAMESPACE, IsNullable = true)]
    public partial class Surface
    {
        [XmlElement()]
        public object init_as_null
        { get; set; }

        [XmlElement()]
        public object init_as_target
        { get; set; }

        [XmlElement()]
        public InitCube init_cube
        { get; set; }

        [XmlElement()]
        public InitVolume init_volume
        { get; set; }

        [XmlElement()]
        public InitPlanar init_planar
        { get; set; }

        [XmlElement("init_from")]
        public InitFrom[] init_from
        { get; set; }

        [XmlElement(DataType = "token")]
        public string format
        { get; set; }

        [XmlElement()]
        public SurfaceFormatHint format_hint
        { get; set; }

        [XmlElement("size", typeof(long))]
        [XmlElement("viewport_ratio", typeof(float))]
        public object item
        { get; set; }

        [XmlElement()]
        [DefaultValueAttribute(typeof(uint), "0")]
        public uint mip_levels
        { get; set; }

        [XmlElement()]
        public bool mipmap_generate
        { get; set; }

        [XmlIgnoreAttribute()]
        public bool mipmap_generateSpecified
        { get; set; }

        [XmlElement("extra")]
        public Extra[] extra
        { get; set; }

        [XmlAttribute()]
        public SurfaceType type
        { get; set; }


        // constructors
        public Surface()
        {
            this.mip_levels = ((uint)(0));
        }

        public Surface(SurfaceType type, InitFrom initfrom)
        {
            this.mip_levels = ((uint)(0));
            this.type = type;
            this.init_from = new InitFrom[] { initfrom };
        }


        // member classes
        #region InitCube
        [Serializable()]
        [XmlType(Namespace = Collada.XMLNAMESPACE)]
        [XmlRoot(Namespace = Collada.XMLNAMESPACE, IsNullable = true)]
        public partial class InitCube
        {
            [XmlElement("all", typeof(All))]
            [XmlElement("face", typeof(Face))]
            [XmlElement("primary", typeof(Primary))]
            public object[] items
            { get; set; }

            // member classes
            #region All
            [Serializable()]
            [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
            public partial class All
            {
                [XmlAttribute(DataType = "IDREF")]
                public string @ref
                { get; set; }
            }
            #endregion

            #region Face
            [Serializable()]
            [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
            public partial class Face
            {
                [XmlAttribute(DataType = "IDREF")]
                public string @ref
                { get; set; }
            }
            #endregion

            #region Primary
            [Serializable()]
            [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
            public partial class Primary
            {
                [XmlElement("order")]
                public SurfaceFace[] order
                { get; set; }

                [XmlAttribute(DataType = "IDREF")]
                public string @ref
                { get; set; }
            }
            #endregion

        }
        #endregion

        #region InitFrom
        [Serializable()]
        [XmlType(Namespace = Collada.XMLNAMESPACE)]
        [XmlRoot(Namespace = Collada.XMLNAMESPACE, IsNullable = true)]
        public partial class InitFrom
        {

            [XmlAttribute()]
            [DefaultValueAttribute(typeof(uint), "0")]
            public uint mip
            { get; set; }

            [XmlAttribute()]
            [DefaultValueAttribute(typeof(uint), "0")]
            public uint slice
            { get; set; }

            [XmlAttribute()]
            [DefaultValueAttribute(SurfaceFace.POSITIVE_X)]
            public SurfaceFace face
            { get; set; }

            [XmlTextAttribute(DataType = "IDREF")]
            public string value
            { get; set; }

            // constructors
            public InitFrom()
            {
                this.mip = ((uint)(0));
                this.slice = ((uint)(0));
                this.face = SurfaceFace.POSITIVE_X;
            }

            public InitFrom(string value)
            {
                this.mip = ((uint)(0));
                this.slice = ((uint)(0));
                this.face = SurfaceFace.POSITIVE_X;
                this.value = value;
            }

            public InitFrom(uint mip, uint slice, SurfaceFace face)
            {
                this.mip = mip;
                this.slice = slice;
                this.face = face;
            }

            public InitFrom(uint mip, uint slice, SurfaceFace face, string value)
            {
                this.mip = mip;
                this.slice = slice;
                this.face = face;
                this.value = value;
            }
        }
        #endregion

        #region InitVolume
        [Serializable()]
        [XmlType(Namespace = Collada.XMLNAMESPACE)]
        [XmlRoot(Namespace = Collada.XMLNAMESPACE, IsNullable = true)]
        public partial class InitVolume
        {
            [XmlElement("all", typeof(All))]
            [XmlElement("primary", typeof(Primary))]
            public object item
            { get; set; }

            // member classes
            #region All
            [Serializable()]
            [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
            public partial class All
            {
                [XmlAttribute(DataType = "IDREF")]
                public string @ref
                { get; set; }
            }
            #endregion

            #region Primary
            [Serializable()]
            [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
            public partial class Primary
            {
                [XmlAttribute(DataType = "IDREF")]
                public string @ref
                { get; set; }
            }
            #endregion

        }
        #endregion

        #region Planar
        [Serializable()]
        [XmlType(Namespace = Collada.XMLNAMESPACE)]
        [XmlRoot(Namespace = Collada.XMLNAMESPACE, IsNullable = true)]
        public partial class InitPlanar
        {
            [XmlElement("all")]
            public All item
            { get; set; }

            // member classes
            #region All
            [Serializable()]
            [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
            public partial class All
            {
                [XmlAttribute(DataType = "IDREF")]
                public string @ref
                { get; set; }
            }
            #endregion
        }
        #endregion

    }

    public abstract class Surface<T> : Surface where T : class
    {
        [XmlElement()]
        public SurfaceGenerator<T> generator
        { get; set; }
    }

    [Serializable()]
    [XmlType(Namespace = Collada.XMLNAMESPACE)]
    [XmlRoot(Namespace = Collada.XMLNAMESPACE, IsNullable = true)]
    public partial class CG_Surface : Surface<CG.Technique.SetParam>
    { }

    [Serializable()]
    [XmlType(Namespace = Collada.XMLNAMESPACE)]
    [XmlRoot(Namespace = Collada.XMLNAMESPACE, IsNullable = true)]
    public partial class GLSL_Surface : Surface<GLSL.Technique.GLSL_SetParamSimple>
    { }


    [Serializable()]
    [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
    public partial class SurfaceGeneratorBase
    {
        [XmlElement("annotate")]
        public Annotate[] annotate
        { get; set; }

        [XmlElement("code", typeof(CodeProfile))]
        [XmlElement("include", typeof(Include))]
        public object[] items
        { get; set; }

        [XmlElement()]
        public Name name
        { get; set; }

        // member classes
        #region Name
        [Serializable()]
        [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
        public partial class Name
        {
            [XmlAttribute(DataType = "NCName")]
            public string source
            { get; set; }

            [XmlTextAttribute(DataType = "NCName")]
            public string value
            { get; set; }
        }
        #endregion
    }

    [Serializable()]
    [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
    public partial class SurfaceGenerator<T> : SurfaceGeneratorBase where T : class
    {
        [XmlElement("setparam")]
        public T[] setparam
        { get; set; }
    }


}
