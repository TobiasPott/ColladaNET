using System;
using System.ComponentModel;
using System.Xml.Serialization;

namespace ColladaNET.Elements
{


    [Serializable()]
    [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
    [XmlRoot(Namespace = Collada.XMLNAMESPACE, IsNullable = false)]
    public partial class Asset
    {
        [XmlElement("contributor")]
        public Contributor[] contributor
        { get; set; }

        [XmlElement()]
        public DateTime created
        { get; set; }

        [XmlElement()]
        public string keywords
        { get; set; } = string.Empty;

        [XmlElement()]
        public DateTime modified
        { get; set; }

        [XmlElement()]
        public string revision
        { get; set; } = string.Empty;

        [XmlElement()]
        public string subject
        { get; set; } = string.Empty;

        [XmlElement()]
        public string title
        { get; set; } = string.Empty;

        [XmlElement()]
        public Unit unit
        { get; set; }

        [XmlElement()]
        [DefaultValueAttribute(UpAxisType.Y_UP)]
        public UpAxisType up_axis
        { get; set; } = UpAxisType.Y_UP;



        // costructors
        public Asset()
        { }

        public Asset(Contributor contributor, DateTime created, DateTime modified, Unit unit, UpAxisType upAxis, string keywords = "", string revision = "", string subject = "", string title = "")
            : this(new Contributor[] { contributor }, created, modified, unit, upAxis, keywords, revision, subject, title)
        { }

        public Asset(Contributor[] contributor, DateTime created, DateTime modified, Unit unit, UpAxisType upAxis, string keywords = "", string revision = "", string subject = "", string title = "")
        {
            this.contributor = contributor;
            this.created = created;
            this.modified = modified;
            this.unit = unit;
            this.up_axis = UpAxisType.Y_UP;
            this.keywords = keywords;
            this.revision = revision;
            this.subject = subject;
            this.title = title;
        }


        // member classes
        #region Contributor
        [Serializable()]
        [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
        public partial class Contributor : AtomicBase
        {
            [XmlElement()]
            public string author
            { get; set; }

            [XmlElement()]
            public string authoring_tool
            { get; set; }

            [XmlElement()]
            public string comments
            { get; set; }

            [XmlElement()]
            public string copyright
            { get; set; }

            [XmlElement(DataType = "anyURI")]
            public string source_data
            { get; set; }


            // constructors
            public Contributor()
            { this.authoring_tool = "ColladaNET::" + typeof(Contributor).Assembly.FullName; }

            public Contributor(string author, string comments, string copyright, string sourceData)
                : this()
            {
                this.author = author;
                this.comments = comments;
                this.copyright = copyright;
                this.source_data = sourceData;
            }

            public Contributor(string author, string authoringTool, string comments, string copyright, string sourceData)
                : this(author, comments, copyright, sourceData)
            { this.authoring_tool = authoringTool; }
        }
        #endregion

        #region Unit
        [Serializable()]
        [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
        public partial class Unit : AtomicBase
        {
            // name values:
            // meter
            // centimeter
            // millimeter

            [XmlAttribute()]
            [DefaultValueAttribute(1)]
            public float meter
            { get; set; } = 1.0f;

            [XmlAttribute(DataType = "NMTOKEN")]
            [DefaultValueAttribute("meter")]
            public string name
            { get; set; } = "meter";

            [XmlIgnore()]
            public AssetUnits unit
            { get; set; }


            public Unit()
            { }

            // additional constructor to fast create new instance with values
            public Unit(float meter, string name)
            {
                this.meter = meter;
                this.name = name;
            }

        }

        #endregion

    }
}