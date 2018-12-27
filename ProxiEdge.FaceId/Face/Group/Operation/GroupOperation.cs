using ProxiEdge.FaceId.Base;
using ProxiEdge.FaceId.Face.Group.Parameter;
using ProxiEdge.FaceId.Face.Group.Result;

namespace ProxiEdge.FaceId.Face.Group.Operation
{
    public class GroupOperation : FaceIdApiOperation<GroupResult>
    {
        GroupParameter groupClassificationParameter;

        public GroupOperation(string[] faceIds)
        {
            groupClassificationParameter = new GroupParameter() { FaceIds = faceIds };
        }

        protected override byte[] Data {
            get
            {
                return groupClassificationParameter.ToByteArray();
            }
        }

        protected override string Operation { get { return FaceOperation.group.ToString(); } }

        protected override string JSON
        {
            get
            {
                return groupClassificationParameter.ToJson();
            }
        }
    }
}
