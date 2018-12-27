using ProxiEdge.FaceId.Base;
using ProxiEdge.FaceId.Face.Identify.Parameter;
using ProxiEdge.FaceId.Face.Identify.Result;

namespace ProxiEdge.FaceId.Face.Identify.Operation
{
    public class IdentifyOperation : FaceIdApiOperation<IdentifyResult>
    {
        IdentifyParameter identifyParameter;

        public IdentifyOperation(string[] faceIds,string groupId,bool useLargeGroup = false,int maxNumOfCandidatesReturned = 10,double confidenceThreshold = 0.5)
        {
            identifyParameter = new IdentifyParameter()
            {
                FaceIds = faceIds,
                ConfidenceThreshold = confidenceThreshold,
                MaxNumOfCandidatesReturned = maxNumOfCandidatesReturned
            };

            if (useLargeGroup)
                identifyParameter.LargePersonGroupId = groupId;
            else
                identifyParameter.PersonGroupId = groupId;
        }

        protected override byte[] Data { get { return identifyParameter.ToByteArray(); } }

        protected override string Operation { get { return FaceOperation.identify.ToString(); } }

        protected override string JSON { get { return identifyParameter.ToJson(); } }
    }
}
