using System;
using System.Xml.Serialization;

namespace ColladaNET.FX.Profiles
{
    
    [Serializable()]
    [XmlType(Namespace = Collada.XMLNAMESPACE)]
    public enum Pipeline_Stage
    {
        VERTEXPROGRAM,
        FRAGMENTPROGRAM,
    }


    #region Common Enumeration Types
    [Serializable()]
    [XmlType(Namespace = Collada.XMLNAMESPACE)]
    public enum SurfaceFace
    {
        POSITIVE_X,
        NEGATIVE_X,
        POSITIVE_Y,
        NEGATIVE_Y,
        POSITIVE_Z,
        NEGATIVE_Z,
    }

    [Serializable()]
    [XmlType(Namespace = Collada.XMLNAMESPACE)]
    public enum Modifier
    {
        CONST,
        UNIFORM,
        VARYING,
        STATIC,
        VOLATILE,
        EXTERN,
        SHARED,
    }

    [Serializable()]
    [XmlType(Namespace = Collada.XMLNAMESPACE)]
    public enum SurfaceFormatHintChannels
    {
        RGB,
        RGBA,
        L,
        LA,
        D,
        XYZ,
        XYZW,
    }

    [Serializable()]
    [XmlType(Namespace = Collada.XMLNAMESPACE)]
    public enum SurfaceFormatHintRange
    {
        SNORM,
        UNORM,
        SINT,
        UINT,
        FLOAT,
    }

    [Serializable()]
    [XmlType(Namespace = Collada.XMLNAMESPACE)]
    public enum SurfaceFormatHintPrecision
    {
        LOW,
        MID,
        HIGH,
    }

    [Serializable()]
    [XmlType(Namespace = Collada.XMLNAMESPACE)]
    public enum SurfaceFormatHintOption
    {
        SRGB_GAMMA,
        NORMALIZED3,
        NORMALIZED4,
        COMPRESSABLE,
    }

    [Serializable()]
    [XmlType(Namespace = Collada.XMLNAMESPACE)]
    public enum SurfaceType
    {
        UNTYPED,
        [XmlEnumAttribute("1D")]
        Item1D,
        [XmlEnumAttribute("2D")]
        Item2D,
        [XmlEnumAttribute("3D")]
        Item3D,
        RECT,
        CUBE,
        DEPTH,
    }

    [Serializable()]
    [XmlType(Namespace = Collada.XMLNAMESPACE)]
    public enum SamplerWrap
    {
        NONE,
        WRAP,
        MIRROR,
        CLAMP,
        BORDER,
    }

    [Serializable()]
    [XmlType(Namespace = Collada.XMLNAMESPACE)]
    public enum SamplerFilter
    {
        NONE,
        NEAREST,
        LINEAR,
        NEAREST_MIPMAP_NEAREST,
        LINEAR_MIPMAP_NEAREST,
        NEAREST_MIPMAP_LINEAR,
        LINEAR_MIPMAP_LINEAR,
    }

    [Serializable()]
    [XmlType(Namespace = Collada.XMLNAMESPACE)]
    public enum Opaque
    {
        A_ONE,
        RGB_ZERO,
    }
    #endregion

    #region GL Enumeration Types
    [Serializable()]
    [XmlType(Namespace = Collada.XMLNAMESPACE)]
    public enum GL_Func
    {
        NEVER,
        LESS,
        LEQUAL,
        EQUAL,
        GREATER,
        NOTEQUAL,
        GEQUAL,
        ALWAYS,
    }

    [Serializable()]
    [XmlType(Namespace = Collada.XMLNAMESPACE)]
    public enum GL_BlendEquation
    {
        FUNC_ADD,
        FUNC_SUBTRACT,
        FUNC_REVERSE_SUBTRACT,
        MIN,
        MAX,
    }

    [Serializable()]
    [XmlType(Namespace = Collada.XMLNAMESPACE)]
    public enum GL_Blend
    {
        ZERO,
        ONE,
        SRC_COLOR,
        ONE_MINUS_SRC_COLOR,
        DEST_COLOR,
        ONE_MINUS_DEST_COLOR,
        SRC_ALPHA,
        ONE_MINUS_SRC_ALPHA,
        DST_ALPHA,
        ONE_MINUS_DST_ALPHA,
        CONSTANT_COLOR,
        ONE_MINUS_CONSTANT_COLOR,
        CONSTANT_ALPHA,
        ONE_MINUS_CONSTANT_ALPHA,
        SRC_ALPHA_SATURATE,
    }

    [Serializable()]
    [XmlType(Namespace = Collada.XMLNAMESPACE)]
    public enum GL_Face
    {
        FRONT,
        BACK,
        FRONT_AND_BACK,
    }

