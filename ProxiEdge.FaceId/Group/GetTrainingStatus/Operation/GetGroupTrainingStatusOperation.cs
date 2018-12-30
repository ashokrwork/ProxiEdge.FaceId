using ProxiEdge.FaceId.Base;
using ProxiEdge.FaceId.Group.GetTrainingStatus.Result;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProxiEdge.FaceId.Group.GetTrainingStatus.Operation
{
    public class GetGroupTrainingStatusOperation : FaceIdApiOperation<GetGroupTrainingStatusResult>
    {
        bool IsLargeGroup;
        string GroupId;

        public GetGroupTrainingStatusOperation(string groupId, bool isLargeGroup = false)
        {
            GroupId = groupId;
            IsLargeGroup = isLargeGroup;
        }

        protected override string QueryString => string.Format("/{0}/training", GroupId);

        protected override byte[] Data => throw new NotImplementedException();

        protected override string EndPoint => IsLargeGroup ? GroupEndPoint.largepersongroups.ToString() : GroupEndPoint.persongroups.ToString();

        protected override string HttpMethod => System.Net.Http.HttpMethod.Get.Method;

        protected override string JSON => "";
    }
}
