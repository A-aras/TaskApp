using System;
using System.Collections.Generic;

namespace Task.Entities
{
    public class TaskModel
    {

        private int taskId;

        public int TaskId
        {
            get { return taskId; }
            set { taskId = value; }
        }

        private ParentTaskModel parentTask;

        public ParentTaskModel ParentTask
        {
            get { return parentTask; }
            set { parentTask = value; }
        }

        private int? parentTaskId;

        public int? ParentTaskId
        {
            get { return parentTaskId; }
            set { parentTaskId = value; }
        }

        private string taskDescription;

        public string TaskDescription
        {
            get { return taskDescription; }
            set { taskDescription = value; }
        }


        private DateTime? startDate;

        public DateTime? StartDate
        {
            get { return startDate; }
            set { startDate = value; }
        }

        private DateTime? endDate;

        public DateTime? EndDate
        {
            get { return endDate; }
            set { endDate = value; }
        }

        private int priority;

        public int Priority
        {
            get { return priority; }
            set { priority = value; }
        }

        private bool isClosed;

        public bool IsClosed
        {
            get { return isClosed; }
            set { isClosed = value; }
        }

        //public ICollection<TaskModel> ToList()
        //{
        //    throw new NotImplementedException();
        //}
    }
}
