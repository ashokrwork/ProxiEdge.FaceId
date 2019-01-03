using ProxiEdge.FaceId.Base;
using ProxiEdge.FaceId.Group.CreatePerson.Parameter;
using ProxiEdge.FaceId.Group.CreatePerson.Result;
using System;

namespace ProxiEdge.FaceId.Group.CreatePerson.Operation
{
    public class CreatePersonOperation : FaceIdApiOperation<CreatePersonResult>
    {
        CreatePersonParameter Parameter;
        string GroupId;
        bool IsLargeGroup;

        public CreatePersonOperation(string groupId,string name, bool isLargeGroup = false, string userData = "")
        {
            Parameter = new CreatePersonParameter() { Name = name, UserData = userData };
            IsLargeGroup = isLargeGroup;
            GroupId = groupId;
        }

        protected override string QueryString => string.Format("/{0}/persons", GroupId);

        protected override byte[] Data => throw new NotImplementedException();

        protected override string JSON => Parameter.ToJson();

        protected override string EndPoint => IsLargeGroup? GroupEndPoint.largepersongroups.ToString() : GroupEndPoint.persongroups.ToString();
    }
}
