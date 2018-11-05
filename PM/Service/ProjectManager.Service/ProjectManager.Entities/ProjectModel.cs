using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProjectManager.Entities
{
    public class ProjectModel
    {

        private int projectId;

        public int ProjectId
        {
            get { return projectId; }
            set { projectId = value; }
        }

        private UserModel projectManager;

        public UserModel ProjectManager
        {
            get { return projectManager; }
            set { projectManager = value; }
        }

        private int? projectManagerId;

        public int? ProjectManagerId
        {
            get { return projectManagerId; }
            set { projectManagerId = value; }
        }

        private string project;

        [Required]
        public string Project
        {
            get { return project; }
            set { project = value; }
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

        [Range(1, 30)]
        public int Priority
        {
            get { return priority; }
            set { priority = value; }
        }

        private ICollection<TaskModel> tasks;

        public ICollection<TaskModel> Tasks
        {
            get { return tasks; }
            set { tasks = value; }
        }

    }
}
