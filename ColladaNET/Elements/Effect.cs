using ColladaNET.FX.Profiles;
using ColladaNET.FX.Profiles.Shared;
using ColladaNET.FX.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;

namespace ColladaNET
{

    [Serializable()]
    [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
    [XmlRoot(Namespace = Collada.XMLNAMESPACE, IsNullable = false)]
    public partial class Effect : LibraryItemBase
    {
        [XmlElement("annotate")]
        public Annotate[] annotate
        { get; set; }

        [XmlElement("image")]
        public Image[] image
        { get; set; }

        [XmlElement("newparam")]
        public NewParam[] newparam
        { get; set; }


        [XmlElement("profile_COMMON", typeof(Common))]
        public Common[] profileCommon
        { get; set; }
        [XmlElement("profile_CG", typeof(CG))]
        public CG[] profileCG
        { get; set; }
        [XmlElement("profile_GLES", typeof(GLES))]
        public GLES[] profileGLES
        { get; set; }
        [XmlElement("profile_GLSL", typeof(GLSL))]
        public GLSL[] profileGLSL
        { get; set; }

        /// <summary>
        /// does the instance has at least one profile defined (as required by Collada Spec)
        /// </summary>
        public bool HasProfile
        { get { return HasProfileCommon || HasProfileCG || HasProfileGLES || HasProfileGLSL; } }
        public bool HasProfileCommon
        { get { return (profileCommon != null && profileCommon.Length > 0); } }
        public bool HasProfileCG
        { get { return (profileCG != null && profileCG.Length > 0); } }
        public bool HasProfileGLES
        { get { return (profileGLES != null && profileGLES.Length > 0); } }
        public bool HasProfileGLSL
        { get { return (profileGLSL != null && profileGLSL.Length > 0); } }


        // constructors
        public Effect() { }

        public Effect(string id, string name)
        {
            this.id = id;
            this.name = name;
        }
        public Effect(string id, string name, params Common[] profiles) : this(id, name)
        { this.profileCommon = profiles; }
        public Effect(string id, string name, params CG[] profiles) : this(id, name)
        { this.profileCG = profiles; }
        public Effect(string id, string name, params GLES[] profiles) : this(id, name)
        { this.profileGLES = profiles; }
        public Effect(string id, string name, params GLSL[] profiles) : this(id, name)
        { this.profileGLSL = profiles; }
        public Effect(string id, string name, Common[] profilesCommon = null, CG[] profilesCG = null, GLES[] profilesGLES = null, GLSL[] profilesGLSL = null) : this(id, name)
        {
            this.profileCommon = profilesCommon;
            this.profileCG = profilesCG;
            this.profileGLES = profilesGLES;
            this.profileGLSL = profilesGLSL;
        }

        // member classes
        #region NewParam
        [Serializable()]
        [XmlType(Namespace = Collada.XMLNAMESPACE)]
        [XmlRoot(Namespace = Collada.XMLNAMESPACE, IsNullable = true)]
        public partial class NewParam
        {

            [XmlElement("annotate")]
            public Annotate[] annotate
            { get; set; }

            [XmlElement(DataType = "NCName")]
            public string semantic
            { get; set; }

            [XmlElement()]
            public Modifier modifier
            { get; set; }

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

            [XmlAttribute(DataType = "NCName")]
            public string sid
            { get; set; }

        }
        #endregion

    }

}
