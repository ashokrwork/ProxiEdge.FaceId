using ProxiEdge.FaceId.Base;

namespace ProxiEdge.FaceId.Face.Verify.Parameter
{
    internal class FaceToFaceVerifyParameter : ApiParameterBase
    {
        public string FaceId1 { get; set; }
        public string FaceId2 { get; set; }
    }
}
