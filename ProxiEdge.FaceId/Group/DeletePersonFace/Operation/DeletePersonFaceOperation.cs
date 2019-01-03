using ProxiEdge.FaceId.Base;
using System;

namespace ProxiEdge.FaceId.Group.DeletePersonFace.Operation
{
    public class DeletePersonFaceOperation : FaceIdApiOperation<string>
    {
        bool IsLargeGroup;
        string GroupId;
        string PersonId;
        string PersistedFaceId;

        public DeletePersonFaceOperation(string groupId,string personId,string persistedFaceId,bool isLargeGroup = false)
        {
            GroupId = groupId;
            PersonId = personId;
            PersistedFaceId = persistedFaceId;
            IsLargeGroup = isLargeGroup;
        }

        protected override string QueryString => string.Format("/{0}/persons/{1}/persistedfaces/{2}", GroupId,PersonId,PersistedFaceId);

        protected override string HttpMethod => System.Net.Http.HttpMethod.Delete.Method;

        protected override byte[] Data => throw new NotImplementedException();

        protected override string JSON => "";

        protected override string EndPoint => IsLargeGroup?GroupEndPoint.largepersongroups.ToString() : GroupEndPoint.persongroups.ToString();
    }
}
