using ColladaNET.Elements;
using System;
using System.Xml.Serialization;

namespace ColladaNET
{

    [Serializable()]
    [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
    [XmlRoot(Namespace = Collada.XMLNAMESPACE, IsNullable = false)]
    public partial class Controller : LibraryItemBase
    {
        public enum ControllerTypes
        {
            None,
            Morph,
            Skin
        }

        [XmlElement("morph", typeof(Morph))]
        //[XmlElement("skin", typeof(Skin))]
        public Morph morph
        { get; set; }
        //[XmlElement("morph", typeof(Morph))]
        [XmlElement("skin", typeof(Skin))]
        public Skin skin
        { get; set; }



        [XmlIgnore()]
        public ControllerTypes ControllerType
        {
            get
            {
                if (morph != null)
                    return ControllerTypes.Morph;
                if (skin != null)
                    return ControllerTypes.Skin;
                return ControllerTypes.None;
            }
        }





        public Controller()
        { }

        public Controller(string id, string name)
        {
            this.id = id;
            this.name = name;
        }
        public Controller(string id, string name, Skin skin) : this(id, name)
        { this.skin = skin; }
        public Controller(string id, string name, Morph morph) : this(id, name)
        { this.morph = morph; }

    }

}
