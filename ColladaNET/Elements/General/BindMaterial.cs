using System;
using System.Xml.Serialization;

namespace ColladaNET.Elements
{
    [Serializable()]
    [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
    [XmlRoot(Namespace = Collada.XMLNAMESPACE, IsNullable = false)]
    public partial class BindMaterial
    {
        [XmlElement("param")]
        public Param[] param
        { get; set; }

        [XmlArrayAttribute("technique_common")]
        [XmlArrayItemAttribute(ElementName = "instance_material", IsNullable = false)]
        public InstanceMaterial[] materialInstances
        { get; set; }

        [XmlElement("technique")]
        public Technique[] technique
        { get; set; }

        [XmlElement("extra")]
        public Extra[] extra
        { get; set; }


        public BindMaterial()
        { }

        public BindMaterial(string[] materialNames = null)
        {
            if (materialNames != null && materialNames.Length > 0)
            {
                this.materialInstances = new InstanceMaterial[materialNames.Length];
                for (int i = 0; i < materialNames.Length; i++)
                    this.materialInstances[i] = new InstanceMaterial(materialNames[i], "#" + materialNames[i]);
            }
        }
    }

}
