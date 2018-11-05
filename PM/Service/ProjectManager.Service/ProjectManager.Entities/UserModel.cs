using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProjectManager.Entities
{
    public class UserModel
    {

        private int userId;

        public int UserId
        {
            get { return userId; }
            set { userId = value; }
        }

        //private ParentTaskModel parentTask;

        //public ParentTaskModel ParentTask
        //{
        //    get { return parentTask; }
        //    set { parentTask = value; }
        //}

        //private int? parentTaskId;

        //public int? ParentTaskId
        //{
        //    get { return parentTaskId; }
        //    set { parentTaskId = value; }
        //}

        private string firstName;

        [Required]
        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }

        private string lastName;

        [Required]
        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }




        private int employeeId;

        [Required]
        public int EmployeeId
        {
            get { return employeeId; }
            set { employeeId = value; }
        }

        private int projectId;

        
        public int ProjectId
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

        private int taskId;

        
        public int TaskId
        {
            get { return taskId; }
            set { taskId = value; }
        }

        private TaskModel task;

        public TaskModel Task { 
            get { return task; }
            set { task = value; }
        }

    }
}
