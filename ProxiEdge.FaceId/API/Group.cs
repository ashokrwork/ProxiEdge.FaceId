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
using ProxiEdge.FaceId.Group.List.Group.Operation;
using ProxiEdge.FaceId.Group.List.Group.Result;
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
    public class Group : APIBase
    {
        #region Group

        public static void CreateGroup(string groupId, string groupName, string userData,EventHandler<string> completed, EventHandler<ProgressChangedEventArgs> progressChanged = null)
        {
            var operation = new CreateGroupOperation(groupId, groupName, userData);
            ExecuteOperationAsync(operation, completed, progressChanged);
        }

        public static void DeleteGroup(string groupId, EventHandler<string> completed, EventHandler<ProgressChangedEventArgs> progressChanged = null)
        {
            var operation = new DeleteGroupOperation(groupId);
            ExecuteOperationAsync(operation, completed, progressChanged);
        }
        
        public static void GetGroup(string groupId, EventHandler<GetGroupResult> completed, EventHandler<ProgressChangedEventArgs> progressChanged = null)
        {
            var operation = new GetGroupOperation(groupId);
            ExecuteOperationAsync(operation, completed, progressChanged);
        }
        
        public static void GetTrainingStatus(string groupId, EventHandler<GetGroupTrainingStatusResult> completed, EventHandler<ProgressChangedEventArgs> progressChanged = null)
        {
            var operation = new GetGroupTrainingStatusOperation(groupId);
            ExecuteOperationAsync(operation, completed, progressChanged);
        }

        public static void List(EventHandler<List<ListGroupResult>> completed, EventHandler<ProgressChangedEventArgs> progressChanged = null,string start = "",int top = 1000)
        {
            var operation = new ListGroupOperation(start, top);
            ExecuteOperationAsync(operation, completed, progressChanged);
        }

        public static void Train(string groupId, EventHandler<string> completed, EventHandler<ProgressChangedEventArgs> progressChanged = null)
        {
            var operation = new TrainGroupOperation(groupId);
            ExecuteOperationAsync(operation, completed, progressChanged);
        }

        public static void Update(string groupId, string name, string userData, EventHandler<string> completed, EventHandler<ProgressChangedEventArgs> progressChanged = null)
        {
            var operation = new UpdateGroupOperation(groupId, name, userData);
            ExecuteOperationAsync(operation, completed, progressChanged);
        }
        #endregion

        #region Person
        // EventHandler<string> completed, EventHandler<ProgressChangedEventArgs> progressChanged = null

        public static void CreatePersonAsync(string groupId, string name, EventHandler<CreatePersonResult> completed, EventHandler<ProgressChangedEventArgs> progressChanged = null, string userData = "")
        {
            var operation = new CreatePersonOperation(groupId, name, false, userData);
            ExecuteOperationAsync(operation, completed, progressChanged);
        }

        public static CreatePersonOperation CreatePerson(string groupId, string name, string userData = "")
        {
            var operation = new CreatePersonOperation(groupId, name, false, userData);
            operation.Execute();
            return operation;
        }

        public static void UpdatePerson(string groupId, string personId, string name, string userData, EventHandler<string> completed, EventHandler<ProgressChangedEventArgs> progressChanged = null)
        {
            var operation = new UpdatePersonOperation(groupId, personId, name, userData, false);
            ExecuteOperationAsync(operation, completed, progressChanged);
        }

        public static void GetPerson(string groupId, string personId, EventHandler<GetPersonResult> completed, EventHandler<ProgressChangedEventArgs> progressChanged = null)
        {
            var operation = new GetPersonOperation(groupId, personId, false);
            ExecuteOperationAsync(operation, completed, progressChanged);
        }

        public static void DeletePerson(string groupId, string personId, EventHandler<string> completed, EventHandler<ProgressChangedEventArgs> progressChanged = null)
        {
            var operation = new DeletePersonOperation(groupId, personId, false);
            ExecuteOperationAsync(operation, completed, progressChanged);
        }

        public static void GetAllPersons(string groupId, EventHandler<List<ListPersonResult>> completed, EventHandler<ProgressChangedEventArgs> progressChanged = null, string start = "", int top = 1000)
        {
            var operation = new ListPersonOperation(groupId, false, start, top);
            ExecuteOperationAsync(operation, completed, progressChanged);
        }

        public static void AddPersonFaceAsync(string pictureUrl, string groupId, string personId, EventHandler<PersonAddFaceResult> completed, EventHandler<ProgressChangedEventArgs> progressChanged = null, string userData = "", string targetFace = "")
        {
            var operation = new PersonAddFaceOperation(pictureUrl, groupId, personId, false, userData, targetFace);
            ExecuteOperationAsync(operation, completed, progressChanged);
        }

        public static PersonAddFaceOperation AddPersonFace(string pictureUrl, string groupId, string personId, string userData = "", string targetFace = "")
        {
            var operation = new PersonAddFaceOperation(pictureUrl, groupId, personId, false, userData, targetFace);
            operation.Execute();
            return operation;
        }

        public static void UpdatePersonFace(string groupId, string personId, string faceId, string userData, EventHandler<string> completed, EventHandler<ProgressChangedEventArgs> progressChanged = null)
        {
            var operation = new UpdatePersonFaceOperation(groupId, personId, faceId, userData, false);
            ExecuteOperationAsync(operation, completed, progressChanged);
        }

        public static void GetPersonFace(string groupId, string personId, string persistedFaceId, EventHandler<GetPersonFaceResult> completed, EventHandler<ProgressChangedEventArgs> progressChanged = null)
        {
            var operation = new GetPersonFaceOperation(groupId, personId, persistedFaceId, false);
            ExecuteOperationAsync(operation, completed, progressChanged);
        }

        public static void DeletePersonFace(string groupId, string personId, string persistedFaceId, EventHandler<string> completed, EventHandler<ProgressChangedEventArgs> progressChanged = null)
        {
            var operation = new DeletePersonFaceOperation(groupId, personId, persistedFaceId, false);
            ExecuteOperationAsync(operation, completed, progressChanged);
        }

        #endregion

        #region Consolidated Actions

        public static void CreatePersonWithFace(string pictureUrl,string groupId, string name, EventHandler<PersonAddFaceResult> completed, EventHandler<ProgressChangedEventArgs> progressChanged = null, string userData = "")
        {
            //var faceId = Face.Detect(pictureUrl, true).Results[0].FaceId;
            var personId = CreatePerson(groupId, name,userData).Results.PersonId;
            AddPersonFaceAsync(pictureUrl, groupId, personId, completed, progressChanged);
        }

        #endregion
    }
}
