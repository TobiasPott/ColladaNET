using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Xml.Serialization;

namespace ColladaNET.Elements
{

    
    [Serializable()]
    [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
    [XmlRoot(Namespace = Collada.XMLNAMESPACE, IsNullable = false)]
    public partial class PhysicsScene : LibraryItemBase
    {
        [XmlElement("instance_force_field")]
        public InstanceForceField[] instance_force_field
        { get; set; }

        [XmlElement("instance_physics_model")]
        public InstancePhysicsModel[] instance_physics_model
        { get; set; }

        [XmlElement()]
        public Technique_Common technique_common
        { get; set; }

        [XmlElement("technique")]
        public Technique[] technique
        { get; set; }


        
        [Serializable()]
        [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
        public partial class Technique_Common
        {
            [XmlElement()]
            public TargetableFloat3 gravity
            { get; set; }

            [XmlElement()]
            public TargetableFloat time_step
            { get; set; }
        }


    }

}
