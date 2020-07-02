using ColladaNET.Elements;
using System;
using System.Xml.Serialization;

namespace ColladaNET
{
    [Serializable()]
    [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
    [XmlRoot(Namespace = Collada.XMLNAMESPACE, IsNullable = false)]
    public partial class Material : LibraryItemBase
    {
        [XmlElement()]
        public InstanceEffect instance_effect
        { get; set; }


        // constructors
        public Material() { }

        public Material(string id, InstanceEffect effect)
            : this(id, id, effect) { }

        public Material(string id, string name, InstanceEffect effect)
        {
            this.id = id;
            this.name = name;
            this.instance_effect = effect;
        }

    }

}
