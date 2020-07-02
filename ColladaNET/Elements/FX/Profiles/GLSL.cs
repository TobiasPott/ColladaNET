using ColladaNET.Elements;
using ColladaNET.FX.Profiles.Shared;
using ColladaNET.FX.Types;
using System;
using System.Xml.Serialization;

namespace ColladaNET.FX.Profiles
{

    [Serializable()]
    [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
    [XmlRoot("profile_GLSL", Namespace = Collada.XMLNAMESPACE, IsNullable = false)]
    public partial class GLSL : ProfileBaseExtended<GLSL.Technique, GLSL.Technique.GLSL_NewParam>
    {

        // member classes
        #region Technique
        [Serializable()]
        [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
        public partial class Technique : TechniqueBase
        {

            [XmlElement("annotate")]
            public Annotate[] annotate
            { get; set; }

            [XmlElement("code", typeof(CodeProfile))]
            public CodeProfile[] code
            { get; set; }

            [XmlElement("include", typeof(Include))]
            public Include[] include
            { get; set; }

            [XmlElement("setparam", typeof(SetParam))]
            public SetParam[] setparam
            { get; set; }

            [XmlElement("newparam", typeof(GLSL_NewParam))]
            public GLSL_NewParam[] newparam
            { get; set; }


            [XmlElement("pass")]
            public Pass[] pass
            { get; set; }


            // member classes
            #region SetParam
            [Serializable()]
            [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
            //[XmlRoot(Namespace = Collada.XMLNAMESPACE, IsNullable = true)]
            public partial class SetParam
            {
                [XmlElement("annotate")]
                public Annotate[] annotate
                { get; set; }

                [XmlElement("array", typeof(GLSL_SetArray))]
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
                [XmlElement("sampler1D", typeof(Sampler1D))]
                [XmlElement("sampler2D", typeof(Sampler2D))]
                [XmlElement("sampler3D", typeof(Sampler3D))]
                [XmlElement("samplerCUBE", typeof(SamplerCUBE))]
                [XmlElement("samplerDEPTH", typeof(SamplerDEPTH))]
                [XmlElement("samplerRECT", typeof(SamplerRECT))]
                [XmlElement("surface", typeof(GLSL_Surface))]
                [XmlChoiceIdentifierAttribute("itemElementName")]
                public object item
                { get; set; }

                [XmlElement()]
                [XmlIgnoreAttribute()]
                public ItemsChoice_CGFieldType itemElementName
                { get; set; }

                [XmlAttribute(DataType = "token")]
                public string @ref
                { get; set; }

                [XmlAttribute(DataType = "NCName")]
                public string program
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

                [XmlElement("color_target")]
                public ColorTarget[] color_target
                { get; set; }

                [XmlElement("depth_target")]
                public DepthTarget[] depth_target
                { get; set; }

                [XmlElement("stencil_target")]
                public StencilTarget[] stencil_target
                { get; set; }

                [XmlElement("color_clear")]
                public ClearColor[] color_clear
                { get; set; }

                [XmlElement("depth_clear")]
                public ClearDepth[] depth_clear
                { get; set; }

                [XmlElement("stencil_clear")]
                public ClearStencil[] stencil_clear
                { get; set; }

                [XmlElement()]
                public string draw
                { get; set; }

                [XmlElement("alpha_func", typeof(Shared.AlphaFunc))]
                [XmlElement("alpha_test_enable", typeof(Shared.AlphaTestEnable))]
                [XmlElement("auto_normal_enable", typeof(AutoNormalEnable))]
                [XmlElement("blend_color", typeof(BlendColor))]
                [XmlElement("blend_enable", typeof(FX.Profiles.Shared.BlendEnable))]
                [XmlElement("blend_equation", typeof(BlendEquation))]
                [XmlElement("blend_equation_separate", typeof(BlendEquationSeparate))]
                [XmlElement("blend_func", typeof(FX.Profiles.Shared.BlendFunc))]
                [XmlElement("blend_func_separate", typeof(BlendFuncSeparate))]
                [XmlElement("clear_color", typeof(ClearColor))]
                [XmlElement("clear_depth", typeof(ClearDepth))]
                [XmlElement("clear_stencil", typeof(ClearStencil))]
                [XmlElement("clip_plane", typeof(ClipPlane))]
                [XmlElement("clip_plane_enable", typeof(ClipPlaneEnable))]
                [XmlElement("color_logic_op_enable", typeof(ColorLogicOpEnable))]
                [XmlElement("color_mask", typeof(ColorMask))]
                [XmlElement("color_material", typeof(ColorMaterial))]
                [XmlElement("color_material_enable", typeof(ColorMaterialEnable))]
                [XmlElement("cull_face", typeof(CullFace))]
                [XmlElement("cull_face_enable", typeof(CullFaceEnable))]
                [XmlElement("depth_bounds", typeof(DepthBounds))]
                [XmlElement("depth_bounds_enable", typeof(DepthBoundsEnable))]
                [XmlElement("depth_clamp_enable", typeof(DepthClampEnable))]
                [XmlElement("depth_func", typeof(DepthFunc))]
                [XmlElement("depth_mask", typeof(DepthMask))]
                [XmlElement("depth_range", typeof(DepthRange))]
                [XmlElement("depth_test_enable", typeof(DepthTestEnable))]
                [XmlElement("dither_enable", typeof(DitherEnable))]
                [XmlElement("fog_color", typeof(FogColor))]
                [XmlElement("fog_coord_src", typeof(FogCoordSrc))]
                [XmlElement("fog_density", typeof(FogDensity))]
                [XmlElement("fog_enable", typeof(FogEnable))]
                [XmlElement("fog_end", typeof(FogEnd))]
                [XmlElement("fog_mode", typeof(FogMode))]
                [XmlElement("fog_start", typeof(FogStart))]
                [XmlElement("front_face", typeof(FrontFace))]
                [XmlElement("gl_hook_abstract", typeof(object))]
                [XmlElement("light_ambient", typeof(LightAmbient))]
                [XmlElement("light_constant_attenuation", typeof(LightConstantAttenuation))]
                [XmlElement("light_diffuse", typeof(LightDiffuse))]
                [XmlElement("light_enable", typeof(LightEnable))]
                [XmlElement("light_linear_attenuation", typeof(LightLinearAttenuation))]
                [XmlElement("light_model_ambient", typeof(LightModelAmbient))]
                [XmlElement("light_model_color_control", typeof(LightModelColorControl))]
                [XmlElement("light_model_local_viewer_enable", typeof(LightModelLocalViewerEnable))]
                [XmlElement("light_model_two_side_enable", typeof(LightModelTwoSideEnable))]
                [XmlElement("light_position", typeof(LightPosition))]
                [XmlElement("light_quadratic_attenuation", typeof(LightQuadraticAttenuation))]
                [XmlElement("light_specular", typeof(LightSpecular))]
                [XmlElement("light_spot_cutoff", typeof(LightSpotCutoff))]
                [XmlElement("light_spot_direction", typeof(LightSpotDirection))]
                [XmlElement("light_spot_exponent", typeof(LightSpotExponent))]
                [XmlElement("lighting_enable", typeof(LightingEnable))]
                [XmlElement("line_smooth_enable", typeof(LineSmoothEnable))]
                [XmlElement("line_stipple", typeof(LineStipple))]
                [XmlElement("line_stipple_enable", typeof(LineStippleEnable))]
                [XmlElement("line_width", typeof(LineWidth))]
                [XmlElement("logic_op", typeof(LogicOp))]
                [XmlElement("logic_op_enable", typeof(LogicOpEnable))]
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
                [XmlElement("polygon_mode", typeof(PolygonMode))]
                [XmlElement("polygon_offset", typeof(PolygonOffset))]
                [XmlElement("polygon_offset_fill_enable", typeof(PolygonOffsetFillEnable))]
                [XmlElement("polygon_offset_line_enable", typeof(PolygonOffsetLineEnable))]
                [XmlElement("polygon_offset_point_enable", typeof(PolygonOffsetPointEnable))]
                [XmlElement("polygon_smooth_enable", typeof(PolygonSmoothEnable))]
                [XmlElement("polygon_stipple_enable", typeof(PolygonStippleEnable))]
                [XmlElement("projection_matrix", typeof(ProjectionMatrix))]
                [XmlElement("rescale_normal_enable", typeof(RescaleNormalEnable))]
                [XmlElement("sample_alpha_to_coverage_enable", typeof(SampleAlphaToCoverageEnable))]
                [XmlElement("sample_alpha_to_one_enable", typeof(SampleAlphaToOneEnable))]
                [XmlElement("sample_coverage_enable", typeof(SampleCoverageEnable))]
                [XmlElement("scissor", typeof(Scissor))]
                [XmlElement("scissor_test_enable", typeof(ScissorTestEnable))]
                [XmlElement("shade_model", typeof(ShadeModel))]
                [XmlElement("shader", typeof(Shader))]
                [XmlElement("stencil_func", typeof(StencilFunc))]
                [XmlElement("stencil_func_separate", typeof(StencilFuncSeparate))]
                [XmlElement("stencil_mask", typeof(StencilMask))]
                [XmlElement("stencil_mask_separate", typeof(StencilMaskSeparate))]
                [XmlElement("stencil_op", typeof(StencilOp))]
                [XmlElement("stencil_op_separate", typeof(StencilOpSeparate))]
                [XmlElement("stencil_test_enable", typeof(StencilTestEnable))]
                [XmlElement("texture1D", typeof(Texture1D))]
                [XmlElement("texture1D_enable", typeof(Texture1DEnable))]
                [XmlElement("texture2D", typeof(Texture2D))]
                [XmlElement("texture2D_enable", typeof(Texture2DEnable))]
                [XmlElement("texture3D", typeof(Texture3D))]
                [XmlElement("texture3D_enable", typeof(Texture3DEnable))]
                [XmlElement("textureCUBE", typeof(TextureCUBE))]
                [XmlElement("textureCUBE_enable", typeof(TextureCUBEEnable))]
                [XmlElement("textureDEPTH", typeof(TextureDEPTH))]
                [XmlElement("textureDEPTH_enable", typeof(TextureDEPTHEnable))]
                [XmlElement("textureRECT", typeof(TextureRECT))]
                [XmlElement("textureRECT_enable", typeof(TextureRECTEnable))]
                [XmlElement("texture_env_color", typeof(TextureEnvColor))]
                [XmlElement("texture_env_mode", typeof(TextureEnvMode))]
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
            public partial class GLSL_NewParam : NewParamExtended
            {
                [XmlIgnoreAttribute()]
                public bool modifierSpecified
                { get; set; }

                [XmlElement("array", typeof(GLSL_NewArray))]
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
                [XmlElement("sampler1D", typeof(Sampler1D))]
                [XmlElement("sampler2D", typeof(Sampler2D))]
                [XmlElement("sampler3D", typeof(Sampler3D))]
                [XmlElement("samplerCUBE", typeof(SamplerCUBE))]
                [XmlElement("samplerDEPTH", typeof(SamplerDEPTH))]
                [XmlElement("samplerRECT", typeof(SamplerRECT))]
                [XmlElement("surface", typeof(GLSL_Surface))]
                [XmlChoiceIdentifierAttribute("ItemElementName")]
                public object item
                { get; set; }

                [XmlElement()]
                [XmlIgnoreAttribute()]
                public ItemsChoice_CGFieldType ItemElementName
                { get; set; }

            }

            #endregion



            [Serializable()]
            [XmlType(Namespace = Collada.XMLNAMESPACE)]
            [XmlRoot(Namespace = Collada.XMLNAMESPACE, IsNullable = true)]
            public partial class GLSL_SetParamSimple
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
                public int @int
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
                public GLSL_Surface surface
                { get; set; }

                [XmlElement()]
                public Sampler1D sampler1D
                { get; set; }

                [XmlElement()]
                public Sampler2D sampler2D
                { get; set; }

                [XmlElement()]
                public Sampler3D sampler3D
                { get; set; }

                [XmlElement()]
                public SamplerCUBE samplerCUBE
                { get; set; }

                [XmlElement()]
                public SamplerRECT samplerRECT
                { get; set; }

                [XmlElement()]
                public SamplerDEPTH samplerDEPTH
                { get; set; }

                [XmlElement()]
                public string @enum
                { get; set; }

                [XmlAttribute(DataType = "token")]
                public string @ref
                { get; set; }
            }

            [Serializable()]
            [XmlType(Namespace = Collada.XMLNAMESPACE)]
            [XmlRoot(Namespace = Collada.XMLNAMESPACE, IsNullable = true)]
            public partial class GLSL_SetArray
            {

                [XmlElement("array", typeof(GLSL_SetArray))]
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
                [XmlElement("sampler1D", typeof(Sampler1D))]
                [XmlElement("sampler2D", typeof(Sampler2D))]
                [XmlElement("sampler3D", typeof(Sampler3D))]
                [XmlElement("samplerCUBE", typeof(SamplerCUBE))]
                [XmlElement("samplerDEPTH", typeof(SamplerDEPTH))]
                [XmlElement("samplerRECT", typeof(SamplerRECT))]
                [XmlElement("surface", typeof(GLSL_Surface))]
                [XmlChoiceIdentifierAttribute("itemsElementName")]
                public object[] items
                { get; set; }

                [XmlElement("itemsElementName")]
                [XmlIgnoreAttribute()]
                public ItemsChoice_CGFieldType[] itemsElementName
                { get; set; }

                [XmlAttribute(DataType = "unsignedInt")]
                public uint length
                { get; set; }
            }

            [Serializable()]
            [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
            [XmlRoot(ElementName = "array", Namespace = Collada.XMLNAMESPACE, IsNullable = true)]
            public partial class GLSL_NewArray
            {
                [XmlElement("array", typeof(GLSL_NewArray))]
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
                [XmlElement("sampler1D", typeof(Sampler1D))]
                [XmlElement("sampler2D", typeof(Sampler2D))]
                [XmlElement("sampler3D", typeof(Sampler3D))]
                [XmlElement("samplerCUBE", typeof(SamplerCUBE))]
                [XmlElement("samplerDEPTH", typeof(SamplerDEPTH))]
                [XmlElement("samplerRECT", typeof(SamplerRECT))]
                [XmlElement("surface", typeof(GLSL_Surface))]
                [XmlChoiceIdentifierAttribute("itemsElementName")]
                public object[] items
                { get; set; }

                [XmlElement("itemsElementName")]
                [XmlIgnoreAttribute()]
                public ItemsChoice_CGFieldType[] itemsElementName
                { get; set; }

                [XmlAttribute(DataType = "unsignedInt")]
                public uint length
                { get; set; }
            }
        }

        #endregion

    }

}
