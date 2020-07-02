using ColladaNET.Elements;
using System;

namespace ColladaNET.Generation
{

    public struct DAEGeometryDataSourceInfo
    {
        private GeometryDataType _type;
        private ulong _index;

        public GeometryDataType Type
        { get { return _type; } }
        public ulong Index
        { get { return _index; } }


        public DAEGeometryDataSourceInfo(GeometryDataType dtype, ulong index)
        {
            _type = dtype;
            _index = index;
        }
    }
    public struct DAEGeometryInputSemanticInfo
    {
        private Semantic _semantic;
        private ulong _dataSourceIndex;
        private ulong _setIndex;

        public Semantic Semantic
        { get { return _semantic; } }
        public ulong DataSourceIndex
        { get { return _dataSourceIndex; } }
        public ulong SetIndex
        { get { return _setIndex; } }


        public DAEGeometryInputSemanticInfo(Semantic semantic, ulong dataSourceIndex, ulong setIndex)
        {
            _semantic = semantic;
            _dataSourceIndex = dataSourceIndex;
            _setIndex = setIndex;
        }
    }
    public class DAEGeometryDataSource
    {
        //private DAEGeometryDataSourceInfo _info;
        //private float[] _data;

        public DAEGeometryDataSourceInfo Info
        { get; private set; }
        public float[] Data
        { get; private set; }

        public DAEGeometryDataSource(DAEGeometryDataSourceInfo info, float[] data)
        {
            this.Info = info;
            this.Data = data;
        }
    }

    public static class DAEGeometry
    {


        private static Vertices GenerateVertices(string geoName)
        {
            Vertices vertex = new Vertices(geoName + "-VERTEX", new Input("POSITION", "#" + geoName + "-POSITION"));
            return vertex;
        }

        private static ulong ExpandSources(Mesh mesh)
        {
            Source[] sources = mesh.source;
            Array.Resize<Source>(ref sources, (int)sources.Length + 1);
            mesh.source = sources;
            return (ulong)(sources.Length - 1);
        }
        private static ulong ExpandItems(Mesh mesh)
        {
            object[] items = mesh.primitives;
            Array.Resize<object>(ref items, (int)items.Length + 1);
            mesh.primitives = items;
            return (ulong)(items.Length - 1);
        }
        private static ulong ExpandInput(Polylist polylist)
        {
            InputOffset[] inputs = polylist.input;
            Array.Resize<InputOffset>(ref inputs, (int)inputs.Length + 1);
            polylist.input = inputs;
            return (ulong)(inputs.Length - 1);
        }


        private static void AppendGeometryDataNormal(Mesh mesh, string geoName, ulong channel, float[] normals)
        {
            ulong indMeshSource = (ulong)DAEGeometry.ExpandSources(mesh);
            mesh.source[indMeshSource] = Source.CreateNormals(geoName, channel, normals);
            //ulong indPolylistInput = (ulong)COLLADAGeometry.ExpandPolylist(polylist);
            //polylist.input[indPolylistInput] = new InputLocalOffset(indPolylistInput, "NORMAL", "#" + geoName + "-Normal" + channel);
        }
        private static void AppendGeometryDataTexCoord(Mesh mesh, string geoName, ulong channel, float[] texcoords)
        {
            ulong indMeshSource = (ulong)DAEGeometry.ExpandSources(mesh);
            mesh.source[indMeshSource] = Source.CreateUVs(geoName, channel, texcoords);
            //ulong indPolylistInput = (ulong)COLLADAGeometry.ExpandPolylist(polylist);
            //polylist.input[indPolylistInput] = new InputLocalOffset(indPolylistInput, "TEXCOORD", "#" + geoName + "-UV" + channel);
        }
        private static void AppendGeometryDataVertexColor(Mesh mesh, string geoName, ulong channel, float[] vertexColors)
        {
            ulong indMeshSource = (ulong)DAEGeometry.ExpandSources(mesh);
            mesh.source[indMeshSource] = Source.CreateVertexColors(geoName, channel, vertexColors);
            //ulong indPolylistInput = (ulong)COLLADAGeometry.ExpandPolylist(polylist);
            //polylist.input[indPolylistInput] = new InputLocalOffset(indPolylistInput, "COLOR", "#" + geoName + "-VERTEX_COLOR" + channel, channel);
        }
        private static void AppendGeometryDataVertex(Mesh mesh, string geoName, float[] positions)
        {
            ulong indMeshSource = (ulong)DAEGeometry.ExpandSources(mesh);
            mesh.source[indMeshSource] = Source.CreatePositions(geoName, positions);
            //ulong indPolylistInput = (ulong)COLLADAGeometry.ExpandPolylist(polylist);
            //polylist.input[indPolylistInput] = new InputLocalOffset(indPolylistInput, "VERTEX", string.Concat("#", geoName, "-VERTEX"));
            mesh.vertices = new Vertices(string.Concat(geoName, "-VERTEX"), new Input("POSITION", "#" + geoName + "-POSITION"));
        }
        private static void AppendPolylistSemantic(Polylist polylist, string geoName, Semantic semantic, ulong dataSource, ulong set)
        {
            ulong indPolylistInput = (ulong)DAEGeometry.ExpandInput(polylist);
            switch (semantic)
            {
                case Semantic.VERTEX:
                    polylist.input[indPolylistInput] = new InputOffset("VERTEX", "#" + geoName + "-VERTEX", indPolylistInput);
                    break;
                case Semantic.NORMAL:
                    polylist.input[indPolylistInput] = new InputOffset("NORMAL", "#" + geoName + "-Normal" + dataSource, indPolylistInput);
                    break;
                case Semantic.TEXCOORD:
                    polylist.input[indPolylistInput] = new InputOffset("TEXCOORD", "#" + geoName + "-UV" + dataSource, indPolylistInput, set);
                    break;
                case Semantic.COLOR:
                    polylist.input[indPolylistInput] = new InputOffset("COLOR", "#" + geoName + "-VERTEX_COLOR" + dataSource, indPolylistInput, set);
                    break;
            }
        }


