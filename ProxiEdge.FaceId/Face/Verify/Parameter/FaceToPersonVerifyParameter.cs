using ProxiEdge.FaceId.Base;

namespace ProxiEdge.FaceId.Face.Verify.Parameter
{
    internal class FaceToPersonVerifyParameter : ApiParameterBase
    {
        public string FaceId { get; set; }
        public string PersonGroupId { get; set; }
        public string LargePersonGroupId { get; set; }
        public string PersonId { get; set; }
    }
}
