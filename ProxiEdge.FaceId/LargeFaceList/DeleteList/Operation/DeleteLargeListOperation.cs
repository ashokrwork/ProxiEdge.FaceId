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

        protected override string JSON => string.Empty; 

        protected override string Operation => LargeFaceListOperation.largefacelists.ToString(); 

        protected override string HttpMethod => System.Net.Http.HttpMethod.Delete.Method; 

        protected override string QueryString => string.Format("/{0}", FaceListId); 
    }
}
