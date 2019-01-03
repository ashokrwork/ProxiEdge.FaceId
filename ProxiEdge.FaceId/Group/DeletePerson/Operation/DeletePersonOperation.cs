using ProxiEdge.FaceId.Base;
using System;

namespace ProxiEdge.FaceId.Group.DeletePerson.Operation
{
    public class DeletePersonOperation : FaceIdApiOperation<string>
    {
        bool IsLargeGroup;
        string GroupId;
        string PersonId;

        public DeletePersonOperation(string groupId,string personId,bool isLargeGroup = false)
        {
            GroupId = groupId;
            PersonId = personId;
            IsLargeGroup = isLargeGroup;
        }

        protected override string QueryString => string.Format("/{0}/persons/{1}",GroupId,PersonId);

        protected override byte[] Data => throw new NotImplementedException();

        protected override string JSON => "";

        protected override string EndPoint => IsLargeGroup? GroupEndPoint.largepersongroups.ToString() : GroupEndPoint.persongroups.ToString();

        protected override string HttpMethod => System.Net.Http.HttpMethod.Delete.Method;
    }
}
