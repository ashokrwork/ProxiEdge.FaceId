using ProxiEdge.FaceId.Base;
using ProxiEdge.FaceId.Face.Detect.Operation;
using ProxiEdge.FaceId.Face.Detect.Result;
using ProxiEdge.FaceId.Face.FindSimilar.Operation;
using ProxiEdge.FaceId.Face.FindSimilar.Result;
using ProxiEdge.FaceId.Face.Group.Operation;
using ProxiEdge.FaceId.Face.Group.Result;
using ProxiEdge.FaceId.Face.Identify.Operation;
using ProxiEdge.FaceId.Face.Identify.Result;
using ProxiEdge.FaceId.Face.Verify.Operation;
using ProxiEdge.FaceId.Face.Verify.Result;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace ProxiEdge.FaceId.API
{
    public class Face : APIBase
    {
        /// <summary>
        /// Detect human faces in an image, return face rectangles, and optionally with faceIds, landmarks, and attributes.
        /// Optional parameters including faceId, landmarks, and attributes.
        /// Attributes include age, gender, headPose, smile, facialHair, glasses, emotion, hair, makeup, occlusion, accessories, blur, exposure and noise.
        /// faceId will be used in Face - Identify, Face - Verify, and Face - Find Similar.It will expire 24 hours after the detection call.
        /// Higher face image quality means better detection and recognition precision. Please consider high-quality faces: frontal, clear, and face size is 200x200 pixels (100 pixels between eyes) or bigger.
        /// JPEG, PNG, GIF (the first frame), and BMP format are supported.The allowed image file size is from 1KB to 6MB.
        /// Faces are detectable when its size is 36x36 to 4096x4096 pixels.If need to detect very small but clear faces, please try to enlarge the input image.
        /// Up to 64 faces can be returned for an image. Faces are ranked by face rectangle size from large to small.
        /// Face detector prefer frontal and near-frontal faces. There are cases that faces may not be detected, e.g.exceptionally large face angles (head-pose) or being occluded, or wrong image orientation.
        /// Attributes(age, gender, headPose, smile, facialHair, glasses, emotion, hair, makeup, occlusion, accessories, blur, exposure and noise) may not be perfectly accurate.HeadPose's pitch value is a reserved field and will always return 0.
        /// </summary>
        /// <param name="pictureUrl">URL of input image.</param>
        /// <param name="completed">The event to be called after processing completed</param>
        /// <param name="progressChanged">The event to be called during execution for progress reporting</param>
        /// <param name="returnFaceId">Return faceIds of the detected faces or not. The default value is true</param>
        /// <param name="returnFaceLandmarks">Return face landmarks of the detected faces or not. The default value is false.</param>
        /// <param name="requiredFaceAttributes">Analyze and return the one or more specified face attributes in the comma-separated string like "returnFaceAttributes=age,gender". Supported face attributes include age, gender, headPose, smile, facialHair, glasses, emotion, hair, makeup, occlusion, accessories, blur, exposure and noise. Face attribute analysis has additional computational and time cost.</param>
        public static void Detect(string pictureUrl, EventHandler<List<FaceDetectionResult>> completed, EventHandler<ProgressChangedEventArgs> progressChanged = null, bool returnFaceId = true, bool returnFaceLandmarks = false, string requiredFaceAttributes = "")
        {
            using (var operation = new FaceDetectionOperation(pictureUrl, returnFaceId, returnFaceLandmarks, requiredFaceAttributes))
            {
                ExecuteOperation(operation, completed, progressChanged);
            }
        }

        /// <summary>
        /// Detect human faces in an image, return face rectangles, and optionally with faceIds, landmarks, and attributes.
        /// Optional parameters including faceId, landmarks, and attributes.
        /// Attributes include age, gender, headPose, smile, facialHair, glasses, emotion, hair, makeup, occlusion, accessories, blur, exposure and noise.
        /// faceId will be used in Face - Identify, Face - Verify, and Face - Find Similar.It will expire 24 hours after the detection call.
        /// Higher face image quality means better detection and recognition precision. Please consider high-quality faces: frontal, clear, and face size is 200x200 pixels (100 pixels between eyes) or bigger.
        /// JPEG, PNG, GIF (the first frame), and BMP format are supported.The allowed image file size is from 1KB to 6MB.
        /// Faces are detectable when its size is 36x36 to 4096x4096 pixels.If need to detect very small but clear faces, please try to enlarge the input image.
        /// Up to 64 faces can be returned for an image. Faces are ranked by face rectangle size from large to small.
        /// Face detector prefer frontal and near-frontal faces. There are cases that faces may not be detected, e.g.exceptionally large face angles (head-pose) or being occluded, or wrong image orientation.
        /// Attributes(age, gender, headPose, smile, facialHair, glasses, emotion, hair, makeup, occlusion, accessories, blur, exposure and noise) may not be perfectly accurate.HeadPose's pitch value is a reserved field and will always return 0.
        /// </summary>
        /// <param name="picture">Byte[] of input image.</param>
        /// <param name="completed">The event to be called after processing completed</param>
        /// <param name="progressChanged">The event to be called during execution for progress reporting</param>
        /// <param name="returnFaceId">Return faceIds of the detected faces or not. The default value is true</param>
        /// <param name="returnFaceLandmarks">Return face landmarks of the detected faces or not. The default value is false.</param>
        /// <param name="requiredFaceAttributes">Analyze and return the one or more specified face attributes in the comma-separated string like "returnFaceAttributes=age,gender". Supported face attributes include age, gender, headPose, smile, facialHair, glasses, emotion, hair, makeup, occlusion, accessories, blur, exposure and noise. Face attribute analysis has additional computational and time cost.</param>
        public static void Detect(byte[] picture, EventHandler<List<FaceDetectionResult>> completed, EventHandler<ProgressChangedEventArgs> progressChanged = null, bool returnFaceId = true, bool returnFaceLandmarks = false, string requiredFaceAttributes = "")
        {
            var operation = new FaceDetectionOperation(picture, returnFaceId, returnFaceLandmarks, requiredFaceAttributes);
            ExecuteOperation(operation, completed, progressChanged);
        }

        public static void FindSimilar(string faceId, string faceListId, EventHandler<List<FindSimilarResults>> completed, bool useLargeList = false, EventHandler<ProgressChangedEventArgs> progressChanged = null, int maxNumOfCandidatesReturned = 20, FindSimilarMode findMode = FindSimilarMode.matchPerson)
        {
            var operation = new FindSimilarOperation(faceId, faceListId, useLargeList, maxNumOfCandidatesReturned, findMode);
            ExecuteOperation(operation, completed, progressChanged);
        }

        public static void FindSimilar(string faceId, string[] faceIds, EventHandler<List<FindSimilarResults>> completed, EventHandler<ProgressChangedEventArgs> progressChanged = null, int maxNumOfCandidatesReturned = 20, FindSimilarMode findMode = FindSimilarMode.matchPerson)
        {
            var operation = new FindSimilarOperation(faceId, faceIds, maxNumOfCandidatesReturned, findMode);
            ExecuteOperation(operation, completed, progressChanged);
        }

        public static void FindSimilarInList(string faceId, string faceListId, EventHandler<List<FindSimilarResults>> completed, EventHandler<ProgressChangedEventArgs> progressChanged = null, int maxNumOfCandidatesReturned = 20, FindSimilarMode findMode = FindSimilarMode.matchPerson)
        {
            var operation = new FindSimilarOperation(faceId, faceListId, false, maxNumOfCandidatesReturned, findMode);
            ExecuteOperation(operation, completed, progressChanged);
        }

        public static void FindSimilarInLargeList(string faceId, string largeFaceListId, EventHandler<List<FindSimilarResults>> completed, EventHandler<ProgressChangedEventArgs> progressChanged = null, int maxNumOfCandidatesReturned = 20, FindSimilarMode findMode = FindSimilarMode.matchPerson)
        {
            var operation = new FindSimilarOperation(faceId, largeFaceListId, true, maxNumOfCandidatesReturned, findMode);
            ExecuteOperation(operation, completed, progressChanged);
        }

        public static void Group(string[] faceIds, EventHandler<GroupResult> completed, EventHandler<ProgressChangedEventArgs> progressChanged = null)
        {
            var operation = new GroupOperation(faceIds);
            ExecuteOperation(operation, completed, progressChanged);
        }

        public static void IdentifyInGroup(string[] faceIds, string groupId, EventHandler<IdentifyResult> completed, EventHandler<ProgressChangedEventArgs> progressChanged = null, int maxNumOfCandidatesReturned = 10, double confidenceThreshold = 0.5)
        {
            var operation = new IdentifyOperation(faceIds, groupId, false, maxNumOfCandidatesReturned, confidenceThreshold);
            ExecuteOperation(operation, completed, progressChanged);
        }

        public static void IdentifyInLargeGroup(string[] faceIds, string largeGroupId, EventHandler<IdentifyResult> completed, EventHandler<ProgressChangedEventArgs> progressChanged = null, int maxNumOfCandidatesReturned = 10, double confidenceThreshold = 0.5)
        {
            var operation = new IdentifyOperation(faceIds, largeGroupId, true, maxNumOfCandidatesReturned, confidenceThreshold);
            ExecuteOperation(operation, completed, progressChanged);
        }

        public static void Verify(string originalFaceId, string toMatchFaceId, EventHandler<FaceVerifyResult> completed, EventHandler<ProgressChangedEventArgs> progressChanged = null)
        {
            var operation = new FaceVerifyOperation(originalFaceId, toMatchFaceId);
            ExecuteOperation(operation, completed, progressChanged);
        }

        public static void VerifyInGroup(string faceId, string personId, string personGroupId, EventHandler<FaceVerifyResult> completed, EventHandler<ProgressChangedEventArgs> progressChanged = null)
        {
            var operation = new FaceVerifyOperation(faceId, personId, personGroupId);
            ExecuteOperation(operation, completed, progressChanged);
        }

        public static void VerifyInLargeGroup(string faceId, string personId, string largePersonGroupId, EventHandler<FaceVerifyResult> completed, EventHandler<ProgressChangedEventArgs> progressChanged = null)
        {
            var operation = new FaceVerifyOperation(faceId, personId, largePersonGroupId, true);
            ExecuteOperation(operation, completed, progressChanged);
        }
    }
}
