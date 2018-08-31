using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.Entities;

namespace Task.Api.Tests
{
    public static class TaskServiceFakeData
    {
        public static class TasksData
        {
            public static TaskModel Task1 = new TaskModel() { TaskId = 1, TaskDescription = "First Task", StartDate = new DateTime(2018, 16, 08), EndDate = new DateTime(2018, 16, 08), Priority = 1, //ParentTask = null
            };
            public static TaskModel Task2 = new TaskModel() { TaskId = 2, TaskDescription = "Second Task", StartDate = new DateTime(2018, 16, 08), EndDate = new DateTime(2018, 16, 08), Priority = 1, //ParentTask = null
            };

            public static IQueryable<TaskModel> AllTaks = new List<TaskModel>() { Task1, Task2 }.AsQueryable();

        }

        public static class ParentTasksData
        {
            public static ParentTaskModel ParentTask1 = new ParentTaskModel() { ParentTaskId = 1, Parent_Task = "Parent First Task", //Tasks = TasksData.AllTaks.ToList() 
            };
            

            public static IQueryable<ParentTaskModel> AllParentTaks = new List<ParentTaskModel>() { ParentTask1 }.AsQueryable();

        }
    }
}
