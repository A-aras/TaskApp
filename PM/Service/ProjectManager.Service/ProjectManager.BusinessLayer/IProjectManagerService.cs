using System.Collections.Generic;
using ProjectManager.Entities;

namespace ProjectManager.BusinessLayer
{
    public interface IProjectManagerService
    {
        #region User 
        ICollection<UserModel> GetUsers();

        UserModel GetUserById(int userId);

        UserModel AddUser(UserModel user);

        UserModel UpdateUser(UserModel user);

        bool DeleteUser(UserModel user);

        #endregion

        #region Project

        ICollection<ProjectModel> GetProjects();

        ProjectModel AddProject(ProjectModel project);

        ProjectModel UpdateProject(ProjectModel project);

        bool DeleteProject(ProjectModel project);

        #endregion

        #region ParentTask
        ICollection<ParentTaskModel> GetParentTasks();
        ParentTaskModel AddParentTask(ParentTaskModel parentTask);
        #endregion

        #region Task
        ICollection<TaskModel> GetTasks();
        ICollection<TaskModel> GetAllTaskForProject(ProjectModel parentTask);
        TaskModel UpdateTaks(TaskModel task);
        TaskModel AddTask(TaskModel task);
        bool DeleteTaks(TaskModel task);

        #endregion
    }
}
