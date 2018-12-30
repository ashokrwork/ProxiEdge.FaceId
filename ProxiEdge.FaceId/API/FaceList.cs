using ProxiEdge.FaceId.Base;
using ProxiEdge.FaceId.Face.FindSimilar.Result;
using ProxiEdge.FaceId.FaceList.AddFace.Operation;
using ProxiEdge.FaceId.FaceList.AddFace.Result;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace ProxiEdge.FaceId.API
{
    public class FaceList : APIBase
    {
        public static void AddFace(string pictureUrl, string faceListId, EventHandler<AddFaceResult> completed, EventHandler<ProgressChangedEventArgs> progressChanged = null, string userData = "", string targetFace = "")
        {
            var operation = new AddFaceOperation(pictureUrl, faceListId, userData, targetFace);
            ExecuteOperation(operation, completed, progressChanged);
        }

        public static void AddFace(byte[] picture, string faceListId, EventHandler<AddFaceResult> completed, EventHandler<ProgressChangedEventArgs> progressChanged = null, string userData = "", string targetFace = "")
        {
            var operation = new AddFaceOperation(picture, faceListId, userData, targetFace);
            ExecuteOperation(operation, completed, progressChanged);
        }

        public static void FindFace(string faceId, string faceListId, EventHandler<List<FindSimilarResults>> completed, EventHandler<ProgressChangedEventArgs> progressChanged = null, bool useLargeList = false,  int maxNumOfCandidatesReturned = 20, FindSimilarMode findMode = FindSimilarMode.matchPerson)
        {
             Face.FindSimilarInList(faceId, faceListId, completed, progressChanged, maxNumOfCandidatesReturned, findMode);
        }

    }
}
