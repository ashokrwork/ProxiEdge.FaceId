using ProxiEdge.FaceId.Base;
using ProxiEdge.FaceId.FaceList.GetList.Result;
using System;

namespace ProxiEdge.FaceId.FaceList.GetList.Operation
{
    public class GetListOperation : FaceIdApiOperation<GetListResult>
    {
        string FaceListId;

        public GetListOperation(string faceListId)
        {
            FaceListId = faceListId;
        }

        protected override byte[] Data => throw new NotImplementedException();

        protected override string JSON { get { return string.Empty; } }

        protected override string EndPoint { get { return FaceListEndPoint.facelists.ToString(); } }

        protected override string HttpMethod { get { return System.Net.Http.HttpMethod.Get.Method; } }

        protected override string QueryString { get { return string.Format("/{0}", FaceListId); } }
    }
}
