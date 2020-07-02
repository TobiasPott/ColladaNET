using ColladaNET.Elements;
using ColladaNET.FX.Profiles.Shared;
using ColladaNET.FX.Types;
using System;
using System.Xml.Serialization;

namespace ColladaNET.FX.Profiles
{

    [Serializable()]
    [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
    [XmlRoot("profile_COMMON", Namespace = Collada.XMLNAMESPACE, IsNullable = false)]
    public partial class Common : ProfileBase<Common.Technique, Common.Technique.Common_NewParam>
    {
        public enum ShadingModels
        {
            None,
            Lambert,
            Phong,
            Blinn,
            Constant
        }


        private ShadingModels _shadingModel = ShadingModels.None;

        [XmlIgnore()]
        public ShadingModels ShadingModel
        {
            get
            {
                if (_shadingModel == ShadingModels.None)
                    _shadingModel = technique.GetShadingModel();
                return _shadingModel;
            }
        }



        // constructors
        public Common()
        { }
        public Common(Common.Technique techniqueInstance)
        { this.technique = techniqueInstance; }



        public Technique.Base GetShadingModel(ShadingModels shadingModel)
        {
            switch (shadingModel)
            {
                case ShadingModels.Constant:
                    return GetShadingModel<Technique.Constant>();
                case ShadingModels.Lambert:
                    return GetShadingModel<Technique.Lambert>();
                case ShadingModels.Blinn:
                    return GetShadingModel<Technique.Blinn>();
                case ShadingModels.Phong:
                    return GetShadingModel<Technique.Phong>();
            }
            return null;
        }
        public Technique.Base GetShadingModel()
        { return technique.item; }
        public T GetShadingModel<T>() where T : Technique.Base
        {
            if (technique.item != null && technique.item is T)
                return (T)technique.item;
            return null;
        }




        // ! ! ! !
        // move static methods to external helper class to keep code structure identical to other profiles
        #region Static methods - Generate...
        public static Common.Technique.Common_NewParam[] GenerateSurfaceSampler(ref Texture texture, string prefix)
        {
            Common.Technique.Common_NewParam[] items = new Common.Technique.Common_NewParam[] {
                    new Common.Technique.Common_NewParam(prefix + "surface_param_id", new Surface(SurfaceType.Item2D, new Surface.InitFrom(texture.texture))),
                    new Common.Technique.Common_NewParam(prefix + "sampler2D_param_id", new Sampler2D(prefix + "surface_param_id"))
            };
            texture.texture = prefix + "sampler2D_param_id";

            return items;
        }
        public static Common GenerateLambert(ColorOrTexture diffuse,
                                                ColorOrTexture emission,
                                                ColorOrTexture ambient,
                                                ColorOrTexture reflective,
                                                FloatOrParam reflectivity,
                                                Transparent transparent,
                                                FloatOrParam transparency,
                                                FloatOrParam index_of_refraction)
        {
            Technique fxTechnique = new Technique();

            // add the surface sampler element to the technique to provide blender support
            if (Collada.CompatibilityToBlender && diffuse != null)
            {
                Texture texture = diffuse;
                fxTechnique.Add(Common.GenerateSurfaceSampler(ref texture, "diffuse_"));
            }

            Common.Technique.Lambert fxShader = new Common.Technique.Lambert(diffuse, emission, ambient, reflective, reflectivity, transparent, transparency, index_of_refraction);
            fxTechnique.item = fxShader;

            Common fxProfile = new Common(fxTechnique);
            //fxProfile.technique = fxTechnique;

            return fxProfile;
        }

        // merge the phong, blinn, etc stuff into the GenerateLambert and rename it to GenerateCommonProfile or simmilar
        public static Common GeneratePhong(ColorOrTexture diffuse,
                                                ColorOrTexture emission,
                                                ColorOrTexture ambient,
                                                ColorOrTexture specular,
                                                FloatOrParam shininess,
                                                ColorOrTexture reflective,
                                                FloatOrParam reflectivity,
                                                Transparent transparent,
                                                FloatOrParam transparency,
                                                FloatOrParam index_of_refraction)
        {
            Technique fxTechnique = new Technique();
            // add the surface sampler element to the technique to provide blender support
            if (Collada.CompatibilityToBlender && diffuse != null)
            {
                Texture texture = diffuse;
                fxTechnique.Add(Common.GenerateSurfaceSampler(ref texture, "diffuse_"));
            }

            Common.Technique.Phong fxShader = new Common.Technique.Phong(diffuse, emission, ambient, specular, shininess, reflective, reflectivity, transparent, transparency, index_of_refraction);
            fxTechnique.item = fxShader;

            Common fxProfile = new Common(fxTechnique);
            //fxProfile.technique = fxTechnique;

            return fxProfile;
        }

        public static Common GenerateBlinn(ColorOrTexture diffuse,
                                                ColorOrTexture emission,
                                                ColorOrTexture ambient,
                                                ColorOrTexture specular,
                                                FloatOrParam shininess,
                                                ColorOrTexture reflective,
                                                FloatOrParam reflectivity,
                                                Transparent transparent,
                                                FloatOrParam transparency,
                                                FloatOrParam index_of_refraction)
        {
            Technique fxTechnique = new Technique();
            // add the surface sampler element to the technique to provide blender support
            if (Collada.CompatibilityToBlender && diffuse != null)
            {
                Texture texture = diffuse;
                fxTechnique.Add(Common.GenerateSurfaceSampler(ref texture, "diffuse_"));
            }

            Common.Technique.Blinn fxShader = new Common.Technique.Blinn(diffuse, emission, ambient, specular, shininess, reflective, reflectivity, transparent, transparency, index_of_refraction);
            fxTechnique.item = fxShader;

            Common fxProfile = new Common(fxTechnique);
            //fxProfile.technique = fxTechnique;

            return fxProfile;
        }
        #endregion


        // member classes
        #region Technique
        [Serializable()]
        [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
        public partial class Technique : TechniqueBase
        {
            [XmlElement()]
            public Asset asset
            { get; set; }


            [XmlElement("blinn", typeof(Blinn))]
            [XmlElement("constant", typeof(Constant))]
            [XmlElement("lambert", typeof(Lambert))]
            [XmlElement("phong", typeof(Phong))]
            public Base item
            { get; set; }


            [XmlElement("newparam", typeof(Common_NewParam))]
            public Common_NewParam[] newparam
            { get; set; }


            // constructors 
            public Technique()
            { this.sid = "standard"; }

            public Technique(Blinn item)
                : this()
            { this.item = item; }


            public Technique(string sid)
            { this.sid = sid; }

            public Technique(string sid, Blinn item)
                : this(sid)
            { this.item = item; }

            public Technique(string sid, Constant item)
                : this(sid)
            { this.item = item; }

            public Technique(string sid, Lambert item)
                : this(sid)
            { this.item = item; }

            public Technique(string sid, Phong item)
                : this(sid)
            { this.item = item; }




            // methods
            /// <summary>
            /// gets the shading model used by this technique instance
            /// </summary>
            /// <returns>returns the shading model name or None (which indicates an invalid technique instance)</returns>
            internal ShadingModels GetShadingModel()
            {
                if (item is Constant)
                    return ShadingModels.Constant;
                if (item is Lambert)
                    return ShadingModels.Lambert;
                if (item is Blinn)
                    return ShadingModels.Blinn;
                if (item is Phong)
                    return ShadingModels.Phong;
                return ShadingModels.None;
            }

            public void Add(Common_NewParam[] itemsToAdd)
            {
                if (itemsToAdd != null)
                {
                    int lastIndex = 0;
                    if (newparam == null)
                    {
                        this.newparam = new Common_NewParam[itemsToAdd.Length];
                    }
                    else
                    {
                        lastIndex = this.newparam.Length;
                        this.newparam = Utilities.InitOrResize(this.newparam, itemsToAdd.Length);
                    }
                    for (int i = 0; i < itemsToAdd.Length; i++)
                    {
                        this.newparam[lastIndex + i] = itemsToAdd[i];
                    }
                }
            }





            // member classes
            #region Base
            [Serializable()]
            [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
            public abstract partial class Base
            {
                [XmlElement()]
                public ColorOrTexture emission
                { get; set; }

                [XmlElement()]
                public ColorOrTexture reflective
                { get; set; }

                [XmlElement()]
                public FloatOrParam reflectivity
                { get; set; }

                [XmlElement()]
                public Transparent transparent
                { get; set; }

                [XmlElement()]
                public FloatOrParam transparency
                { get; set; }

                [XmlElement()]
                public FloatOrParam index_of_refraction
                { get; set; }


                // constructors
                public Base() { }

                public Base(ColorOrTexture emission)
                { this.emission = emission; }

                public Base(ColorOrTexture emission = null,
                    ColorOrTexture reflective = null,
                    FloatOrParam reflectivity = null,
                    Transparent transparent = null,
                    FloatOrParam transparency = null,
                    FloatOrParam index_of_refraction = null)
                {
                    this.emission = emission;
                    this.reflective = reflective;
                    this.reflectivity = reflectivity;
                    this.transparent = transparent;
                    this.transparency = transparency;
                    this.index_of_refraction = index_of_refraction;
                }
            }
            #endregion

            #region Diffuse
            [Serializable()]
            [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
            public abstract partial class Diffuse : Base
            {
                [XmlElement()]
                public ColorOrTexture ambient
                { get; set; }

                [XmlElement()]
                public ColorOrTexture diffuse
                { get; set; }

                // constructors
                public Diffuse() { }
                public Diffuse(ColorOrTexture diffuse)
                { this.diffuse = diffuse; }

                public Diffuse(ColorOrTexture diffuse,
                    ColorOrTexture emission = null,
                    ColorOrTexture ambient = null,
                    ColorOrTexture reflective = null,
                    FloatOrParam reflectivity = null,
                    Transparent transparent = null,
                    FloatOrParam transparency = null,
                    FloatOrParam index_of_refraction = null) : base(emission, reflective, reflectivity, transparent, transparency, index_of_refraction)
                {
                    this.ambient = ambient;
                    this.diffuse = diffuse;
                }
            }
            #endregion

            #region Specular
            [Serializable()]
            [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
            public abstract partial class Specular : Diffuse
            {
                [XmlElement()]
                public ColorOrTexture specular
                { get; set; }

                [XmlElement()]
                public FloatOrParam shininess
                { get; set; }


                // constructors
                public Specular() { }
                public Specular(ColorOrTexture diffuse) : base(diffuse)
                { }
                public Specular(ColorOrTexture diffuse,
                    ColorOrTexture emission = null,
                    ColorOrTexture ambient = null,
                    ColorOrTexture specular = null,
                    FloatOrParam shininess = null,
                    ColorOrTexture reflective = null,
                    FloatOrParam reflectivity = null,
                    Transparent transparent = null,
                    FloatOrParam transparency = null,
                    FloatOrParam index_of_refraction = null) : base(diffuse, emission, ambient, reflective, reflectivity, transparent, transparency, index_of_refraction)
                {
                    this.specular = specular;
                    this.shininess = shininess;
                }
            }
            #endregion

            #region Constant
            [Serializable()]
            [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
            public partial class Constant : Base
            {
                // constructors
                public Constant() { }

                public Constant(ColorOrTexture emission) : base(emission)
                { }

                public Constant(ColorOrTexture emission = null,
                                                        ColorOrTexture reflective = null,
                                                        FloatOrParam reflectivity = null,
                                                        Transparent transparent = null,
                                                        FloatOrParam transparency = null,
                                                        FloatOrParam index_of_refraction = null) : base(emission, reflective, reflectivity, transparent, transparency, index_of_refraction)
                { }

            }
            #endregion

            #region Lambert
            [Serializable()]
            [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
            public partial class Lambert : Diffuse
            {
                // constructors
                public Lambert() { }

                public Lambert(ColorOrTexture diffuse) : base(diffuse)
                { }

                public Lambert(ColorOrTexture diffuse,
                                ColorOrTexture emission = null,
                                ColorOrTexture ambient = null,
                                ColorOrTexture reflective = null,
                                FloatOrParam reflectivity = null,
                                Transparent transparent = null,
                                FloatOrParam transparency = null,
                                FloatOrParam index_of_refraction = null) : base(diffuse, emission, ambient, reflective, reflectivity, transparent, transparency, index_of_refraction)
                { }

            }
            #endregion

            #region Phong
            [Serializable()]
            [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
            public partial class Phong : Common.Technique.Specular
            {
                // constructors
                public Phong() { }
                public Phong(ColorOrTexture diffuse) : base(diffuse)
                { }
                public Phong(ColorOrTexture diffuse,
                                ColorOrTexture emission = null,
                                ColorOrTexture ambient = null,
                                ColorOrTexture specular = null,
                                FloatOrParam shininess = null,
                                ColorOrTexture reflective = null,
                                FloatOrParam reflectivity = null,
                                Transparent transparent = null,
                                FloatOrParam transparency = null,
                                FloatOrParam index_of_refraction = null) : base(diffuse, emission, ambient, specular, shininess, reflective, reflectivity, transparent, transparency, index_of_refraction)
                { }

            }
            #endregion

            #region Blinn
            [Serializable()]
            [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
            public partial class Blinn : Specular
            {
                // constructors
                public Blinn() { }
                public Blinn(ColorOrTexture diffuse) : base(diffuse)
                { }
                public Blinn(ColorOrTexture diffuse,
                                ColorOrTexture emission = null,
                                ColorOrTexture ambient = null,
                                ColorOrTexture specular = null,
                                FloatOrParam shininess = null,
                                ColorOrTexture reflective = null,
                                FloatOrParam reflectivity = null,
                                Transparent transparent = null,
                                FloatOrParam transparency = null,
                                FloatOrParam index_of_refraction = null) : base(diffuse, emission, ambient, specular, shininess, reflective, reflectivity, transparent, transparency, index_of_refraction)
                { }

            }
            #endregion

            #region NewParam
            [Serializable()]
            [XmlType(Namespace = Collada.XMLNAMESPACE)]
            [XmlRoot(Namespace = Collada.XMLNAMESPACE, IsNullable = true)]
            public partial class Common_NewParam : NewParamBase
            {

                [XmlElement("float", typeof(float))]
                [XmlElement("float2", typeof(float))]
                [XmlElement("float3", typeof(float))]
                [XmlElement("float4", typeof(float))]
                [XmlElement("sampler2D", typeof(Sampler2D))]
                [XmlElement("surface", typeof(Surface))]
                [XmlChoiceIdentifierAttribute("itemElementName")]
                public object item
                { get; set; }

                [XmlElement()]
                [XmlIgnoreAttribute()]
                public Common_NewParam_ItemElementName itemElementName
                { get; set; }



                // constructors
                public Common_NewParam() { }

                public Common_NewParam(string sid)
                { this.sid = sid; }

                public Common_NewParam(string sid, Surface surfaceitem)
                    : this(sid)
                {
                    this.sid = sid;
                    this.item = surfaceitem;
                    this.itemElementName = Common_NewParam_ItemElementName.surface;
                }

                public Common_NewParam(string sid, Sampler2D sampleritem)
                    : this(sid)
                {
                    this.sid = sid;
                    this.item = sampleritem;
                    this.itemElementName = Common_NewParam_ItemElementName.sampler2D;
                }

            }
            #endregion
        }

        #endregion
    }

}