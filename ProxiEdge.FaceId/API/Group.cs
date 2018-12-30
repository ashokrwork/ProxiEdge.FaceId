using ProxiEdge.FaceId.Group.Create.Operation;
using ProxiEdge.FaceId.Group.Delete.Operation;
using ProxiEdge.FaceId.Group.GetGroup.Operation;
using ProxiEdge.FaceId.Group.GetGroup.Result;
using ProxiEdge.FaceId.Group.GetTrainingStatus.Operation;
using ProxiEdge.FaceId.Group.GetTrainingStatus.Result;
using ProxiEdge.FaceId.Group.List.Group.Operation;
using ProxiEdge.FaceId.Group.List.Group.Result;
using ProxiEdge.FaceId.Group.Train.Operation;
using ProxiEdge.FaceId.Group.Update.Operation;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace ProxiEdge.FaceId.API
{
    public class Group : APIBase
    {
        // EventHandler<string> completed, EventHandler<ProgressChangedEventArgs> progressChanged = null
        public static void CreateGroup(string groupId, string groupName, string userData,EventHandler<string> completed, EventHandler<ProgressChangedEventArgs> progressChanged = null)
        {
            var operation = new CreateGroupOperation(groupId, groupName, userData);
            ExecuteOperation(operation, completed, progressChanged);
        }

        

        public static void DeleteGroup(string groupId, EventHandler<string> completed, EventHandler<ProgressChangedEventArgs> progressChanged = null)
        {
            var operation = new DeleteGroupOperation(groupId);
            ExecuteOperation(operation, completed, progressChanged);
        }

       

        public static void GetGroup(string groupId, EventHandler<GetGroupResult> completed, EventHandler<ProgressChangedEventArgs> progressChanged = null)
        {
            var operation = new GetGroupOperation(groupId);
            ExecuteOperation(operation, completed, progressChanged);
        }


        public static void GetTrainingStatus(string groupId, EventHandler<GetGroupTrainingStatusResult> completed, EventHandler<ProgressChangedEventArgs> progressChanged = null)
        {
            var operation = new GetGroupTrainingStatusOperation(groupId);
            ExecuteOperation(operation, completed, progressChanged);
        }

        public static void List(EventHandler<List<ListGroupResult>> completed, EventHandler<ProgressChangedEventArgs> progressChanged = null,string start = "",int top = 1000)
        {
            var operation = new ListGroupOperation(start, top);
            ExecuteOperation(operation, completed, progressChanged);
        }

        public static void Train(string groupId, EventHandler<string> completed, EventHandler<ProgressChangedEventArgs> progressChanged = null)
        {
            var operation = new TrainGroupOperation(groupId);
            ExecuteOperation(operation, completed, progressChanged);
        }

        public static void Update(string groupId, string name, string userData, EventHandler<string> completed, EventHandler<ProgressChangedEventArgs> progressChanged = null)
        {
            var operation = new UpdateGroupOperation(groupId, name, userData);
            ExecuteOperation(operation, completed, progressChanged);
        }
    }
}
