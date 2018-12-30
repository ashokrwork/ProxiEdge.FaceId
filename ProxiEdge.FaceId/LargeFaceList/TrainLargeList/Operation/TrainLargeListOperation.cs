using ProxiEdge.FaceId.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProxiEdge.FaceId.LargeFaceList.TrainLargeList.Operation
{
    public class TrainLargeListOperation : FaceIdApiOperation<string>
    {
        public string LargeListId;

        public TrainLargeListOperation(string largeListId)
        {
            LargeListId = largeListId;
        }

        protected override string QueryString => string.Format("/{0}/train", LargeListId);

        protected override byte[] Data => throw new NotImplementedException();

        protected override string JSON => "";

        protected override string Operation => LargeFaceListOperation.largefacelists.ToString();
    }
}
