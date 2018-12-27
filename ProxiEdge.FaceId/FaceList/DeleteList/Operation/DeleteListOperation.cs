using ProxiEdge.FaceId.Base;
using System;

namespace ProxiEdge.FaceId.FaceList.DeleteList.Operation
{
    public class DeleteListOperation : FaceIdApiOperation<string>
    {
        string FaceListId;

        public DeleteListOperation(string faceListId)
        {
            FaceListId = faceListId;
        }

        protected override byte[] Data => throw new NotImplementedException();

        protected override string JSON { get { return string.Empty; } }

        protected override string Operation { get { return FaceListOperation.facelists.ToString(); } }

        protected override string HttpMethod { get { return System.Net.Http.HttpMethod.Delete.Method; } }

        protected override string QueryString { get { return string.Format("/{0}", FaceListId); } }
    }
}
