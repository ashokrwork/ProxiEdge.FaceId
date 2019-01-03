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
using ProxiEdge.FaceId.FaceList.AddFace.Result;
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
        public static void DetectAsync(string pictureUrl, EventHandler<List<FaceDetectionResult>> completed, EventHandler<ProgressChangedEventArgs> progressChanged = null, bool returnFaceId = true, bool returnFaceLandmarks = false, string requiredFaceAttributes = "")
        {
            var operation = new FaceDetectionOperation(pictureUrl, returnFaceId, returnFaceLandmarks, requiredFaceAttributes);
            ExecuteOperationAsync(operation, completed, progressChanged);

        }

        public static FaceDetectionOperation Detect(string pictureUrl, bool returnFaceId = true, bool returnFaceLandmarks = false, string requiredFaceAttributes = "")
        {
            var operation = new FaceDetectionOperation(pictureUrl, returnFaceId, returnFaceLandmarks, requiredFaceAttributes);
            operation.Execute();
            return operation;
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
        public static void DetectAsync(byte[] picture, EventHandler<List<FaceDetectionResult>> completed, EventHandler<ProgressChangedEventArgs> progressChanged = null, bool returnFaceId = true, bool returnFaceLandmarks = false, string requiredFaceAttributes = "")
        {
            var operation = new FaceDetectionOperation(picture, returnFaceId, returnFaceLandmarks, requiredFaceAttributes);
            ExecuteOperationAsync(operation, completed, progressChanged);
        }

        public static FaceDetectionOperation Detect(byte[] picture,  bool returnFaceId = true, bool returnFaceLandmarks = false, string requiredFaceAttributes = "")
        {
            var operation = new FaceDetectionOperation(picture, returnFaceId, returnFaceLandmarks, requiredFaceAttributes);
            operation.Execute();
            return operation;
        }

        public static void FindSimilar(string faceId, string faceListId, EventHandler<List<FindSimilarResults>> completed, bool useLargeList = false, EventHandler<ProgressChangedEventArgs> progressChanged = null, int maxNumOfCandidatesReturned = 20, FindSimilarMode findMode = FindSimilarMode.matchPerson)
        {
            var operation = new FindSimilarOperation(faceId, faceListId, useLargeList, maxNumOfCandidatesReturned, findMode);
            ExecuteOperationAsync(operation, completed, progressChanged);
        }

        /// <summary>
        /// Given query face's faceId, to search the similar-looking faces from a faceId array, a face list or a large face list. 
        /// faceId array contains the faces created by Face - Detect, which will expire 24 hours after creation. 
        /// A "faceListId" is created by FaceList - Create containing persistedFaceIds that will not expire. 
        /// And a "largeFaceListId" is created by LargeFaceList - Create containing persistedFaceIds that will also not expire. 
        /// Depending on the input the returned similar faces list contains faceIds or persistedFaceIds ranked by similarity. 
        /// Find similar has two working modes, "matchPerson" and "matchFace". 
        /// "matchPerson" is the default mode that it tries to find faces of the same person as possible by using internal same-person thresholds.
        /// It is useful to find a known person's other photos. Note that an empty list will be returned if no faces pass the internal thresholds. 
        /// "matchFace" mode ignores same-person thresholds and returns ranked similar faces anyway, even the similarity is low. 
        /// It can be used in the cases like searching celebrity-looking faces.
        /// </summary>
        /// <param name="faceId">
        /// faceId of the query face. User needs to call Face - Detect first to get a valid faceId. 
        /// Note that this faceId is not persisted and will expire 24 hours after the detection call.</param>
        /// <param name="faceIds">An array of candidate faceIds. All of them are created by Face - Detect and the faceIds will expire 24 hours after the detection call. The number of faceIds is limited to 1000. Parameter faceListId, largeFaceListId and faceIds should not be provided at the same time.</param>
        /// <param name="completed">Event handler to be called after the opration finishes</param>
        /// <param name="progressChanged">Event handler to be called for progress reporting</param>
        /// <param name="maxNumOfCandidatesReturned">Optional parameter. 
        /// The number of top similar faces returned.
        /// The valid range is [1, 1000].It defaults to 20.</param>
        /// <param name="findMode">Optional parameter. 
        /// Similar face searching mode.It can be "matchPerson" or "matchFace". It defaults to "matchPerson".</param>
        public static void FindSimilar(string faceId, string[] faceIds, EventHandler<List<FindSimilarResults>> completed, EventHandler<ProgressChangedEventArgs> progressChanged = null, int maxNumOfCandidatesReturned = 20, FindSimilarMode findMode = FindSimilarMode.matchPerson)
        {
            var operation = new FindSimilarOperation(faceId, faceIds, maxNumOfCandidatesReturned, findMode);
            ExecuteOperationAsync(operation, completed, progressChanged);
        }


        public static void FindSimilar(string faceId, string faceListId, EventHandler<List<FindSimilarResults>> completed, EventHandler<ProgressChangedEventArgs> progressChanged = null, int maxNumOfCandidatesReturned = 20, FindSimilarMode findMode = FindSimilarMode.matchPerson)
        {
            var operation = new FindSimilarOperation(faceId, faceListId, false, maxNumOfCandidatesReturned, findMode);
            ExecuteOperationAsync(operation, completed, progressChanged);
        }

        public static void FindSimilarInLargeList(string faceId, string largeFaceListId, EventHandler<List<FindSimilarResults>> completed, EventHandler<ProgressChangedEventArgs> progressChanged = null, int maxNumOfCandidatesReturned = 20, FindSimilarMode findMode = FindSimilarMode.matchPerson)
        {
            var operation = new FindSimilarOperation(faceId, largeFaceListId, true, maxNumOfCandidatesReturned, findMode);
            ExecuteOperationAsync(operation, completed, progressChanged);
        }


        public static void Group(string[] faceIds, EventHandler<GroupResult> completed, EventHandler<ProgressChangedEventArgs> progressChanged = null)
        {
            var operation = new GroupOperation(faceIds);
            ExecuteOperationAsync(operation, completed, progressChanged);
        }

        public static void IdentifyInGroup(string[] faceIds, string groupId, EventHandler<IdentifyResult> completed, EventHandler<ProgressChangedEventArgs> progressChanged = null, int maxNumOfCandidatesReturned = 10, double confidenceThreshold = 0.5)
        {
            var operation = new IdentifyOperation(faceIds, groupId, false, maxNumOfCandidatesReturned, confidenceThreshold);
            ExecuteOperationAsync(operation, completed, progressChanged);
        }

        public static void IdentifyInLargeGroup(string[] faceIds, string largeGroupId, EventHandler<IdentifyResult> completed, EventHandler<ProgressChangedEventArgs> progressChanged = null, int maxNumOfCandidatesReturned = 10, double confidenceThreshold = 0.5)
        {
            var operation = new IdentifyOperation(faceIds, largeGroupId, true, maxNumOfCandidatesReturned, confidenceThreshold);
            ExecuteOperationAsync(operation, completed, progressChanged);
        }

        public static void Verify(string originalFaceId, string toMatchFaceId, EventHandler<FaceVerifyResult> completed, EventHandler<ProgressChangedEventArgs> progressChanged = null)
        {
            var operation = new FaceVerifyOperation(originalFaceId, toMatchFaceId);
            ExecuteOperationAsync(operation, completed, progressChanged);
        }

        public static void VerifyInGroup(string faceId, string personId, string personGroupId, EventHandler<FaceVerifyResult> completed, EventHandler<ProgressChangedEventArgs> progressChanged = null)
        {
            var operation = new FaceVerifyOperation(faceId, personId, personGroupId);
            ExecuteOperationAsync(operation, completed, progressChanged);
        }

        public static void VerifyInLargeGroup(string faceId, string personId, string largePersonGroupId, EventHandler<FaceVerifyResult> completed, EventHandler<ProgressChangedEventArgs> progressChanged = null)
        {
            var operation = new FaceVerifyOperation(faceId, personId, largePersonGroupId, true);
            ExecuteOperationAsync(operation, completed, progressChanged);
        }

        public static void DeleteFromList(string faceListId, string persistedFaceId, EventHandler<string> completed, EventHandler<ProgressChangedEventArgs> progressChanged = null)
        {
            FaceList.DeleteFace(faceListId, persistedFaceId, completed, progressChanged);
        }

        public static void AddToList(string pictureUrl, string faceListId, EventHandler<AddFaceResult> completed, EventHandler<ProgressChangedEventArgs> progressChanged = null, string userData = "", string targetFace = "")
        {
            FaceList.AddFace(pictureUrl, faceListId, completed, progressChanged, userData, targetFace);
        }
        public static void AddToList(byte[] picture, string faceListId, EventHandler<AddFaceResult> completed, EventHandler<ProgressChangedEventArgs> progressChanged = null, string userData = "", string targetFace = "")
        {
            FaceList.AddFace(picture, faceListId, completed, progressChanged, userData, targetFace);
        }

        public static void AddToLargeList(string pictureUrl, string largeListId, EventHandler<FaceId.LargeFaceList.AddFace.Result.AddFaceResult> completed, EventHandler<ProgressChangedEventArgs> progressChanged = null, string userData = "", string targetFace = "")
        {
            LargeFaceList.AddFace(pictureUrl, largeListId, completed, progressChanged, userData, targetFace);
        }

        public static void AddToLargeList(byte[] picture, string largeListId, EventHandler<FaceId.LargeFaceList.AddFace.Result.AddFaceResult> completed, EventHandler<ProgressChangedEventArgs> progressChanged = null, string userData = "", string targetFace = "")
        {
            LargeFaceList.AddFace(picture, largeListId, completed, progressChanged, userData, targetFace);
        }

        public static void DetectAndVerify(string originalFacePictureUrl, string toMatchFacePictureUrl, EventHandler<FaceVerifyResult> completed, EventHandler<ProgressChangedEventArgs> progressChanged = null)
        {
            var detectionOperation = new FaceDetectionOperation(originalFacePictureUrl);
            detectionOperation.ProgressChanged += progressChanged;
            detectionOperation.ExecuteAsync();

            detectionOperation.OperationCompleted += (sender, e) =>
            {
                var operation = (IApiOperation)sender;

                if (operation.IsSuccedded)
                {
                    var detectionOperation2 = new FaceDetectionOperation(toMatchFacePictureUrl);
                    detectionOperation2.ProgressChanged += progressChanged;
                    detectionOperation2.ExecuteAsync();
                    detectionOperation2.OperationCompleted += (sender2, e2) =>
                    {
                        var operation2 = (IApiOperation)sender2;

                        if (operation.IsSuccedded)
                        {
                            var verifyOperation = new FaceVerifyOperation(e[0].FaceId, e2[0].FaceId);
                            verifyOperation.ProgressChanged += progressChanged;
                            verifyOperation.OperationCompleted += completed;

                            verifyOperation.ExecuteAsync();
                        }
                    };
                }
            };
        }

        public static void DetectAndVerify(byte[] originalFacePicture, byte[] toMatchFacePicture, EventHandler<FaceVerifyResult> completed, EventHandler<ProgressChangedEventArgs> progressChanged = null)
        {
            var detectionOperation = new FaceDetectionOperation(originalFacePicture);
            detectionOperation.ProgressChanged += progressChanged;
            detectionOperation.ExecuteAsync();

            detectionOperation.OperationCompleted += (sender, e) =>
            {
                var operation = (IApiOperation)sender;

                if (operation.IsSuccedded)
                {
                    var detectionOperation2 = new FaceDetectionOperation(toMatchFacePicture);
                    detectionOperation2.ProgressChanged += progressChanged;
                    detectionOperation2.ExecuteAsync();
                    detectionOperation2.OperationCompleted += (sender2, e2) =>
                    {
                        var operation2 = (IApiOperation)sender2;

                        if (operation.IsSuccedded)
                        {
                            var verifyOperation = new FaceVerifyOperation(e[0].FaceId, e2[0].FaceId);
                            verifyOperation.ProgressChanged += progressChanged;
                            verifyOperation.OperationCompleted += completed;

                            verifyOperation.ExecuteAsync();
                        }
                    };
                }
            };

        }
    }
}
