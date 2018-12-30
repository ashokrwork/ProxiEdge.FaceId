using ProxiEdge.FaceId.Base;
using ProxiEdge.FaceId.LargeFaceList.LargeFaceListUpdate.Parameter;
using System;

namespace ProxiEdge.FaceId.LargeFaceList.LargeFaceListUpdate.Operation
{
    public class LargeFaceListUpdateOperation : FaceIdApiOperation<string>
    {
        string LargeListId;
        LargeFaceListUpdateParameter Parameter;

        public LargeFaceListUpdateOperation(string largeListId,string name,string userData = "")
        {
            LargeListId = largeListId;
            Parameter = new LargeFaceListUpdateParameter { Name = name,UserData = userData };
        }

        protected override string QueryString => string.Format("/{0}", LargeListId);

        protected override byte[] Data => throw new NotImplementedException();

        protected override string JSON => Parameter.ToJson();

        protected override string EndPoint => FaceListEndPoint.largefacelists.ToString();

        protected override string HttpMethod => "PATCH" ;
    }
}
