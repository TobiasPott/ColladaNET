using ColladaNET.FX.Profiles.Shared;
using ColladaNET.FX.Types;
using System;
using System.Xml.Serialization;

namespace ColladaNET
{

    [Serializable()]
    [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
    [XmlRoot(Namespace = Collada.XMLNAMESPACE, IsNullable = false)]
    public partial class InstanceEffect : InstanceBase.WithUrl
    {

        [XmlElement("technique_hint")]
        public TechniqueHint[] technique_hint
        { get; set; }

        [XmlElement("setparam")]
        public SetParam[] setparam
        { get; set; }


        // constructors
        public InstanceEffect() { }

        public InstanceEffect(string url)
        {
            this.url = url;
        }


        // member classes
        #region SetParam
        [Serializable()]
        [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
        public partial class SetParam
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

            [XmlAttribute(DataType = "token")]
            public string @ref
            { get; set; }

        }
        #endregion

        #region TechniqueHint
        [Serializable()]
        [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
        public partial class TechniqueHint
        {

            [XmlAttribute(DataType = "NCName")]
            public string platform
            { get; set; }

            [XmlAttribute(DataType = "NCName")]
            public string profile
            { get; set; }

            [XmlAttribute(DataType = "NCName")]
            public string @ref
            { get; set; }
        }
        #endregion
    }

}
