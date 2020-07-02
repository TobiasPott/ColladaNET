using System;
using System.Xml.Serialization;

namespace ColladaNET.Elements
{
    [Serializable()]
    [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
    [XmlRoot(Namespace = Collada.XMLNAMESPACE, IsNullable = false)]
    public partial class RigidConstraint
    {
        [XmlElement()]
        public Attachment ref_attachment
        { get; set; }

        [XmlElement()]
        public Attachment attachment
        { get; set; }

        [XmlElement()]
        public TechniqueCommon technique_common
        { get; set; }

        [XmlElement("technique")]
        public Technique[] technique
        { get; set; }

        [XmlElement("extra")]
        public Extra[] extra
        { get; set; }

        [XmlAttribute(DataType = "NCName")]
        public string sid
        { get; set; }

        [XmlAttribute(DataType = "NCName")]
        public string name
        { get; set; }



        // RidigConstraint member classes
        #region Attachment
        [Serializable()]
        [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
        public partial class Attachment
        {
            [XmlElement("rotate", typeof(Rotate))]
            [XmlElement("translate", typeof(Translate))]
            public object[] transformation
            { get; set; }


            [XmlElement("extra", typeof(Extra))]
            public Extra[] extra
            { get; set; }

            [XmlAttribute(DataType = "anyURI")]
            public string rigid_body
            { get; set; }

        }
        #endregion

        #region TechniqueCommon
        [Serializable()]
        [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
        public partial class TechniqueCommon
        {
            [XmlElement()]
            public Enabled enabled
            { get; set; }

            [XmlElement()]
            public Interpenetrate interpenetrate
            { get; set; }

            [XmlElement()]
            public Limits limits
            { get; set; }

            [XmlElement()]
            public Spring spring
            { get; set; }

            // RidigConstraint technique member classes
            #region Enabled
            [Serializable()]
            [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
            public partial class Enabled
            {
                [XmlAttribute(DataType = "NCName")]
                public string sid
                { get; set; }

                [XmlTextAttribute()]
                public bool value
                { get; set; }
            }
            #endregion

            #region Interpenetrate
            [Serializable()]
            [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
            public partial class Interpenetrate
            {
                [XmlAttribute(DataType = "NCName")]
                public string sid
                { get; set; }

                [XmlTextAttribute()]
                public bool value
                { get; set; }
            }
            #endregion

            #region Limits
            [Serializable()]
            [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
            public partial class Limits
            {
                [XmlElement()]
                public Swing_Cone_and_Twist swing_cone_and_twist
                { get; set; }

                [XmlElement()]
                public Linear linear
                { get; set; }


                // Limit member classes
                #region Linear
                [Serializable()]
                [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
                public partial class Linear
                {
                    [XmlElement()]
                    public TargetableFloat3 min
                    { get; set; }

                    [XmlElement()]
                    public TargetableFloat3 max
                    { get; set; }
                }
                #endregion

                #region Swing_Cone_and_Twist
                [Serializable()]
                [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
                public partial class Swing_Cone_and_Twist
                {
                    [XmlElement()]
                    public TargetableFloat3 min
                    { get; set; }

                    [XmlElement()]
                    public TargetableFloat3 max
                    { get; set; }
                }
                #endregion

            }
            #endregion

            #region Spring
            [Serializable()]
            [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
            public partial class Spring
            {
                [XmlElement()]
                public Angular angular
                { get; set; }

                [XmlElement()]
                public Linear linear
                { get; set; }


                // Spring member classes
                #region Angular
                [Serializable()]
                [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
                public partial class Angular
                {
                    [XmlElement()]
                    public TargetableFloat stiffness
                    { get; set; }

                    [XmlElement()]
                    public TargetableFloat damping
                    { get; set; }

                    [XmlElement()]
                    public TargetableFloat target_value
                    { get; set; }

                }
                #endregion

                #region Linear
                [Serializable()]
                [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
                public partial class Linear
                {
                    [XmlElement()]
                    public TargetableFloat stiffness
                    { get; set; }

                    [XmlElement()]
                    public TargetableFloat damping
                    { get; set; }

                    [XmlElement()]
                    public TargetableFloat target_value
                    { get; set; }

                }

                #endregion

            }
            #endregion

        }

        #endregion

    }

}
