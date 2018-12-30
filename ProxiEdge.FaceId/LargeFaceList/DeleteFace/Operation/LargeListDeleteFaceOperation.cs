using ProxiEdge.FaceId.Base;
using System;

namespace ProxiEdge.FaceId.LargeFaceList.DeleteFace.Operation
{
    public class LargeListDeleteFaceOperation : FaceIdApiOperation<string>
    {
        string FaceListId;
        string PersistedFaceId;

        public LargeListDeleteFaceOperation(string faceListId,string persistedFaceId)
        {
            FaceListId = faceListId;
            PersistedFaceId = persistedFaceId;
        }

        protected override byte[] Data => throw new NotImplementedException();

        protected override string JSON => string.Empty; 

        protected override string Operation => LargeFaceListOperation.largefacelists.ToString(); 

        protected override string HttpMethod => System.Net.Http.HttpMethod.Delete.Method; 

        protected override string QueryString => string.Format("/{0}/persistedFaces/{1}", FaceListId,PersistedFaceId); 
    }
}
