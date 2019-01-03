using ProxiEdge.FaceId.Base;
using ProxiEdge.FaceId.Group.AddFace.Parameter;
using ProxiEdge.FaceId.Person.AddFace.Result;

namespace ProxiEdge.FaceId.Group.AddFace.Operation
{
    public class PersonAddFaceOperation : FaceIdApiOperation<PersonAddFaceResult>
    {
        bool UsePictureUrl;
        string GroupId;
        bool IsLargeGroup;
        string PersonId;
        byte[] Picture;
        PersonAddFaceParameter Parameter;
        string UserData;
        string TargetFace;

        public PersonAddFaceOperation(string pictureUrl,string groupId,string personId,bool isLargeGroup = false,string userData = "",string targetFace = "")
        {
            GroupId = groupId;
            isLargeGroup = IsLargeGroup;
            PersonId = personId;
            Parameter = new PersonAddFaceParameter() { Url = pictureUrl };
            UsePictureUrl = true;
            UserData = userData;
            TargetFace = targetFace;
        }

        public PersonAddFaceOperation(byte[] picture, string groupId, string personId, bool isLargeGroup = false, string userData = "", string targetFace = "")
        {
            GroupId = groupId;
            isLargeGroup = IsLargeGroup;
            PersonId = personId;
            Picture = picture;
            
            UserData = userData;
            TargetFace = targetFace;
        }

        protected override string QueryString => string.Format("/{0}/persons/{1}/persistedfaces?userData={2}&targetFace={3}",new object[] { GroupId, PersonId, UserData, TargetFace });

        protected override string ContentType => UsePictureUrl? WebClientContentType.Json : WebClientContentType.Binary;

        protected override byte[] Data => Picture;

        protected override string JSON => Parameter.ToJson();

        protected override string EndPoint => IsLargeGroup ? GroupEndPoint.largepersongroups.ToString() : GroupEndPoint.persongroups.ToString();
    }
}
