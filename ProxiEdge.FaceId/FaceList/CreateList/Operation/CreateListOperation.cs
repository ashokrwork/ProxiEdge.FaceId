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

        protected override string QueryString => string.Format("/{0}",FaceListId); 

        protected override string JSON => CreateListParameter.ToJson(); 

        protected override string EndPoint => FaceListEndPoint.facelists.ToString(); 

        protected override string HttpMethod => System.Net.Http.HttpMethod.Put.Method; 



        protected override byte[] Data => null;
    }
}
