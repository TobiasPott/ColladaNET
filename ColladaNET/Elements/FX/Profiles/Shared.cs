using ColladaNET.Elements;
using ColladaNET.FX.Types;
using System;
using System.ComponentModel;
using System.Xml.Serialization;

namespace ColladaNET.FX.Profiles.Shared
{
    [Serializable()]
    [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
    public abstract partial class PassParamBase
    {
        [XmlAttribute(DataType = "NCName")]
        public string param
        { get; set; } = string.Empty;
    }

    [Serializable()]
    [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
    public abstract partial class PassIndexedParam : PassParamBase
    {
        [XmlAttribute(DataType = "unsignedInt")]
        public uint index
        { get; set; } = 0u;
    }


    public interface INewParam
    {
        string sid { get; set; }
        string semantic { get; set; }
    }
    public abstract partial class NewParamBase : INewParam
    {
        [XmlAttribute(DataType = "NCName")]
        public string sid
        { get; set; }

        [XmlElement(DataType = "NCName")]
        public string semantic
        { get; set; }
    }
    public abstract partial class NewParamExtended : NewParamBase
    {
        [XmlElement("annotate")]
        public Annotate[] annotate
        { get; set; }

        [XmlElement()]
        public Modifier modifier
        { get; set; }
    }


    public interface ITechnique
    {
        string id { get; set; }
        string sid { get; set; }
        Image[] image { get; set; }
        Extra[] extra { get; set; }
    }
    public abstract partial class TechniqueBase : ITechnique
    {
        [XmlAttribute(DataType = "ID")]
        public string id
        { get; set; }

        [XmlAttribute(DataType = "NCName")]
        public string sid
        { get; set; }

        [XmlElement("image", typeof(Image))]
        public Image[] image
        { get; set; }

        [XmlElement("extra")]
        public Extra[] extra
        { get; set; }
    }





    #region Alpha
    [Serializable()]
    [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
    public partial class AlphaFunc
    {
        [XmlElement()]
        public Func func
        { get; set; }

        [XmlElement()]
        public Value value
        { get; set; }

        // member classes
        #region Func
        [Serializable()]
        [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
        public partial class Func : PassParamBase
        {
            public Func()
            { this.value = GL_Func.ALWAYS; }

            [XmlAttribute()]
            [DefaultValueAttribute(GL_Func.ALWAYS)]
            public GL_Func value
            { get; set; }
        }
        #endregion

        #region Value
        [Serializable()]
        [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
        public partial class Value : PassParamBase
        {
            public Value()
            { this.value = 0.0f; }

            [XmlAttribute()]
            [DefaultValueAttribute(typeof(float), "0")]
            public float value
            { get; set; }

        }
        #endregion

    }

    [Serializable()]
    [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
    public partial class AlphaTestEnable : PassParamBase
    {
        public AlphaTestEnable()
        { this.value = false; }

        [XmlAttribute()]
        [DefaultValueAttribute(false)]
        public bool value
        { get; set; }

    }
    #endregion

    [Serializable()]
    [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
    public partial class AutoNormalEnable : PassParamBase
    {
        public AutoNormalEnable()
        { this.value = false; }

        [XmlAttribute()]
        [DefaultValueAttribute(false)]
        public bool value
        { get; set; } = false;
    }

    #region Blend
    [Serializable()]
    [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
    public partial class BlendColor : PassParamBase
    {
        public BlendColor()
        { this.value = new float[] { 0, 0, 0, 0 }; }

        [XmlAttribute()]
        public float[] value
        { get; set; }
    }

    [Serializable()]
    [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
    public partial class BlendEnable : PassParamBase
    {
        public BlendEnable()
        { this.value = false; }

        [XmlAttribute()]
        [DefaultValueAttribute(false)]
        public bool value
        { get; set; }
    }

    [Serializable()]
    [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
    public partial class BlendEquation : PassParamBase
    {
        public BlendEquation()
        { this.value = GL_BlendEquation.FUNC_ADD; }

        [XmlAttribute()]
        [DefaultValueAttribute(GL_BlendEquation.FUNC_ADD)]
        public GL_BlendEquation value
        { get; set; }
    }

    [Serializable()]
    [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
    public partial class BlendEquationSeparate
    {
        [XmlElement()]
        public RGB rgb
        { get; set; }

        [XmlElement()]
        public Alpha alpha
        { get; set; }

        // member classes
        #region RGB
        [Serializable()]
        [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
        public partial class RGB : PassParamBase
        {
            public RGB()
            { this.value = GL_BlendEquation.FUNC_ADD; }

            [XmlAttribute()]
            [DefaultValueAttribute(GL_BlendEquation.FUNC_ADD)]
            public GL_BlendEquation value
            { get; set; }
        }
        #endregion

        #region Alpha
        [Serializable()]
        [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
        public partial class Alpha : PassParamBase
        {
            public Alpha()
            { this.value = GL_BlendEquation.FUNC_ADD; }

            [XmlAttribute()]
            [DefaultValueAttribute(GL_BlendEquation.FUNC_ADD)]
            public GL_BlendEquation value
            { get; set; }
        }
        #endregion

    }

    [Serializable()]
    [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
    public partial class BlendFunc
    {
        [XmlElement()]
        public Src src
        { get; set; }

        [XmlElement()]
        public Dest dest
        { get; set; }

        // member classes
        #region Src
        [Serializable()]
        [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
        public partial class Src : PassParamBase
        {
            public Src()
            { this.value = GL_Blend.ONE; }

            [XmlAttribute()]
            [DefaultValueAttribute(GL_Blend.ONE)]
            public GL_Blend value
            { get; set; }
        }
        #endregion

        #region Dest
        [Serializable()]
        [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
        public partial class Dest : PassParamBase
        {
            public Dest()
            {
                this.value = GL_Blend.ZERO;
            }

            [XmlAttribute()]
            [DefaultValueAttribute(GL_Blend.ZERO)]
            public GL_Blend value
            { get; set; }
        }
        #endregion
    }

    [Serializable()]
    [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
    public partial class BlendFuncSeparate
    {
        [XmlElement()]
        public SrcRGB src_rgb
        { get; set; }

        [XmlElement()]
        public DestRGB dest_rgb
        { get; set; }

        [XmlElement()]
        public SrcAlpha src_alpha
        { get; set; }

        [XmlElement()]
        public DestAlpha dest_alpha
        { get; set; }

        // member classes
        #region SrcRGB
        [Serializable()]
        [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
        public partial class SrcRGB : PassParamBase
        {
            public SrcRGB()
            { this.value = GL_Blend.ONE; }

            [XmlAttribute()]
            [DefaultValueAttribute(GL_Blend.ONE)]
            public GL_Blend value
            { get; set; }
        }
        #endregion

        #region DestRGB
        [Serializable()]
        [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
        public partial class DestRGB : PassParamBase
        {
            public DestRGB()
            { this.value = GL_Blend.ZERO; }

            [XmlAttribute()]
            [DefaultValueAttribute(GL_Blend.ZERO)]
            public GL_Blend value
            { get; set; }
        }
        #endregion

        #region SrcAlpha
        [Serializable()]
        [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
        public partial class SrcAlpha : PassParamBase
        {
            public SrcAlpha()
            { this.value = GL_Blend.ONE; }

            [XmlAttribute()]
            [DefaultValueAttribute(GL_Blend.ONE)]
            public GL_Blend value
            { get; set; }
        }
        #endregion

        #region DestAlpha
        [Serializable()]
        [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
        public partial class DestAlpha : PassParamBase
        {
            public DestAlpha()
            { this.value = GL_Blend.ZERO; }

            [XmlAttribute()]
            [DefaultValueAttribute(GL_Blend.ZERO)]
            public GL_Blend value
            { get; set; }
        }
        #endregion

    }

    #endregion

    #region Clear
    [Serializable()]
    [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
    public partial class ClearColor : PassParamBase
    {
        public ClearColor()
        { this.value = new float[] { 0, 0, 0, 0 }; }

        [XmlAttribute()]
        public float[] value
        { get; set; }
    }

    [Serializable()]
    [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
    public partial class ClearDepth : PassParamBase
    {
        public ClearDepth()
        { this.value = 1; }

        [XmlAttribute()]
        [DefaultValueAttribute(1)]
        public float value
        { get; set; }

        [XmlIgnoreAttribute()]
        public bool valueSpecified
        { get; set; }
    }

    [Serializable()]
    [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
    public partial class ClearStencil : PassParamBase
    {
        public ClearStencil()
        { this.value = 0; }

        [XmlAttribute()]
        [DefaultValueAttribute(typeof(long), "0")]
        public long value
        { get; set; }

        [XmlIgnoreAttribute()]
        public bool valueSpecified
        { get; set; }
    }
    #endregion

    #region Clip
    [Serializable()]
    [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
    public partial class ClipPlane : PassIndexedParam
    {
        [XmlAttribute()]
        public bool[] value
        { get; set; }
    }

    [Serializable()]
    [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
    public partial class ClipPlaneEnable : PassIndexedParam
    {
        public ClipPlaneEnable()
        { this.value = false; }

        [XmlAttribute()]
        [DefaultValueAttribute(false)]
        public bool value
        { get; set; }
    }
    #endregion

    #region Color
    [Serializable()]
    [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
    public partial class ColorLogicOpEnable : PassParamBase
    {
        public ColorLogicOpEnable()
        { this.value = false; }

        [XmlAttribute()]
        [DefaultValueAttribute(false)]
        public bool value
        { get; set; }
    }

    [Serializable()]
    [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
    public partial class ColorMask : PassParamBase
    {
        public ColorMask()
        { this.value = new bool[] { true, true, true, true }; }

        [XmlAttribute()]
        public bool[] value
        { get; set; }
    }

    [Serializable()]
    [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
    public partial class ColorMaterialEnable : PassParamBase
    {
        public ColorMaterialEnable()
        { this.value = true; }

        [XmlAttribute()]
        [DefaultValueAttribute(true)]
        public bool value
        { get; set; }
    }

    [Serializable()]
    [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
    public partial class ColorMaterial
    {
        [XmlElement()]
        public Face face
        { get; set; }

        [XmlElement()]
        public Mode mode
        { get; set; }

        // member classes
        #region Face
        [Serializable()]
        [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
        public partial class Face : PassParamBase
        {
            public Face()
            { this.value = GL_Face.FRONT_AND_BACK; }

            [XmlAttribute()]
            [DefaultValueAttribute(GL_Face.FRONT_AND_BACK)]
            public GL_Face value
            { get; set; }

        }
        #endregion

        #region Mode
        [Serializable()]
        [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
        public partial class Mode : PassParamBase
        {
            public Mode()
            { this.value = GL_Material.AMBIENT_AND_DIFFUSE; }

            [XmlAttribute()]
            [DefaultValueAttribute(GL_Material.AMBIENT_AND_DIFFUSE)]
            public GL_Material value
            { get; set; }

        }
        #endregion
    }
    #endregion

    #region Cull
    [Serializable()]
    [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
    public partial class CullFace : PassParamBase
    {
        public CullFace()
        { this.value = GL_Face.BACK; }

        [XmlAttribute()]
        [DefaultValueAttribute(GL_Face.BACK)]
        public GL_Face value
        { get; set; }
    }

    [Serializable()]
    [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
    public partial class CullFaceEnable : PassParamBase
    {
        public CullFaceEnable()
        { this.value = false; }

        [XmlAttribute()]
        [DefaultValueAttribute(false)]
        public bool value
        { get; set; }
    }
    #endregion

    #region Depth
    [Serializable()]
    [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
    public partial class DepthBounds : PassParamBase
    {
        [XmlAttribute()]
        public float[] value
        { get; set; }
    }

    [Serializable()]
    [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
    public partial class DepthBoundsEnable : PassParamBase
    {
        public DepthBoundsEnable()
        { this.value = false; }

        [XmlAttribute()]
        [DefaultValueAttribute(false)]
        public bool value
        { get; set; }
    }

    [Serializable()]
    [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
    public partial class DepthClampEnable : PassParamBase
    {
        public DepthClampEnable()
        { this.value = false; }

        [XmlAttribute()]
        [DefaultValueAttribute(false)]
        public bool value
        { get; set; }
    }

    [Serializable()]
    [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
    public partial class DepthFunc : PassParamBase
    {
        public DepthFunc()
        { this.value = GL_Func.ALWAYS; }

        [XmlAttribute()]
        [DefaultValueAttribute(GL_Func.ALWAYS)]
        public GL_Func value
        { get; set; }
    }

    [Serializable()]
    [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
    public partial class DepthMask : PassParamBase
    {
        public DepthMask()
        { this.value = false; }

        [XmlAttribute()]
        [DefaultValueAttribute(false)]
        public bool value
        { get; set; }
    }

    [Serializable()]
    [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
    public partial class DepthRange : PassParamBase
    {
        public DepthRange()
        { this.value = new float[] { 0, 1 }; }

        [XmlAttribute()]
        public float[] value
        { get; set; }
    }

    [Serializable()]
    [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
    public partial class DepthTestEnable : PassParamBase
    {
        public DepthTestEnable()
        { this.value = false; }

        [XmlAttribute()]
        [DefaultValueAttribute(false)]
        public bool value
        { get; set; }
    }
    #endregion

    [Serializable()]
    [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
    public partial class DitherEnable : PassParamBase
    {
        public DitherEnable()
        { this.value = false; }

        [XmlAttribute()]
        [DefaultValueAttribute(false)]
        public bool value
        { get; set; }
    }

    #region Fog
    [Serializable()]
    [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
    public partial class FogColor : PassParamBase
    {
        public FogColor()
        { this.value = new float[] { 0, 0, 0, 0 }; }

        [XmlAttribute()]
        public float[] value
        { get; set; }
    }

    [Serializable()]
    [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
    public partial class FogCoordSrc : PassParamBase
    {
        public FogCoordSrc()
        { this.value = GL_FogCoordSrc.FOG_COORDINATE; }

        [XmlAttribute()]
        [DefaultValueAttribute(GL_FogCoordSrc.FOG_COORDINATE)]
        public GL_FogCoordSrc value
        { get; set; }
    }

    [Serializable()]
    [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
    public partial class FogDensity : PassParamBase
    {
        public FogDensity()
        { this.value = 1; }

        [XmlAttribute()]
        [DefaultValueAttribute(1)]
        public float value
        { get; set; }
    }

    [Serializable()]
    [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
    public partial class FogEnable : PassParamBase
    {
        public FogEnable()
        { this.value = false; }

        [XmlAttribute()]
        [DefaultValueAttribute(false)]
        public bool value
        { get; set; }
    }

    [Serializable()]
    [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
    public partial class FogEnd : PassParamBase
    {
        public FogEnd()
        { this.value = 1; }

        [XmlAttribute()]
        [DefaultValueAttribute(1)]
        public float value
        { get; set; }
    }

    [Serializable()]
    [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
    public partial class FogMode : PassParamBase
    {
        public FogMode()
        { this.value = GL_Fog.EXP; }

        [XmlAttribute()]
        [DefaultValueAttribute(GL_Fog.EXP)]
        public GL_Fog value
        { get; set; }
    }

    [Serializable()]
    [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
    public partial class FogStart : PassParamBase
    {
        public FogStart()
        { this.value = 0; }

        [XmlAttribute()]
        [DefaultValueAttribute(0.0f)]
        public float value
        { get; set; }
    }
    #endregion

    [Serializable()]
    [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
    public partial class FrontFace : PassParamBase
    {
        public FrontFace()
        { this.value = GL_FrontFace.CCW; }

        [XmlAttribute()]
        [DefaultValueAttribute(GL_FrontFace.CCW)]
        public GL_FrontFace value
        { get; set; }
    }

    #region Light
    [Serializable()]
    [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
    public partial class LightAmbient : PassIndexedParam
    {
        public LightAmbient()
        { this.value = new float[] { 0, 0, 0, 1 }; }

        [XmlAttribute()]
        public float[] value
        { get; set; }
    }

    [Serializable()]
    [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
    public partial class LightConstantAttenuation : PassIndexedParam
    {

        public LightConstantAttenuation()
        { this.value = 1; }

        [XmlAttribute()]
        [DefaultValueAttribute(1)]
        public float value
        { get; set; }
    }

    [Serializable()]
    [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
    public partial class LightDiffuse : PassIndexedParam
    {
        public LightDiffuse()
        { this.value = new float[] { 0, 0, 0, 0 }; }

        [XmlAttribute()]
        public float[] value
        { get; set; }
    }

    [Serializable()]
    [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
    public partial class LightEnable : PassIndexedParam
    {
        public LightEnable()
        { this.value = false; }

        [XmlAttribute()]
        [DefaultValueAttribute(false)]
        public bool value
        { get; set; }
    }

    [Serializable()]
    [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
    public partial class LightLinearAttenuation : PassIndexedParam
    {
        public LightLinearAttenuation()
        { this.value = 1; }

        [XmlAttribute()]
        [DefaultValueAttribute(1)]
        public float value
        { get; set; }
    }

    [Serializable()]
    [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
    public partial class LightModelAmbient : PassParamBase
    {
        public LightModelAmbient()
        { this.value = new float[] { 0.2f, 0.2f, 0.2f, 1 }; }

        [XmlAttribute()]
        public float[] value
        { get; set; }
    }

    [Serializable()]
    [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
    public partial class LightModelColorControl : PassParamBase
    {
        public LightModelColorControl()
        { this.value = GL_LightModelColorControl.SINGLE_COLOR; }

        [XmlAttribute()]
        [DefaultValueAttribute(GL_LightModelColorControl.SINGLE_COLOR)]
        public GL_LightModelColorControl value
        { get; set; }
    }

    [Serializable()]
    [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
    public partial class LightModelLocalViewerEnable : PassParamBase
    {
        public LightModelLocalViewerEnable()
        { this.value = false; }

        [XmlAttribute()]
        [DefaultValueAttribute(false)]
        public bool value
        { get; set; }
    }

    [Serializable()]
    [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
    public partial class LightModelTwoSideEnable : PassParamBase
    {
        public LightModelTwoSideEnable()
        { this.value = false; }

        [XmlAttribute()]
        [DefaultValueAttribute(false)]
        public bool value
        { get; set; }
    }

    [Serializable()]
    [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
    public partial class LightPosition : PassIndexedParam
    {
        public LightPosition()
        { this.value = new float[] { 0, 0, 1, 0 }; }

        [XmlAttribute()]
        public float[] value
        { get; set; }
    }

    [Serializable()]
    [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
    public partial class LightQuadraticAttenuation : PassIndexedParam
    {
        public LightQuadraticAttenuation()
        { this.value = 1; }

        [XmlAttribute()]
        [DefaultValueAttribute(1)]
        public float value
        { get; set; }
    }

    [Serializable()]
    [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
    public partial class LightSpecular : PassIndexedParam
    {
        public LightSpecular()
        { this.value = new float[] { 0, 0, 0, 0 }; }

        [XmlAttribute()]
        public float[] value
        { get; set; }
    }

    [Serializable()]
    [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
    public partial class LightSpotCutoff : PassIndexedParam
    {
        public LightSpotCutoff()
        { this.value = 180; }

        [XmlAttribute()]
        [DefaultValueAttribute(180)]
        public float value
        { get; set; }
    }

    [Serializable()]
    [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
    public partial class LightSpotDirection : PassIndexedParam
    {
        public LightSpotDirection()
        { this.value = new float[] { 0, 0, -1 }; }

        [XmlAttribute()]
        public float[] value
        { get; set; }
    }

    [Serializable()]
    [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
    public partial class LightSpotExponent : PassIndexedParam
    {
        public LightSpotExponent()
        { this.value = 0; }

        [XmlAttribute()]
        [DefaultValueAttribute(0.0f)]
        public float value
        { get; set; }
    }
    #endregion

    [Serializable()]
    [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
    public partial class LightingEnable : PassParamBase
    {
        public LightingEnable()
        { this.value = false; }

        [XmlAttribute()]
        [DefaultValueAttribute(false)]
        public bool value
        { get; set; }
    }

    #region Line
    [Serializable()]
    [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
    public partial class LineSmoothEnable : PassParamBase
    {
        public LineSmoothEnable()
        { this.value = false; }

        [XmlAttribute()]
        [DefaultValueAttribute(false)]
        public bool value
        { get; set; }
    }

    [Serializable()]
    [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
    public partial class LineStipple : PassParamBase
    {
        public LineStipple()
        { this.value = new long[] { 1L, 65536L }; }

        [XmlAttribute()]
        public long[] value
        { get; set; }
    }

    [Serializable()]
    [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
    public partial class LineStippleEnable : PassParamBase
    {
        public LineStippleEnable()
        { this.value = false; }

        [XmlAttribute()]
        [DefaultValueAttribute(false)]
        public bool value
        { get; set; }
    }

    [Serializable()]
    [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
    public partial class LineWidth : PassParamBase
    {
        public LineWidth()
        { this.value = 1; }

        [XmlAttribute()]
        [DefaultValueAttribute(1)]
        public float value
        { get; set; }
    }

    #endregion

    #region Logic
    [Serializable()]
    [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
    public partial class LogicOp : PassParamBase
    {
        public LogicOp()
        { this.value = GL_LogicOp.COPY; }

        [XmlAttribute()]
        [DefaultValueAttribute(GL_LogicOp.COPY)]
        public GL_LogicOp value
        { get; set; }
    }

    [Serializable()]
    [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
    public partial class LogicOpEnable : PassParamBase
    {
        public LogicOpEnable()
        { this.value = false; }

        [XmlAttribute()]
        [DefaultValueAttribute(false)]
        public bool value
        { get; set; }
    }
    #endregion

    #region Material
    [Serializable()]
    [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
    public partial class MaterialAmbient : PassParamBase
    {
        public MaterialAmbient()
        { this.value = new float[] { 0.2f, 0.2f, 0.2f, 1 }; }

        [XmlAttribute()]
        public float[] value
        { get; set; }
    }

    [Serializable()]
    [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
    public partial class MaterialDiffuse : PassParamBase
    {
        public MaterialDiffuse()
        { this.value = new float[] { 0.8f, 0.8f, 0.8f, 1 }; }

        [XmlAttribute()]
        public float[] value
        { get; set; }
    }

    [Serializable()]
    [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
    public partial class MaterialEmission : PassParamBase
    {
        public MaterialEmission()
        { this.value = new float[] { 0, 0, 0, 1 }; }

        [XmlAttribute()]
        public float[] value
        { get; set; }
    }

    [Serializable()]
    [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
    public partial class MaterialShininess : PassParamBase
    {
        public MaterialShininess()
        { this.value = 0; }

        [XmlAttribute()]
        [DefaultValueAttribute(0.0f)]
        public float value
        { get; set; }
    }

    [Serializable()]
    [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
    public partial class MaterialSpecular : PassParamBase
    {
        public MaterialSpecular()
        { this.value = new float[] { 0, 0, 0, 1 }; }

        [XmlAttribute()]
        public float[] value
        { get; set; }
    }

    #endregion

    [Serializable()]
    [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
    public partial class ModelViewMatrix : PassParamBase
    {
        public ModelViewMatrix()
        {
            this.value = new float[] {
                    1, 0, 0, 0,
                    0, 1, 0, 0,
                    0, 0, 1, 0,
                    0, 0, 0, 1};
        }

        [XmlAttribute()]
        public float[] value
        { get; set; }
    }

    [Serializable()]
    [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
    public partial class MultisampleEnable : PassParamBase
    {
        public MultisampleEnable()
        { this.value = false; }

        [XmlAttribute()]
        [DefaultValueAttribute(false)]
        public bool value
        { get; set; }
    }

    [Serializable()]
    [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
    public partial class NormalizeEnable : PassParamBase
    {
        public NormalizeEnable()
        { this.value = false; }

        [XmlAttribute()]
        [DefaultValueAttribute(false)]
        public bool value
        { get; set; }
    }

    #region Point
    [Serializable()]
    [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
    public partial class PointDistanceAttenuation : PassParamBase
    {
        public PointDistanceAttenuation()
        { this.value = new float[] { 1, 0, 0 }; }

        [XmlAttribute()]
        public float[] value
        { get; set; }

    }

    [Serializable()]
    [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
    public partial class PointFadeThresholdSize : PassParamBase
    {
        public PointFadeThresholdSize()
        { this.value = 1; }

        [XmlAttribute()]
        [DefaultValueAttribute(1)]
        public float value
        { get; set; }
    }

    [Serializable()]
    [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
    public partial class PointSize : PassParamBase
    {
        public PointSize()
        { this.value = 1; }

        [XmlAttribute()]
        [DefaultValueAttribute(1)]
        public float value
        { get; set; }
    }

    [Serializable()]
    [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
    public partial class PointSizeMax : PassParamBase
    {
        public PointSizeMax()
        { this.value = 1; }

        [XmlAttribute()]
        [DefaultValueAttribute(1)]
        public float value
        { get; set; }
    }


    [Serializable()]
    [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
    public partial class PointSizeMin : PassParamBase
    {
        public PointSizeMin()
        { this.value = 0; }

        [XmlAttribute()]
        [DefaultValueAttribute(0.0f)]
        public float value
        { get; set; }
    }

    [Serializable()]
    [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
    public partial class PointSmoothEnable : PassParamBase
    {
        public PointSmoothEnable()
        { this.value = false; }

        [XmlAttribute()]
        [DefaultValueAttribute(false)]
        public bool value
        { get; set; }
    }
    #endregion

    #region Polygon
    [Serializable()]
    [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
    public partial class PolygonMode
    {
        [XmlElement()]
        public Face face
        { get; set; }

        [XmlElement()]
        public Mode mode
        { get; set; }


        // member classes
        #region Face
        [Serializable()]
        [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
        public partial class Face : PassParamBase
        {
            public Face()
            { this.value = GL_Face.FRONT_AND_BACK; }

            [XmlAttribute()]
            [DefaultValueAttribute(GL_Face.FRONT_AND_BACK)]
            public GL_Face value
            { get; set; }
        }
        #endregion

        #region Mode
        [Serializable()]
        [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
        public partial class Mode : PassParamBase
        {
            public Mode()
            { this.value = GL_PolygonMode.FILL; }

            [XmlAttribute()]
            [DefaultValueAttribute(GL_PolygonMode.FILL)]
            public GL_PolygonMode value
            { get; set; }
        }
        #endregion
    }

    [Serializable()]
    [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
    public partial class PolygonOffset : PassParamBase
    {
        public PolygonOffset()
        { this.value = new float[] { 0, 0 }; }

        [XmlAttribute()]
        public float[] value
        { get; set; }
    }

    [Serializable()]
    [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
    public partial class PolygonOffsetFillEnable : PassParamBase
    {
        public PolygonOffsetFillEnable()
        { this.value = false; }

        [XmlAttribute()]
        [DefaultValueAttribute(false)]
        public bool value
        { get; set; }
    }

    [Serializable()]
    [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
    public partial class PolygonOffsetLineEnable : PassParamBase
    {
        public PolygonOffsetLineEnable()
        { this.value = false; }

        [XmlAttribute()]
        [DefaultValueAttribute(false)]
        public bool value
        { get; set; }
    }

    [Serializable()]
    [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
    public partial class PolygonOffsetPointEnable : PassParamBase
    {
        public PolygonOffsetPointEnable()
        { this.value = false; }

        [XmlAttribute()]
        [DefaultValueAttribute(false)]
        public bool value
        { get; set; }
    }

    [Serializable()]
    [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
    public partial class PolygonSmoothEnable : PassParamBase
    {
        public PolygonSmoothEnable()
        { this.value = false; }

        [XmlAttribute()]
        [DefaultValueAttribute(false)]
        public bool value
        { get; set; }
    }

    [Serializable()]
    [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
    public partial class PolygonStippleEnable : PassParamBase
    {
        public PolygonStippleEnable()
        { this.value = false; }

        [XmlAttribute()]
        [DefaultValueAttribute(false)]
        public bool value
        { get; set; }
    }
    #endregion

    [Serializable()]
    [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
    public partial class ProjectionMatrix : PassParamBase
    {
        public ProjectionMatrix()
        {
            this.value = new float[] {
                    1, 0, 0, 0,
                    0, 1, 0, 0,
                    0, 0, 1, 0,
                    0, 0, 0, 1};
        }

        [XmlAttribute()]
        public float[] value
        { get; set; }
    }

    [Serializable()]
    [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
    public partial class RescaleNormalEnable : PassParamBase
    {
        public RescaleNormalEnable()
        { this.value = false; }

        [XmlAttribute()]
        [DefaultValueAttribute(false)]
        public bool value
        { get; set; }
    }

    #region Sample
    [Serializable()]
    [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
    public partial class SampleAlphaToCoverageEnable : PassParamBase
    {
        public SampleAlphaToCoverageEnable()
        { this.value = false; }

        [XmlAttribute()]
        [DefaultValueAttribute(false)]
        public bool value
        { get; set; }
    }

    [Serializable()]
    [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
    public partial class SampleAlphaToOneEnable : PassParamBase
    {
        public SampleAlphaToOneEnable()
        { this.value = false; }

        [XmlAttribute()]
        [DefaultValueAttribute(false)]
        public bool value
        { get; set; }
    }

    [Serializable()]
    [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
    public partial class SampleCoverageEnable : PassParamBase
    {
        public SampleCoverageEnable()
        { this.value = false; }

        [XmlAttribute()]
        [DefaultValueAttribute(false)]
        public bool value
        { get; set; }
    }
    #endregion

    #region Sampler
    [Serializable()]
    [XmlType(Namespace = Collada.XMLNAMESPACE)]
    [XmlRoot(Namespace = Collada.XMLNAMESPACE, IsNullable = true)]
    public partial class SamplerBase
    {
        [XmlElement(DataType = "NCName")]
        public string source
        { get; set; }

        [XmlElement()]
        [DefaultValueAttribute(SamplerWrap.WRAP)]
        public SamplerWrap wrap_s
        { get; set; }

        [XmlElement()]
        [DefaultValueAttribute(SamplerFilter.NONE)]
        public SamplerFilter minfilter
        { get; set; }

        [XmlElement()]
        [DefaultValueAttribute(SamplerFilter.NONE)]
        public SamplerFilter magfilter
        { get; set; }

        [XmlElement("extra")]
        public Extra[] extra
        { get; set; }
    }

    [Serializable()]
    [XmlType(Namespace = Collada.XMLNAMESPACE)]
    [XmlRoot(Namespace = Collada.XMLNAMESPACE, IsNullable = true)]
    public partial class Sampler1DBase : SamplerBase
    {
        [XmlElement()]
        [DefaultValueAttribute(SamplerFilter.NONE)]
        public SamplerFilter mipfilter
        { get; set; }

        [XmlElement()]
        public string border_color
        { get; set; }

        [XmlElement()]
        [DefaultValueAttribute((byte)0)]
        public byte mipmap_maxlevel
        { get; set; }

        [XmlElement()]
        [DefaultValueAttribute(0.0f)]
        public float mipmap_bias
        { get; set; }

    }

    [Serializable()]
    [XmlType(Namespace = Collada.XMLNAMESPACE)]
    [XmlRoot(Namespace = Collada.XMLNAMESPACE, IsNullable = true)]
    public partial class Sampler2DBase : Sampler1DBase
    {
        [XmlElement()]
        [DefaultValueAttribute(SamplerWrap.WRAP)]
        public SamplerWrap wrap_t
        { get; set; }
    }

    [Serializable()]
    [XmlType(Namespace = Collada.XMLNAMESPACE)]
    [XmlRoot(Namespace = Collada.XMLNAMESPACE, IsNullable = true)]
    public partial class Sampler3DBase : Sampler2DBase
    {
        [XmlElement()]
        [DefaultValueAttribute(SamplerWrap.WRAP)]
        public SamplerWrap wrap_p
        { get; set; }
    }

    [Serializable()]
    [XmlType(Namespace = Collada.XMLNAMESPACE)]
    [XmlRoot(Namespace = Collada.XMLNAMESPACE, IsNullable = true)]
    public partial class Sampler1D : Sampler1DBase
    {
        public Sampler1D()
        {
            this.wrap_s = SamplerWrap.WRAP;
            this.minfilter = SamplerFilter.NONE;
            this.magfilter = SamplerFilter.NONE;
            this.mipfilter = SamplerFilter.NONE;
            this.mipmap_maxlevel = ((byte)(0));
            this.mipmap_bias = ((float)(0F));
        }
    }

    [Serializable()]
    [XmlType(Namespace = Collada.XMLNAMESPACE)]
    [XmlRoot(Namespace = Collada.XMLNAMESPACE, IsNullable = true)]
    public partial class Sampler2D : Sampler2DBase
    {
        // constructors
        public Sampler2D()
        {
            this.wrap_s = SamplerWrap.WRAP;
            this.wrap_t = SamplerWrap.WRAP;
            this.minfilter = SamplerFilter.NONE;
            this.magfilter = SamplerFilter.NONE;
            this.mipfilter = SamplerFilter.NONE;
            this.mipmap_maxlevel = ((byte)(255));
            this.mipmap_bias = ((float)(0F));
        }

        public Sampler2D(string source)
        {
            this.wrap_s = SamplerWrap.WRAP;
            this.wrap_t = SamplerWrap.WRAP;
            this.minfilter = SamplerFilter.NONE;
            this.magfilter = SamplerFilter.NONE;
            this.mipfilter = SamplerFilter.NONE;
            this.mipmap_maxlevel = ((byte)(255));
            this.mipmap_bias = ((float)(0F));
            this.source = source;
        }
    }

    [Serializable()]
    [XmlType(Namespace = Collada.XMLNAMESPACE)]
    [XmlRoot(Namespace = Collada.XMLNAMESPACE, IsNullable = true)]
    public partial class Sampler3D : Sampler3DBase
    {
        public Sampler3D()
        {
            this.wrap_s = SamplerWrap.WRAP;
            this.wrap_t = SamplerWrap.WRAP;
            this.wrap_p = SamplerWrap.WRAP;
            this.minfilter = SamplerFilter.NONE;
            this.magfilter = SamplerFilter.NONE;
            this.mipfilter = SamplerFilter.NONE;
            this.mipmap_maxlevel = ((byte)(255));
            this.mipmap_bias = ((float)(0F));
        }

    }

    [Serializable()]
    [XmlType(Namespace = Collada.XMLNAMESPACE)]
    [XmlRoot(Namespace = Collada.XMLNAMESPACE, IsNullable = true)]
    public partial class SamplerRECT : Sampler2DBase
    {
        public SamplerRECT()
        {
            this.wrap_s = SamplerWrap.WRAP;
            this.wrap_t = SamplerWrap.WRAP;
            this.minfilter = SamplerFilter.NONE;
            this.magfilter = SamplerFilter.NONE;
            this.mipfilter = SamplerFilter.NONE;
            this.mipmap_maxlevel = ((byte)(255));
            this.mipmap_bias = ((float)(0F));
        }

    }

    [Serializable()]
    [XmlType(Namespace = Collada.XMLNAMESPACE)]
    [XmlRoot(Namespace = Collada.XMLNAMESPACE, IsNullable = true)]
    public partial class SamplerCUBE : Sampler3DBase
    {
        public SamplerCUBE()
        {
            this.wrap_s = SamplerWrap.WRAP;
            this.wrap_t = SamplerWrap.WRAP;
            this.wrap_p = SamplerWrap.WRAP;
            this.minfilter = SamplerFilter.NONE;
            this.magfilter = SamplerFilter.NONE;
            this.mipfilter = SamplerFilter.NONE;
            this.mipmap_maxlevel = ((byte)(255));
            this.mipmap_bias = ((float)(0F));
        }
    }

    [Serializable()]
    [XmlType(Namespace = Collada.XMLNAMESPACE)]
    [XmlRoot(Namespace = Collada.XMLNAMESPACE, IsNullable = true)]
    public partial class SamplerDEPTH : SamplerBase
    {
        [XmlElement()]
        [DefaultValueAttribute(SamplerWrap.WRAP)]
        public SamplerWrap wrap_t
        { get; set; }

        public SamplerDEPTH()
        {
            this.wrap_s = SamplerWrap.WRAP;
            this.wrap_t = SamplerWrap.WRAP;
            this.minfilter = SamplerFilter.NONE;
            this.magfilter = SamplerFilter.NONE;
        }

    }

    #endregion

    #region Scissor
    [Serializable()]
    [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
    public partial class Scissor : PassParamBase
    {
        [XmlAttribute()]
        public long[] value
        { get; set; }
    }

    [Serializable()]
    [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
    public partial class ScissorTestEnable : PassParamBase
    {
        public ScissorTestEnable()
        { this.value = false; }

        [XmlAttribute()]
        [DefaultValueAttribute(false)]
        public bool value
        { get; set; }
    }
    #endregion

    [Serializable()]
    [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
    public partial class ShadeModel : PassParamBase
    {
        public ShadeModel()
        { this.value = GL_ShadeModel.SMOOTH; }

        [XmlAttribute()]
        [DefaultValueAttribute(GL_ShadeModel.SMOOTH)]
        public GL_ShadeModel value
        { get; set; }
    }

    #region Shader
    [Serializable()]
    [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
    public partial class ShaderBase
    {
        [XmlElement("annotate")]
        public Annotate[] annotate
        { get; set; }

        [XmlElement()]
        public CompilerTarget compiler_target
        { get; set; }

        [XmlElement()]
        public string compiler_options
        { get; set; }

        [XmlElement()]
        public Name name
        { get; set; }

        [XmlAttribute()]
        public Pipeline_Stage stage
        { get; set; }

        [XmlIgnoreAttribute()]
        public bool stageSpecified
        { get; set; }


        // member classes
        #region CompilerTarget
        [Serializable()]
        [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
        public partial class CompilerTarget
        {
            [XmlTextAttribute(DataType = "NMTOKEN")]
            public string value
            { get; set; }
        }
        #endregion

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
    public partial class Shader : ShaderBase
    {

        [XmlElement("bind")]
        public Bind[] bind
        { get; set; }

        // member classes
        #region Bind
        [Serializable()]
        [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
        public partial class Bind
        {
            [XmlElement("bool", typeof(bool))]
            [XmlElement("bool2", typeof(bool))]
            [XmlElement("bool3", typeof(bool))]
            [XmlElement("bool4", typeof(bool))]
            [XmlElement("enum", typeof(string))]
            [XmlElement("float", typeof(float))]
            [XmlElement("float2", typeof(float))]
            [XmlElement("float2x2", typeof(float))]
            [XmlElement("float3", typeof(float))]
            [XmlElement("float3x3", typeof(float))]
            [XmlElement("float4", typeof(float))]
            [XmlElement("float4x4", typeof(float))]
            [XmlElement("int", typeof(int))]
            [XmlElement("int2", typeof(int))]
            [XmlElement("int3", typeof(int))]
            [XmlElement("int4", typeof(int))]
            [XmlElement("param", typeof(ColladaNET.FX.Types.Param))]
            [XmlElement("sampler1D", typeof(Sampler1D))]
            [XmlElement("sampler2D", typeof(Sampler2D))]
            [XmlElement("sampler3D", typeof(Sampler3D))]
            [XmlElement("samplerCUBE", typeof(SamplerCUBE))]
            [XmlElement("samplerDEPTH", typeof(SamplerDEPTH))]
            [XmlElement("samplerRECT", typeof(SamplerRECT))]
            [XmlElement("surface", typeof(Surface))]
            [XmlChoiceIdentifierAttribute("itemElementName")]
            public object item
            { get; set; }

            [XmlElement("itemElementName")]
            [XmlIgnoreAttribute()]
            public ItemsChoice_CGFieldType itemElementName
            { get; set; }

            [XmlAttribute(DataType = "NCName")]
            public string symbol
            { get; set; }
        }
        #endregion
    }

    [Serializable()]
    [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
    public partial class ShaderCG : ShaderBase
    {
        [XmlElement("bind")]
        public Bind[] bind
        { get; set; }

        // member classes
        #region Bind
        [Serializable()]
        [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
        public partial class Bind
        {
            [XmlElement("bool", typeof(bool))]
            [XmlElement("bool1", typeof(bool))]
            [XmlElement("bool1x1", typeof(bool))]
            [XmlElement("bool1x2", typeof(bool))]
            [XmlElement("bool1x3", typeof(bool))]
            [XmlElement("bool1x4", typeof(bool))]
            [XmlElement("bool2", typeof(bool))]
            [XmlElement("bool2x1", typeof(bool))]
            [XmlElement("bool2x2", typeof(bool))]
            [XmlElement("bool2x3", typeof(bool))]
            [XmlElement("bool2x4", typeof(bool))]
            [XmlElement("bool3", typeof(bool))]
            [XmlElement("bool3x1", typeof(bool))]
            [XmlElement("bool3x2", typeof(bool))]
            [XmlElement("bool3x3", typeof(bool))]
            [XmlElement("bool3x4", typeof(bool))]
            [XmlElement("bool4", typeof(bool))]
            [XmlElement("bool4x1", typeof(bool))]
            [XmlElement("bool4x2", typeof(bool))]
            [XmlElement("bool4x3", typeof(bool))]
            [XmlElement("bool4x4", typeof(bool))]
            [XmlElement("enum", typeof(string))]
            [XmlElement("fixed", typeof(float))]
            [XmlElement("fixed1", typeof(float))]
            [XmlElement("fixed1x1", typeof(float))]
            [XmlElement("fixed1x2", typeof(float))]
            [XmlElement("fixed1x3", typeof(float))]
            [XmlElement("fixed1x4", typeof(float))]
            [XmlElement("fixed2", typeof(float))]
            [XmlElement("fixed2x1", typeof(float))]
            [XmlElement("fixed2x2", typeof(float))]
            [XmlElement("fixed2x3", typeof(float))]
            [XmlElement("fixed2x4", typeof(float))]
            [XmlElement("fixed3", typeof(float))]
            [XmlElement("fixed3x1", typeof(float))]
            [XmlElement("fixed3x2", typeof(float))]
            [XmlElement("fixed3x3", typeof(float))]
            [XmlElement("fixed3x4", typeof(float))]
            [XmlElement("fixed4", typeof(float))]
            [XmlElement("fixed4x1", typeof(float))]
            [XmlElement("fixed4x2", typeof(float))]
            [XmlElement("fixed4x3", typeof(float))]
            [XmlElement("fixed4x4", typeof(float))]
            [XmlElement("float", typeof(float))]
            [XmlElement("float1", typeof(float))]
            [XmlElement("float1x1", typeof(float))]
            [XmlElement("float1x2", typeof(float))]
            [XmlElement("float1x3", typeof(float))]
            [XmlElement("float1x4", typeof(float))]
            [XmlElement("float2", typeof(float))]
            [XmlElement("float2x1", typeof(float))]
            [XmlElement("float2x2", typeof(float))]
            [XmlElement("float2x3", typeof(float))]
            [XmlElement("float2x4", typeof(float))]
            [XmlElement("float3", typeof(float))]
            [XmlElement("float3x1", typeof(float))]
            [XmlElement("float3x2", typeof(float))]
            [XmlElement("float3x3", typeof(float))]
            [XmlElement("float3x4", typeof(float))]
            [XmlElement("float4", typeof(float))]
            [XmlElement("float4x1", typeof(float))]
            [XmlElement("float4x2", typeof(float))]
            [XmlElement("float4x3", typeof(float))]
            [XmlElement("float4x4", typeof(float))]
            [XmlElement("half", typeof(float))]
            [XmlElement("half1", typeof(float))]
            [XmlElement("half1x1", typeof(float))]
            [XmlElement("half1x2", typeof(float))]
            [XmlElement("half1x3", typeof(float))]
            [XmlElement("half1x4", typeof(float))]
            [XmlElement("half2", typeof(float))]
            [XmlElement("half2x1", typeof(float))]
            [XmlElement("half2x2", typeof(float))]
            [XmlElement("half2x3", typeof(float))]
            [XmlElement("half2x4", typeof(float))]
            [XmlElement("half3", typeof(float))]
            [XmlElement("half3x1", typeof(float))]
            [XmlElement("half3x2", typeof(float))]
            [XmlElement("half3x3", typeof(float))]
            [XmlElement("half3x4", typeof(float))]
            [XmlElement("half4", typeof(float))]
            [XmlElement("half4x1", typeof(float))]
            [XmlElement("half4x2", typeof(float))]
            [XmlElement("half4x3", typeof(float))]
            [XmlElement("half4x4", typeof(float))]
            [XmlElement("int", typeof(int))]
            [XmlElement("int1", typeof(int))]
            [XmlElement("int1x1", typeof(int))]
            [XmlElement("int1x2", typeof(int))]
            [XmlElement("int1x3", typeof(int))]
            [XmlElement("int1x4", typeof(int))]
            [XmlElement("int2", typeof(int))]
            [XmlElement("int2x1", typeof(int))]
            [XmlElement("int2x2", typeof(int))]
            [XmlElement("int2x3", typeof(int))]
            [XmlElement("int2x4", typeof(int))]
            [XmlElement("int3", typeof(int))]
            [XmlElement("int3x1", typeof(int))]
            [XmlElement("int3x2", typeof(int))]
            [XmlElement("int3x3", typeof(int))]
            [XmlElement("int3x4", typeof(int))]
            [XmlElement("int4", typeof(int))]
            [XmlElement("int4x1", typeof(int))]
            [XmlElement("int4x2", typeof(int))]
            [XmlElement("int4x3", typeof(int))]
            [XmlElement("int4x4", typeof(int))]
            [XmlElement("param", typeof(ColladaNET.FX.Types.Param))]
            [XmlElement("sampler1D", typeof(Sampler1D))]
            [XmlElement("sampler2D", typeof(Sampler2D))]
            [XmlElement("sampler3D", typeof(Sampler3D))]
            [XmlElement("samplerCUBE", typeof(SamplerCUBE))]
            [XmlElement("samplerDEPTH", typeof(SamplerDEPTH))]
            [XmlElement("samplerRECT", typeof(SamplerRECT))]
            [XmlElement("string", typeof(string))]
            [XmlElement("surface", typeof(CG_Surface))]
            [XmlChoiceIdentifierAttribute("itemElementName")]
            public object item
            { get; set; }

            [XmlElement("itemElementName")]
            [XmlIgnoreAttribute()]
            public ItemsChoice_CGFieldTypeExtended itemElementName
            { get; set; }

            [XmlAttribute(DataType = "NCName")]
            public string symbol
            { get; set; }

        }
        #endregion
    }
    #endregion

    #region Stencil
    [Serializable()]
    [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
    public partial class StencilFunc
    {
        [XmlElement()]
        public Func func
        { get; set; }

        [XmlElement()]
        public Ref @ref
        { get; set; }

        [XmlElement()]
        public Mask mask
        { get; set; }

        // member classes
        #region Func
        [Serializable()]
        [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
        public partial class Func : PassParamBase
        {
            public Func()
            { this.value = GL_Func.ALWAYS; }

            [XmlAttribute()]
            [DefaultValueAttribute(GL_Func.ALWAYS)]
            public GL_Func value
            { get; set; }
        }
        #endregion

        #region Ref
        [Serializable()]
        [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
        public partial class Ref : PassParamBase
        {
            public Ref()
            { this.value = ((byte)(0)); }

            [XmlAttribute()]
            [DefaultValueAttribute(typeof(byte), "0")]
            public byte value
            { get; set; }
        }
        #endregion

        #region Mask
        [Serializable()]
        [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
        public partial class Mask : PassParamBase
        {
            public Mask()
            { this.value = ((byte)(255)); }

            [XmlAttribute()]
            [DefaultValueAttribute(typeof(byte), "255")]
            public byte value
            { get; set; }
        }
        #endregion

    }

    [Serializable()]
    [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
    public partial class StencilFuncSeparate
    {
        [XmlElement()]
        public Front front
        { get; set; }

        [XmlElement()]
        public Back back
        { get; set; }

        [XmlElement()]
        public Ref @ref
        { get; set; }

        [XmlElement()]
        public Mask mask
        { get; set; }

        // member classes
        #region Front
        [Serializable()]
        [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
        public partial class Front : PassParamBase
        {
            public Front()
            { this.value = GL_Func.ALWAYS; }

            [XmlAttribute()]
            [DefaultValueAttribute(GL_Func.ALWAYS)]
            public GL_Func value
            { get; set; }
        }
        #endregion

        #region Back
        [Serializable()]
        [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
        public partial class Back : PassParamBase
        {
            public Back()
            { this.value = GL_Func.ALWAYS; }

            [XmlAttribute()]
            [DefaultValueAttribute(GL_Func.ALWAYS)]
            public GL_Func value
            { get; set; }
        }
        #endregion

        #region Ref
        [Serializable()]
        [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
        public partial class Ref : PassParamBase
        {
            public Ref()
            { this.value = ((byte)(0)); }

            [XmlAttribute()]
            [DefaultValueAttribute(typeof(byte), "0")]
            public byte value
            { get; set; }
        }
        #endregion

        #region Mask
        [Serializable()]
        [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
        public partial class Mask : PassParamBase
        {
            public Mask()
            { this.value = ((byte)(255)); }

            [XmlAttribute()]
            [DefaultValueAttribute(typeof(byte), "255")]
            public byte value
            { get; set; }
        }
        #endregion
    }

    [Serializable()]
    [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
    public partial class StencilMask : PassParamBase
    {
        public StencilMask()
        { this.value = ((long)(4294967295)); }

        [XmlAttribute()]
        [DefaultValueAttribute(typeof(long), "4294967295")]
        public long value
        { get; set; }
    }

    [Serializable()]
    [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
    public partial class StencilMaskSeparate
    {

        [XmlElement()]
        public Face face
        { get; set; }

        [XmlElement()]
        public Mask mask
        { get; set; }


        // member classes      
        #region Face
        [Serializable()]
        [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
        public partial class Face : PassParamBase
        {
            public Face()
            { this.value = GL_Face.FRONT_AND_BACK; }

            [XmlAttribute()]
            [DefaultValueAttribute(GL_Face.FRONT_AND_BACK)]
            public GL_Face value
            { get; set; }
        }
        #endregion

        #region Mask
        [Serializable()]
        [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
        public partial class Mask : PassParamBase
        {
            public Mask()
            { this.value = ((byte)(255)); }

            [XmlAttribute()]
            [DefaultValueAttribute(typeof(byte), "255")]
            public byte value
            { get; set; }
        }
        #endregion

    }

    [Serializable()]
    [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
    public partial class StencilOp
    {
        [XmlElement()]
        public Fail fail
        { get; set; }

        [XmlElement()]
        public ZFail zfail
        { get; set; }

        [XmlElement()]
        public ZPass zpass
        { get; set; }

        // member classes
        #region Pass
        [Serializable()]
        [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
        public partial class Fail : PassParamBase
        {
            public Fail()
            { this.value = GLES_StencilOpType.KEEP; }

            [XmlAttribute()]
            [DefaultValueAttribute(GLES_StencilOpType.KEEP)]
            public GLES_StencilOpType value
            { get; set; }
        }
        #endregion

        #region Z Fail
        [Serializable()]
        [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
        public partial class ZFail : PassParamBase
        {
            public ZFail()
            { this.value = GLES_StencilOpType.KEEP; }

            [XmlAttribute()]
            [DefaultValueAttribute(GLES_StencilOpType.KEEP)]
            public GLES_StencilOpType value
            { get; set; }
        }
        #endregion

        #region Z Pass
        [Serializable()]
        [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
        public partial class ZPass : PassParamBase
        {
            public ZPass()
            { this.value = GLES_StencilOpType.KEEP; }

            [XmlAttribute()]
            [DefaultValueAttribute(GLES_StencilOpType.KEEP)]
            public GLES_StencilOpType value
            { get; set; }
        }
        #endregion
    }

    [Serializable()]
    [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
    public partial class StencilOpSeparate
    {
        [XmlElement()]
        public Face face
        { get; set; }

        [XmlElement()]
        public Fail fail
        { get; set; }

        [XmlElement()]
        public ZFail zfail
        { get; set; }

        [XmlElement()]
        public ZPass zpass
        { get; set; }

        // member classes
        #region Face
        [Serializable()]
        [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
        public partial class Face : PassParamBase
        {
            public Face()
            { this.value = GL_Face.FRONT_AND_BACK; }

            [XmlAttribute()]
            [DefaultValueAttribute(GL_Face.FRONT_AND_BACK)]
            public GL_Face value
            { get; set; }
        }
        #endregion

        #region Fail
        [Serializable()]
        [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
        public partial class Fail : PassParamBase
        {
            public Fail()
            { this.value = GL_StencilOp.KEEP; }

            [XmlAttribute()]
            [DefaultValueAttribute(GL_StencilOp.KEEP)]
            public GL_StencilOp value
            { get; set; }
        }
        #endregion

        #region ZFail
        [Serializable()]
        [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
        public partial class ZFail : PassParamBase
        {
            public ZFail()
            { this.value = GL_StencilOp.KEEP; }

            [XmlAttribute()]
            [DefaultValueAttribute(GL_StencilOp.KEEP)]
            public GL_StencilOp value
            { get; set; }
        }
        #endregion

        #region ZPass
        [Serializable()]
        [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
        public partial class ZPass : PassParamBase
        {
            public ZPass()
            { this.value = GL_StencilOp.KEEP; }

            [XmlAttribute()]
            [DefaultValueAttribute(GL_StencilOp.KEEP)]
            public GL_StencilOp value
            { get; set; }
        }
        #endregion
    }

    [Serializable()]
    [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
    public partial class StencilTestEnable : PassParamBase
    {
        public StencilTestEnable()
        { this.value = false; }

        [XmlAttribute()]
        [DefaultValueAttribute(false)]
        public bool value
        { get; set; }
    }
    #endregion

    #region Texture
    [Serializable()]
    [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
    public partial class TextureEnableBase : PassIndexedParam
    {
        [XmlAttribute()]
        [DefaultValueAttribute(false)]
        public bool value
        { get; set; }
    }

    [Serializable()]
    [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
    public partial class Texture1D
    {
        [XmlElement("param", typeof(string), DataType = "NCName")]
        [XmlElement("value", typeof(Sampler1D))] // changed from GL_Sampler..
        public object item
        { get; set; }

        [XmlAttribute(DataType = "nonNegativeInteger")]
        public string index
        { get; set; }
    }

    [Serializable()]
    [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
    public partial class Texture1DEnable : TextureEnableBase
    {
        public Texture1DEnable()
        { this.value = false; }
    }

    [Serializable()]
    [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
    public partial class Texture2D
    {
        [XmlElement("param", typeof(string), DataType = "NCName")]
        [XmlElement("value", typeof(Sampler2D))] // changed from GL_Sampler..
        public object item
        { get; set; }

        [XmlAttribute(DataType = "nonNegativeInteger")]
        public string index
        { get; set; }
    }

    [Serializable()]
    [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
    public partial class Texture2DEnable : TextureEnableBase
    {
        public Texture2DEnable()
        { this.value = false; }
    }

    [Serializable()]
    [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
    public partial class Texture3D
    {
        [XmlElement("param", typeof(string), DataType = "NCName")]
        [XmlElement("value", typeof(Sampler3D))] // changed from GL_Sampler..
        public object item
        { get; set; }

        [XmlAttribute(DataType = "nonNegativeInteger")]

        public string index
        { get; set; }
    }

    [Serializable()]
    [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
    public partial class Texture3DEnable : TextureEnableBase
    {
        public Texture3DEnable()
        { this.value = false; }
    }

    [Serializable()]
    [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
    public partial class TextureCUBE
    {
        [XmlElement("param", typeof(string), DataType = "NCName")]
        [XmlElement("value", typeof(SamplerCUBE))]
        public object item
        { get; set; }

        [XmlAttribute(DataType = "nonNegativeInteger")]
        public string index
        { get; set; }
    }

    [Serializable()]
    [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
    public partial class TextureCUBEEnable : TextureEnableBase
    {
        public TextureCUBEEnable()
        { this.value = false; }
    }

    [Serializable()]
    [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
    public partial class TextureDEPTH
    {
        [XmlElement("param", typeof(string), DataType = "NCName")]
        [XmlElement("value", typeof(SamplerDEPTH))] // changed from GL_Sampler..
        public object item
        { get; set; }

        [XmlAttribute(DataType = "nonNegativeInteger")]
        public string index
        { get; set; }
    }

    [Serializable()]
    [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
    public partial class TextureDEPTHEnable : TextureEnableBase
    {
        public TextureDEPTHEnable()
        { this.value = false; }
    }

    [Serializable()]
    [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
    public partial class TextureRECT
    {
        [XmlElement("param", typeof(string), DataType = "NCName")]
        [XmlElement("value", typeof(SamplerRECT))] // changed from GL_Sampler..
        public object item
        { get; set; }

        [XmlAttribute(DataType = "nonNegativeInteger")]
        public string index
        { get; set; }
    }

    [Serializable()]
    [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
    public partial class TextureRECTEnable : TextureEnableBase
    {
        public TextureRECTEnable()
        { this.value = false; }
    }

    [Serializable()]
    [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
    public partial class TextureEnvColor : PassIndexedParam
    {
        [XmlAttribute()]
        public float[] value
        { get; set; }
    }

    [Serializable()]
    [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
    public partial class TextureEnvMode : PassIndexedParam
    {
        [XmlAttribute()]
        public string value
        { get; set; }
    }
    #endregion

    #region Texture_Pipeline
    [Serializable()]
    [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
    public partial class TexturePipeline : PassParamBase
    {
        [XmlElement()]
        public GLES.GLES_TexturePipeline value
        { get; set; }
    }

    [Serializable()]
    [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
    public partial class TexturePipelineEnable : PassParamBase
    {
        public TexturePipelineEnable()
        { this.value = false; }

        [XmlAttribute()]
        [DefaultValueAttribute(false)]
        public bool value
        { get; set; }
    }
    #endregion

}
