using System;
using System.Xml.Serialization;

namespace ColladaNET.Elements
{
    [Serializable()]
    [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
    [XmlRoot(Namespace = Collada.XMLNAMESPACE, IsNullable = false)]
    public partial class Source
    {
        [XmlElement()]
        public Asset asset
        { get; set; }

        [XmlElement("IDREF_array", typeof(IDREFArray))]
        [XmlElement("Name_array", typeof(NameArray))]
        [XmlElement("bool_array", typeof(BoolArray))]
        [XmlElement("float_array", typeof(FloatArray))]
        [XmlElement("int_array", typeof(IntArray))]
        public object array
        { get; set; }

        [XmlElement()]
        public TechniqueCommon technique_common
        { get; set; }

        [XmlElement("technique")]
        public Technique[] technique
        { get; set; }

        [XmlAttribute(DataType = "ID")]
        public string id
        { get; set; }

        [XmlAttribute(DataType = "NCName")]
        public string name
        { get; set; }


        // constructors
        public Source() { }

        public Source(string id, TechniqueCommon techniqueCommon)
        {
            this.id = id;
            this.technique_common = techniqueCommon;
        }

        public Source(string id, FloatArray item, TechniqueCommon techniqueCommon)
            : this(id, techniqueCommon)
        { this.array = item; }

        public Source(string id, NameArray item, TechniqueCommon techniqueCommon)
            : this(id, techniqueCommon)
        { this.array = item; }

        public Source(string id, BoolArray item, TechniqueCommon techniqueCommon)
            : this(id, techniqueCommon)
        { this.array = item; }

        public Source(string id, IDREFArray item, TechniqueCommon techniqueCommon)
            : this(id, techniqueCommon)
        { this.array = item; }

        // type-check and itemField-cast methods
        private bool IsItem<T>() where T : ArrayBase
        { return array.GetType().Equals(typeof(T)); }
        public T GetItemAs<T>() where T : ArrayBase
        {
            if (this.IsItem<T>())
                return (T)array;
            return null;
        }

        public bool IsItemIDREFArray()
        { return IsItem<IDREFArray>(); }
        public bool IsItemNameArray()
        { return IsItem<NameArray>(); }
        public bool IsItemBoolArray()
        { return IsItem<BoolArray>(); }
        public bool IsItemIntArray()
        { return IsItem<IntArray>(); }
        public bool IsItemFloatArray()
        { return IsItem<FloatArray>(); }

        public IDREFArray GetItemAsIDREFArray()
        { return GetItemAs<IDREFArray>(); }
        public NameArray GetItemAsNameArray()
        { return GetItemAs<NameArray>(); }
        public BoolArray GetItemAsBoolArray()
        { return GetItemAs<BoolArray>(); }
        public IntArray GetItemAsIntArray()
        { return GetItemAs<IntArray>(); }
        public FloatArray GetItemAsFloatArray()
        { return GetItemAs<FloatArray>(); }


        public T GetItem<T>() where T : class
        {
            if (this.array != null && this.array.GetType().Equals(typeof(T)))
                return (T)this.array;
            return default(T);
        }


        // member classes
        #region Technique
        [Serializable()]
        [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
        public partial class TechniqueCommon
        {
            [XmlElement()]
            public Accessor accessor
            { get; set; }


            // constructors
            public TechniqueCommon() { }

            public TechniqueCommon(Accessor accessor)
            { this.accessor = accessor; }
        }
        #endregion



        #region Static Methods
        public static Source CreateJoints(string geoName, string[] values)
        {
            ulong stride = 1;
            NameArray sourceItem = new NameArray(geoName + "-Joints-array", values);
            Source source = new Source(string.Concat(geoName, "-Joints"), sourceItem,
                new Source.TechniqueCommon(new Accessor(sourceItem.count / stride, string.Concat("#", geoName, "-Joints-array"), (ulong)0, stride, new Param[] { new Param("name") })));
            return source;
        }
        public static Source CreateMatrices(string geoName, float[] values)
        {
            ulong stride = 16;
            FloatArray sourceItem = new FloatArray(geoName + "-Matrices-array", values);
            Source source = new Source(string.Concat(geoName, "-Matrices"), sourceItem,
                new Source.TechniqueCommon(new Accessor(sourceItem.count / stride, string.Concat("#", geoName, "-Matrices-array"), (ulong)0, stride, new Param[] { new Param("float4x4") })));
            return source;
        }
        public static Source CreateWeights(string geoName, float[] values)
        {
            ulong stride = 1;
            FloatArray sourceItem = new FloatArray(geoName + "-Weights-array", values);
            Source source = new Source(string.Concat(geoName, "-Weights"), sourceItem,
                new Source.TechniqueCommon(new Accessor(sourceItem.count / stride, string.Concat("#", geoName, "-Weights-array"), (ulong)0, stride, new Param[] { new Param("float") })));
            return source;
        }

        public static Source CreatePositions(string geoName, float[] values)
        {
            ulong stride = 3;
            FloatArray sourceItem = new FloatArray(geoName + "-POSITION-array", values);
            Source source = new Source(string.Concat(geoName, "-POSITION"), sourceItem, new Source.TechniqueCommon(new Accessor(sourceItem.count / stride, string.Concat(geoName, "-POSITION-array"), (ulong)0, stride, new Param[] { new Param("float", "X"), new Param("float", "Y"), new Param("float", "Z") })));
            return source;
        }
        public static Source CreateNormals(string geoName, ulong channel, float[] values)
        {
            ulong stride = 3;
            string name = string.Format(geoName + "-Normal{0}", channel);
            FloatArray sourceItem = new FloatArray(string.Concat(name, "-array"), values);
            Source source = new Source(name, sourceItem, new Source.TechniqueCommon(new Accessor(sourceItem.count / stride, string.Concat(name, "-array"), (ulong)0, stride, new Param[] { new Param("float", "X"), new Param("float", "Y"), new Param("float", "Z") })));
            return source;
        }
        public static Source CreateUVs(string geoName, ulong channel, float[] values)
        {
            ulong stride = 2;
            string name = string.Format(geoName + "-UV{0}", channel);
            FloatArray sourceItem = new FloatArray(string.Concat(name, "-array"), values);
            Source source = new Source(name, sourceItem, new Source.TechniqueCommon(new Accessor(sourceItem.count / stride, string.Concat(name, "-array"), (ulong)0, stride, new Param[] { new Param("float", "S"), new Param("float", "T") })));
            return source;
        }
        public static Source CreateVertexColors(string geoName, ulong channel, float[] values)
        {
            ulong stride = 4;
            string name = string.Format(geoName + "-VERTEX_COLOR{0}", channel);
            FloatArray sourceItem = new FloatArray(string.Concat(name, "-array"), values);
            Source source = new Source(name, sourceItem, new Source.TechniqueCommon(new Accessor(sourceItem.count / stride, string.Concat(name, "-array"), (ulong)0, stride, new Param[] { new Param("float", "R"), new Param("float", "G"), new Param("float", "B"), new Param("float", "A") })));
            return source;
        }

        #endregion
    }

}
