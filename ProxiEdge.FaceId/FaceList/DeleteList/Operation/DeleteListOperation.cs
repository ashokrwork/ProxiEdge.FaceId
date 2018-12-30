using ProxiEdge.FaceId.Base;

namespace ProxiEdge.FaceId.FaceList.DeleteList.Operation
{
    public class DeleteListOperation : FaceIdApiOperation<string>
    {
        string FaceListId;

        public DeleteListOperation(string faceListId)
        {
            FaceListId = faceListId;
        }

        protected override byte[] Data => null;

        protected override string JSON => string.Empty; 

        protected override string Operation => FaceListOperation.facelists.ToString(); 

        protected override string HttpMethod => System.Net.Http.HttpMethod.Delete.Method; 

        protected override string QueryString => string.Format("/{0}", FaceListId); 
    }
}
