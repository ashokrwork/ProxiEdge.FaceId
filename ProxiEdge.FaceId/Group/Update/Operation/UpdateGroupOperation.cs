using ProxiEdge.FaceId.Base;
using ProxiEdge.FaceId.Group.Update.Parameter;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProxiEdge.FaceId.Group.Update.Operation
{
    public class UpdateGroupOperation : FaceIdApiOperation<string>
    {
        UpdateGroupParameter Parameter;
        bool IsLargeGroup;
        string GroupId;

        public UpdateGroupOperation(string groupId,string name,string userData,bool isLargeGroup = false)
        {
            Parameter = new UpdateGroupParameter() { Name = name,UserData = userData };
            IsLargeGroup = isLargeGroup;
            GroupId = groupId;
        }

        protected override string QueryString => string.Format("/{0}",GroupId);

        protected override byte[] Data => throw new NotImplementedException();

        protected override string JSON => Parameter.ToJson();

        protected override string EndPoint => IsLargeGroup ? GroupEndPoint.largepersongroups.ToString() : GroupEndPoint.persongroups.ToString();

        protected override string HttpMethod => "PATCH";
    }
}
