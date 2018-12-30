using System;

namespace ProxiEdge.FaceId.Group.GetTrainingStatus.Result
{
    public class GetGroupTrainingStatusResult
    {
        public string Status { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public DateTime LastActionDateTime { get; set; }
        public string Message { get; set; }
    }
}
