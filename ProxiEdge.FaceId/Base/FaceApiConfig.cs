using Newtonsoft.Json;
using ProxiEdge.FaceId.Base;
using System;

namespace ProxiEdge.FaceId.Configurations
{
    public class FaceApiConfig
    {
        internal FaceIdEndPoint EndPoint { get; set; }
        internal string ApiKey { get; set; }

        private FaceApiConfig(FaceIdEndPoint endPoint, string apiKey)
        {
            EndPoint = endPoint;
            ApiKey = apiKey;
        }

        private static FaceApiConfig instance { get; set; }

        public static void Init(FaceIdEndPoint endPoint, string apiKey)
        {
            instance = new FaceApiConfig(endPoint, apiKey);
        }

        internal static FaceApiConfig Get()
        {
            if (instance != null)
                return instance;
            else
                throw new Exception("Configurations not initiated");
        }

        internal static JsonSerializerSettings JsonSettings => new JsonSerializerSettings()
        {
            NullValueHandling = NullValueHandling.Ignore,
            DateFormatHandling = DateFormatHandling.IsoDateFormat,
            DateTimeZoneHandling = DateTimeZoneHandling.Utc,
            DateParseHandling = DateParseHandling.DateTime,
            MissingMemberHandling = MissingMemberHandling.Ignore
        };
    }
}
