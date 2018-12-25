using Newtonsoft.Json;
using ProxiEdge.FaceId.Json;
using ProxiEdge.FaceId.Results;
using System;
using System.Net;
using System.Text;

namespace ProxiEdge.FaceId
{
    public class FaceIdService
    {
        private string EndPointUrl { get; set; }
        private string ApiKey { get; set; }

        public event EventHandler<UploadProgressChangedEventArgs> ProgressChanged;
        public event EventHandler<FaceDetectionResults> DetectionCompleted;
        public event EventHandler<FindSimilarResults> FindSimilarCompleted;
        public event EventHandler<FaceVerifyResults> VerificationCompleted;
        
        public FaceIdService(FaceIdEndPoint endPoint,string apiKey)
        {
            EndPointUrl = string.Format("https://{0}.api.cognitive.microsoft.com/face/v1.0",endPoint.ToString());
            ApiKey = apiKey;
        }

        private WebClient GetClient(string contentType)
        {
            var client = new WebClient();

            client.Headers.Add("Ocp-Apim-Subscription-Key", ApiKey);
            client.Headers.Add(HttpRequestHeader.ContentType, contentType);

            client.UploadProgressChanged += Client_ProgressChanged;
            

            return client;
        }

        #region Similar

        public void FindSimilar(string detectedFaceId, string targetFaceListId, int maxNumberToReturn = 20, FindSimilarMode findMode = FindSimilarMode.matchPerson)
        {
            var url = new Uri(string.Format("{0}/{1}", EndPointUrl, FaceIdOperation.findsimilars.ToString()));

            using (var client = GetClient(WebClientContentType.Json))
            {
                client.UploadDataCompleted += Client_FindSimilarCompleted;
                client.UploadDataAsync(url, new FindSimilarParameter() { faceId = detectedFaceId,faceListId = targetFaceListId,maxNumOfCandidatesReturned = maxNumberToReturn, mode = findMode.ToString()}.ToByteArray());
            }
        }

        private void Client_FindSimilarCompleted(object sender, UploadDataCompletedEventArgs e)
        {
            var results = PrepareResults(e, new FindSimilarResults());
            FindSimilarCompleted?.Invoke(this, (FindSimilarResults)results);
        }

        #endregion

        #region Verify

        public void Verify(string originalFaceId,string matchedFaceId)
        {
            var url = new Uri(string.Format("{0}/{1}", EndPointUrl, FaceIdOperation.verify.ToString()));

            using (var client = GetClient(WebClientContentType.Json))
            {
                client.UploadDataCompleted += Client_VerificationCompleted; 
                client.UploadDataAsync(url, new FaceToFaceVerifyParameter() { faceId1 = originalFaceId,faceId2=matchedFaceId }.ToByteArray());
            }
        }

        private void Client_VerificationCompleted(object sender, UploadDataCompletedEventArgs e)
        {
            var results = PrepareResults(e, new FaceVerifyResults());

            VerificationCompleted?.Invoke(this, (FaceVerifyResults)results);
        }

        #endregion

        #region Detection
        public void DetectFaces(string pictureUrl,bool returnFaceId = true, bool returnFaceLandmarks = false, string returnFaceAttributes = "")
        {
            var url = new Uri(string.Format("{0}/{1}?returnFaceId={2}&returnFaceLandmarks={3}&returnFaceAttributes={4}",
                new object[] { EndPointUrl, FaceIdOperation.detect.ToString(), returnFaceId.ToString().ToLower(), returnFaceLandmarks.ToString().ToLower(), returnFaceAttributes }));

            using (var client = GetClient(WebClientContentType.Json))
            {
                client.UploadDataCompleted += Client_DetectionCompleted;
                client.UploadDataAsync(url, new FaceDetectionParameter() { url = pictureUrl }.ToByteArray());
            }
        }

        public void DetectFaces(byte[] picture, bool returnFaceId = true, bool returnFaceLandmarks = false, string returnFaceAttributes = "")
        {
            var url = new Uri(string.Format("{0}/{1}?returnFaceId={2}&returnFaceLandmarks={3}&returnFaceAttributes={4}",
                new object[] { EndPointUrl, FaceIdOperation.detect.ToString(), returnFaceId.ToString().ToLower(), returnFaceLandmarks.ToString().ToLower(), returnFaceAttributes }));
            
            using (var client = GetClient(WebClientContentType.Binary))
            {
                client.UploadDataCompleted += Client_DetectionCompleted;
                client.UploadDataAsync(url, picture);
            }
        }
        #endregion

        #region Events
        private void Client_ProgressChanged(object sender, UploadProgressChangedEventArgs e)
        {
            ProgressChanged?.Invoke(this, e);
        }

        

        private void Client_DetectionCompleted(object sender, UploadDataCompletedEventArgs e)
        {
            var results = PrepareResults(e,new FaceDetectionResults());

            DetectionCompleted?.Invoke(this, (FaceDetectionResults)results);
        }

        private IApiResults<T> PrepareResults<T>(UploadDataCompletedEventArgs e, ApiResults<T> results) 
        {
            //var results = default(T);
            if (e.Error != null)
            {
                results.IsSuccedded = false;
                results.Error = e.Error;
            }
            else
            {
                results.IsSuccedded = true;
                var jsonResults = Encoding.UTF8.GetString(e.Result);
                results.Results = JsonConvert.DeserializeObject<T>(jsonResults);
            }

            return results;
        }

        #endregion
    }
}
