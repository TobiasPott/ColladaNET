using ColladaNET.Elements;
using ColladaNET.FX.Profiles.Shared;
using ColladaNET.FX.Types;
using System.Xml.Serialization;

namespace ColladaNET.FX.Profiles
{
    public abstract partial class ProfileBase<T, U> where T : ITechnique where U : INewParam
    {
        [XmlElement()]
        public Asset asset
        { get; set; }

        [XmlElement("extra")]
        public Extra[] extra
        { get; set; }

        [XmlAttribute(DataType = "ID")]
        public string id
        { get; set; }


        [XmlElement("image", typeof(Image))]
        public Image[] image
        { get; set; }

        //[XmlElement("newparam", typeof(Common_NewParam))]
        [XmlElement()]
        public U[] newparam
        { get; set; }


        [XmlElement()]
        public T technique
        { get; set; }



        public ProfileBase()
        { }
        public ProfileBase(T techniqueInstance)
        { this.technique = techniqueInstance; }

    }
    public abstract partial class ProfileBaseExtended<T, U> : ProfileBase<T, U> where T : ITechnique where U : INewParam
    {
        [XmlElement("code", typeof(CodeProfile))]
        public CodeProfile[] code
        { get; set; }

        [XmlElement("include", typeof(Include))]
        public Include[] include
        { get; set; }
    }

}