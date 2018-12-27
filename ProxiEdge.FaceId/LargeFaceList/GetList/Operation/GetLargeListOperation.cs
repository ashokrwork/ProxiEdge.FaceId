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

        protected override string JSON { get { return string.Empty; } }

        protected override string Operation { get { return FaceListOperation.facelists.ToString(); } }

        protected override string HttpMethod { get { return System.Net.Http.HttpMethod.Get.Method; } }

        protected override string QueryString { get { return string.Format("/{0}", FaceListId); } }
    }
}
