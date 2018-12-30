using ProxiEdge.FaceId.Base;
using ProxiEdge.FaceId.Group.Create.Parameter;
using System;

namespace ProxiEdge.FaceId.Group.Create.Operation
{
    public class CreateGroupOperation : FaceIdApiOperation<string>
    {
        CreateGroupParameter parameter;
        string GroupId;
        bool IsLargeGroup;

        public CreateGroupOperation(string groupId,string groupName,string userData,bool isLargeGroup = false)
        {
            parameter = new CreateGroupParameter() { Name = groupName, UserData = userData };
            GroupId = groupId;
            IsLargeGroup = isLargeGroup;
        }

        protected override string QueryString => string.Format("/{0}", GroupId);

        protected override byte[] Data => throw new NotImplementedException();

        protected override string JSON => parameter.ToJson();

        protected override string EndPoint => IsLargeGroup ? GroupEndPoint.largepersongroups.ToString() : GroupEndPoint.persongroups.ToString();

        protected override string HttpMethod => System.Net.Http.HttpMethod.Put.Method;
    }
}
