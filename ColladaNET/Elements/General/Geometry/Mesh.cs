using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace ColladaNET.Elements
{

    [Serializable()]
    [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
    [XmlRoot(Namespace = Collada.XMLNAMESPACE, IsNullable = false)]
    public partial class Mesh : GeometryBase
    {
        [XmlElement("lines", typeof(Lines))]
        [XmlElement("linestrips", typeof(LineStrips))]
        [XmlElement("polygons", typeof(Polygons))]
        [XmlElement("polylist", typeof(Polylist))]
        [XmlElement("triangles", typeof(Triangles))]
        [XmlElement("trifans", typeof(TriFans))]
        [XmlElement("tristrips", typeof(TriStrips))]
        public object[] primitives
        { get; set; }

        [XmlElement()]
        public Vertices vertices
        { get; set; }



        public T GetPrimitive<T>()
        {
            for (int i = 0; i < this.primitives.Length; i++)
                if (this.primitives[i] != null && this.primitives[i].GetType().Equals(typeof(T)))
                    return (T)this.primitives[i];
            return default(T);
        }

        public T[] GetPrimitives<T>()
        {
            List<T> result = new List<T>();
            for (int i = 0; i < this.primitives.Length; i++)
                if (this.primitives[i] != null && this.primitives[i].GetType().Equals(typeof(T)))
                    result.Add((T)this.primitives[i]);
            return result.ToArray();
        }

    }
}
