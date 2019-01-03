using System.Collections.Generic;

namespace ProxiEdge.FaceId.Group.ListPerson.Result
{
    public class ListPersonResult
    {
        public string PersonId { get; set; }
        public string Name { get; set; }
        public string UserData { get; set; }
        public List<string> PersistedFaceIds { get; set; }
    }
}
