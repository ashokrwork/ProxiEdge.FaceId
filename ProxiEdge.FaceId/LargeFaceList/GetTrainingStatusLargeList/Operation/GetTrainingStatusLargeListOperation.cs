using ProxiEdge.FaceId.Base;
using ProxiEdge.FaceId.LargeFaceList.GetTrainingStatusLargeList.Result;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProxiEdge.FaceId.LargeFaceList.GetTrainingStatusLargeList.Operation
{
    public class GetTrainingStatusLargeListOperation : FaceIdApiOperation<GetTrainingStatusLargeListResult>
    {
        string LargeFaceListId;

        public GetTrainingStatusLargeListOperation(string largeFaceListId)
        {
            LargeFaceListId = largeFaceListId;
        }

        protected override string QueryString => string.Format("/{0}/training",LargeFaceListId);

        protected override byte[] Data => throw new NotImplementedException();

        protected override string JSON => "";

        protected override string Operation => LargeFaceListOperation.largefacelists.ToString();

        protected override string HttpMethod => System.Net.Http.HttpMethod.Get.ToString();
    }
}
