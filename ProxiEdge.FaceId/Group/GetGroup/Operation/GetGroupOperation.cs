using ProxiEdge.FaceId.Base;
using ProxiEdge.FaceId.Group.GetGroup.Result;
using System;

namespace ProxiEdge.FaceId.Group.GetGroup.Operation
{
    public class GetGroupOperation : FaceIdApiOperation<GetGroupResult>
    {
        bool IsLargeGroup;
        string GroupId;

        public GetGroupOperation(string groupId, bool isLargeGroup = false)
        {
            GroupId = groupId;
            IsLargeGroup = isLargeGroup;
        }

        protected override string QueryString => string.Format("/{0}", GroupId);

        protected override byte[] Data => throw new NotImplementedException();

        protected override string EndPoint => IsLargeGroup ? GroupEndPoint.largepersongroups.ToString() : GroupEndPoint.persongroups.ToString();

        protected override string HttpMethod => System.Net.Http.HttpMethod.Get.Method;

        protected override string JSON => "";
    }
}
