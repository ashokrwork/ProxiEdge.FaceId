using Newtonsoft.Json;
using ProxiEdge.FaceId.Configurations;
using System;
using System.ComponentModel;
using System.Net;
using System.Text;

namespace ProxiEdge.FaceId.Base
{
    public abstract class FaceIdApiOperation<T> : IDisposable, IApiOperation
    {
        protected virtual string HttpMethod { get { return System.Net.Http.HttpMethod.Post.Method; } }
        protected virtual string ContentType { get { return WebClientContentType.Json; } }

        protected virtual string QueryString { get; }
        
        

        public T Results { get; set; }

        protected abstract byte[] Data { get; }

        protected abstract string JSON { get; }
        
        protected abstract string EndPoint { get; }

        public bool IsSuccedded { get; set; }
        public Exception Error { get; set; }
        public bool IsExecuting { get; private set; }

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

        

        private void SetResults(string results)
        {
            IsSuccedded = true;
            Results = JsonConvert.DeserializeObject<T>(results, FaceApiConfig.JsonSettings);
        }

        private void PrepareResults(UploadDataCompletedEventArgs e)
        {

            if (e.Error != null)
            {
                IsSuccedded = false;
                Error = e.Error;
            }
            else
            {
                SetResults(Encoding.UTF8.GetString(e.Result));
            }

        }

        private void PrepareResults(UploadStringCompletedEventArgs e)
        {

            if (e.Error != null)
            {
                IsSuccedded = false;
                Error = e.Error;
            }
            else
            {
                SetResults(e.Result);
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

        public void Execute()
        {
            IsExecuting = true;

            var config = FaceApiConfig.Get();

            Execute(config.EndPoint, config.ApiKey);
        }

        public void Execute(FaceIdEndPoint endPoint, string apiKey)
        {
            IsExecuting = true;

            var url = new Uri(string.Format("https://{0}.api.cognitive.microsoft.com/face/v1.0/{1}{2}", endPoint.ToString(), EndPoint, QueryString));

            using (var client = PrepareClient(apiKey))
            {
                if (ContentType == WebClientContentType.Binary)
                {
                    client.UploadDataAsync(url, HttpMethod, Data);
                }
                else if (ContentType == WebClientContentType.Json)
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

        private void Client_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            ProgressChanged?.Invoke(this, e);
        }
        

        private void Client_UploadProgressChanged(object sender, UploadProgressChangedEventArgs e)
        {
            ProgressChanged?.Invoke(this, e);
        }

        

        private void Client_UploadDataCompleted(object sender, UploadDataCompletedEventArgs e)
        {
            IsExecuting = false;

            PrepareResults(e);

            OperationCompleted?.Invoke(this, Results);
        }

        private void Client_UploadStringCompleted(object sender, UploadStringCompletedEventArgs e)
        {
            IsExecuting = false;

            PrepareResults(e);

            OperationCompleted?.Invoke(this, Results);
        }

        private void Client_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            IsExecuting = false;

            PrepareDownloadStringResults(e);
            OperationCompleted?.Invoke(this, Results);
        }

        public virtual void Dispose()
        {
            
        }
    }
}