        public static void AppendDataSource(Mesh mesh, string geoName, GeometryDataType dataType, float[] data, ulong channel = 0)
        {
            switch (dataType)
            {
                case GeometryDataType.Position:
                    DAEGeometry.AppendGeometryDataVertex(mesh, geoName, data);
                    break;
                case GeometryDataType.Normal:
                    DAEGeometry.AppendGeometryDataNormal(mesh, geoName, channel, data);
                    break;
                case GeometryDataType.TexCoord:
                    DAEGeometry.AppendGeometryDataTexCoord(mesh, geoName, channel, data);
                    break;
                case GeometryDataType.VertexColor:
                    DAEGeometry.AppendGeometryDataVertexColor(mesh, geoName, channel, data);
                    break;
            }
        }


        public static Geometry Polylist(string geoID, string geoName, string matName, float[] positions, float[] normals, float[] texcoords, float[] vertexColors, int[] vCount, int[] primitive)
        {
            int numSources = 1;
            if (normals != null)
                numSources++;
            if (texcoords != null)
                numSources++;
            if (vertexColors != null)
                numSources++;

            if ((positions == null ? true : positions.Length == 0))
            {
                throw new ArgumentException("Missing position data. Provide at least position data to use Polylist()", "positions");
            }
            Mesh mesh = new Mesh()
            {
                source = new Source[numSources]
            };
            Polylist polyList = new Polylist((ulong)vCount.Length, matName, vCount, primitive)
            {
                input = new InputOffset[numSources]
            };
            mesh.primitives = new object[] { polyList };
            ulong sInd = (ulong)0;
            mesh.source[sInd] = Source.CreatePositions(geoName, positions);
            polyList.input[sInd] = new InputOffset("VERTEX", string.Concat("#", geoName, "-VERTEX", sInd));
            if (normals != null)
            {
                sInd++;
                mesh.source[sInd] = Source.CreateNormals(geoName, 0, normals);
                polyList.input[sInd] = new InputOffset("NORMAL", string.Concat("#", geoName, "-Normal0", sInd));
            }
            if (texcoords != null)
            {
                sInd++;
                mesh.source[sInd] = Source.CreateUVs(geoName, 0, texcoords);
                polyList.input[sInd] = new InputOffset("TEXCOORD", string.Concat("#", geoName, "-UV", sInd));
            }
            if (vertexColors != null)
            {
                sInd++;
                mesh.source[sInd] = Source.CreateVertexColors(geoName, 0, vertexColors);
                polyList.input[sInd] = new InputOffset("COLOR", string.Concat("#", geoName, "-VERTEX_COLOR0", sInd));
            }
            mesh.vertices = DAEGeometry.GenerateVertices(geoName);
            Geometry geo = new Geometry(geoID, geoName, mesh);
            return geo;
        }
        public static Geometry Polylist(string geoID, string geoName, string matName, GeometryDataType[] dataTypes, float[][] data, ulong[] channels, Semantic[] semantics, ulong[] dataSources, ulong[] sets, int[] vCount, int[] primitives)
        {
            int maxLength = Math.Min((int)data.Length, (int)dataTypes.Length);
            Mesh mesh = new Mesh();
            mesh.source = new Source[0];
            Polylist polylist = new Polylist((ulong)vCount.Length, matName, vCount, primitives);
            polylist.input = new InputOffset[0];

            // ! ! ! ! 
            // separate adding data and adding semantic inputs into two loops/steps
            //  -> add a GeometryDataType enumeration to identify each data array as a specific data (Vertex, Normal, Texcoord, Colors)
            //  -> and the Semantic which generates the "input" types for the composed vertex data which is generated by the primitive list
            for (int i = 0; i < maxLength; i++)
                DAEGeometry.AppendDataSource(mesh, geoName, dataTypes[i], data[i], channels[i]);

            for (int i = 0; i < maxLength; i++)
                DAEGeometry.AppendPolylistSemantic(polylist, geoName, semantics[i], dataSources[i], sets[i]);


            mesh.primitives = new object[] { polylist };
            Geometry geo = new Geometry(geoID, geoName, mesh);
            return geo;
        }
        public static Geometry Polylist(string geoID, string geoName, string matName, DAEGeometryDataSourceInfo[] dataSourceInfos, float[][] data, DAEGeometryInputSemanticInfo[] semanticsInfos, int[] vCount, int[] primitives)
        {
            int maxLength = Math.Min((int)data.Length, (int)dataSourceInfos.Length);
            Mesh mesh = new Mesh();
            mesh.source = new Source[0];
            Polylist polylist = new Polylist((ulong)vCount.Length, matName, vCount, primitives);
            polylist.input = new InputOffset[0];

            for (int i = 0; i < maxLength; i++)
                DAEGeometry.AppendDataSource(mesh, geoName, dataSourceInfos[i].Type, data[i], dataSourceInfos[i].Index);
            for (int i = 0; i < semanticsInfos.Length; i++)
                DAEGeometry.AppendPolylistSemantic(polylist, geoName, semanticsInfos[i].Semantic, semanticsInfos[i].DataSourceIndex, semanticsInfos[i].SetIndex);

            mesh.primitives = new object[] { polylist };
            Geometry geo = new Geometry(geoID, geoName, mesh);
            return geo;
        }