    [Serializable()]
    [XmlType(Namespace = Collada.XMLNAMESPACE)]
    public enum GL_Material
    {
        EMISSION,
        AMBIENT,
        DIFFUSE,
        SPECULAR,
        AMBIENT_AND_DIFFUSE,
    }

    [Serializable()]
    [XmlType(Namespace = Collada.XMLNAMESPACE)]
    public enum GL_FogCoordSrc
    {
        FOG_COORDINATE,
        FRAGMENT_DEPTH,
    }

    [Serializable()]
    [XmlType(Namespace = Collada.XMLNAMESPACE)]
    public enum GL_Fog
    {
        LINEAR,
        EXP,
        EXP2,
    }

    [Serializable()]
    [XmlType(Namespace = Collada.XMLNAMESPACE)]
    public enum GL_FrontFace
    {
        CW,
        CCW,
    }

    [Serializable()]
    [XmlType(Namespace = Collada.XMLNAMESPACE)]
    public enum GL_LightModelColorControl
    {
        SINGLE_COLOR,
        SEPARATE_SPECULAR_COLOR,
    }

    [Serializable()]
    [XmlType(Namespace = Collada.XMLNAMESPACE)]
    public enum GL_LogicOp
    {
        CLEAR,
        AND,
        AND_REVERSE,
        COPY,
        AND_INVERTED,
        NOOP,
        XOR,
        OR,
        NOR,
        EQUIV,
        INVERT,
        OR_REVERSE,
        COPY_INVERTED,
        NAND,
        SET,
    }

    [Serializable()]
    [XmlType(Namespace = Collada.XMLNAMESPACE)]
    public enum GL_PolygonMode
    {
        POINT,
        LINE,
        FILL,
    }

    [Serializable()]
    [XmlType(Namespace = Collada.XMLNAMESPACE)]
    public enum GL_ShadeModel
    {
        FLAT,
        SMOOTH,
    }

    [Serializable()]
    [XmlType(Namespace = Collada.XMLNAMESPACE)]
    public enum GL_StencilOp
    {
        KEEP,
        ZERO,
        REPLACE,
        INCR,
        DECR,
        INVERT,
        INCR_WRAP,
        DECR_WRAP,
    }

    #endregion

    #region GLES Enumeration Types
    [Serializable()]
    [XmlType(Namespace = Collada.XMLNAMESPACE)]
    public enum GLES_TexCombinerSource
    {
        TEXTURE,
        CONSTANT,
        PRIMARY,
        PREVIOUS,
    }

    [Serializable()]
    [XmlType(Namespace = Collada.XMLNAMESPACE)]
    public enum GLES_TexCombinerOperandRGB
    {
        SRC_COLOR,
        ONE_MINUS_SRC_COLOR,
        SRC_ALPHA,
        ONE_MINUS_SRC_ALPHA,
    }

    [Serializable()]
    [XmlType(Namespace = Collada.XMLNAMESPACE)]
    public enum GLES_TexCombinerOperatorRGB
    {
        REPLACE,
        MODULATE,
        ADD,
        ADD_SIGNED,
        INTERPOLATE,
        SUBTRACT,
        DOT3_RGB,
        DOT3_RGBA,
    }

    [Serializable()]
    [XmlType(Namespace = Collada.XMLNAMESPACE)]
    public enum GLES_TexCombinerOperandAlpha
    {
        SRC_ALPHA,
        ONE_MINUS_SRC_ALPHA,
    }

    [Serializable()]
    [XmlType(Namespace = Collada.XMLNAMESPACE)]
    public enum GLES_TexCombinerOperatorAlpha
    {
        REPLACE,
        MODULATE,
        ADD,
        ADD_SIGNED,
        INTERPOLATE,
        SUBTRACT,
    }

    [Serializable()]
    [XmlType(Namespace = Collada.XMLNAMESPACE)]
    public enum GLES_TexEnvMode
    {
        REPLACE,
        MODULATE,
        DECAL,
        BLEND,
        ADD,
    }

    [Serializable()]
    [XmlType(Namespace = Collada.XMLNAMESPACE)]
    public enum GLES_SamplerWrap
    {
        REPEAT,
        CLAMP,
        CLAMP_TO_EDGE,
        MIRRORED_REPEAT,
    }

    [Serializable()]
    [XmlType(Namespace = Collada.XMLNAMESPACE)]
    public enum GLES_StencilOpType
    {
        KEEP,
        ZERO,
        REPLACE,
        INCR,
        DECR,
        INVERT,
    }
    #endregion

}
