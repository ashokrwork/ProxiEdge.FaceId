using Newtonsoft.Json;
using ProxiEdge.FaceId.Configurations;
using System.Text;

namespace ProxiEdge.FaceId.Base
{
    /// <summary>
    /// Used as base class for any API parameter
    /// </summary>
    internal class ApiParameterBase
    {
        /// <summary>
        /// Converts the current parameter to byte[]
        /// </summary>
        /// <returns></returns>
        public byte[] ToByteArray()
        {
            var json = JsonConvert.SerializeObject(this, Formatting.None, new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore });
            return Encoding.UTF8.GetBytes(json);
        }
        /// <summary>
        /// Converts the current parameter to JSON string
        /// </summary>
        /// <returns></returns>
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.None, FaceApiConfig.JsonSettings);
        }
    }
}