        public static Geometry Geometry(string id, string name, DAEGeometryDataSource[] dataSources)
        {
            int maxLength = dataSources.Length;
            Mesh mesh = new Mesh();
            mesh.source = new Source[0];

            for (int i = 0; i < maxLength; i++)
                DAEGeometry.AppendDataSource(mesh, name, dataSources[i].Info.Type, dataSources[i].Data, dataSources[i].Info.Index);

            Geometry geo = new Geometry(id, name, mesh);
            return geo;
        }

        public static Geometry Mesh(string id, string name, DAEGeometryDataSourceInfo[] dataSourceInfos, float[][] data)
        {
            int maxLength = Math.Min((int)data.Length, (int)dataSourceInfos.Length);
            Mesh mesh = new Mesh();
            mesh.source = new Source[0];
            mesh.primitives = new object[0];

            for (int i = 0; i < maxLength; i++)
                DAEGeometry.AppendDataSource(mesh, name, dataSourceInfos[i].Type, data[i], dataSourceInfos[i].Index);

            Geometry geo = new Geometry(id, name, mesh);
            return geo;
        }

        // move to MeshDAE class (and make it an instance-method instead of static
        public static void AppendPolylist(string geoName, string matName, DAEGeometryInputSemanticInfo[] semanticsInfos, int[] vCount, int[] primitives, Mesh mesh)
        {
            if (mesh == null)
                return;

            ulong polylistIndex = DAEGeometry.ExpandItems(mesh);
            Polylist polylist = new Polylist((ulong)vCount.Length, matName, vCount, primitives);
            polylist.input = new InputOffset[0];

            for (int i = 0; i < semanticsInfos.Length; i++)
                DAEGeometry.AppendPolylistSemantic(polylist, geoName, semanticsInfos[i].Semantic, semanticsInfos[i].DataSourceIndex, semanticsInfos[i].SetIndex);

            mesh.primitives[polylistIndex] = polylist;
        }

        public static Geometry Triangles(string geoID, string geoName, string matName, float[] positions, float[] normals, float[] texcoords, float[] vertexColors, int[] triangles)
        {
            int numSources = 1;
            if (normals != null)
            {
                numSources++;
            }
            if (texcoords != null)
            {
                numSources++;
            }
            if (vertexColors != null)
            {
                numSources++;
            }
            Mesh mesh = new Mesh()
            {
                source = new Source[numSources]
            };
            Triangles tris = new Triangles((ulong)((long)triangles.Length / (long)(3 * numSources)), matName, triangles)
            {
                input = new InputOffset[numSources]
            };

            mesh.primitives = new object[] { tris };
            ulong sInd = 0;
            mesh.source[sInd] = Source.CreatePositions(geoName, positions);
            tris.input[sInd] = new InputOffset("VERTEX", string.Concat("#", geoName, "-VERTEX", sInd));
            if (normals != null)
            {
                sInd++;
                mesh.source[sInd] = Source.CreateNormals(geoName, 0, normals);
                tris.input[sInd] = new InputOffset("NORMAL", string.Concat("#", geoName, "-Normal0", sInd));
            }
            if (texcoords != null)
            {
                sInd++;
                mesh.source[sInd] = Source.CreateUVs(geoName, 0, texcoords);
                tris.input[sInd] = new InputOffset("TEXCOORD", string.Concat("#", geoName, "-UV0", sInd));
            }
            if (vertexColors != null)
            {
                sInd++;
                mesh.source[sInd] = Source.CreateVertexColors(geoName, 0, vertexColors);
                tris.input[sInd] = new InputOffset("COLOR", string.Concat("#", geoName, "-VERTEX_COLOR0", sInd));
            }
            mesh.vertices = DAEGeometry.GenerateVertices(geoName);
            Geometry geo = new Geometry(geoID, geoName, mesh);
            return geo;
        }


    }

}
