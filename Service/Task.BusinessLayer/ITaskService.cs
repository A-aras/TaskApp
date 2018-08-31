using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.Entities;

namespace Task.BusinessLayer
{
    public interface ITaskService
    {

        TaskModel GetTaskById(int id);
        TaskModel UpdateTaks(TaskModel id);

        bool DeleteTaks(TaskModel id);

        ICollection<TaskModel> GetAllTasks();

        ICollection<TaskModel> QueryTask(string name,DateTime? startDate,DateTime? endDate,int? priority, string parentTask);

        ICollection<ParentTaskModel> GetAllParentTasks();
    }
}
