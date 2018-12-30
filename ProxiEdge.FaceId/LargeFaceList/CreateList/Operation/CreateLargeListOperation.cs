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

        protected override string QueryString => string.Format("/{0}",FaceListId); 

        protected override string JSON => CreateListParameter.ToJson(); 

        protected override string Operation => LargeFaceListOperation.largefacelists.ToString(); 

        protected override string HttpMethod => System.Net.Http.HttpMethod.Put.Method; 



        protected override byte[] Data => throw new NotImplementedException();
    }
}
