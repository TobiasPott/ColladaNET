using System;
using System.Xml.Serialization;

namespace ColladaNET.Elements
{

    [Serializable()]
    [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
    [XmlRoot(Namespace = Collada.XMLNAMESPACE, IsNullable = false)]
    public partial class Camera : LibraryItemBase
    {
        [XmlElement()]
        public Optics optics
        { get; set; }

        [XmlElement()]
        public Imager imager
        { get; set; }



        // custom class extensions for easier information handling
        public bool IsOrtographic
        { get { return optics.technique_common.item != null ? optics.technique_common.item is Optics.TechniqueCommon.Orthographic : false; } }
        public bool IsPerspective
        { get { return optics.technique_common.item != null ? optics.technique_common.item is Optics.TechniqueCommon.Perspective : false; } }


        // member classes
        #region Imager
        [Serializable()]
        [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
        public partial class Imager
        {
            [XmlElement("technique")]
            public Technique[] technique
            { get; set; }

            [XmlElement("extra")]
            public Extra[] extra
            { get; set; }

        }
        #endregion

        #region Optics
        [Serializable()]
        [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
        public partial class Optics
        {
            [XmlElement()]
            public TechniqueCommon technique_common
            { get; set; }

            [XmlElement("technique")]
            public Technique[] technique
            { get; set; }

            [XmlElement("extra")]
            public Extra[] extra
            { get; set; }

            // member classes
            #region TechniqueCommon
            [Serializable()]
            [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
            public partial class TechniqueCommon
            {
                [XmlElement("orthographic", typeof(Orthographic))]
                [XmlElement("perspective", typeof(Perspective))]
                public object item
                { get; set; }


                // member classes
                #region Base
                [Serializable()]
                [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
                public partial class Base
                {
                    [XmlElement()]
                    public TargetableFloat znear
                    { get; set; }

                    [XmlElement()]
                    public TargetableFloat zfar
                    { get; set; }
                }
                #endregion

                #region Base
                [Serializable()]
                [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
                public partial class Perspective : Base
                {
                    [XmlElement("aspect_ratio", typeof(TargetableFloat))]
                    [XmlElement("xfov", typeof(TargetableFloat))]
                    [XmlElement("yfov", typeof(TargetableFloat))]
                    [XmlChoiceIdentifierAttribute("itemsElementName")]
                    public TargetableFloat[] items
                    { get; set; }


                    [XmlElement("itemsElementName")]
                    [XmlIgnoreAttribute()]
                    public ItemsChoice_CameraOpticsTechnique_CommonPerspective[] itemsElementName
                    { get; set; }
                }
                #endregion

                #region Perspective
                [Serializable()]
                [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
                public partial class Orthographic : Base
                {
                    [XmlElement("aspect_ratio", typeof(TargetableFloat))]
                    [XmlElement("xmag", typeof(TargetableFloat))]
                    [XmlElement("ymag", typeof(TargetableFloat))]
                    [XmlChoiceIdentifierAttribute("itemsElementName")]
                    public TargetableFloat[] Items
                    { get; set; }

                    [XmlElement("itemsElementName")]
                    [XmlIgnoreAttribute()]
                    public ItemsChoice_CameraOpticsTechnique_CommonOrthographic[] itemsElementName
                    { get; set; }
                }
                #endregion

            }
            #endregion

        }
        #endregion

    }

}
