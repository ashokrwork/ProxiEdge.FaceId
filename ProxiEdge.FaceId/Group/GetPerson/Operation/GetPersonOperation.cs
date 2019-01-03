using ProxiEdge.FaceId.Base;
using ProxiEdge.FaceId.Group.GetPerson.Result;
using System;

namespace ProxiEdge.FaceId.Group.GetPerson.Operation
{
    public class GetPersonOperation : FaceIdApiOperation<GetPersonResult>
    {
        bool IsLargeGroup;
        string GroupId;
        string PersonId;

        public GetPersonOperation(string groupId,string personId,bool isLargeGroup = false)
        {
            GroupId = groupId;
            PersonId = personId;
            IsLargeGroup = isLargeGroup;
        }

        protected override string HttpMethod => System.Net.Http.HttpMethod.Get.ToString();

        protected override string QueryString => string.Format("/{0}/persons/{1}",GroupId,PersonId);

        protected override byte[] Data => throw new NotImplementedException();

        protected override string JSON => "";

        protected override string EndPoint => IsLargeGroup ? GroupEndPoint.largepersongroups.ToString() : GroupEndPoint.persongroups.ToString();
    }
}
