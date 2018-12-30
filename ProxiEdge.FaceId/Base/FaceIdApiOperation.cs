using Newtonsoft.Json;
using ProxiEdge.FaceId.Configurations;
using System;
using System.ComponentModel;
using System.Net;
using System.Text;

namespace ProxiEdge.FaceId.Base
{
    public abstract class FaceIdApiOperation<T> : IDisposable
    {
        protected virtual string HttpMethod { get { return System.Net.Http.HttpMethod.Post.Method; } }
        protected virtual string ContentType { get { return WebClientContentType.Json; } }

        protected virtual string QueryString { get; }
        
        public bool IsSuccedded { get; set; }
        public Exception Error { get; set; }

        public T Results { get; set; }

        protected abstract byte[] Data { get; }

        protected abstract string JSON { get; }
        
        protected abstract string Operation { get; }

        private void PrepareDownloadStringResults(DownloadStringCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                IsSuccedded = false;
                Error = e.Error;
            }
            else
            {
                IsSuccedded = true;
                
                Results = JsonConvert.DeserializeObject<T>(e.Result);
            }
        }

        private void PrepareByteResults(UploadDataCompletedEventArgs e)
        {

            if (e.Error != null)
            {
                IsSuccedded = false;
                Error = e.Error;
            }
            else
            {
                IsSuccedded = true;
                var jsonResults = Encoding.UTF8.GetString(e.Result);
                Results = JsonConvert.DeserializeObject<T>(jsonResults);
            }


        }

        private void PrepareStringResults(UploadStringCompletedEventArgs e)
        {

            if (e.Error != null)
            {
                IsSuccedded = false;
                Error = e.Error;
            }
            else
            {
                IsSuccedded = true;
                
                Results = JsonConvert.DeserializeObject<T>(e.Result);
            }


        }


        public event EventHandler<ProgressChangedEventArgs> ProgressChanged;
        public event EventHandler<T> OperationCompleted;

        protected WebClient PrepareClient(string apiKey)
        {
            var client = new WebClient();

            client.Headers.Add("Ocp-Apim-Subscription-Key", apiKey);
            client.Headers.Add(HttpRequestHeader.ContentType, this.ContentType);

            client.UploadProgressChanged += Client_UploadProgressChanged;
            client.DownloadProgressChanged += Client_DownloadProgressChanged;

            client.UploadDataCompleted += Client_UploadDataCompleted;
            client.UploadStringCompleted += Client_UploadStringCompleted;

            client.DownloadStringCompleted += Client_DownloadStringCompleted; ;

            return client;
        }

        private void Client_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            ProgressChanged?.Invoke(this, e);
        }

        private void Client_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            PrepareDownloadStringResults(e);
            OperationCompleted?.Invoke(this, Results);
        }

        private void Client_UploadProgressChanged(object sender, UploadProgressChangedEventArgs e)
        {
            ProgressChanged?.Invoke(this, e);
        }

        public void Execute()
        {
            var config = FaceApiConfig.Get();

            Execute(config.EndPoint, config.ApiKey);
        }

        public void Execute(FaceIdEndPoint endPoint, string apiKey)
        {
            var url = new Uri(string.Format("https://{0}.api.cognitive.microsoft.com/face/v1.0/{1}{2}", endPoint.ToString(), Operation, QueryString));

            using (var client = PrepareClient(apiKey))
            {
                if (ContentType == WebClientContentType.Binary)
                {
                    client.UploadDataAsync(url, HttpMethod, Data);
                }
                else if(ContentType == WebClientContentType.Json)
                {
                    if (HttpMethod == "GET")
                    {
                        client.DownloadStringAsync(url);
                    }
                    else
                    {
                        client.UploadStringAsync(url, HttpMethod, JSON);
                    }
                }
            }
        }

        private void Client_UploadDataCompleted(object sender, UploadDataCompletedEventArgs e)
        {
            PrepareByteResults(e);

            OperationCompleted?.Invoke(this, Results);
        }

        private void Client_UploadStringCompleted(object sender, UploadStringCompletedEventArgs e)
        {
            PrepareStringResults(e);

            OperationCompleted?.Invoke(this, Results);
        }

        public virtual void Dispose()
        {
            
        }
    }
}
