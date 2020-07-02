using System;
using System.Xml.Serialization;

namespace ColladaNET.Elements
{

    [Serializable()]
    [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
    [XmlRoot(Namespace = Collada.XMLNAMESPACE, IsNullable = false)]
    public partial class Triangles : Primitive<Indices>
    {

        // constructors
        public Triangles() { }

        public Triangles(ulong count, string material, string indices)
        {
            this.count = count;
            this.material = material;
            this.p = new Indices() { rawIndices = indices };
        }

        public Triangles(ulong count, string material, int[] indices)
            : this(count, material, Utilities.FromArray<int>(indices)) { }





        public bool HasInput(string semantic)
        {
            foreach (InputOffset inputLocalOffset in input)
            {
                if (inputLocalOffset.semantic.ToLowerInvariant().Equals(semantic.ToLowerInvariant()))
                    return true;
            }
            return false;
        }

        public bool HasInput(string semantic, out string inputSource)
        {
            inputSource = string.Empty;
            foreach (InputOffset inputLocalOffset in input)
            {
                if (inputLocalOffset.semantic.ToLowerInvariant().Equals(semantic.ToLowerInvariant()))
                {
                    inputSource = inputLocalOffset.source.TrimStart(new char[] { '#' }); ;
                    return true;
                }
            }
            return false;
        }

        public bool HasInput(string semantic, out string inputSource, out InputOffset inputLocalOff)
        {
            inputSource = string.Empty;
            inputLocalOff = null;
            foreach (InputOffset inputLocalOffset in input)
            {
                if (inputLocalOffset.semantic.ToLowerInvariant().Equals(semantic.ToLowerInvariant()))
                {
                    inputLocalOff = inputLocalOffset;
                    inputSource = inputLocalOffset.source.TrimStart(new char[] { '#' }); ;
                    return true;
                }
            }
            return false;
        }

        public InputOffset GetInput(string semantic)
        {
            foreach (InputOffset inputLocalOffset in input)
            {
                if (inputLocalOffset.semantic.ToLowerInvariant().Equals(semantic.ToLowerInvariant()))
                    return inputLocalOffset;
            }
            return null;
        }

        public int GetStrideSize()
        {
            int result = 0;
            foreach (InputOffset inputLocalOffset in input)
            {
                if ((int)inputLocalOffset.offset > result)
                    result = (int)inputLocalOffset.offset;
            }
            return result;
        }



    }

}
