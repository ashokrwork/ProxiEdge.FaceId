using ProxiEdge.FaceId.Base;
using ProxiEdge.FaceId.LargeFaceList.GetFace.Result;
using System;

namespace ProxiEdge.FaceId.LargeFaceList.GetFace.Operation
{
    public class LargeListGetFaceOperation : FaceIdApiOperation<LargeListGetFaceResult>
    {
        string LargeFaceListId;
        string PersistedFaceId;

        public LargeListGetFaceOperation(string largeFaceListId,string persistedFaceId)
        {
            LargeFaceListId = largeFaceListId;
            PersistedFaceId = persistedFaceId;
        }

        protected override byte[] Data => throw new NotImplementedException();

        protected override string JSON { get { return string.Empty; } }

        protected override string HttpMethod { get { return System.Net.Http.HttpMethod.Get.Method; } }

        protected override string Operation { get { return LargeFaceListOperation.largefacelists.ToString(); } }

        protected override string QueryString { get { return string.Format("/{0}/persistedFaces/{1}", LargeFaceListId, PersistedFaceId); } }
    }
}
