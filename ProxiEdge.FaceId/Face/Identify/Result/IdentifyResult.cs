using System.Collections.Generic;

namespace ProxiEdge.FaceId.Face.Identify.Result
{
    public class Candidate
    {
        public string PersonId { get; set; }
        public double Confidence { get; set; }
    }
    public class IdentifyResult
    {
        public string FaceId { get; set; }
        public List<Candidate> Candidates { get; set; }
    }
}
