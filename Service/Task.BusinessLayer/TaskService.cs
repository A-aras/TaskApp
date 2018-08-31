using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.DataLayer;
using Task.Entities;

namespace Task.BusinessLayer
{
    public class TaskService : ITaskService
    {
        private ITaskDbContext dbContext;
        public TaskService(ITaskDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public bool DeleteTaks(TaskModel id)
        {
            dbContext.Tasks.Remove(id);
            return dbContext.SaveChanges() == 0;
        }

        public ICollection<ParentTaskModel> GetAllParentTasks()
        {
            return dbContext.ParentTasks.ToList();
        }

        public ICollection<TaskModel> GetAllTasks()
        {
            return dbContext.Tasks.ToList();
        }

        public TaskModel GetTaskById(int id)
        {
            return dbContext.Tasks.FirstOrDefault(x => x.TaskId == id);
        }

        public ICollection<TaskModel> QueryTask(string name, DateTime? startDate, DateTime? endDate, int? priority, string parentTask)
        {
            return dbContext.Tasks.Where(x => (string.IsNullOrEmpty(name) || name == x.TaskDescription)
            && (startDate == null || x.StartDate >= startDate)
            && (endDate == null || x.EndDate >= endDate)
            && (priority == null || x.Priority == priority)
            //&& (string.IsNullOrEmpty(parentTask) || parentTask == x.ParentTask.Parent_Task)
            ).ToList();
        }

        public TaskModel UpdateTaks(TaskModel id)
        {
            dbContext.Tasks.Attach(id);
            dbContext.Entry(id).State = System.Data.Entity.EntityState.Modified;
            if (dbContext.SaveChanges() >= 0)
            {
                return dbContext.Tasks.Find(id.TaskId);
            }
            else { return null; }
        }
    }
}
