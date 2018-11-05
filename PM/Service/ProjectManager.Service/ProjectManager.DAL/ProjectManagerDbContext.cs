using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectManager.Entities;

namespace ProjectManager.DAL
{
    public class ProjectManagerDbContext : DbContext, IProjectManagerDbContext
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

        private IDbSet<UserModel> users;

        public IDbSet<UserModel> Users
        {
            get { return users; }
            set { users = value; }
        }

        private IDbSet<ProjectModel> projects;

        public IDbSet<ProjectModel> Projects
        {
            get { return projects; }
            set { projects = value; }
        }

        public ProjectManagerDbContext() : base("name=projectManagerDbSource")
        {
            Tasks = this.Set<TaskModel>();
            ParentTasks = this.Set<ParentTaskModel>();
            Users = this.Set<UserModel>();
            Projects = this.Set<ProjectModel>();
        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            var taskMap = modelBuilder.Entity<TaskModel>();
            taskMap.HasKey(x => x.TaskId);
            taskMap.Property(x => x.TaskId).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity).HasColumnName("Task_Id");
            taskMap.Property(x => x.TaskDescription).HasColumnName("Task");
            taskMap.Property(x => x.StartDate).HasColumnName("StartDate");
            taskMap.Property(x => x.EndDate).HasColumnName("EndDate");
            taskMap.Property(x => x.IsClosed).HasColumnName("IsClosed");
            taskMap.Property(x => x.Priority);
            //taskMap.Property(x => x.ParentTaskId).HasColumnName("ParentTask_ParentTaskId");
            taskMap.HasOptional(x => x.ParentTask).WithMany(x => x.Tasks);
            taskMap.HasOptional(x => x.Project).WithMany(x => x.Tasks);

            taskMap.Ignore(x => x.User);
            taskMap.Ignore(x => x.UserId);


            taskMap.ToTable("Task");


            var projectMap = modelBuilder.Entity<ProjectModel>();
            projectMap.HasKey(x => x.ProjectId);
            projectMap.Property(x => x.ProjectId).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity).HasColumnName("ProjectId");
            projectMap.Property(x => x.Project).HasColumnName("Project");
            projectMap.Property(x => x.StartDate).HasColumnName("StartDate");
            projectMap.Property(x => x.EndDate).HasColumnName("EndDate");
            projectMap.Property(x => x.Priority);
            projectMap.HasOptional(x => x.ProjectManager).WithOptionalPrincipal(x => x.Project);


            projectMap.ToTable("Project");


            var userMap = modelBuilder.Entity<UserModel>();
            userMap.HasKey(x => x.UserId);
            userMap.Property(x => x.UserId).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity).HasColumnName("UserId");
            userMap.Property(x => x.FirstName).HasColumnName("FName");
            userMap.Property(x => x.LastName).HasColumnName("LName");
            userMap.Property(x => x.EmployeeId).HasColumnName("EmpId");
            userMap.Ignore(x => x.ProjectId);
            userMap.Ignore(x => x.TaskId);

            userMap.HasOptional(x => x.Project).WithOptionalDependent(x => x.ProjectManager).Map(x =>
            {
                x.MapKey("ProjectId");
            });


            userMap.ToTable("User");

            var parentTaskMap = modelBuilder.Entity<ParentTaskModel>();
            parentTaskMap.HasKey(x => x.ParentTaskId).Property(x => x.ParentTaskId).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity).HasColumnName("Parent_Id");
            parentTaskMap.ToTable("ParentTask");
            parentTaskMap.Property(x => x.Parent_Task).HasColumnName("Parent_Task");

            base.OnModelCreating(modelBuilder);
        }

        public void SetEntityState(object value, EntityState state)
        {
            Entry(value).State = state;
        }
    }
}
