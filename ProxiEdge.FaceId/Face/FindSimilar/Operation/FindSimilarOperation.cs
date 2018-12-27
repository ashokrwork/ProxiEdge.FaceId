using ProxiEdge.FaceId.Base;
using ProxiEdge.FaceId.Face.FindSimilar.Parameter;
using ProxiEdge.FaceId.FindSimilar.Face.Result;
using System.Collections.Generic;

namespace ProxiEdge.FaceId.Face.FindSimilar.Operation
{
    public class FindSimilarOperation : FaceIdApiOperation<List<FindSimilarResults>>
    {

        FindSimilarParameter findSimilarParameter;

        public FindSimilarOperation(string faceId,string faceListId,bool useLargeList, int maxNumOfCandidatesReturned = 20, FindSimilarMode findMode = FindSimilarMode.matchPerson)
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

        protected override byte[] Data { get { return findSimilarParameter.ToByteArray(); } }

        protected override string Operation { get { return FaceOperation.findsimilars.ToString(); } }

        protected override string JSON { get { return findSimilarParameter.ToJson(); } }
    }
}
