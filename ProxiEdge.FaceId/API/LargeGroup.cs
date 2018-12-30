using ProxiEdge.FaceId.Group.Create.Operation;
using ProxiEdge.FaceId.Group.Delete.Operation;
using ProxiEdge.FaceId.Group.GetGroup.Operation;
using ProxiEdge.FaceId.Group.GetGroup.Result;
using ProxiEdge.FaceId.Group.GetTrainingStatus.Operation;
using ProxiEdge.FaceId.Group.GetTrainingStatus.Result;
using ProxiEdge.FaceId.Group.List.LargeGroup.Operation;
using ProxiEdge.FaceId.Group.List.LargeGroup.Result;
using ProxiEdge.FaceId.Group.Train.Operation;
using ProxiEdge.FaceId.Group.Update.Operation;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace ProxiEdge.FaceId.API
{
    public class LargeGroup : APIBase
    {
        public static void DeleteGroup(string groupId, EventHandler<string> completed, EventHandler<ProgressChangedEventArgs> progressChanged = null)
        {
            var operation = new DeleteGroupOperation(groupId, true);
            ExecuteOperation(operation, completed, progressChanged);
        }

        public static void GetGroup(string groupId, EventHandler<GetGroupResult> completed, EventHandler<ProgressChangedEventArgs> progressChanged = null)
        {
            var operation = new GetGroupOperation(groupId, true);
            ExecuteOperation(operation, completed, progressChanged);
        }

        public static void CreateGroup(string groupId, string groupName, string userData, EventHandler<string> completed, EventHandler<ProgressChangedEventArgs> progressChanged = null)
        {
            var operation = new CreateGroupOperation(groupId, groupName, userData, true);
            ExecuteOperation(operation, completed, progressChanged);
        }

        public static void GetTrainingStatus(string groupId, EventHandler<GetGroupTrainingStatusResult> completed, EventHandler<ProgressChangedEventArgs> progressChanged = null)
        {
            var operation = new GetGroupTrainingStatusOperation(groupId,true);
            ExecuteOperation(operation, completed, progressChanged);
        }

        public static void List(EventHandler<List<ListLargeGroupResult>> completed, EventHandler<ProgressChangedEventArgs> progressChanged = null, string start = "", int top = 1000)
        {
            var operation = new ListLargeGroupOperation(start, top);
            ExecuteOperation(operation, completed, progressChanged);
        }

        public static void Train(string groupId, EventHandler<string> completed, EventHandler<ProgressChangedEventArgs> progressChanged = null)
        {
            var operation = new TrainGroupOperation(groupId,true);
            ExecuteOperation(operation, completed, progressChanged);
        }

        public static void Update(string groupId, string name, string userData, EventHandler<string> completed, EventHandler<ProgressChangedEventArgs> progressChanged = null)
        {
            var operation = new UpdateGroupOperation(groupId, name, userData,true);
            ExecuteOperation(operation, completed, progressChanged);
        }
    }
}
