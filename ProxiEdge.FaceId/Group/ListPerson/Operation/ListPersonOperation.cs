using ProxiEdge.FaceId.Base;
using ProxiEdge.FaceId.Group.ListPerson.Result;
using System;
using System.Collections.Generic;

namespace ProxiEdge.FaceId.Group.ListPerson.Operation
{
    public class ListPersonOperation : FaceIdApiOperation<List<ListPersonResult>>
    {
        bool IsLargeGroup;
        string GroupId;
        string Start;
        int Top;

        public ListPersonOperation(string groupId,bool isLargeGroup = false,string start = "",int top = 1000)
        {
            GroupId = groupId;
            IsLargeGroup = isLargeGroup;
            Start = start;
            Top = top;
        }

        protected override string QueryString => string.Format("/{0}/persons?start={1}&top={2}",GroupId,Start,Top.ToString());

        protected override string HttpMethod => System.Net.Http.HttpMethod.Get.Method;

        protected override byte[] Data => throw new NotImplementedException();

        protected override string JSON => "";

        protected override string EndPoint => IsLargeGroup ? GroupEndPoint.largepersongroups.ToString() : GroupEndPoint.persongroups.ToString();
    }
}
