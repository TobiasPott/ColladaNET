using ColladaNET.Elements;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;

namespace ColladaNET
{

    [Serializable()]
    [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
    [XmlRoot(Namespace = Collada.XMLNAMESPACE, IsNullable = false)]
    public partial class Node : LibraryItemBase, INodeContainer
    {
        // ! ! ! !
        // create explicit type for Translate and Scale which derive from TargetableFloat3 to allow additional inheritance
        [XmlElement("lookat", typeof(LookAt))]
        [XmlElement("matrix", typeof(Matrix))]
        [XmlElement("rotate", typeof(Rotate))]
        [XmlElement("scale", typeof(Scale))]
        [XmlElement("skew", typeof(Skew))]
        [XmlElement("translate", typeof(Translate))]
        [XmlChoiceIdentifierAttribute("itemsElementName")]
        public object[] transformation
        { get; set; }

        [XmlElement("itemsElementName")]
        [XmlIgnoreAttribute()]
        public Node_ItemsElementName[] itemsElementName
        { get; set; }

        [XmlElement("instance_camera")]
        public List<InstanceCamera> instance_camera
        { get; set; } = new List<InstanceCamera>();

        [XmlElement("instance_controller")]
        public List<InstanceController> instance_controller
        { get; set; } = new List<InstanceController>();

        [XmlElement("instance_geometry")]
        public List<InstanceGeometry> instance_geometry
        { get; set; } = new List<InstanceGeometry>();

        [XmlElement("instance_light")]
        public List<InstanceLight> instance_light
        { get; set; } = new List<InstanceLight>();

        [XmlElementAttribute("instance_node")]
        public List<InstanceNode> instance_node
        { get; set; } = new List<InstanceNode>();

        [XmlElement("node")]
        public List<Node> nodes
        { get; set; } = new List<Node>();

        [XmlAttribute(DataType = "NCName")]
        public string sid
        { get; set; } = string.Empty;

        [XmlAttribute()]
        [DefaultValueAttribute(NodeType.NODE)]
        public NodeType type
        { get; set; }

        [XmlAttribute(DataType = "Name")]
        public string[] layer
        { get; set; }



        // constructors
        public Node()
        { this.type = NodeType.NODE; }

        public Node(string id, string name, string sid)
            : this()
        {
            this.id = id;
            this.name = name;
            this.sid = sid;
            this.transformation = new object[0];
            this.itemsElementName = new Node_ItemsElementName[0];
        }
        public Node(string id, string name, string sid, NodeType type)
            : this(id, name, sid)
        {
            this.type = type;
            this.transformation = new object[0];
            this.itemsElementName = new Node_ItemsElementName[0];
        }



        public void ClearItems()
        {
            this.transformation = new object[0];
            this.itemsElementName = new Node_ItemsElementName[0];
        }


        // add transformation child element methods
        public void AddTranslate(string sid, float x, float y, float z)
        {
            int index = this.transformation.Length;

            this.transformation = Utilities.InitOrResize(this.transformation, 1);
            this.itemsElementName = Utilities.InitOrResize(this.itemsElementName, 1);
            this.transformation[index] = new Translate(sid, x, y, z);
            this.itemsElementName[index] = Node_ItemsElementName.translate;
        }
        public void AddTranslate(float x, float y, float z)
        {
            int index = this.transformation.Length;

            this.transformation = Utilities.InitOrResize(this.transformation, 1);
            this.itemsElementName = Utilities.InitOrResize(this.itemsElementName, 1);
            this.transformation[index] = new Translate("translate", x, y, z);
            this.itemsElementName[index] = Node_ItemsElementName.translate;
        }
        public void AddRotate(string sid, float axisX, float axisY, float axisZ, float angle)
        {
            int index = this.transformation.Length;

            this.transformation = Utilities.InitOrResize(this.transformation, 1);
            this.itemsElementName = Utilities.InitOrResize(this.itemsElementName, 1);
            this.transformation[index] = new Rotate(sid, axisX, axisY, axisZ, angle);
            this.itemsElementName[index] = Node_ItemsElementName.rotate;
        }
        public void AddRotate(float angleX, float angleY, float angleZ)
        {
            int index = this.transformation.Length;

            this.transformation = Utilities.InitOrResize(this.transformation, 3);
            this.itemsElementName = Utilities.InitOrResize(this.itemsElementName, 3);
            this.transformation[index] = new Rotate("rotateX", 1.0f, 0.0f, 0.0f, angleX);
            this.itemsElementName[index] = Node_ItemsElementName.rotate;
            this.transformation[index + 1] = new Rotate("rotateY", 0.0f, 1.0f, 0.0f, angleY);
            this.itemsElementName[index + 1] = Node_ItemsElementName.rotate;
            this.transformation[index + 2] = new Rotate("rotateZ", 0.0f, 0.0f, 1.0f, angleZ);
            this.itemsElementName[index + 2] = Node_ItemsElementName.rotate;
        }
        public void AddScale(string sid, float x, float y, float z)
        {
            int index = this.transformation.Length;

            this.transformation = Utilities.InitOrResize(this.transformation, 1);
            this.itemsElementName = Utilities.InitOrResize(this.itemsElementName, 1);
            this.transformation[index] = new Translate(sid, x, y, z);
            this.itemsElementName[index] = Node_ItemsElementName.scale;
        }
        public void AddScale(float x, float y, float z)
        {
            int index = this.transformation.Length;

            this.transformation = Utilities.InitOrResize(this.transformation, 1);
            this.itemsElementName = Utilities.InitOrResize(this.itemsElementName, 1);
            this.transformation[index] = new Scale("scale", x, y, z);
            this.itemsElementName[index] = Node_ItemsElementName.scale;
        }



        // add specific node child elements e.g. instance_geometry
        public void AddNode(Node node)
        {
            this.nodes.Add(node);
            //this.nodes = Utilities.InitOrResize(this.nodes, 1);
            //int length = this.nodes.Length;
            //this.nodes[length - 1] = node;
        }

        // Has... methods to check if node has instance types as items
        public bool HasCamera()
        { return instance_camera.Count > 0; }
        public bool HasController()
        { return instance_controller.Count > 0; }
        public bool HasGeometry()
        { return instance_geometry.Count > 0; }
        public bool HasLight()
        { return instance_light.Count > 0; }
        public bool HasNode()
        { return instance_node.Count > 0; }

        // Get.. methods to retrieve list of specific instance types



        // add specific node child elements e.g. instance_geometry
        public void AddInstanceGeometry(string geoUrlName, string[] materialNames = null)
        {
            InstanceGeometry instance = new InstanceGeometry(geoUrlName);
            this.instance_geometry.Add(instance);
            if (materialNames != null && materialNames.Length > 0)
                instance.bind_material = new BindMaterial(materialNames);
        }
        public void AddInstanceController(string ctrlUrlName, string[] materialNames = null)
        {
            InstanceController instance = new InstanceController(ctrlUrlName);
            this.instance_controller.Add(instance);
            if (materialNames != null && materialNames.Length > 0)
                instance.bind_material = new BindMaterial(materialNames);
        }


        // ! ! ! ! ! 
        // add the AddInstanceController method to include skin/rig controller to the scene instead of the InstanceGeometry
        // ! ! ! ! !





        public Node FindPath(string nodePath, NodeFindMethod method)
        {
            return this.Find(nodePath, method);
        }
    }

}