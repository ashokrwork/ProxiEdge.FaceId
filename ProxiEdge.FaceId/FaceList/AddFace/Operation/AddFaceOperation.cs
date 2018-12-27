using ProxiEdge.FaceId.Base;
using ProxiEdge.FaceId.FaceList.AddFace.Parameter;
using ProxiEdge.FaceId.FaceList.AddFace.Result;

namespace ProxiEdge.FaceId.FaceList.AddFace.Operation
{
    public class AddFaceOperation : FaceIdApiOperation<AddFaceResult>
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

        public AddFaceOperation(string pictureUrl, string faceListId, string userData = "", string targetFace = "")
        {
            FaceListId = faceListId;
            UserData = string.IsNullOrEmpty(userData) ? "" : string.Format("?userData={0}", userData);
            TargetFace = string.IsNullOrEmpty(targetFace) ? "" : string.Format("?targetFace={0}", targetFace); 

            addFaceParameter = new AddFaceParameter() { Url = pictureUrl };

            usePictureUrl = true;
        }

        public AddFaceOperation(byte[] picture, string faceListId, string userData = "", string targetFace = "")
        {
            PictureBytes = picture;
            FaceListId = faceListId;
            UserData = string.IsNullOrEmpty(userData) ? "" : string.Format("?userData={0}", userData);
            TargetFace = string.IsNullOrEmpty(targetFace) ? "" : string.Format("?targetFace={0}", targetFace); 
        }

        protected override string QueryString
        {
            get
            {
                return string.Format("/{0}/persistedFaces{1}{2}", FaceListId,UserData,TargetFace);
            }
        }

        protected override string ContentType { get { if (usePictureUrl) return WebClientContentType.Json; else return WebClientContentType.Binary; } }

        protected override string JSON { get { return addFaceParameter.ToJson(); } }

        protected override string Operation { get { return FaceListOperation.facelists.ToString(); } }
    }
}
