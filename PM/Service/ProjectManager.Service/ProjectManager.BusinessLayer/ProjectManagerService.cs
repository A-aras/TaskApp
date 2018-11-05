using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectManager.Entities;
using ProjectManager.DAL;
using System.Data.Entity;

namespace ProjectManager.BusinessLayer
{
    public class ProjectManagerService : IProjectManagerService
    {

        private IProjectManagerDbContext dbContext;
        public ProjectManagerService(IProjectManagerDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public ParentTaskModel AddParentTask(ParentTaskModel parentTask)
        {
            dbContext.ParentTasks.Add(parentTask);
            if (dbContext.SaveChanges() >= 0)
            {
                return parentTask;
            }
            else { return null; }
        }

        public ProjectModel AddProject(ProjectModel project)
        {
            dbContext.Projects.Add(project);
            if (project.ProjectManager != null)
            {
                dbContext.SetEntityState(project.ProjectManager, EntityState.Unchanged);
            }
            if (dbContext.SaveChanges() >= 0)
            {
                return project;
            }
            else { return null; }
        }

        public TaskModel AddTask(TaskModel task)
        {
            dbContext.Tasks.Add(task);
            if (task.ParentTask != null)
            {
                dbContext.SetEntityState(task.ParentTask, EntityState.Unchanged);
            }
            if (task.User != null)
            {
                dbContext.SetEntityState(task.User, EntityState.Unchanged);
            }
            if (dbContext.SaveChanges() >= 0)
            {
                return task;
            }
            else { return null; }
        }

        public UserModel AddUser(UserModel user)
        {
            dbContext.Users.Add(user);
            if (user.Project != null)
            {
                dbContext.SetEntityState(user.Project, EntityState.Unchanged);
            }
            if (user.Task != null)
            {
                dbContext.SetEntityState(user.Task, EntityState.Unchanged);
            }
            if (dbContext.SaveChanges() >= 0)
            {
                return user;
            }
            else { return null; }
        }

        public bool DeleteProject(ProjectModel project)
        {
            dbContext.Projects.Remove(project);
            return dbContext.SaveChanges() == 1;
        }

        public bool DeleteTaks(TaskModel task)
        {
            dbContext.Tasks.Remove(task);
            return dbContext.SaveChanges() == 1;
        }

        public bool DeleteUser(UserModel user)
        {
            dbContext.Users.Remove(user);
            return dbContext.SaveChanges() == 1;
        }

        public ICollection<TaskModel> GetAllTaskForProject(ProjectModel project)
        {
            return dbContext.Tasks.Where(x => x.ProjectId == project.ProjectId).ToList();
        }

        public ICollection<ParentTaskModel> GetParentTasks()
        {
            return dbContext.ParentTasks.ToList();
        }

        public ICollection<ProjectModel> GetProjects()
        {
            return dbContext.Projects.ToList();
        }

        public ICollection<TaskModel> GetTasks()
        {
            return dbContext.Tasks.ToList();
        }

        public UserModel GetUserById(int userId)
        {
            return dbContext.Users.Find(userId);
        }

        public ICollection<UserModel> GetUsers()
        {
            return dbContext.Users.ToList();
        }

        public ProjectModel UpdateProject(ProjectModel project)
        {
            //if (id.IsClosed && !ignoreClosedCheck)
            //{
            //    throw new Exception("You cannot update an closed task");
            //}
            dbContext.Projects.Attach(project);
            dbContext.SetEntityState(project, EntityState.Modified);
            //dbContext.Entry(id).State = System.Data.Entity.EntityState.Modified;
            if (dbContext.SaveChanges() >= 0)
            {
                return dbContext.Projects.Find(project.ProjectId);
            }
            else { return null; }
        }

        public TaskModel UpdateTaks(TaskModel task)
        {
            //if (id.IsClosed && !ignoreClosedCheck)
            //{
            //    throw new Exception("You cannot update an closed task");
            //}
            dbContext.Tasks.Attach(task);
            dbContext.SetEntityState(task, EntityState.Modified);
            //dbContext.Entry(id).State = System.Data.Entity.EntityState.Modified;
            if (dbContext.SaveChanges() >= 0)
            {
                return dbContext.Tasks.Find(task.TaskId);
            }
            else { return null; }
        }

        public UserModel UpdateUser(UserModel user)
        {
            //if (id.IsClosed && !ignoreClosedCheck)
            //{
            //    throw new Exception("You cannot update an closed task");
            //}
            dbContext.Users.Attach(user);
            dbContext.SetEntityState(user, EntityState.Modified);
            //dbContext.Entry(id).State = System.Data.Entity.EntityState.Modified;
            if (dbContext.SaveChanges() >= 0)
            {
                return dbContext.Users.Find(user.UserId);
            }
            else { return null; }
        }
    }
}
