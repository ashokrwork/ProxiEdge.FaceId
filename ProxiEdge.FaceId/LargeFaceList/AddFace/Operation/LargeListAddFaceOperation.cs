using ProxiEdge.FaceId.Base;
using ProxiEdge.FaceId.LargeFaceList.AddFace.Parameter;
using ProxiEdge.FaceId.LargeFaceList.AddFace.Result;

namespace ProxiEdge.FaceId.LargeFaceList.AddFace.Operation
{
    public class LargeListAddFaceOperation : FaceIdApiOperation<AddFaceResult>
    {
        AddFaceParameter addFaceParameter;
        bool usePictureUrl;
        byte[] PictureBytes;
        string FaceListId;
        string UserData;
        string TargetFace;

        protected override byte[] Data
        {
            get
            {

                return PictureBytes;

            }
        }

        public LargeListAddFaceOperation(string pictureUrl, string faceListId, string userData = "", string targetFace = "")
        {
            FaceListId = faceListId;
            UserData = string.IsNullOrEmpty(userData) ? "" : string.Format("?userData={0}", userData);
            TargetFace = string.IsNullOrEmpty(targetFace) ? "" : string.Format("?targetFace={0}", targetFace); 

            addFaceParameter = new AddFaceParameter() { Url = pictureUrl };

            usePictureUrl = true;
        }

        public LargeListAddFaceOperation(byte[] picture, string faceListId, string userData = "", string targetFace = "")
        {
            PictureBytes = picture;
            FaceListId = faceListId;
            UserData = string.IsNullOrEmpty(userData) ? "" : string.Format("?userData={0}", userData);
            TargetFace = string.IsNullOrEmpty(targetFace) ? "" : string.Format("?targetFace={0}", targetFace); 
        }

        protected override string QueryString => string.Format("/{0}/persistedFaces{1}{2}", FaceListId,UserData,TargetFace);
            
        protected override string ContentType => usePictureUrl?  WebClientContentType.Json: WebClientContentType.Binary; 

        protected override string JSON => addFaceParameter.ToJson();

        protected override string Operation => LargeFaceListOperation.largefacelists.ToString(); 
    }
}
