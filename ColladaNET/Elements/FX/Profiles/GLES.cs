using ColladaNET.Elements;
using ColladaNET.FX.Profiles.Shared;
using ColladaNET.FX.Types;
using System;
using System.ComponentModel;
using System.Xml.Serialization;

namespace ColladaNET.FX.Profiles
{
    [Serializable()]
    [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
    [XmlRoot("profile_GLES", Namespace = Collada.XMLNAMESPACE, IsNullable = false)]
    public partial class GLES : ProfileBase<GLES.Technique, GLES.Technique.GLES_NewParam>
    {

        [XmlAttribute(DataType = "NCName")]
        [DefaultValueAttribute("PC")]
        public string platform




        { get; set; }
        public GLES()
        {
            this.platform = "PC";
        }


        // member classes
        #region Technique
        [Serializable()]
        [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
        public partial class Technique : TechniqueBase
        {
            [XmlElement()]
            public Asset asset
            { get; set; }

            [XmlElement("annotate")]
            public Annotate[] annotate
            { get; set; }

            [XmlElement("setparam", typeof(SetParam))]
            public SetParam[] setparam
            { get; set; }

            [XmlElement("newparam", typeof(GLES_NewParam))]
            public GLES_NewParam[] newparam
            { get; set; }

            [XmlElement("pass")]
            public Pass[] pass
            { get; set; }


            // member classes
            #region SetParam
            [Serializable()]
            [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
            public partial class SetParam
            {
                [XmlElement("annotate")]
                public Annotate[] annotate
                { get; set; }

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
                public float float1x1
                { get; set; }

                [XmlElement()]
                public string float1x2
                { get; set; }

                [XmlElement()]
                public string float1x3
                { get; set; }

                [XmlElement()]
                public string float1x4
                { get; set; }

                [XmlElement()]
                public string float2x1
                { get; set; }

                [XmlElement()]
                public string float2x2
                { get; set; }

                [XmlElement()]
                public string float2x3
                { get; set; }

                [XmlElement()]
                public string float2x4
                { get; set; }

                [XmlElement()]
                public string float3x1
                { get; set; }

                [XmlElement()]
                public string float3x2
                { get; set; }

                [XmlElement()]
                public string float3x3
                { get; set; }

                [XmlElement()]
                public string float3x4
                { get; set; }

                [XmlElement()]
                public string float4x1
                { get; set; }

                [XmlElement()]
                public string float4x2
                { get; set; }

                [XmlElement()]
                public string float4x3
                { get; set; }

                [XmlElement()]
                public string float4x4
                { get; set; }

                [XmlElement()]
                public Surface surface
                { get; set; }

                [XmlElement()]
                public GLES_TexturePipeline texture_pipeline
                { get; set; }

                [XmlElement()]
                public GLES_SamplerState sampler_state
                { get; set; }

                [XmlElement()]
                public GLES_TextureUnit texture_unit
                { get; set; }

                [XmlElement()]
                public string @enum
                { get; set; }

                [XmlAttribute(DataType = "NCName")]
                public string @ref
                { get; set; }
            }
            #endregion

            #region Pass
            [Serializable()]
            [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
            public partial class Pass
            {
                [XmlElement("annotate")]
                public Annotate[] annotate
                { get; set; }

                [XmlElement(DataType = "NCName")]
                public string color_target
                { get; set; }

                [XmlElement(DataType = "NCName")]
                public string depth_target
                { get; set; }

                [XmlElement(DataType = "NCName")]
                public string stencil_target
                { get; set; }

                [XmlElement()]
                public string color_clear
                { get; set; }

                [XmlElement()]
                public float depth_clear
                { get; set; }

                [XmlIgnoreAttribute()]
                public bool depth_clearSpecified
                { get; set; }

                [XmlElement()]
                public sbyte stencil_clear
                { get; set; }

                [XmlIgnoreAttribute()]
                public bool stencil_clearSpecified
                { get; set; }

                [XmlElement()]
                public string draw
                { get; set; }

                [XmlElement("alpha_func", typeof(AlphaFunc))]
                [XmlElement("alpha_test_enable", typeof(AlphaTestEnable))]
                [XmlElement("blend_enable", typeof(BlendEnable))]
                [XmlElement("blend_func", typeof(BlendFunc))]
                [XmlElement("clear_color", typeof(ClearColor))]
                [XmlElement("clear_depth", typeof(ClearDepth))]
                [XmlElement("clear_stencil", typeof(ClearStencil))]
                [XmlElement("clip_plane", typeof(ClipPlane))]
                [XmlElement("clip_plane_enable", typeof(ClipPlaneEnable))]
                [XmlElement("color_logic_op_enable", typeof(ColorLogicOpEnable))]
                [XmlElement("color_mask", typeof(ColorMask))]
                [XmlElement("color_material_enable", typeof(ColorMaterialEnable))]
                [XmlElement("cull_face", typeof(CullFace))]
                [XmlElement("cull_face_enable", typeof(CullFaceEnable))]
                [XmlElement("depth_func", typeof(DepthFunc))]
                [XmlElement("depth_mask", typeof(DepthMask))]
                [XmlElement("depth_range", typeof(DepthRange))]
                [XmlElement("depth_test_enable", typeof(DepthTestEnable))]
                [XmlElement("dither_enable", typeof(DitherEnable))]
                [XmlElement("fog_color", typeof(FogColor))]
                [XmlElement("fog_density", typeof(FogDensity))]
                [XmlElement("fog_enable", typeof(FogEnable))]
                [XmlElement("fog_end", typeof(FogEnd))]
                [XmlElement("fog_mode", typeof(FogMode))]
                [XmlElement("fog_start", typeof(FogStart))]
                [XmlElement("front_face", typeof(FrontFace))]
                [XmlElement("light_ambient", typeof(LightAmbient))]
                [XmlElement("light_constant_attenuation", typeof(LightConstantAttenuation))]
                [XmlElement("light_diffuse", typeof(LightDiffuse))]
                [XmlElement("light_enable", typeof(LightEnable))]
                [XmlElement("light_linear_attenutation", typeof(LightLinearAttenuation))]
                [XmlElement("light_model_ambient", typeof(LightModelAmbient))]
                [XmlElement("light_model_two_side_enable", typeof(LightModelTwoSideEnable))]
                [XmlElement("light_position", typeof(LightPosition))]
                [XmlElement("light_quadratic_attenuation", typeof(LightQuadraticAttenuation))]
                [XmlElement("light_specular", typeof(LightSpecular))]
                [XmlElement("light_spot_cutoff", typeof(LightSpotCutoff))]
                [XmlElement("light_spot_direction", typeof(LightSpotDirection))]
                [XmlElement("light_spot_exponent", typeof(LightSpotExponent))]
                [XmlElement("lighting_enable", typeof(LightingEnable))]
                [XmlElement("line_smooth_enable", typeof(LineSmoothEnable))]
                [XmlElement("line_width", typeof(LineWidth))]
                [XmlElement("logic_op", typeof(LogicOp))]
                [XmlElement("material_ambient", typeof(MaterialAmbient))]
                [XmlElement("material_diffuse", typeof(MaterialDiffuse))]
                [XmlElement("material_emission", typeof(MaterialEmission))]
                [XmlElement("material_shininess", typeof(MaterialShininess))]
                [XmlElement("material_specular", typeof(MaterialSpecular))]
                [XmlElement("model_view_matrix", typeof(ModelViewMatrix))]
                [XmlElement("multisample_enable", typeof(MultisampleEnable))]
                [XmlElement("normalize_enable", typeof(NormalizeEnable))]
                [XmlElement("point_distance_attenuation", typeof(PointDistanceAttenuation))]
                [XmlElement("point_fade_threshold_size", typeof(PointFadeThresholdSize))]
                [XmlElement("point_size", typeof(PointSize))]
                [XmlElement("point_size_max", typeof(PointSizeMax))]
                [XmlElement("point_size_min", typeof(PointSizeMin))]
                [XmlElement("point_smooth_enable", typeof(PointSmoothEnable))]
                [XmlElement("polygon_offset", typeof(PolygonOffset))]
                [XmlElement("polygon_offset_fill_enable", typeof(PolygonOffsetFillEnable))]
                [XmlElement("projection_matrix", typeof(ProjectionMatrix))]
                [XmlElement("rescale_normal_enable", typeof(RescaleNormalEnable))]
                [XmlElement("sample_alpha_to_coverage_enable", typeof(SampleAlphaToCoverageEnable))]
                [XmlElement("sample_alpha_to_one_enable", typeof(SampleAlphaToOneEnable))]
                [XmlElement("sample_coverage_enable", typeof(SampleCoverageEnable))]
                [XmlElement("scissor", typeof(Scissor))]
                [XmlElement("scissor_test_enable", typeof(ScissorTestEnable))]
                [XmlElement("shade_model", typeof(ShadeModel))]
                [XmlElement("stencil_func", typeof(StencilFunc))]
                [XmlElement("stencil_mask", typeof(StencilMask))]
                [XmlElement("stencil_op", typeof(StencilOp))]
                [XmlElement("stencil_test_enable", typeof(StencilTestEnable))]
                [XmlElement("texture_pipeline", typeof(TexturePipeline))]
                [XmlElement("texture_pipeline_enable", typeof(TexturePipelineEnable))]
                public object[] Items
                { get; set; }

                [XmlAttribute(DataType = "NCName")]
                public string sid
                { get; set; }

            }
            #endregion

            #region NewParam
            [Serializable()]
            [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
            //[XmlRoot(Namespace = Collada.XMLNAMESPACE, IsNullable = true)]
            public partial class GLES_NewParam : NewParamExtended
            {
                [XmlIgnoreAttribute()]
                public bool modifierSpecified
                { get; set; }

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
                public float float1x1
                { get; set; }

                [XmlElement()]
                public string float1x2
                { get; set; }

                [XmlElement()]
                public string float1x3
                { get; set; }

                [XmlElement()]
                public string float1x4
                { get; set; }

                [XmlElement()]
                public string float2x1
                { get; set; }

                [XmlElement()]
                public string float2x2
                { get; set; }

                [XmlElement()]
                public string float2x3
                { get; set; }

                [XmlElement()]
                public string float2x4
                { get; set; }

                [XmlElement()]
                public string float3x1
                { get; set; }

                [XmlElement()]
                public string float3x2
                { get; set; }

                [XmlElement()]
                public string float3x3
                { get; set; }

                [XmlElement()]
                public string float3x4
                { get; set; }

                [XmlElement()]
                public string float4x1
                { get; set; }

                [XmlElement()]
                public string float4x2
                { get; set; }

                [XmlElement()]
                public string float4x3
                { get; set; }

                [XmlElement()]
                public string float4x4
                { get; set; }

                [XmlElement()]
                public Surface surface
                { get; set; }

                [XmlElement()]
                public GLES_TexturePipeline texture_pipeline
                { get; set; }

                [XmlElement()]
                public GLES_SamplerState sampler_state
                { get; set; }

                [XmlElement()]
                public GLES_TextureUnit texture_unit
                { get; set; }

                [XmlElement()]
                public string @enum
                { get; set; }

            }
            #endregion
        }
        #endregion




        [Serializable()]
        [XmlType(Namespace = Collada.XMLNAMESPACE)]
        [XmlRoot(Namespace = Collada.XMLNAMESPACE, IsNullable = true)]
        public partial class GLES_TexturePipeline
        {
            [XmlElement("extra", typeof(Extra))]
            [XmlElement("texcombiner", typeof(TexCombiner))]
            [XmlElement("texenv", typeof(TexEnv))]
            public object[] items
            { get; set; }

            [XmlAttribute(DataType = "NCName")]
            public string sid
            { get; set; }

            // member classes
            #region TexCombiner
            [Serializable()]
            [XmlType(Namespace = Collada.XMLNAMESPACE)]
            [XmlRoot(Namespace = Collada.XMLNAMESPACE, IsNullable = true)]
            public partial class TexCombiner
            {
                [XmlElement()]
                public GLES_TextureConstant constant
                { get; set; }

                [XmlElement("RGB")]
                public RGB rgb
                { get; set; }

                [XmlElement()]
                public Alpha alpha
                { get; set; }

                // member classes
                #region RGB
                [Serializable()]
                [XmlType(Namespace = Collada.XMLNAMESPACE)]
                [XmlRoot(Namespace = Collada.XMLNAMESPACE, IsNullable = true)]
                public partial class RGB
                {
                    [XmlElement("argument")]
                    public RGBArgument[] argument
                    { get; set; }

                    [XmlAttribute()]
                    public GLES_TexCombinerOperatorRGB @operator
                    { get; set; }

                    [XmlIgnoreAttribute()]
                    public bool operatorSpecified
                    { get; set; }

                    [XmlAttribute()]
                    public float scale
                    { get; set; }

                    [XmlIgnoreAttribute()]
                    public bool scaleSpecified
                    { get; set; }


                    // member classes
                    #region Argument
                    [Serializable()]
                    [XmlType(Namespace = Collada.XMLNAMESPACE)]
                    [XmlRoot(Namespace = Collada.XMLNAMESPACE, IsNullable = true)]
                    public partial class RGBArgument
                    {
                        [XmlAttribute()]
                        public GLES_TexCombinerSource source
                        { get; set; }

                        [XmlIgnoreAttribute()]
                        public bool sourceSpecified
                        { get; set; }

                        [XmlAttribute()]
                        [DefaultValueAttribute(GLES_TexCombinerOperandRGB.SRC_COLOR)]
                        public GLES_TexCombinerOperandRGB operand
                        { get; set; }

                        [XmlAttribute(DataType = "NCName")]
                        public string unit
                        { get; set; }


                        public RGBArgument()
                        {
                            this.operand = GLES_TexCombinerOperandRGB.SRC_COLOR;
                        }

                    }

                    #endregion
                }
                #endregion

                #region Alpha
                [Serializable()]
                [XmlType(Namespace = Collada.XMLNAMESPACE)]
                [XmlRoot(Namespace = Collada.XMLNAMESPACE, IsNullable = true)]
                public partial class Alpha
                {
                    [XmlElement("argument")]
                    public AlphaArgument[] argument
                    { get; set; }

                    [XmlAttribute()]
                    public GLES_TexCombinerOperatorAlpha @operator
                    { get; set; }

                    [XmlIgnoreAttribute()]
                    public bool operatorSpecified
                    { get; set; }

                    [XmlAttribute()]
                    public float scale
                    { get; set; }

                    [XmlIgnoreAttribute()]
                    public bool scaleSpecified
                    { get; set; }


                    // member classes
                    #region Argument
                    [Serializable()]
                    [XmlType(Namespace = Collada.XMLNAMESPACE)]
                    [XmlRoot(Namespace = Collada.XMLNAMESPACE, IsNullable = true)]
                    public partial class AlphaArgument
                    {
                        [XmlAttribute()]
                        public GLES_TexCombinerSource source
                        { get; set; }

                        [XmlIgnoreAttribute()]
                        public bool sourceSpecified
                        { get; set; }

                        [XmlAttribute()]
                        [DefaultValueAttribute(GLES_TexCombinerOperandAlpha.SRC_ALPHA)]
                        public GLES_TexCombinerOperandAlpha operand
                        { get; set; }

                        [XmlAttribute(DataType = "NCName")]
                        public string unit
                        { get; set; }


                        public AlphaArgument()
                        {
                            this.operand = GLES_TexCombinerOperandAlpha.SRC_ALPHA;
                        }
                    }
                    #endregion

                }
                #endregion

            }
            #endregion

            #region TexEnv
            [Serializable()]
            [XmlType(Namespace = Collada.XMLNAMESPACE)]
            [XmlRoot(Namespace = Collada.XMLNAMESPACE, IsNullable = true)]
            public partial class TexEnv
            {
                [XmlElement()]
                public GLES_TextureConstant constant
                { get; set; }

                [XmlAttribute()]
                public GLES_TexEnvMode @operator
                { get; set; }

                [XmlIgnoreAttribute()]
                public bool operatorSpecified
                { get; set; }

                [XmlAttribute(DataType = "NCName")]
                public string unit
                { get; set; }
            }

            #endregion
        }

        [Serializable()]
        [XmlType(Namespace = Collada.XMLNAMESPACE)]
        [XmlRoot(Namespace = Collada.XMLNAMESPACE, IsNullable = true)]
        public partial class GLES_TextureConstant
        {
            [XmlAttribute()]
            public float[] value
            { get; set; }

            [XmlAttribute(DataType = "NCName")]
            public string param
            { get; set; }
        }


        [Serializable()]
        [XmlType(Namespace = Collada.XMLNAMESPACE)]
        [XmlRoot(Namespace = Collada.XMLNAMESPACE, IsNullable = true)]
        public partial class GLES_SamplerState
        {
            [XmlElement()]
            [DefaultValueAttribute(GLES_SamplerWrap.REPEAT)]
            public GLES_SamplerWrap wrap_s
            { get; set; }

            [XmlElement()]
            [DefaultValueAttribute(GLES_SamplerWrap.REPEAT)]
            public GLES_SamplerWrap wrap_t
            { get; set; }

            [XmlElement()]
            [DefaultValueAttribute(SamplerFilter.NONE)]
            public SamplerFilter minfilter
            { get; set; }

            [XmlElement()]
            [DefaultValueAttribute(SamplerFilter.NONE)]
            public SamplerFilter magfilter
            { get; set; }

            [XmlElement()]
            [DefaultValueAttribute(SamplerFilter.NONE)]
            public SamplerFilter mipfilter
            { get; set; }

            [XmlElement()]
            [DefaultValueAttribute((byte)255)]
            public byte mipmap_maxlevel
            { get; set; }

            [XmlElement()]
            [DefaultValueAttribute(0.0f)]
            public float mipmap_bias
            { get; set; }

            [XmlElement("extra")]
            public Extra[] extra
            { get; set; }

            [XmlAttribute(DataType = "NCName")]
            public string sid
            { get; set; }


            public GLES_SamplerState()
            {
                this.wrap_s = GLES_SamplerWrap.REPEAT;
                this.wrap_t = GLES_SamplerWrap.REPEAT;
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
        public partial class GLES_TextureUnit
        {
            [XmlElement(DataType = "NCName")]
            public string surface
            { get; set; }

            [XmlElement(DataType = "NCName")]
            public string sampler_state
            { get; set; }

            [XmlElement()]
            public Texcoord texcoord
            { get; set; }

            [XmlElement("extra")]
            public Extra[] extra
            { get; set; }

            [XmlAttribute(DataType = "NCName")]
            public string sid
            { get; set; }

            // member classes
            #region Texcoord
            [Serializable()]
            [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
            public partial class Texcoord
            {

                [XmlAttribute(DataType = "NCName")]
                public string semantic
                { get; set; }
            }
            #endregion
        }

    }

}