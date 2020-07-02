using ColladaNET.Elements;
using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace ColladaNET
{

    [Serializable()]
    [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
    [XmlRoot(Namespace = Collada.XMLNAMESPACE, IsNullable = false)]
    public partial class VisualScene : LibraryItemBase, INodeContainer
    {
        [XmlElement("node")]
        public List<Node> nodes
        { get; set; } = new List<Node>();

        [XmlElement("evaluate_scene")]
        public EvaluateScene[] evaluate_scene
        { get; set; }


        // constructors
        public VisualScene() { }

        public VisualScene(string id, string name)
        {
            this.id = id;
            this.name = name;
        }

        public VisualScene(string id, string name, Node[] nodes)
            : this(id, name)
        { this.nodes.AddRange(nodes); }



        public int AddNode(Node node)
        {
            this.nodes.Add(node);
            return this.nodes.Count - 1;
        }


        // member classes
        #region EvaluateScene
        [Serializable()]
        [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
        public partial class EvaluateScene
        {
            [XmlElement("render")]
            public Render[] render
            { get; set; }

            [XmlAttribute(DataType = "NCName")]
            public string name
            { get; set; }

            // member classes
            #region Render
            [Serializable()]
            [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
            public partial class Render
            {
                [XmlElement("layer", DataType = "NCName")]
                public string[] layer
                { get; set; }

                [XmlElement()]
                public InstanceEffect instance_effect
                { get; set; }

                [XmlAttribute(DataType = "anyURI")]
                public string camera_node
                { get; set; }
            }
            #endregion
        }
        #endregion


    }
}