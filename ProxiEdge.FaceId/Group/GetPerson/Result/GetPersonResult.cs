using System;
using System.Collections.Generic;
using System.Text;

namespace ProxiEdge.FaceId.Group.GetPerson.Result
{
    public class GetPersonResult
    {
        public string PersonId { get; set; }
        public List<string> PersistedFaceIds { get; set; }
        public string Name { get; set; }
        public string UserData { get; set; }
    }
}
