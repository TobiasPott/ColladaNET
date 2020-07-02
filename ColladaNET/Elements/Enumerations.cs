using System;
using System.CodeDom.Compiler;
using System.Xml.Serialization;

namespace ColladaNET
{
    public enum AssetUnits
    {
        meter,
        centimeter,
        millimeter
    }


    
    [Serializable()]
    [XmlType(Namespace = Collada.XMLNAMESPACE)]
    public enum VersionType
    {
        [XmlEnumAttribute("1.4.0")]
        V140,
        [XmlEnumAttribute("1.4.1")]
        V141,
    }

    
    [Serializable()]
    [XmlType(Namespace = Collada.XMLNAMESPACE)]
    public enum NodeType
    {
        JOINT,
        NODE,
    }

    
    [Serializable()]
    [XmlType(Namespace = Collada.XMLNAMESPACE)]
    public enum UpAxisType
    {
        X_UP,
        Y_UP,
        Z_UP,
    }

    
    [Serializable()]
    [XmlType(Namespace = Collada.XMLNAMESPACE)]
    public enum MorphMethodType
    {
        NORMALIZED,
        RELATIVE,
    }

    
    [Serializable()]
    [XmlType(Namespace = Collada.XMLNAMESPACE, IncludeInSchema = false)]
    public enum Common_NewParam_ItemElementName
    {
        @float,
        float2,
        float3,
        float4,
        sampler2D,
        surface,
    }

    
    [Serializable()]
    [XmlType(Namespace = Collada.XMLNAMESPACE, IncludeInSchema = false)]
    public enum ItemsChoice_CGFieldType
    {
        array,
        @bool,
        bool2,
        bool3,
        bool4,
        @enum,
        @float,
        float2,
        float2x2,
        float3,
        float3x3,
        float4,
        float4x4,
        @int,
        int2,
        int3,
        int4,
        sampler1D,
        sampler2D,
        sampler3D,
        samplerCUBE,
        samplerDEPTH,
        samplerRECT,
        surface,
        param,
    }

    
    [Serializable()]
    [XmlType(Namespace = Collada.XMLNAMESPACE, IncludeInSchema = false)]
    public enum ItemsChoice_CameraOpticsTechnique_CommonOrthographic
    {
        aspect_ratio,
        xmag,
        ymag,
    }

    
    [Serializable()]
    [XmlType(Namespace = Collada.XMLNAMESPACE, IncludeInSchema = false)]
    public enum ItemsChoice_CameraOpticsTechnique_CommonPerspective
    {
        aspect_ratio,
        xfov,
        yfov,
    }

    
    [Serializable()]
    [XmlType(Namespace = Collada.XMLNAMESPACE, IncludeInSchema = false)]
    public enum ItemsChoice_CGFieldTypeExtended
    {
        array,
        @bool,
        bool1,
        bool1x1,
        bool1x2,
        bool1x3,
        bool1x4,
        bool2,
        bool2x1,
        bool2x2,
        bool2x3,
        bool2x4,
        bool3,
        bool3x1,
        bool3x2,
        bool3x3,
        bool3x4,
        bool4,
        bool4x1,
        bool4x2,
        bool4x3,
        bool4x4,
        connect_param,
        @enum,
        @fixed,
        fixed1,
        fixed1x1,
        fixed1x2,
        fixed1x3,
        fixed1x4,
        fixed2,
        fixed2x1,
        fixed2x2,
        fixed2x3,
        fixed2x4,
        fixed3,
        fixed3x1,
        fixed3x2,
        fixed3x3,
        fixed3x4,
        fixed4,
        fixed4x1,
        fixed4x2,
        fixed4x3,
        fixed4x4,
        @float,
        float1,
        float1x1,
        float1x2,
        float1x3,
        float1x4,
        float2,
        float2x1,
        float2x2,
        float2x3,
        float2x4,
        float3,
        float3x1,
        float3x2,
        float3x3,
        float3x4,
        float4,
        float4x1,
        float4x2,
        float4x3,
        float4x4,
        half,
        half1,
        half1x1,
        half1x2,
        half1x3,
        half1x4,
        half2,
        half2x1,
        half2x2,
        half2x3,
        half2x4,
        half3,
        half3x1,
        half3x2,
        half3x3,
        half3x4,
        half4,
        half4x1,
        half4x2,
        half4x3,
        half4x4,
        @int,
        int1,
        int1x1,
        int1x2,
        int1x3,
        int1x4,
        int2,
        int2x1,
        int2x2,
        int2x3,
        int2x4,
        int3,
        int3x1,
        int3x2,
        int3x3,
        int3x4,
        int4,
        int4x1,
        int4x2,
        int4x3,
        int4x4,
        sampler1D,
        sampler2D,
        sampler3D,
        samplerCUBE,
        samplerDEPTH,
        samplerRECT,
        setparam,
        @string,
        surface,
        usertype,
        param,
    }

    
    [Serializable()]
    [XmlType(Namespace = Collada.XMLNAMESPACE, IncludeInSchema = false)]
    public enum Node_ItemsElementName
    {
        lookat,
        matrix,
        rotate,
        scale,
        skew,
        translate,
    }


    public enum NodeFindMethod
    {
        ByName,
        ByID
    }

}
