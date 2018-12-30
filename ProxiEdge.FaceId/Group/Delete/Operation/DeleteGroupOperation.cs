using ProxiEdge.FaceId.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProxiEdge.FaceId.Group.Delete.Operation
{
    public class DeleteGroupOperation : FaceIdApiOperation<string>
    {
        bool IsLargeGroup;
        string GroupId;

        public DeleteGroupOperation(string groupId, bool isLargeGroup = false)
        {
            GroupId = groupId;
            IsLargeGroup = isLargeGroup;
        }

        protected override string QueryString => string.Format("/{0}", GroupId);

        protected override byte[] Data => throw new NotImplementedException();

        protected override string EndPoint => IsLargeGroup ? GroupEndPoint.largepersongroups.ToString() : GroupEndPoint.persongroups.ToString();

        protected override string HttpMethod => System.Net.Http.HttpMethod.Delete.Method;

        protected override string JSON => "";
    }
}
