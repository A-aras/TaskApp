using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProjectManager.Entities
{
    //[Serializable]
    public class TaskModel//:IValidatableObject
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

        [Required]
        public string TaskDescription
        {
            get { return taskDescription; }
            set { taskDescription = value; }
        }


        private DateTime? startDate;

        [Required]
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

        [Range(1,30)]
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

        //public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        //{
        //    throw new NotImplementedException();
        //}

        //public ICollection<TaskModel> ToList()
        //{
        //    throw new NotImplementedException();
        //}

        private int? projectId;

        public int? ProjectId
        {
            get { return projectId; }
            set { projectId = value; }
        }


        private ProjectModel project;

        public ProjectModel Project
        {
            get { return project; }
            set { project = value; }
        }

        private int? userId;

        public int? UserId 
        {
            get { return userId; }
            set { userId = value; }
        }


        private UserModel user;

        public UserModel User
        {
            get { return user; }
            set { user = value; }
        }
    }
}
