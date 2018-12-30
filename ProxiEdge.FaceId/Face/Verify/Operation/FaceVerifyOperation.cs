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


        protected override byte[] Data => IsFaceToFaceVerify ? faceToFaceVerifyParameter.ToByteArray() : faceToPersonVerifyParameter.ToByteArray();
        
        protected override string Operation => FaceOperation.verify.ToString();

        protected override string JSON => IsFaceToFaceVerify ? faceToFaceVerifyParameter.ToJson() : faceToPersonVerifyParameter.ToJson();
    }
}
