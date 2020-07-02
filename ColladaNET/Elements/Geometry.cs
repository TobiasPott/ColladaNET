using ColladaNET.Elements;
using System;
using System.Xml.Serialization;

namespace ColladaNET
{
    [Serializable()]
    [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
    [XmlRoot(Namespace = Collada.XMLNAMESPACE, IsNullable = false)]
    public partial class Geometry : LibraryItemBase
    {
        public enum GeometryTypes
        {
            None,
            ConvexMesh,
            Mesh,
            Spline
        }


        [XmlElement("convex_mesh", typeof(ConvexMesh))]
        public ConvexMesh convexMesh
        { get; set; }
        [XmlElement("mesh", typeof(Mesh))]
        public Mesh mesh
        { get; set; }
        [XmlElement("spline", typeof(Spline))]
        public Spline spline
        { get; set; }


        [XmlIgnore()]
        public GeometryTypes GeometryType
        {
            get
            {
                if (convexMesh != null)
                    return GeometryTypes.ConvexMesh;
                if (spline != null)
                    return GeometryTypes.Spline;
                if (mesh != null)
                    return GeometryTypes.Mesh;
                return GeometryTypes.None;
            }
        }





        // constructors
        public Geometry() { }

        public Geometry(string id, string name)
        {
            this.id = id;
            this.name = name;
        }

        public Geometry(string id, string name, Mesh mesh)
            : this(id, name)
        { this.mesh = mesh; }

        public Geometry(string id, string name, ConvexMesh convexMesh)
            : this(id, name)
        { this.convexMesh = convexMesh; }

        public Geometry(string id, string name, Spline spline)
            : this(id, name)
        { this.spline = spline; }


        public void SetMaterial(string materialName)
        {
            Geometry.SetMaterial(this, materialName);
        }




        public static void SetMaterial(Geometry geo, string materialName)
        {
            if (geo.GeometryType == GeometryTypes.Mesh)
            {
                if (geo.mesh == null)
                    return;

                foreach (Lines lines in geo.mesh.GetPrimitives<Lines>())
                    lines.material = materialName;
                foreach (LineStrips linestrips in geo.mesh.GetPrimitives<LineStrips>())
                    linestrips.material = materialName;
                foreach (Polygons polygons in geo.mesh.GetPrimitives<Polygons>())
                    polygons.material = materialName;
                foreach (Polylist polylist in geo.mesh.GetPrimitives<Polylist>())
                    polylist.material = materialName;
                foreach (Triangles triangles in geo.mesh.GetPrimitives<Triangles>())
                    triangles.material = materialName;
                foreach (TriFans trifans in geo.mesh.GetPrimitives<TriFans>())
                    trifans.material = materialName;
                foreach (TriStrips tristrips in geo.mesh.GetPrimitives<TriStrips>())
                    tristrips.material = materialName;
            }
        }


    }

}
