using System;
using System.Collections.Generic;
using System.Text;

namespace ProxiEdge.FaceId.FaceList.GetList.Result
{
    public class PersistedFace
    {
        public string PersistedFaceId { get; set; }
        public string UserData { get; set; }
    }

    public class GetListResult
    {
        public string FaceListId { get; set; }
        public string Name { get; set; }
        public string UserData { get; set; }
        public List<PersistedFace> PersistedFaces { get; set; }
    }
}
