using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.DataLayer;
using Task.Entities;
using static Task.Api.Tests.TaskServiceFakeData;
using NSubstitute.ReturnsExtensions;
using NSubstitute;
using System.Data.Entity.Infrastructure;

namespace Task.Api.Tests
{
    public class TaskDbContextFake : ITaskDbContext
    {
        private IDbSet<TaskModel> tasks;

        public IDbSet<TaskModel> Tasks
        {
            get { return tasks; }
            set { tasks = value; }
        }


        private IDbSet<ParentTaskModel> parentTasks;

        public IDbSet<ParentTaskModel> ParentTasks
        {
            get { return parentTasks; }
            set { parentTasks = value; }
        }

        public TaskDbContextFake()
        {
            IDbSet<TaskModel> task = NSubstitute.Substitute.For<IDbSet<TaskModel>>();
            tasks.Provider.Returns(TasksData.AllTaks.Provider);
            tasks.Expression.Returns(TasksData.AllTaks.Expression);
            tasks.ElementType.Returns(TasksData.AllTaks.ElementType);
            tasks.GetEnumerator().Returns(TasksData.AllTaks.GetEnumerator());
            this.Tasks = task;


            IDbSet<ParentTaskModel> parentTask = NSubstitute.Substitute.For<IDbSet<ParentTaskModel>>();
            parentTask.Provider.Returns(ParentTasksData.AllParentTaks.Provider);
            parentTask.Expression.Returns(ParentTasksData.AllParentTaks.Expression);
            parentTask.ElementType.Returns(ParentTasksData.AllParentTaks.ElementType);
            parentTask.GetEnumerator().Returns(ParentTasksData.AllParentTaks.GetEnumerator());
            this.ParentTasks = parentTask;

        }

        public int SaveChanges()
        {
            throw new NotImplementedException();
        }

        public DbEntityEntry Entry(object value)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
