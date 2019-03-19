using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using TaskManager.BL;
using TaskManager.Entities;

namespace TaskManager.API.Controllers
{
    public class ValuesController : ApiController
    {
        BusinessLayer blObject = null;

        [HttpGet]
        //Method for Getting all Tasks
        [Route("api/Values/GetAllTasks")]
        [ResponseType(typeof(List<Task>))]
        public IHttpActionResult GetAllTasks()
        {
            blObject = new BusinessLayer();
            List<Task> tasks = blObject.GetAllTasks();
            return Ok(tasks);
        }

        [HttpGet]
        //Method for Getting all Parent Tasks
        [Route("api/Values/GetAllParentTasks")]
        [ResponseType(typeof(List<ParentTask>))]
        public IHttpActionResult GetAllParentTasks()
        {
            blObject = new BusinessLayer();
            List<ParentTask> tasks = blObject.GetAllParentTasks();
            return Ok(tasks);
        }

        [HttpPost]
        [Route("api/Values/AddTask")]
        //Method for Adding  new Task Item
        [ResponseType(typeof(void))]
        public IHttpActionResult AddTask([FromBody]Task newTask)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            blObject = new BusinessLayer();
            blObject.AddTask(newTask);
            return Ok();
        }

        [HttpPut]
        [Route("api/Values/UpdateTask")]
        //Method for Updating Existing Task Item
        [ResponseType(typeof(void))]
        public IHttpActionResult UpdateTask([FromBody]Task editTask)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            blObject = new BusinessLayer();
            blObject.UpdateTask(editTask);
            return Ok();
        }

        [HttpDelete]
        //Method for Deleting Existing Task Item
        [Route("api/Values/DeleteTask/{Id}")]
        [ResponseType(typeof(void))]
        public IHttpActionResult DeleteTask(int Id)
        {
            blObject = new BusinessLayer();
            blObject.DeleteTask(Id);
            return Ok();
        }

        [HttpGet]
        //Method for Retrieving all Users
        [Route("api/Values/GetAllUsers")]
        [ResponseType(typeof(List<User>))]
        public IHttpActionResult GetAllUsers()
        {
            blObject = new BusinessLayer();
            List<User> users = blObject.GetAllUsers();
            return Ok(users);
        }

        [HttpPost]
        [Route("api/Values/AddUser")]
        //Method for Adding New User
        [ResponseType(typeof(void))]
        public IHttpActionResult AddUser([FromBody]User newUser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            blObject = new BusinessLayer();
            blObject.AddUser(newUser);
            return Ok();
        }

        [HttpPut]
        //Method for Updating Existing User
        [Route("api/Values/UpdateUser")]
        [ResponseType(typeof(void))]
        public IHttpActionResult UpdateUser([FromBody]User editUser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            blObject = new BusinessLayer();
            blObject.UpdateUser(editUser);
            return Ok();
        }

        [HttpDelete]
        //Method for Deleting Existing User
        [Route("api/Values/DeleteUser/{Id}")]
        [ResponseType(typeof(void))]
        public IHttpActionResult DeleteUser(int Id)
        {
            blObject = new BusinessLayer();
            blObject.DeleteUser(Id);
            return Ok();
        }

        [HttpGet]
        //Method for Retrieving all projects
        [Route("api/Values/GetAllProjects")]
        [ResponseType(typeof(List<Project>))]
        public IHttpActionResult GetAllProjects()
        {
            blObject = new BusinessLayer();
            List<Project> projects = blObject.GetAllProjects();
            return Ok(projects);
        }

        [HttpPost]
        //Method for Adding New Project
        [Route("api/Values/AddProject")]
        [ResponseType(typeof(void))]
        public IHttpActionResult AddProject([FromBody]Project newProject)
        {
            blObject = new BusinessLayer();
            blObject.AddProject(newProject);
            return Ok();
        }

        [HttpPut]
        //Method for Updating Existing Project
        [Route("api/Values/UpdateProject")]
        [ResponseType(typeof(void))]
        public IHttpActionResult UpdateProject([FromBody]Project editProject)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            blObject = new BusinessLayer();
            blObject.UpdateProject(editProject);
            return Ok();
        }

        [HttpDelete]
        //Method for Deleting Existing Project
        [Route("api/Values/DeleteProject/{Id}")]
        [ResponseType(typeof(void))]
        public IHttpActionResult DeleteProject(int Id)
        {
            blObject = new BusinessLayer();
            blObject.DeleteProject(Id);
            return Ok();
        }
    }
}
