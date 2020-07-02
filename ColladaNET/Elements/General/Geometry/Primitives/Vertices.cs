using System;
using System.Xml.Serialization;

namespace ColladaNET.Elements
{


    [Serializable()]
    [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
    [XmlRoot(Namespace = Collada.XMLNAMESPACE, IsNullable = false)]
    public partial class Vertices
    {

        [XmlElement("input")]
        public Input[] input
        { get; set; }

        [XmlElement("extra")]
        public Extra[] extra
        { get; set; }

        [XmlAttribute(DataType = "ID")]
        public string id
        { get; set; }

        [XmlAttribute(DataType = "NCName")]
        public string name
        { get; set; }


        // constructors
        public Vertices() { }

        public Vertices(string id)
        { this.id = id; }

        public Vertices(string id, Input input)
            : this(id)
        { this.input = new Input[] { input }; }

        public Vertices(string id, Input[] input)
            : this(id)
        { this.input = input; }



        public bool HasInput(string semantic)
        {
            foreach (Input inputLocal in input)
            {
                if (inputLocal.semantic.ToLowerInvariant().Equals(semantic.ToLowerInvariant()))
                    return true;
            }
            return false;
        }

        public bool HasInput(string semantic, out string inputSource)
        {
            inputSource = string.Empty;
            foreach (Input inputLocal in input)
            {
                if (inputLocal.semantic.ToLowerInvariant().Equals(semantic.ToLowerInvariant()))
                {
                    inputSource = inputLocal.source.TrimStart(new char[] { '#' });
                    return true;
                }
            }
            return false;
        }

        public Input GetInput(string semantic)
        {
            foreach (Input inputLocal in input)
            {
                if (inputLocal.semantic.ToLowerInvariant().Equals(semantic.ToLowerInvariant()))
                    return inputLocal;
            }
            return null;
        }

    }
}