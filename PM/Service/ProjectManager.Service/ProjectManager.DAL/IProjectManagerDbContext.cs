using ProjectManager.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManager.DAL
{
    public interface IProjectManagerDbContext
    {
        IDbSet<TaskModel> Tasks { get; set; }

        IDbSet<ParentTaskModel> ParentTasks { get; set; }

        IDbSet<UserModel> Users { get; set; }

        IDbSet<ProjectModel> Projects { get; set; }

        int SaveChanges();

        void SetEntityState(object value, EntityState state);
    }
}
