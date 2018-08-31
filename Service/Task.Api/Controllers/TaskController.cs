using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using Task.Api.Models;
using Task.DataLayer;
using Task.Entities;



namespace Task.Api.Controllers
{

    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    public class TaskController : ApiController
    {
        private ITaskDbContext db;

        public TaskController(ITaskDbContext dbContext)
        {
            this.db = dbContext;
        }


        // GET: api/Task
        [Route("api/Task/GetAllTask")]
        [HttpGet]
        public IQueryable<TaskModel> GetAllTaskModels()
        {
            var taskResulst = db.Tasks.Include(x => x.ParentTask);
            Console.WriteLine(taskResulst.ToString());
            return taskResulst;
        }

        // GET: api/Task
        [Route("api/Task/GetAllParentTask")]
        [HttpGet]
        public IQueryable<ParentTaskModel> GetAllParentTaskModels()
        {
            var taskResulst = db.ParentTasks;
            Console.WriteLine(taskResulst.ToString());
            return taskResulst;
        }

        // GET: api/Task/5
        [ResponseType(typeof(TaskModel))]
        [Route("api/Task/GetTaskById/{id:int}")]
        [HttpGet]
        public IHttpActionResult GetTaskModel(int id)
            
        {
            TaskModel taskModel = db.Tasks.Find(id);
            if (taskModel == null)
            {
                return NotFound();
            }

            return Ok(taskModel);
        }

        // GET: api/Task
        [Route("api/Task/QueryTaks")]
        [HttpGet]
        public IQueryable<TaskModel> GetTaskModels([FromUri]TaskQueryModel query)
        {

            //var taskResulst = db.Tasks.Include(x => x.ParentTask).Where(x => Matches(query, x));

            var taskResulst = db.Tasks.Include(x => x.ParentTask).Where(x => x.TaskDescription.StartsWith(query.TaskName));
            //Console.WriteLine(taskResulst.ToString());
            return taskResulst;
        }

        private bool Matches(TaskQueryModel query, TaskModel task)
        {
            var result = true;
            if (!string.IsNullOrEmpty(query.TaskName))
            {
                result = task.TaskDescription.StartsWith(query.TaskName);
            }
            if(!result && !string.IsNullOrEmpty(query.ParentTask))
            {
                result = task.ParentTask.Parent_Task == query.ParentTask;
            }
            if (!result && query.PriorityFrom.HasValue )
            {
                result = task.Priority >= query.PriorityFrom;
            }
            if (!result && query.PriorityTo.HasValue)
            {
                result = task.Priority <= query.PriorityTo;
            }
            if (!result && query.StartDate.HasValue)
            {
                result = task.StartDate >= query.StartDate;
            }
            if (!result && query.EndDate.HasValue)
            {
                result = task.EndDate <= query.EndDate;
            }
            return result;
        }

        // PUT: api/Task/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTaskModel(int id, TaskModel taskModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != taskModel.TaskId)
            {
                return BadRequest();
            }

            db.Entry(taskModel).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TaskModelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Task
        [ResponseType(typeof(TaskModel))]
        public IHttpActionResult PostTaskModel(TaskModel taskModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Tasks.Add(taskModel);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = taskModel.TaskId }, taskModel);
        }

        // DELETE: api/Task/5
        [ResponseType(typeof(TaskModel))]
        public IHttpActionResult DeleteTaskModel(int id)
        {
            TaskModel taskModel = db.Tasks.Find(id);
            if (taskModel == null)
            {
                return NotFound();
            }

            db.Tasks.Remove(taskModel);
            db.SaveChanges();

            return Ok(taskModel);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TaskModelExists(int id)
        {
            return db.Tasks.Count(e => e.TaskId == id) > 0;
        }
    }
}