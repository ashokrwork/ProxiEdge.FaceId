using ProxiEdge.FaceId.Base;
using ProxiEdge.FaceId.FaceList.UpdateList.Parameter;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProxiEdge.FaceId.FaceList.UpdateList.Operation
{
    public class UpdateListOperation : FaceIdApiOperation<string>
    {
        UpdateListParameter UpdateListParameter;
        string FaceListId;

        public UpdateListOperation(string faceListId, string listName, string listDescription = "")
        {
            FaceListId = faceListId;
            UpdateListParameter = new UpdateListParameter()
            {
                Name = listName,
                UserData = listDescription
            };
        }

        protected override string QueryString { get { return string.Format("/{0}", FaceListId); } }

        protected override string JSON { get { return UpdateListParameter.ToJson(); } }

        protected override string Operation { get { return FaceListOperation.facelists.ToString(); } }

        protected override string HttpMethod { get { return "PATCH"; } }



        protected override byte[] Data => throw new NotImplementedException();
    }
}
