using ProxiEdge.FaceId.Group.AddFace.Operation;
using ProxiEdge.FaceId.Group.Create.Operation;
using ProxiEdge.FaceId.Group.CreatePerson.Operation;
using ProxiEdge.FaceId.Group.CreatePerson.Result;
using ProxiEdge.FaceId.Group.Delete.Operation;
using ProxiEdge.FaceId.Group.DeletePerson.Operation;
using ProxiEdge.FaceId.Group.DeletePersonFace.Operation;
using ProxiEdge.FaceId.Group.GetGroup.Operation;
using ProxiEdge.FaceId.Group.GetGroup.Result;
using ProxiEdge.FaceId.Group.GetPerson.Operation;
using ProxiEdge.FaceId.Group.GetPerson.Result;
using ProxiEdge.FaceId.Group.GetPersonFace.Operation;
using ProxiEdge.FaceId.Group.GetPersonFace.Result;
using ProxiEdge.FaceId.Group.GetTrainingStatus.Operation;
using ProxiEdge.FaceId.Group.GetTrainingStatus.Result;
using ProxiEdge.FaceId.Group.List.LargeGroup.Operation;
using ProxiEdge.FaceId.Group.List.LargeGroup.Result;
using ProxiEdge.FaceId.Group.ListPerson.Operation;
using ProxiEdge.FaceId.Group.ListPerson.Result;
using ProxiEdge.FaceId.Group.Train.Operation;
using ProxiEdge.FaceId.Group.Update.Operation;
using ProxiEdge.FaceId.Group.UpdatePerson.Operation;
using ProxiEdge.FaceId.Group.UpdatePersonFace.Operation;
using ProxiEdge.FaceId.Person.AddFace.Result;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace ProxiEdge.FaceId.API
{
    public class LargeGroup : APIBase
    {
        #region Group
        public static void DeleteGroup(string groupId, EventHandler<string> completed, EventHandler<ProgressChangedEventArgs> progressChanged = null)
        {
            var operation = new DeleteGroupOperation(groupId, true);
            ExecuteOperationAsync(operation, completed, progressChanged);
        }

        public static void GetGroup(string groupId, EventHandler<GetGroupResult> completed, EventHandler<ProgressChangedEventArgs> progressChanged = null)
        {
            var operation = new GetGroupOperation(groupId, true);
            ExecuteOperationAsync(operation, completed, progressChanged);
        }

        public static void CreateGroup(string groupId, string groupName, string userData, EventHandler<string> completed, EventHandler<ProgressChangedEventArgs> progressChanged = null)
        {
            var operation = new CreateGroupOperation(groupId, groupName, userData, true);
            ExecuteOperationAsync(operation, completed, progressChanged);
        }

        public static void GetTrainingStatus(string groupId, EventHandler<GetGroupTrainingStatusResult> completed, EventHandler<ProgressChangedEventArgs> progressChanged = null)
        {
            var operation = new GetGroupTrainingStatusOperation(groupId,true);
            ExecuteOperationAsync(operation, completed, progressChanged);
        }

        public static void List(EventHandler<List<ListLargeGroupResult>> completed, EventHandler<ProgressChangedEventArgs> progressChanged = null, string start = "", int top = 1000)
        {
            var operation = new ListLargeGroupOperation(start, top);
            ExecuteOperationAsync(operation, completed, progressChanged);
        }

        public static void Train(string groupId, EventHandler<string> completed, EventHandler<ProgressChangedEventArgs> progressChanged = null)
        {
            var operation = new TrainGroupOperation(groupId,true);
            ExecuteOperationAsync(operation, completed, progressChanged);
        }

        public static void Update(string groupId, string name, string userData, EventHandler<string> completed, EventHandler<ProgressChangedEventArgs> progressChanged = null)
        {
            var operation = new UpdateGroupOperation(groupId, name, userData,true);
            ExecuteOperationAsync(operation, completed, progressChanged);
        }
        #endregion

        #region Person
        // EventHandler<string> completed, EventHandler<ProgressChangedEventArgs> progressChanged = null

        public static void CreatePerson(string groupId, string name, EventHandler<CreatePersonResult> completed, EventHandler<ProgressChangedEventArgs> progressChanged = null, string userData = "")
        {
            var operation = new CreatePersonOperation(groupId, name, true, userData);
            ExecuteOperationAsync(operation, completed, progressChanged);
        }

        public static void UpdatePerson(string groupId, string personId, string name, string userData, EventHandler<string> completed, EventHandler<ProgressChangedEventArgs> progressChanged = null)
        {
            var operation = new UpdatePersonOperation(groupId, personId, name, userData, true);
            ExecuteOperationAsync(operation, completed, progressChanged);
        }

        public static void GetPerson(string groupId, string personId, EventHandler<GetPersonResult> completed, EventHandler<ProgressChangedEventArgs> progressChanged = null)
        {
            var operation = new GetPersonOperation(groupId, personId, true);
            ExecuteOperationAsync(operation, completed, progressChanged);
        }

        public static void DeletePerson(string groupId, string personId, EventHandler<string> completed, EventHandler<ProgressChangedEventArgs> progressChanged = null)
        {
            var operation = new DeletePersonOperation(groupId, personId, true);
            ExecuteOperationAsync(operation, completed, progressChanged);
        }

        public static void GetAllPersons(string groupId, EventHandler<List<ListPersonResult>> completed, EventHandler<ProgressChangedEventArgs> progressChanged = null, string start = "", int top = 1000)
        {
            var operation = new ListPersonOperation(groupId, true, start, top);
            ExecuteOperationAsync(operation, completed, progressChanged);
        }

        public static void AddPersonFace(string pictureUrl, string groupId, string personId, EventHandler<PersonAddFaceResult> completed, EventHandler<ProgressChangedEventArgs> progressChanged = null, string userData = "", string targetFace = "")
        {
            var operation = new PersonAddFaceOperation(pictureUrl, groupId, personId, true, userData, targetFace);
            ExecuteOperationAsync(operation, completed, progressChanged);
        }

        public static void UpdatePersonFace(string groupId, string personId, string faceId, string userData, EventHandler<string> completed, EventHandler<ProgressChangedEventArgs> progressChanged = null)
        {
            var operation = new UpdatePersonFaceOperation(groupId, personId, faceId, userData, true);
            ExecuteOperationAsync(operation, completed, progressChanged);
        }

        public static void GetPersonFace(string groupId, string personId, string persistedFaceId, EventHandler<GetPersonFaceResult> completed, EventHandler<ProgressChangedEventArgs> progressChanged = null)
        {
            var operation = new GetPersonFaceOperation(groupId, personId, persistedFaceId, true);
            ExecuteOperationAsync(operation, completed, progressChanged);
        }

        public static void DeletePersonFace(string groupId, string personId, string persistedFaceId, EventHandler<string> completed, EventHandler<ProgressChangedEventArgs> progressChanged = null)
        {
            var operation = new DeletePersonFaceOperation(groupId, personId, persistedFaceId, true);
            ExecuteOperationAsync(operation, completed, progressChanged);
        }

        #endregion
    }
}
