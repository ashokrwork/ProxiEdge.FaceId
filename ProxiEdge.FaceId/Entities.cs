using Newtonsoft.Json;
using ProxiEdge.FaceId.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProxiEdge.FaceId.Entities
{
    public class FaceRectangle
    {
        public int width { get; set; }
        public int height { get; set; }
        public int left { get; set; }
        public int top { get; set; }
    }

    public class PupilLeft
    {
        public double x { get; set; }
        public double y { get; set; }
    }

    public class PupilRight
    {
        public double x { get; set; }
        public double y { get; set; }
    }

    public class NoseTip
    {
        public double x { get; set; }
        public double y { get; set; }
    }

    public class MouthLeft
    {
        public double x { get; set; }
        public double y { get; set; }
    }

    public class MouthRight
    {
        public double x { get; set; }
        public double y { get; set; }
    }

    public class EyebrowLeftOuter
    {
        public double x { get; set; }
        public double y { get; set; }
    }

    public class EyebrowLeftInner
    {
        public double x { get; set; }
        public double y { get; set; }
    }

    public class EyeLeftOuter
    {
        public double x { get; set; }
        public double y { get; set; }
    }

    public class EyeLeftTop
    {
        public double x { get; set; }
        public double y { get; set; }
    }

    public class EyeLeftBottom
    {
        public double x { get; set; }
        public double y { get; set; }
    }

    public class EyeLeftInner
    {
        public double x { get; set; }
        public double y { get; set; }
    }

    public class EyebrowRightInner
    {
        public double x { get; set; }
        public double y { get; set; }
    }

    public class EyebrowRightOuter
    {
        public double x { get; set; }
        public double y { get; set; }
    }

    public class EyeRightInner
    {
        public double x { get; set; }
        public double y { get; set; }
    }

    public class EyeRightTop
    {
        public double x { get; set; }
        public double y { get; set; }
    }

    public class EyeRightBottom
    {
        public double x { get; set; }
        public double y { get; set; }
    }

    public class EyeRightOuter
    {
        public double x { get; set; }
        public double y { get; set; }
    }

    public class NoseRootLeft
    {
        public double x { get; set; }
        public double y { get; set; }
    }

    public class NoseRootRight
    {
        public double x { get; set; }
        public double y { get; set; }
    }

    public class NoseLeftAlarTop
    {
        public double x { get; set; }
        public double y { get; set; }
    }

    public class NoseRightAlarTop
    {
        public double x { get; set; }
        public double y { get; set; }
    }

    public class NoseLeftAlarOutTip
    {
        public double x { get; set; }
        public double y { get; set; }
    }

    public class NoseRightAlarOutTip
    {
        public double x { get; set; }
        public double y { get; set; }
    }

    public class UpperLipTop
    {
        public double x { get; set; }
        public double y { get; set; }
    }

    public class UpperLipBottom
    {
        public double x { get; set; }
        public double y { get; set; }
    }

    public class UnderLipTop
    {
        public double x { get; set; }
        public double y { get; set; }
    }

    public class UnderLipBottom
    {
        public double x { get; set; }
        public double y { get; set; }
    }

    public class FaceLandmarks
    {
        public PupilLeft pupilLeft { get; set; }
        public PupilRight pupilRight { get; set; }
        public NoseTip noseTip { get; set; }
        public MouthLeft mouthLeft { get; set; }
        public MouthRight mouthRight { get; set; }
        public EyebrowLeftOuter eyebrowLeftOuter { get; set; }
        public EyebrowLeftInner eyebrowLeftInner { get; set; }
        public EyeLeftOuter eyeLeftOuter { get; set; }
        public EyeLeftTop eyeLeftTop { get; set; }
        public EyeLeftBottom eyeLeftBottom { get; set; }
        public EyeLeftInner eyeLeftInner { get; set; }
        public EyebrowRightInner eyebrowRightInner { get; set; }
        public EyebrowRightOuter eyebrowRightOuter { get; set; }
        public EyeRightInner eyeRightInner { get; set; }
        public EyeRightTop eyeRightTop { get; set; }
        public EyeRightBottom eyeRightBottom { get; set; }
        public EyeRightOuter eyeRightOuter { get; set; }
        public NoseRootLeft noseRootLeft { get; set; }
        public NoseRootRight noseRootRight { get; set; }
        public NoseLeftAlarTop noseLeftAlarTop { get; set; }
        public NoseRightAlarTop noseRightAlarTop { get; set; }
        public NoseLeftAlarOutTip noseLeftAlarOutTip { get; set; }
        public NoseRightAlarOutTip noseRightAlarOutTip { get; set; }
        public UpperLipTop upperLipTop { get; set; }
        public UpperLipBottom upperLipBottom { get; set; }
        public UnderLipTop underLipTop { get; set; }
        public UnderLipBottom underLipBottom { get; set; }
    }

    public class FacialHair
    {
        public double moustache { get; set; }
        public double beard { get; set; }
        public double sideburns { get; set; }
    }

    public class HeadPose
    {
        public double roll { get; set; }
        public int yaw { get; set; }
        public int pitch { get; set; }
    }

    public class Emotion
    {
        public double anger { get; set; }
        public int contempt { get; set; }
        public double disgust { get; set; }
        public double fear { get; set; }
        public double happiness { get; set; }
        public double neutral { get; set; }
        public int sadness { get; set; }
        public double surprise { get; set; }
    }

    public class HairColor
    {
        public string color { get; set; }
        public double confidence { get; set; }
    }

    public class Hair
    {
        public double bald { get; set; }
        public bool invisible { get; set; }
        public List<HairColor> hairColor { get; set; }
    }

    public class Makeup
    {
        public bool eyeMakeup { get; set; }
        public bool lipMakeup { get; set; }
    }

    public class Occlusion
    {
        public bool foreheadOccluded { get; set; }
        public bool eyeOccluded { get; set; }
        public bool mouthOccluded { get; set; }
    }

    public class Accessory
    {
        public string type { get; set; }
        public double confidence { get; set; }
    }


    public class Blur
    {
        public string blurLevel { get; set; }
        public double value { get; set; }
    }

    public class Exposure
    {
        public string exposureLevel { get; set; }
        public double value { get; set; }
    }

    public class Noise
    {
        public string noiseLevel { get; set; }
        public double value { get; set; }
    }

    public class FaceAttributes
    {
        public double age { get; set; }
        public string gender { get; set; }
        public double smile { get; set; }
        public FacialHair facialHair { get; set; }
        public string glasses { get; set; }
        public HeadPose headPose { get; set; }
        public Emotion emotion { get; set; }
        public Hair hair { get; set; }
        public Makeup makeup { get; set; }
        public Occlusion occlusion { get; set; }
        public List<Accessory> accessories { get; set; }
        public Blur blur { get; set; }
        public Exposure exposure { get; set; }
        public Noise noise { get; set; }
    }

    

    
}

