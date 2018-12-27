using ProxiEdge.FaceId.Base;
using ProxiEdge.FaceId.LargeFaceList.CreateList.Parameter;
using System;

namespace ProxiEdge.FaceId.LargeFaceList.CreateList.Operation
{
    public class CreateLargeListOperation : FaceIdApiOperation<string>
    {
        CreateLargeListParameter CreateListParameter;
        string FaceListId;

        public CreateLargeListOperation(string faceListId,string listName,string listDescription = "")
        {
            FaceListId = faceListId;
            CreateListParameter = new CreateLargeListParameter()
            {
                Name = listName,
                UserData = listDescription
            };
        }

        protected override string QueryString { get { return string.Format("/{0}",FaceListId); } }

        protected override string JSON { get { return CreateListParameter.ToJson(); } }

        protected override string Operation { get { return LargeFaceListOperation.largefacelists.ToString(); } }

        protected override string HttpMethod { get { return System.Net.Http.HttpMethod.Put.Method; } }



        protected override byte[] Data => throw new NotImplementedException();
    }
}
