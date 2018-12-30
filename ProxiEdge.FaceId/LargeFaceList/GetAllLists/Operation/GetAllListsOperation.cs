using ProxiEdge.FaceId.Base;
using ProxiEdge.FaceId.LargeFaceList.GetAllLists.Result;
using System.Collections.Generic;

namespace ProxiEdge.FaceId.LargeFaceList.GetAllLists.Operation
{
    public class GetAllLargeListsOperation : FaceIdApiOperation<List<GetAllLargeListsResult>>
    {
        public string Start;
        public int Top;

        public GetAllLargeListsOperation(string start = "",int top = 1000)
        {
            Start = start;
            Top = top;
        }

        protected override string QueryString => string.Format("?start={0}&top={1}", Start, Top.ToString());

        protected override byte[] Data => null;

        protected override string JSON => "";

        protected override string EndPoint => FaceListEndPoint.largefacelists.ToString();

        protected override string HttpMethod => System.Net.Http.HttpMethod.Get.Method;
    }
}
