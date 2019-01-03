using ProxiEdge.FaceId.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProxiEdge.FaceId.Group.UpdatePerson.Parameter
{
    internal class UpdatePersonParameter : ApiParameterBase
    {
        public string Name { get; set; }
        public string UserData { get; set; }
    }
}
