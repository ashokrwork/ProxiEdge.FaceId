using ProxiEdge.FaceId.Base;
using System;
using System.Collections.Generic;
using System.Text;

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

        protected override byte[] Data => throw new NotImplementedException();

        protected override string JSON { get { return string.Empty; } }

        protected override string Operation { get { return FaceListOperation.facelists.ToString(); } }

        protected override string HttpMethod { get { return System.Net.Http.HttpMethod.Delete.Method; } }

        protected override string QueryString { get { return string.Format("/{0}/persistedFaces/{1}", FaceListId,PersistedFaceId); } }
    }
}
