using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Xml.Serialization;

namespace ColladaNET.Elements
{
    
    [Serializable()]
    [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
    [XmlRoot(Namespace = Collada.XMLNAMESPACE, IsNullable = false)]
    public partial class RigidBody
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

        [XmlAttribute(DataType = "NCName")]
        public string sid
        { get; set; }

        [XmlAttribute(DataType = "NCName")]
        public string name
        { get; set; }


        // RigidBody member classes
        #region TechniqueCommon
        [Serializable()]
        [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
        public partial class TechniqueCommon
        {
            [XmlElement()]
            public Dynamic dynamic
            { get; set; }

            [XmlElement()]
            public TargetableFloat mass
            { get; set; }

            [XmlArrayAttribute()]
            [XmlArrayItemAttribute("rotate", typeof(Rotate), IsNullable = false)]
            [XmlArrayItemAttribute("translate", typeof(Translate), IsNullable = false)]
            public object[] mass_frame
            { get; set; }

            [XmlElement()]
            public TargetableFloat3 inertia
            { get; set; }

            [XmlElement("instance_physics_material", typeof(InstancePhysicsMaterial))]
            [XmlElement("physics_material", typeof(PhysicsMaterial))]
            public object physicMaterial
            { get; set; }

            [XmlElement("shape")]
            public Shape[] shape
            { get; set; }



            // Ridigbody technique member classes
            #region Dynamic
            
            [Serializable()]
            [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
            public partial class Dynamic
            {
                [XmlAttribute(DataType = "NCName")]
                public string sid
                { get; set; }

                [XmlTextAttribute()]
                public bool value
                { get; set; }
            }
            #endregion

            #region Shape
            [Serializable()]
            [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
            public partial class Shape
            {
                [XmlElement()]
                public Hollow hollow
                { get; set; }

                [XmlElement()]
                public TargetableFloat mass
                { get; set; }

                [XmlElement()]
                public TargetableFloat density
                { get; set; }

                [XmlElement("instance_physics_material", typeof(InstancePhysicsMaterial))]
                [XmlElement("physics_material", typeof(PhysicsMaterial))]
                public object physicMaterial
                { get; set; }

                [XmlElement("box", typeof(Box))]
                [XmlElement("capsule", typeof(Capsule))]
                [XmlElement("cylinder", typeof(Cylinder))]
                [XmlElement("instance_geometry", typeof(InstanceGeometry))]
                [XmlElement("plane", typeof(Plane))]
                [XmlElement("sphere", typeof(Sphere))]
                [XmlElement("tapered_capsule", typeof(TaperedCapsule))]
                [XmlElement("tapered_cylinder", typeof(TaperedCylinder))]
                public object primitive
                { get; set; }

                [XmlElement("rotate", typeof(Rotate))]
                [XmlElement("translate", typeof(Translate))]
                public object[] transformation
                { get; set; }

                [XmlElement("extra")]
                public Extra[] extra
                { get; set; }

                
                [Serializable()]
                [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
                public partial class Hollow
                {
                    [XmlAttribute(DataType = "NCName")]
                    public string sid
                    { get; set; }

                    [XmlTextAttribute()]
                    public bool value
                    { get; set; }
                }

            }
            #endregion

        }
        #endregion

    }

}
