namespace ColladaNET
{

    public enum Semantic
    {
        /// <summary>
        /// Geometric binormal (bitangent) vector
        /// </summary>
        BINORMAL,
        /// <summary>
        /// Color coordinate vector as RGB (float3)
        /// </summary>
        COLOR,
        /// <summary>
        /// Continuity constraint at the control vertex (CV).
        /// </summary>
        CONTINUITY,
        /// <summary>
        /// Inverse of local-to-world matrix.
        /// </summary>
        INV_BIND_MATRIX,
        /// <summary>
        /// Skin influence identifier
        /// </summary>
        JOINT,
        /// <summary>
        /// Normal vector
        /// </summary>
        NORMAL,
        /// <summary>
        /// Texture coordinate vector
        /// </summary>
        TEXCOORD,
        /// <summary>
        /// Mesh vertex
        /// </summary>
        VERTEX,
        /// <summary>
        /// Skin influence weighting value
        /// </summary>
        WEIGHT
    }
    /*
IMAGE Raster or MIP-level input.
INPUT Sampler input.See also “Curve Interpolation” in Chapter 4: Programming Guide.
IN_TANGENT Tangent vector for preceding control point.See also “Curve Interpolation” in Chapter 4: Programming Guide.
INTERPOLATION Sampler interpolation type. See also “Curve Interpolation” in Chapter 4: Programming Guide.
LINEAR_STEPS Number of piece-wise linear approximation steps to use for the spline segment that follows this CV.See also “Curve Interpolation” in Chapter 4: Programming Guide.
MORPH_TARGET Morph targets for mesh morphing
MORPH_WEIGHT Weights for mesh morphing
OUTPUT Sampler output. See also “Curve Interpolation” in Chapter 4: Programming Guide.
OUT_TANGENT Tangent vector for succeeding control point.See also “Curve Interpolation” in Chapter 4: Programming Guide.
POSITION Geometric coordinate vector. See also “Curve Interpolation” in Chapter 4: Programming Guide.
TANGENT Geometric tangent vector
TEXBINORMAL Texture binormal (bitangent) vector
TEXTANGENT Texture tangent vector
UV Generic parameter vector
*/

    public enum GeometryDataType
    {
        Position,
        Normal,
        TexCoord,
        VertexColor
    }

}
