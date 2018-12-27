using ProxiEdge.FaceId.Base;
using ProxiEdge.FaceId.Face.Verify.Parameter;
using ProxiEdge.FaceId.Face.Verify.Result;

namespace ProxiEdge.FaceId.Face.Verify.Operation
{
    public class FaceVerifyOperation : FaceIdApiOperation<FaceVerifyResult>
    {
        FaceToFaceVerifyParameter faceToFaceVerifyParameter;
        FaceToPersonVerifyParameter faceToPersonVerifyParameter;
        bool IsFaceToFaceVerify;

        public FaceVerifyOperation(string originalFaceId, string toMatchFaceId)
        {
            faceToFaceVerifyParameter = new FaceToFaceVerifyParameter() { FaceId1 = originalFaceId, FaceId2 = toMatchFaceId };
            IsFaceToFaceVerify = true;
        }

       public FaceVerifyOperation(string faceId,string personId,string personGroupId,bool useLargePersonGroup = false)
        {
            faceToPersonVerifyParameter = new FaceToPersonVerifyParameter()
            {
                FaceId = faceId,
                PersonId = personId
            };

            if (useLargePersonGroup)
                faceToPersonVerifyParameter.LargePersonGroupId = personGroupId;
            else
                faceToPersonVerifyParameter.PersonGroupId = personGroupId;
        }
        

        protected override byte[] Data
        {
            get
            {
                if (IsFaceToFaceVerify)
                    return faceToFaceVerifyParameter.ToByteArray();
                else
                    return faceToPersonVerifyParameter.ToByteArray();
            }
        }

       

        protected override string Operation { get { return FaceOperation.verify.ToString(); } }

        protected override string JSON
        {
            get
            {
                if (IsFaceToFaceVerify)
                    return faceToFaceVerifyParameter.ToJson();
                else
                    return faceToPersonVerifyParameter.ToJson();
            }
        }
    }
}
