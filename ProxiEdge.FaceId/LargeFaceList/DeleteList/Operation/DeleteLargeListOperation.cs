using ProxiEdge.FaceId.Base;
using System;

namespace ProxiEdge.FaceId.LargeFaceList.DeleteList.Operation
{
    public class DeleteLargeListOperation : FaceIdApiOperation<string>
    {
        string FaceListId;

        public DeleteLargeListOperation(string faceListId)
        {
            FaceListId = faceListId;
        }

        protected override byte[] Data => throw new NotImplementedException();

        protected override string JSON { get { return string.Empty; } }

        protected override string Operation { get { return LargeFaceListOperation.largefacelists.ToString(); } }

        protected override string HttpMethod { get { return System.Net.Http.HttpMethod.Delete.Method; } }

        protected override string QueryString { get { return string.Format("/{0}", FaceListId); } }
    }
}
