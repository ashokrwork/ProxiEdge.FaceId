using ProxiEdge.FaceId.Base;
using ProxiEdge.FaceId.Group.UpdatePerson.Parameter;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProxiEdge.FaceId.Group.UpdatePerson.Operation
{
    public class UpdatePersonOperation : FaceIdApiOperation<string>
    {
        UpdatePersonParameter Parameter;
        bool IsLargeGroup;
        string GroupId;
        string PersonId;

        public UpdatePersonOperation(string groupId,string personId,string name,string userData,bool isLargeGroup = false)
        {
            Parameter = new UpdatePersonParameter() { Name = name,UserData = userData };
            IsLargeGroup = isLargeGroup;
            GroupId = groupId;
            PersonId = personId;
        }

        protected override string QueryString => string.Format("/{0}/persons/{1}",GroupId,PersonId);

        protected override byte[] Data => throw new NotImplementedException();

        protected override string JSON => Parameter.ToJson();

        protected override string EndPoint => IsLargeGroup ? GroupEndPoint.largepersongroups.ToString() : GroupEndPoint.persongroups.ToString();

        protected override string HttpMethod => "PATCH";
    }
}
