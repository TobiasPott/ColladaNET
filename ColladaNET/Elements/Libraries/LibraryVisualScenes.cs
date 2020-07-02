using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace ColladaNET.Elements
{

    [Serializable()]
    [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
    [XmlRoot(Namespace = Collada.XMLNAMESPACE, IsNullable = false)]
    public partial class LibraryVisualScenes : LibraryBase<VisualScene>
    {

        [XmlElement("visual_scene")]
        public List<VisualScene> visual_scene
        {
            get { return this._items; }
            set { this._items = value; }
        }

        // constructors
        public LibraryVisualScenes() { }

        public LibraryVisualScenes(string id, string name)
            : base(id, name)
        { }

        public LibraryVisualScenes(string id, string name, VisualScene[] visualScenes)
            : base(id, name)
        { this._items.AddRange(visualScenes); }

        public LibraryVisualScenes(VisualScene[] visualScenes)
        { this._items.AddRange(visualScenes); }


        // functional extension for better API support

        /// <summary>
        /// gets the Instance_Geometry[] from all nodes in the visual scene
        /// </summary>
        /// <param name="sceneIndex">index of the visual scene to search in</param>
        /// <returns>an Instance_Geometry[] object if one was found, otherwise null</returns>
        public InstanceGeometry[] GetInstanceGeometries(int sceneIndex)
        {
            List<InstanceGeometry> _allInstanceGeometry = new List<InstanceGeometry>();
            foreach (Node n in this.visual_scene[sceneIndex].nodes)
            {
                if (n.instance_geometry != null && n.instance_geometry.Count > 0)
                    _allInstanceGeometry.AddRange(n.instance_geometry);
            }
            return _allInstanceGeometry.ToArray();
        }

        /// <summary>
        /// gets the Instance_Geometry[] from the visual scene and the specific node
        /// </summary>
        /// <param name="sceneIndex">index of the visual scene to search for the specific node for</param>
        /// <param name="nodeIndex">index of the specific node inside the scene to get the Instance_Geometry[] from</param>
        /// <returns>an Instance_Geometry[] object if one was found, otherwise null</returns>
        public List<InstanceGeometry> GetInstanceGeometries(int sceneIndex, int nodeIndex)
        {
            return this.visual_scene[sceneIndex].nodes[nodeIndex].instance_geometry;
        }

        /// <summary>
        /// gets a Instance_Geometry object from the visual scene matching the given geometry url name
        /// </summary>
        /// <param name="sceneIndex">index of the visual scene to search in</param>
        /// <param name="geoUrlName">url name of the geometry instance</param>
        /// <returns>an Instance_Geometry object if one was found, otherwise null</returns>
        public InstanceGeometry GetInstanceGeometry(int sceneIndex, string geoUrlName)
        {
            InstanceGeometry[] _allInstanceGeometry = this.GetInstanceGeometries(sceneIndex);
            return Array.Find<InstanceGeometry>(_allInstanceGeometry, (x => x.url.Equals(geoUrlName)));
        }


        /// <summary>
        /// gets a Instance_Geometry object from the visual scene and the specific node matching the given geometry url name
        /// </summary>
        /// <param name="sceneIndex">index of the visual scene to search for the specific node for</param>
        /// <param name="nodeIndex">index of the specific node inside the scene to get the instance geometry from</param>
        /// <param name="geoUrlName">url name of the geometry instance</param>
        /// <returns>an Instance_Geometry object if one was found, otherwise null</returns>
        public InstanceGeometry GetInstanceGeometry(int sceneIndex, int nodeIndex, string geoUrlName)
        {
            //return Array.Find<InstanceGeometry>(visual_scene[sceneIndex].nodes[nodeIndex].instance_geometry, (x => x.url.Equals(geoUrlName)));
            return visual_scene[sceneIndex].nodes[nodeIndex].instance_geometry.Find(x => x.url.Equals(geoUrlName));
        }

    }
}