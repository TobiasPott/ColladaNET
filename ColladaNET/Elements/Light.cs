using ColladaNET.Elements;
using System;
using System.Xml.Serialization;

namespace ColladaNET
{

    [Serializable()]
    [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
    [XmlRoot(Namespace = Collada.XMLNAMESPACE, IsNullable = false)]
    public partial class Light : LibraryItemBase
    {
        public enum LightTypes
        {
            None,
            Ambient,
            Directional,
            Spot,
            Point
        }

        [XmlElement()]
        public TechniqueCommon technique_common
        { get; set; }

        [XmlElement("technique")]
        public Technique[] technique
        { get; set; }


        // custom class extensions for easier information handling
        [XmlIgnore()]
        public LightTypes LightType
        {
            get
            {
                if (this.technique_common.ambient != null)
                    return LightTypes.Ambient;
                if (this.technique_common.directional != null)
                    return LightTypes.Directional;
                if (this.technique_common.spot != null)
                    return LightTypes.Spot;
                if (this.technique_common.point != null)
                    return LightTypes.Point;
                return LightTypes.None;
            }
        }


        [XmlIgnore()]
        public TechniqueCommon.Directional Directional
        { get { return this.technique_common.directional; } }
        [XmlIgnore()]
        public TechniqueCommon.Spot Spot
        { get { return this.technique_common.spot; } }
        [XmlIgnore()]
        public TechniqueCommon.Point Point
        { get { return this.technique_common.point; } }
        [XmlIgnore()]
        public TechniqueCommon.Ambient Ambient
        { get { return this.technique_common.ambient; } }

        //[XmlIgnore()]
        //protected bool IsDirectional
        //{ get { return this.technique_common.directional != null; } }
        //[XmlIgnore()]
        //protected bool IsSpot
        //{ get { return this.technique_common.spot != null; } }
        //[XmlIgnore()]
        //protected bool IsPoint
        //{ get { return this.technique_common.point != null; } }
        //[XmlIgnore()]
        //protected bool IsAmbient
        //{ get { return this.technique_common.ambient != null; } }


        public TargetableFloat3 Color
        { get { return this.technique_common.item.color; } }


        public float ConstantAttenuation
        {
            get
            {
                switch (this.LightType)
                {
                    case LightTypes.Point:
                        return this.technique_common.point.constant_attenuation?.value ?? 1.0f;
                    case LightTypes.Spot:
                        return this.technique_common.spot.constant_attenuation?.value ?? 1.0f;
                    default:
                        return 1.0f;
                }
            }
        }
        public float LinearAttenuation
        {
            get
            {
                switch (this.LightType)
                {
                    case LightTypes.Point:
                        return this.technique_common.point.linear_attenuation?.value ?? 0.0f;
                    case LightTypes.Spot:
                        return this.technique_common.spot.linear_attenuation?.value ?? 0.0f;
                    default:
                        return 0.0f;
                }
            }
        }
        public float QuadraticAttenuation
        {
            get
            {
                switch (this.LightType)
                {
                    case LightTypes.Point:
                        return this.technique_common.point.quadratic_attenuation?.value ?? 0.0f;
                    case LightTypes.Spot:
                        return this.technique_common.spot.quadratic_attenuation?.value ?? 0.0f;
                    default:
                        return 0.0f;
                }
            }

        }

        // member classes
        #region TechniqueCommon
        [Serializable()]
        [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
        public partial class TechniqueCommon
        {
            [XmlElement("ambient", typeof(Ambient))]
            public Ambient ambient
            { get; set; }
            [XmlElement("directional", typeof(Directional))]
            public Directional directional
            { get; set; }
            [XmlElement("point", typeof(Point))]
            public Point point
            { get; set; }
            [XmlElement("spot", typeof(Spot))]
            public Spot spot
            { get; set; }


            [XmlIgnore()]
            public Base item
            {
                get
                {
                    if (ambient != null) return ambient;
                    if (point != null) return point;
                    if (spot != null) return spot;
                    return directional;
                }
            }



            // member classes
            #region Light-type base
            [Serializable()]
            [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
            public abstract class Base
            {
                [XmlElement()]
                public TargetableFloat3 color
                { get; set; }
            }
            [Serializable()]
            [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
            public abstract class BaseWithAttenuation : Base
            {
                [XmlElement()]
                public TargetableFloat constant_attenuation
                { get; set; }

                [XmlElement()]
                public TargetableFloat linear_attenuation
                { get; set; }

                [XmlElement()]
                public TargetableFloat quadratic_attenuation
                { get; set; }
            }
            #endregion

            #region Directional Light
            [Serializable()]
            [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
            public partial class Directional : Base
            { }
            #endregion

            #region Ambient Light
            [Serializable()]
            [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
            public partial class Ambient : Base
            { }
            #endregion

            #region Point Light
            [Serializable()]
            [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
            public partial class Point : BaseWithAttenuation
            {
                [XmlElement()]
                public TargetableFloat zfar
                { get; set; }
            }
            #endregion

            #region Spot Light
            [Serializable()]
            [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
            public partial class Spot : BaseWithAttenuation
            {
                [XmlElement()]
                public TargetableFloat falloff_angle
                { get; set; }

                [XmlElement()]
                public TargetableFloat falloff_exponent
                { get; set; }
            }
            #endregion

        }

        #endregion

    }

}
