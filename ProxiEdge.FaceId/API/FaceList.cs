using ProxiEdge.FaceId.Base;
using ProxiEdge.FaceId.Face.FindSimilar.Result;
using ProxiEdge.FaceId.FaceList.AddFace.Operation;
using ProxiEdge.FaceId.FaceList.AddFace.Result;
using ProxiEdge.FaceId.FaceList.CreateList.Operation;
using ProxiEdge.FaceId.FaceList.DeleteFace.Operation;
using ProxiEdge.FaceId.FaceList.DeleteList.Operation;
using ProxiEdge.FaceId.FaceList.GetAllLists.Operation;
using ProxiEdge.FaceId.FaceList.GetAllLists.Result;
using ProxiEdge.FaceId.FaceList.GetList.Operation;
using ProxiEdge.FaceId.FaceList.GetList.Result;
using ProxiEdge.FaceId.FaceList.UpdateList.Operation;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace ProxiEdge.FaceId.API
{
    public class FaceList : APIBase
    {
        // EventHandler<AddFaceResult> completed, EventHandler<ProgressChangedEventArgs> progressChanged = null
        public static void Create(string faceListId, string listName, EventHandler<string> completed, EventHandler<ProgressChangedEventArgs> progressChanged = null, string listDescription = "")
        {
            var operation = new CreateListOperation(faceListId, listName, listDescription);
            ExecuteOperation(operation, completed, progressChanged);
        }

        public static void Get(string faceListId, EventHandler<GetListResult> completed, EventHandler<ProgressChangedEventArgs> progressChanged = null)
        {
            var operation = new GetListOperation(faceListId);
            ExecuteOperation(operation, completed, progressChanged);
        }

        public static void GetAll(EventHandler<List<GetAllListsResult>> completed, EventHandler<ProgressChangedEventArgs> progressChanged = null)
        {
            var operation = new GetAllListsOperation();
            ExecuteOperation(operation, completed, progressChanged);
        }

        public static void Update(string faceListId, string listName, EventHandler<string> completed, EventHandler<ProgressChangedEventArgs> progressChanged = null, string listDescription = "")
        {
            var operation = new UpdateListOperation(faceListId, listName, listDescription);
            ExecuteOperation(operation, completed, progressChanged);
        }

        public static void Delete(string faceListId, EventHandler<string> completed, EventHandler<ProgressChangedEventArgs> progressChanged = null)
        {
            var operation = new DeleteListOperation(faceListId);
            ExecuteOperation(operation, completed, progressChanged);
        }
        
        public static void DeleteFace(string faceListId, string persistedFaceId, EventHandler<string> completed, EventHandler<ProgressChangedEventArgs> progressChanged = null)
        {
            var operation = new DeleteFaceOperation(faceListId, persistedFaceId);
            ExecuteOperation(operation, completed, progressChanged);
        }

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

        public static void FindSimilarFace(string faceId, string faceListId, EventHandler<List<FindSimilarResults>> completed, EventHandler<ProgressChangedEventArgs> progressChanged = null, int maxNumOfCandidatesReturned = 20, FindSimilarMode findMode = FindSimilarMode.matchPerson)
        {
            Face.FindSimilar(faceId, faceListId, completed,false,progressChanged, maxNumOfCandidatesReturned, findMode);
        }
    }
}