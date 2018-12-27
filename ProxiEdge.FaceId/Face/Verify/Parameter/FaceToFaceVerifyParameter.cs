using ProxiEdge.FaceId.Base;

namespace ProxiEdge.FaceId.Face.Verify.Parameter
{
    public class FaceToFaceVerifyParameter : ApiParameterBase
    {
        public string FaceId1 { get; set; }
        public string FaceId2 { get; set; }
    }
}
