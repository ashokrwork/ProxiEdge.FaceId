using ProxiEdge.FaceId.Base;
using ProxiEdge.FaceId.LargeFaceList.LargeFaceListUpdateFace.Parameter;

namespace ProxiEdge.FaceId.LargeFaceList.LargeFaceListUpdateFace.Operation
{
    public class LargeFaceListUpdateFaceOperation : FaceIdApiOperation<string>
    {
        LargeFaceListUpdateFaceParameter Parameter;
        string LargeFaceListId;
        string PersistedFaceId;

        public LargeFaceListUpdateFaceOperation(string largeFaceListId,string persistedFaceId,string userData)
        {
            LargeFaceListId = largeFaceListId;
            PersistedFaceId = persistedFaceId;

            Parameter = new LargeFaceListUpdateFaceParameter { UserData = userData };

        }

        protected override string QueryString => string.Format("/{0}/persistedfaces{1}", LargeFaceListId, PersistedFaceId);

        protected override byte[] Data => throw new System.NotImplementedException();

        protected override string JSON => Parameter.ToJson();

        protected override string Operation => LargeFaceListOperation.largefacelists.ToString();

        protected override string HttpMethod => "PATCH";
    }
}
