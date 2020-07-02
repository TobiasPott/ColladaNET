using ColladaNET.Elements;
using System;
using System.Xml.Serialization;

namespace ColladaNET
{

    [Serializable()]
    [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
    [XmlRoot("instance_geometry", Namespace = Collada.XMLNAMESPACE, IsNullable = false)]
    public partial class InstanceGeometry : InstanceBase.WithUrl
    {
        [XmlElement()]
        public BindMaterial bind_material
        { get; set; }


        // constructors
        public InstanceGeometry() { }

        public InstanceGeometry(string url)
        { this.url = url; }

        public InstanceGeometry(string url, string name, string sid)
            : this(url)
        {
            this.name = name;
            this.sid = sid;
        }



        // functional extension for better API support

        /// <summary>
        /// sets the bind materials to material instances regarding to the given material name array
        /// </summary>
        /// <param name="matName">array of material names which are used to create material instances from</param>
        public void SetBindMaterial(string[] matName)
        {
            if (matName != null || matName.Length > 0)
            {
                BindMaterial bindMaterial = new BindMaterial();
                bindMaterial.materialInstances = new InstanceMaterial[matName.Length];
                for (int i = 0; i < matName.Length; i++)
                    bindMaterial.materialInstances[i] = new InstanceMaterial(matName[i], "#" + matName[i]);

                this.bind_material = bindMaterial;
            }
        }
        /// <summary>
        /// sets the bind materials to material instances regarding to the given material name array
        /// </summary>
        /// <param name="instGeometry">Instance_Geometry object which bind material should be set</param>
        /// <param name="matName">array of material names which are used to create material instances from</param>
        public static void SetBindMaterial(InstanceGeometry instGeometry, string[] matName)
        {
            if (matName != null || matName.Length > 0)
            {
                BindMaterial bindMaterial = new BindMaterial();
                bindMaterial.materialInstances = new InstanceMaterial[matName.Length];
                for (int i = 0; i < matName.Length; i++)
                    bindMaterial.materialInstances[i] = new InstanceMaterial(matName[i], "#" + matName[i]);

                instGeometry.bind_material = bindMaterial;
            }
        }
    }
}