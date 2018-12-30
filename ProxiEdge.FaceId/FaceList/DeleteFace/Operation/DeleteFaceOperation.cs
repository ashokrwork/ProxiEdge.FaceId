using ProxiEdge.FaceId.Base;

namespace ProxiEdge.FaceId.FaceList.DeleteFace.Operation
{
    public class DeleteFaceOperation : FaceIdApiOperation<string>
    {
        string FaceListId;
        string PersistedFaceId;

        public DeleteFaceOperation(string faceListId,string persistedFaceId)
        {
            FaceListId = faceListId;
            PersistedFaceId = persistedFaceId;
        }

        protected override byte[] Data => null;

        protected override string JSON => string.Empty; 

        protected override string EndPoint => FaceListEndPoint.facelists.ToString(); 

        protected override string HttpMethod => System.Net.Http.HttpMethod.Delete.Method; 

        protected override string QueryString => string.Format("/{0}/persistedFaces/{1}", FaceListId,PersistedFaceId); 
    }
}
