using ProxiEdge.FaceId.Base;
using ProxiEdge.FaceId.Face.FindSimilar.Result;
using ProxiEdge.FaceId.LargeFaceList.AddFace.Operation;
using ProxiEdge.FaceId.LargeFaceList.AddFace.Result;
using ProxiEdge.FaceId.LargeFaceList.CreateList.Operation;
using ProxiEdge.FaceId.LargeFaceList.DeleteFace.Operation;
using ProxiEdge.FaceId.LargeFaceList.DeleteList.Operation;
using ProxiEdge.FaceId.LargeFaceList.GetAllLargeListFaces.Operation;
using ProxiEdge.FaceId.LargeFaceList.GetAllLargeListFaces.Result;
using ProxiEdge.FaceId.LargeFaceList.GetAllLists.Operation;
using ProxiEdge.FaceId.LargeFaceList.GetAllLists.Result;
using ProxiEdge.FaceId.LargeFaceList.GetLargeList.Operation;
using ProxiEdge.FaceId.LargeFaceList.GetLargeList.Result;
using ProxiEdge.FaceId.LargeFaceList.GetTrainingStatusLargeList.Operation;
using ProxiEdge.FaceId.LargeFaceList.GetTrainingStatusLargeList.Result;
using ProxiEdge.FaceId.LargeFaceList.LargeFaceListUpdate.Operation;
using ProxiEdge.FaceId.LargeFaceList.LargeFaceListUpdateFace.Operation;
using ProxiEdge.FaceId.LargeFaceList.TrainLargeList.Operation;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace ProxiEdge.FaceId.API
{
    public class LargeFaceList : APIBase
    {

        public static void Create(string listId, string listName, EventHandler<string> completed, EventHandler<ProgressChangedEventArgs> progressChanged = null, string listDescription = "")
        {
            var operation = new CreateLargeListOperation(listId, listName, listDescription);
            ExecuteOperation(operation, completed, progressChanged);
        }

        public static void Get(string listId, EventHandler<GetLargeListResult> completed, EventHandler<ProgressChangedEventArgs> progressChanged = null)
        {
            var operation = new GetLargeListOperation(listId);
            ExecuteOperation(operation, completed, progressChanged);
        }

        public static void GetAll(EventHandler<List<GetAllLargeListsResult>> completed, EventHandler<ProgressChangedEventArgs> progressChanged = null,string start = "",int top =1000)
        {
            var operation = new GetAllLargeListsOperation(start,top);
            ExecuteOperation(operation, completed, progressChanged);
        }

        public static void Update(string listId, string listName, EventHandler<string> completed, EventHandler<ProgressChangedEventArgs> progressChanged = null, string listDescription = "")
        {
            var operation = new LargeFaceListUpdateOperation(listId, listName, listDescription);
            ExecuteOperation(operation, completed, progressChanged);
        }

        public static void UpdateFace(string listId, string persistedFaceId, string userData, EventHandler<string> completed, EventHandler<ProgressChangedEventArgs> progressChanged = null)
        {
            var operation = new LargeFaceListUpdateFaceOperation(listId, persistedFaceId, userData);
            ExecuteOperation(operation, completed, progressChanged);
        }

        public static void Delete(string listId, EventHandler<string> completed, EventHandler<ProgressChangedEventArgs> progressChanged = null)
        {
            var operation = new DeleteLargeListOperation(listId);
            ExecuteOperation(operation, completed, progressChanged);
        }

        public static void DeleteFace(string listId, string persistedFaceId, EventHandler<string> completed, EventHandler<ProgressChangedEventArgs> progressChanged = null)
        {
            var operation = new LargeListDeleteFaceOperation(listId, persistedFaceId);
            ExecuteOperation(operation, completed, progressChanged);
        }

        public static void AddFace(string pictureUrl, string listId, EventHandler<AddFaceResult> completed, EventHandler<ProgressChangedEventArgs> progressChanged = null, string userData = "", string targetFace = "")
        {
            var operation = new LargeListAddFaceOperation(pictureUrl, listId, userData, targetFace);
            ExecuteOperation(operation, completed, progressChanged);
        }

        public static void AddFace(byte[] picture, string listId, EventHandler<AddFaceResult> completed, EventHandler<ProgressChangedEventArgs> progressChanged = null, string userData = "", string targetFace = "")
        {
            var operation = new LargeListAddFaceOperation(picture, listId, userData, targetFace);
            ExecuteOperation(operation, completed, progressChanged);
        }

        public static void FindSimilar(string faceId, string listId, EventHandler<List<FindSimilarResults>> completed, EventHandler<ProgressChangedEventArgs> progressChanged = null, int maxNumOfCandidatesReturned = 20, FindSimilarMode findMode = FindSimilarMode.matchPerson)
        {
            Face.FindSimilar(faceId, listId, completed, true, progressChanged, maxNumOfCandidatesReturned, findMode);
        }

        public static void GetAllFaces(string listId, EventHandler<List<GetAllLargeListFacesResult>> completed, EventHandler<ProgressChangedEventArgs> progressChanged = null, string start = "",int top = 1000)
        {
            var operation = new GetAllLargeListFacesOperation(listId, start, top);
            ExecuteOperation(operation, completed, progressChanged);
        }

        public static void Train(string listId, EventHandler<string> completed, EventHandler<ProgressChangedEventArgs> progressChanged = null)
        {
            var operation = new TrainLargeListOperation(listId);
            ExecuteOperation(operation, completed, progressChanged);
        }

        public static void GetTrainingStatus(string listId, EventHandler<GetTrainingStatusLargeListResult> completed, EventHandler<ProgressChangedEventArgs> progressChanged = null)
        {
            var operation = new GetTrainingStatusLargeListOperation(listId);
            ExecuteOperation(operation, completed, progressChanged);
        }
    }
}
