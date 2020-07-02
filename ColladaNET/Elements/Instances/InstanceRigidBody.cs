using ColladaNET.Elements;
using System;
using System.ComponentModel;
using System.Xml.Serialization;

namespace ColladaNET
{


    [Serializable()]
    [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
    [XmlRoot("instance_rigid_body", Namespace = Collada.XMLNAMESPACE, IsNullable = false)]
    public partial class InstanceRigidBody : InstanceBase
    {

        [XmlElement()]
        public TechniqueCommon technique_common
        { get; set; }

        [XmlElement("technique")]
        public Technique[] technique
        { get; set; }

        [XmlAttribute(DataType = "NCName")]
        public string body
        { get; set; }

        [XmlAttribute(DataType = "anyURI")]
        public string target
        { get; set; }



        // member classes
        #region TechniqueCommon
        [Serializable()]
        [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
        public partial class TechniqueCommon : RigidBody.TechniqueCommon
        {
            private const string DefaultVelocity = "0.0 0.0 0.0";

            [XmlElement()]
            [DefaultValueAttribute(DefaultVelocity)]
            public string angular_velocity
            { get; set; }

            [XmlElement()]
            [DefaultValueAttribute(DefaultVelocity)]
            public string velocity
            { get; set; }


            public TechniqueCommon()
            {
                this.angular_velocity = DefaultVelocity;
                this.velocity = DefaultVelocity;
            }

        }
        #endregion

    }

}
