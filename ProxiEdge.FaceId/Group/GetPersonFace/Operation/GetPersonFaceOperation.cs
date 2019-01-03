using ProxiEdge.FaceId.Base;
using ProxiEdge.FaceId.Group.GetPersonFace.Result;
using System;

namespace ProxiEdge.FaceId.Group.GetPersonFace.Operation
{
    public class GetPersonFaceOperation : FaceIdApiOperation<GetPersonFaceResult>
    {
        bool IsLargeGroup;
        string GroupId;
        string PersonId;
        string PersistedFaceId;
        
        public GetPersonFaceOperation(string groupId,string personId,string persistedFaceId,bool isLargeGroup = false)
        {
            GroupId = groupId;
            PersonId = personId;
            PersistedFaceId = persistedFaceId;
            IsLargeGroup = isLargeGroup;
        }

        protected override string QueryString => string.Format("/{0}/persons/{1}/persistedfaces/{2}",GroupId,PersonId,PersistedFaceId);

        protected override string HttpMethod => System.Net.Http.HttpMethod.Get.ToString();

        protected override byte[] Data => throw new NotImplementedException();

        protected override string JSON => "";

        protected override string EndPoint => IsLargeGroup ? GroupEndPoint.largepersongroups.ToString() : GroupEndPoint.persongroups.ToString();
    }
}
