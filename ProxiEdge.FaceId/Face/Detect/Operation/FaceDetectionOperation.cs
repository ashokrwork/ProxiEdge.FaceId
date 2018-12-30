using ProxiEdge.FaceId.Base;
using System.Collections.Generic;
using System;
using ProxiEdge.FaceId.Face.Detect.Result;
using ProxiEdge.FaceId.Face.Detect.Parameter;

namespace ProxiEdge.FaceId.Face.Detect.Operation
{
    /// <summary>
    /// Used to detect Face List in a picture represented as byte[] or Url
    /// Note: make sure that the picture Url is publicly anonymously browsable from the internet 
    /// </summary>
    public class FaceDetectionOperation : FaceIdApiOperation<List<FaceDetectionResult>>
    {
        
        FaceDetectionParameter PictureUrlParameter;
        
        byte[] PictureBytes;
        bool ReturnFaceId;
        bool ReturnFaceLandmarks;
        string RequiredFaceAttributes;

        bool usePictureUrl;

        public FaceDetectionOperation(string pictureUrl, bool returnFaceId = true, bool returnFaceLandmarks = false, string requiredFaceAttributes = "")
        {
            PictureUrlParameter = new FaceDetectionParameter() { Url = pictureUrl };
            ReturnFaceId = returnFaceId;
            ReturnFaceLandmarks = returnFaceLandmarks;
            RequiredFaceAttributes = requiredFaceAttributes;
            usePictureUrl = true;
        }

        public FaceDetectionOperation(byte[] picture, bool returnFaceId = true, bool returnFaceLandmarks = false, string requiredFaceAttributes = "")
        {
            PictureBytes = picture;
            ReturnFaceId = returnFaceId;
            ReturnFaceLandmarks = returnFaceLandmarks;
            RequiredFaceAttributes = requiredFaceAttributes;
            usePictureUrl = false;
        }

        protected override string QueryString
        => string.Format("?returnFaceId={0}&returnFaceLandmarks={1}&returnFaceAttributes={2}",
                                        new object[] {
                                            ReturnFaceId.ToString().ToLower(),
                                            ReturnFaceLandmarks.ToString().ToLower(),
                                            RequiredFaceAttributes });
            

        protected override string HttpMethod => System.Net.Http.HttpMethod.Post.Method;

        protected override byte[] Data => PictureBytes;

        protected override string ContentType => usePictureUrl? WebClientContentType.Json : WebClientContentType.Binary;

        protected override string EndPoint => FaceEndPoint.detect.ToString();

        protected override string JSON => PictureUrlParameter.ToJson();
    }
}




    



