using ProxiEdge.FaceId.Base;
using ProxiEdge.FaceId.Face.FindSimilar.Parameter;
using ProxiEdge.FaceId.Face.FindSimilar.Result;
using System.Collections.Generic;

namespace ProxiEdge.FaceId.Face.FindSimilar.Operation
{
    public class FindSimilarOperation : FaceIdApiOperation<List<FindSimilarResults>>
    {

        FindSimilarParameter findSimilarParameter;

        public FindSimilarOperation(string faceId,string faceListId,bool useLargeList = false, int maxNumOfCandidatesReturned = 20, FindSimilarMode findMode = FindSimilarMode.matchPerson)
        {
            findSimilarParameter = new FindSimilarParameter()
            {
                FaceId = faceId,
                MaxNumOfCandidatesReturned = maxNumOfCandidatesReturned,
                Mode = findMode.ToString()
            };

            if (useLargeList)
                findSimilarParameter.LargeFaceListId = faceListId;
            else
                findSimilarParameter.FaceListId = faceListId;
        }
        public FindSimilarOperation(string faceId,string[] faceIds, int maxNumOfCandidatesReturned = 20, FindSimilarMode findMode = FindSimilarMode.matchPerson)
        {
            findSimilarParameter = new FindSimilarParameter()
            {
                FaceId = faceId,
                MaxNumOfCandidatesReturned = maxNumOfCandidatesReturned,
                Mode = findMode.ToString(),
                FaceIds = faceIds
            };
        }

        protected override byte[] Data => findSimilarParameter.ToByteArray(); 

        protected override string EndPoint => FaceEndPoint.findsimilars.ToString(); 

        protected override string JSON => findSimilarParameter.ToJson(); 
    }
}
