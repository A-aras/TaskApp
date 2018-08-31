using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.BusinessLayer;
using Task.Entities;

namespace Task.Api.Tests
{
    public class TaskServiceFake : ITaskService
    {
		

        public bool DeleteTaks(TaskModel id)
        {
            throw new NotImplementedException();
        }

        public ICollection<ParentTaskModel> GetAllParentTasks()
        {
            throw new NotImplementedException();
        }

        public ICollection<TaskModel> GetAllTasks()
        {
            throw new NotImplementedException();
        }

        public TaskModel GetTaskById(int id)
        {
            throw new NotImplementedException();
        }

        public ICollection<TaskModel> QueryTask(string name, DateTime? startDate, DateTime? endDate, int? priority, string parentTask)
        {
            throw new NotImplementedException();
        }

        public TaskModel UpdateTaks(TaskModel id)
        {
            throw new NotImplementedException();
        }
    }
}
