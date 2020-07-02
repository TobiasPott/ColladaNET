using System;
using System.Xml.Serialization;

namespace ColladaNET.Elements
{

    [Serializable()]
    [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
    public partial class Scene
    {
        [XmlElement("instance_physics_scene")]
        public InstancePhysicsScene[] instance_physics_scene
        { get; set; }

        [XmlElement("instance_visual_scene")]
        public InstanceVisualScene instance_visual_scene
        { get; set; }

        [XmlElement("extra")]
        public Extra[] extra
        { get; set; }


        // constructors
        public Scene() { }

        public Scene(InstanceVisualScene visualSceneInstance)
        { this.instance_visual_scene = visualSceneInstance; }

        public Scene(InstanceVisualScene visualSceneInstance, InstancePhysicsScene[] physicsSceneInstances)
            : this(visualSceneInstance)
        { this.instance_physics_scene = physicsSceneInstances; }
    }
}