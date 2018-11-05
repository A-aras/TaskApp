using ProjectManager.BusinessLayer;
using ProjectManager.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace ProjectManager.API.Controllers
{
    public class ProjectManagerController : ApiController
    {

        private IProjectManagerService pmService;

        public ProjectManagerController(IProjectManagerService pmService)
        {
            this.pmService = pmService;
        }


        // GET: api/Task
        [Route("api/User/GetUsers")]
        [HttpGet]
        public ICollection<UserModel> GetUsers()
        {
            var result = pmService.GetUsers();
            Console.WriteLine(result.ToString());
            return result;
        }

        [Route("api/User/AddUser")]
        [ResponseType(typeof(UserModel))]
        [HttpPost]
        public IHttpActionResult AddUser(UserModel user)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            UserModel userModel = pmService.GetUserById(user.UserId);
            if (userModel != null)
            {
                return BadRequest();
            }
            var result = pmService.AddUser(user);
            if (result != null)
            {
                return Ok();
            }
            return BadRequest();
        }

        [Route("api/User/UpdateUser")]
        [ResponseType(typeof(UserModel))]
        [HttpPost]
        public IHttpActionResult UpdateUser(UserModel user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            UserModel userModel = pmService.GetUserById(user.UserId);
            if (userModel != null)
            {
                return BadRequest();
            }
            var result = pmService.UpdateUser(user);

            if (result != null)
            {
                return StatusCode(HttpStatusCode.OK);
            }
            return BadRequest();
        }

        [Route("api/User/DeleteUser")]
        [ResponseType(typeof(UserModel))]
        [HttpDelete]
        public IHttpActionResult DeleteUser(UserModel user)
        {

            UserModel userModel = pmService.GetUserById(user.UserId);
            if (userModel == null)
            {
                return NotFound();
            }
            var result = pmService.DeleteUser(user);

            if (result)
            {
                return Ok(userModel);
            }
            return BadRequest();
        }

    }
}