namespace ProxiEdge.FaceId.Results
{
    public interface IApiResults<T>
    {
        
         bool IsSuccedded { get; set; }
         Exception Error { get; set; }
          T Results { get; set; }
    }

    public interface IApiResult
    {

    }

    public abstract class ApiResults<T> : IApiResults<T>
    {
        public bool IsSuccedded { get; set; }
        public Exception Error { get; set; }
        public abstract T Results { get; set; }
    }

    public class FaceDetectionResults : ApiResults<List<FaceResults>>
    {
        public override List<FaceResults> Results { get; set; }
    }

    public class FindSimilarResults : ApiResults<List<SimilarResults>>
    {
        public override List<SimilarResults> Results { get; set; }
        
    }

    public class FaceVerifyResults : ApiResults<FaceVerifyResult>
    {
        public override FaceVerifyResult Results { get; set; }
    }

    public class FaceVerifyResult : IApiResult
    {
        public bool isIdentical { get; set; }
        public int confidence { get; set; }
    }

    public class SimilarResults
    {
        public string persistedFaceId { get; set; }
        public double confidence { get; set; }
    }

    public class FaceResults
    {

        public string faceId { get; set; }
        public FaceRectangle faceRectangle { get; set; }
        public FaceLandmarks faceLandmarks { get; set; }
        public FaceAttributes faceAttributes { get; set; }
    }
}

namespace ProxiEdge.FaceId.Json
{
    public class ApiParameterBase
    {
        public byte[] ToByteArray()
        {
            return Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(this, Formatting.None, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore }));
        }
    }
    public class FaceDetectionParameter : ApiParameterBase
    {
        public string url { get; set; }
    }

    public class FaceToFaceVerifyParameter : ApiParameterBase
    {
        public string faceId1 { get; set; }
        public string faceId2 { get; set; }
    }

    public class FindSimilarParameter : ApiParameterBase
    {
        public string faceId { get; set; }
        public string faceListId { get; set; }
        public string largeFaceListId { get; set; }
        public string[] faceIds { get; set; }
        public int maxNumOfCandidatesReturned { get; set; }
        public string mode { get; set; }
    }

}
