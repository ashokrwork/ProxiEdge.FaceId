using ProxiEdge.FaceId.Base;
using System;
using System.ComponentModel;

namespace ProxiEdge.FaceId.API
{
   public class APIBase
    {
        internal static void ExecuteOperation<T>(FaceIdApiOperation<T> operation, EventHandler<T> completed, EventHandler<ProgressChangedEventArgs> progressChanged)
        {
            operation.OperationCompleted += completed;
            operation.ProgressChanged += progressChanged;
            operation.Execute();
        }
    }
}
