using System;
using System.Xml.Serialization;

namespace ColladaNET.Elements
{

    [Serializable()]
    [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
    [XmlRoot(Namespace = Collada.XMLNAMESPACE, IsNullable = false)]
    public partial class Polylist : Primitive<Indices>
    {
        [XmlElement()]
        public string vcount
        { get; set; }

        [XmlIgnore()]
        /// <summary>
        /// gets or sets the vcount field as int[]
        /// </summary>
        public int[] VCount
        { get; set; }


        // constructors
        public Polylist() { }

        public Polylist(ulong count, string material, string vCount, string indices)
        {
            this.count = count;
            this.material = material;
            this.p = new Indices() { rawIndices = indices };
            this.vcount = vCount;
        }

        public Polylist(ulong count, string material, int[] vcount, int[] indices)
            : this(count, material, Utilities.FromArray<int>(vcount), Utilities.FromArray<int>(indices)) { }




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

        public int[] GetVCount(out int tris, out int quads, out int total)
        {
            tris = quads = total = 0;
            int[] result = new int[this.count];
            string[] splitted = vcount.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = int.Parse(splitted[i]);
                if (result[i] == 3)
                    tris++;
                else if (result[i] == 4)
                    quads++;
            }
            total = tris * 3 + quads * 4;

            return result;
        }

    }

}
