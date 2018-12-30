using ProxiEdge.FaceId.Base;
using ProxiEdge.FaceId.FaceList.GetAllLists.Result;
using System;
using System.Collections.Generic;

namespace ProxiEdge.FaceId.FaceList.GetAllLists.Operation
{
    public class GetAllListsOperation : FaceIdApiOperation<List<GetAllListsResult>>
    {
       

        public GetAllListsOperation()
        {
           
        }

        protected override byte[] Data => throw new NotImplementedException();

        protected override string JSON => string.Empty; 

        protected override string Operation => FaceListOperation.facelists.ToString(); 

        protected override string HttpMethod => System.Net.Http.HttpMethod.Get.Method; 
    }
}
