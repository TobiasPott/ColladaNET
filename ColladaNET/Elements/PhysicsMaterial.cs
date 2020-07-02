using ColladaNET.Elements;
using System;
using System.Xml.Serialization;

namespace ColladaNET
{

    [Serializable()]
    [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
    [XmlRoot(Namespace = Collada.XMLNAMESPACE, IsNullable = false)]
    public partial class PhysicsMaterial : LibraryItemBase
    {
        [XmlElement()]
        public TechniqueCommon technique_common
        { get; set; }

        [XmlElement("technique")]
        public Technique[] technique
        { get; set; }


        // member class
        #region TechniqueCommon
        [Serializable()]
        [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
        public partial class TechniqueCommon
        {
            [XmlElement()]
            public TargetableFloat dynamic_friction
            { get; set; }

            [XmlElement()]
            public TargetableFloat restitution
            { get; set; }

            [XmlElement()]
            public TargetableFloat static_friction
            { get; set; }

        }
        #endregion

    }

}
