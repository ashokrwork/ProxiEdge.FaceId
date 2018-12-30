using ProxiEdge.FaceId.Base;
using ProxiEdge.FaceId.LargeFaceList.GetAllLargeListFaces.Result;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProxiEdge.FaceId.LargeFaceList.GetAllLargeListFaces.Operation
{
    class GetAllLargeListFacesOperation : FaceIdApiOperation<List<GetAllLargeListFacesResult>>
    {
        public string LargeListId;
        public string Start;
        public int Top;

        public GetAllLargeListFacesOperation(string largeListId,string start = "",int top = 1000)
        {
            LargeListId = largeListId;
            Start = start;
            Top = top;
        }

        protected override string QueryString => string.Format("/{0}/persistedfaces?start={1}&top={2}", LargeListId, Start, Top.ToString());

        protected override string HttpMethod => System.Net.Http.HttpMethod.Get.Method;

        protected override byte[] Data => null;

        protected override string JSON => "";

        protected override string Operation => LargeFaceListOperation.largefacelists.ToString();
    }
}
