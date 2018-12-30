using ProxiEdge.FaceId.Base;
using System;

namespace ProxiEdge.FaceId.Group.Train.Operation
{
    public class TrainGroupOperation : FaceIdApiOperation<string>
    {
        bool IsLargeGroup;
        string GroupId;

        public TrainGroupOperation(string groupId,bool isLargeGroup = false)
        {
            IsLargeGroup = isLargeGroup;
            GroupId = groupId;
        }

        protected override string QueryString => string.Format("/{0}/train",GroupId);

        protected override byte[] Data => throw new NotImplementedException();

        protected override string JSON => "";

        protected override string EndPoint => IsLargeGroup ? GroupEndPoint.largepersongroups.ToString() : GroupEndPoint.persongroups.ToString();
    }
}
