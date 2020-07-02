using System;
using System.ComponentModel;
using System.Xml.Serialization;

namespace ColladaNET.Elements
{
    [Serializable()]
    [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
    [XmlRoot(Namespace = Collada.XMLNAMESPACE, IsNullable = false)]
    public partial class Spline : GeometryBase
    {

        [XmlAttribute()]
        [DefaultValueAttribute(false)]
        public bool closed
        { get; set; }

        [XmlElement()]
        public ControlVertices control_vertices
        { get; set; }



        public Spline()
        {
            this.closed = false;
        }


        // member classes
        #region ControlVertices
        [Serializable()]
        [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
        public partial class ControlVertices
        {
            [XmlElement("input")]
            public Input[] input
            { get; set; }

            [XmlElement("extra")]
            public Extra[] extra
            { get; set; }
        }
        #endregion
    }

}
