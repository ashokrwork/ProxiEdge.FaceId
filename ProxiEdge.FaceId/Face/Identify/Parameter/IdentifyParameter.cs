using ProxiEdge.FaceId.Base;

namespace ProxiEdge.FaceId.Face.Identify.Parameter
{
    internal class IdentifyParameter : ApiParameterBase
    {
        /// <summary>
        /// Array of query faces faceIds, created by the Face - Detect. 
        /// Each of the faces are identified independently. 
        /// The valid number of faceIds is between [1, 10].
        /// </summary>
        public string[] FaceIds { get; set; }
        /// <summary>
        /// PersonGroupId of the target person group, created by PersonGroup - Create. 
        /// Parameter personGroupId and largePersonGroupId should not be provided at the same time.
        /// </summary>
        public string PersonGroupId { get; set; }
        /// <summary>
        /// LargePersonGroupId of the target large person group, created by LargePersonGroup - Create. 
        /// Parameter personGroupId and largePersonGroupId should not be provided at the same time.
        /// </summary>
        public string LargePersonGroupId { get; set; }
        /// <summary>
        /// The range of maxNumOfCandidatesReturned is between 1 and 100 (default is 10).
        /// </summary>
        public int MaxNumOfCandidatesReturned { get; set; }
        /// <summary>
        /// Customized identification confidence threshold, in the range of [0, 1]. 
        /// Advanced user can tweak this value to override default internal threshold for better precision on their scenario data. 
        /// Note there is no guarantee of this threshold value working on other data and after algorithm updates.
        /// </summary>
        public double ConfidenceThreshold { get; set; }
    }
}
