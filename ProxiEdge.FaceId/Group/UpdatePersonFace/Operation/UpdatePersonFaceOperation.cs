using ProxiEdge.FaceId.Base;
using ProxiEdge.FaceId.Group.UpdatePersonFace.Parameter;
using System;

namespace ProxiEdge.FaceId.Group.UpdatePersonFace.Operation
{
    public class UpdatePersonFaceOperation : FaceIdApiOperation<string>
    {
        UpdatePersonFaceParameter Parameter;
        bool IsLargeGroup;
        string GroupId;
        string PersonId;
        string FaceId;

        public UpdatePersonFaceOperation(string groupId, string personId,string faceId, string userData, bool isLargeGroup = false)
        {
            Parameter = new UpdatePersonFaceParameter() { UserData = userData };
            IsLargeGroup = isLargeGroup;
            GroupId = groupId;
            PersonId = personId;
            FaceId = faceId;
        }

        protected override string QueryString => string.Format("/{0}/persons/{1}/persistedfaces/{2}", GroupId, PersonId,FaceId);

        protected override byte[] Data => throw new NotImplementedException();

        protected override string JSON => Parameter.ToJson();

        protected override string EndPoint => IsLargeGroup ? GroupEndPoint.largepersongroups.ToString() : GroupEndPoint.persongroups.ToString();

        protected override string HttpMethod => "PATCH";
    }
}
