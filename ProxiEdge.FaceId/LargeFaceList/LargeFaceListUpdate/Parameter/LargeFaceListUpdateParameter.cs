using ProxiEdge.FaceId.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProxiEdge.FaceId.LargeFaceList.LargeFaceListUpdate.Parameter
{
    internal class LargeFaceListUpdateParameter : ApiParameterBase
    {
        internal string Name { get; set; }
        internal string UserData { get; set; }
    }
}
