using ProxiEdge.FaceId.Base;
using ProxiEdge.FaceId.Group.List.Group.Result;
using System;
using System.Collections.Generic;

namespace ProxiEdge.FaceId.Group.List.Group.Operation
{
    public class ListGroupOperation : FaceIdApiOperation<List<ListGroupResult>>
    {
        string Start;
        int Top;

        public ListGroupOperation(string start = "", int top = 1000)
        {
            Start = start;
            Top = top;
        }

        protected override string QueryString => string.Format("?start={0}&top={1}", Start, Top.ToString());

        protected override byte[] Data => throw new NotImplementedException();

        protected override string JSON => "";

        protected override string EndPoint => GroupEndPoint.persongroups.ToString();

        protected override string HttpMethod => System.Net.Http.HttpMethod.Get.Method;
    }
}
