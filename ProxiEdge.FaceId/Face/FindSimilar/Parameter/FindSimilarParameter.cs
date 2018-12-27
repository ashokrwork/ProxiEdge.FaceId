using ProxiEdge.FaceId.Base;

namespace ProxiEdge.FaceId.Face.FindSimilar.Parameter
{
    public class FindSimilarParameter : ApiParameterBase
    {
        public string FaceId { get; set; }
        public string FaceListId { get; set; }
        public string LargeFaceListId { get; set; }
        public string[] FaceIds { get; set; }
        public int MaxNumOfCandidatesReturned { get; set; }
        public string Mode { get; set; }
    }
}
