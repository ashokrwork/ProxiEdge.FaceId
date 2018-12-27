using ProxiEdge.FaceId.Base;
using ProxiEdge.FaceId.FaceList.CreateList.Parameter;
using System;

namespace ProxiEdge.FaceId.FaceList.CreateList.Operation
{
    public class CreateListOperation : FaceIdApiOperation<string>
    {
        CreateListParameter CreateListParameter;
        string FaceListId;

        public CreateListOperation(string faceListId,string listName,string listDescription = "")
        {
            FaceListId = faceListId;
            CreateListParameter = new CreateListParameter()
            {
                Name = listName,
                UserData = listDescription
            };
        }

        protected override string QueryString { get { return string.Format("/{0}",FaceListId); } }

        protected override string JSON { get { return CreateListParameter.ToJson(); } }

        protected override string Operation { get { return FaceListOperation.facelists.ToString(); } }

        protected override string HttpMethod { get { return System.Net.Http.HttpMethod.Put.Method; } }



        protected override byte[] Data => throw new NotImplementedException();
    }
}
