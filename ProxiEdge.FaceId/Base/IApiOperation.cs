using System;
using System.Collections.Generic;
using System.Text;

namespace ProxiEdge.FaceId.Base
{
    public interface IApiOperation
    {
        bool IsSuccedded { get; set; }
        Exception Error { get; set; }
        bool IsExecuting { get;  }
    }
}
