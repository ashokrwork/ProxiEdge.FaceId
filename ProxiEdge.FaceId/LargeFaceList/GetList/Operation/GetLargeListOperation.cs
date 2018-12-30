using ProxiEdge.FaceId.Base;
using ProxiEdge.FaceId.LargeFaceList.GetLargeList.Result;
using System;

namespace ProxiEdge.FaceId.LargeFaceList.GetLargeList.Operation
{
    public class GetLargeListOperation : FaceIdApiOperation<GetLargeListResult>
    {
        string FaceListId;

        public GetLargeListOperation(string faceListId)
        {
            FaceListId = faceListId;
        }

        protected override byte[] Data => throw new NotImplementedException();

        protected override string JSON => string.Empty; 

        protected override string EndPoint => FaceListEndPoint.facelists.ToString(); 

        protected override string HttpMethod => System.Net.Http.HttpMethod.Get.Method; 

        protected override string QueryString => string.Format("/{0}", FaceListId); 
    }
}
