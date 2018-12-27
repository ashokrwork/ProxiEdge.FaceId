# ProxiEdge.FaceId Library

This library is used as a wrapper for Microsoft Cognitive Service (Face Id).


# Sample Usage

```javascript
ProxiEdge.FaceId.Configurations.FaceApiConfig.Init(ProxiEdge.FaceId.Base.FaceIdEndPoint.eastasia, "[API Key]");

var proxiEdgeFaceDetectionOperation = new ProxiEdge.FaceId.Face.Detect.Operation.FaceDetectionOperation("[Photo Url]", true, true);

proxiEdgeFaceDetectionOperation.ProgressChanged += ProxiEdgeFaceDetectionOperation_ProgressChanged;
proxiEdgeFaceDetectionOperation.OperationCompleted += ProxiEdgeFaceDetectionOperation_OperationCompleted;

private void ProxiEdgeFaceDetectionOperation_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
{
    ShowProgress(e.ProgressPercentage);
}

private void ShowProgress(int progressPercentage) {}

private void ProxiEdgeFaceDetectionOperation_OperationCompleted(object sender, System.Collections.Generic.List<ProxiEdge.FaceId.Face.Detect.Result.FaceDetectionResult> e)
 {
   ProxiEdge.FaceId.Face.Detect.Operation.FaceDetectionOperation operation = (ProxiEdge.FaceId.Face.Detect.Operation.FaceDetectionOperation)sender;
    
    if(operation.IsSuccedded)
            {
                ShowResults(e);
            }
            else
            {
                HandleException(operation.Error);
            }
        }
        ```
