using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TaskManager.Entities;

namespace TaskManager.DL
{
    public class DataLayer
    {
        #region Tasks
        //Get List of All Tasks
        public List<Task> GetAllTasks()
        {
            ProjectManagerContext pmContext = new ProjectManagerContext();
            return pmContext.Tasks.ToList();
        }
        //Get List of All Parent Tasks
        public List<ParentTask> GetAllParentTasks()
        {
            ProjectManagerContext pmContext = new ProjectManagerContext();
            return pmContext.ParentTasks.ToList();
        }
        //Get Completed Tasks by Project Id
        public List<Task> GetCompletedTasksByProjectId(int projectId)
        {
            ProjectManagerContext pmContext = new ProjectManagerContext();
            var tasks = pmContext.Tasks.Where(m => m.Project_ID == projectId && m.End_Date > DateTime.Now);
            return tasks.ToList();
        }

        // Add Tasks
        public void AddTask(Task newTask)
        {
            ProjectManagerContext pmContext = new ProjectManagerContext();
            pmContext.Tasks.Add(newTask);
            pmContext.SaveChanges();

            var existingUser = pmContext.Users.Where(m => m.User_ID == newTask.User_ID).FirstOrDefault();

            User newUser = new User();
            newUser.User_ID = 0;
            newUser.FirstName = existingUser.FirstName;
            newUser.LastName = existingUser.LastName;
            newUser.Project_ID = newTask.Project_ID;
            newUser.Employee_ID = existingUser.Employee_ID;
            newUser.Task_ID = newTask.Task_ID;
            pmContext.Users.Add(newUser);
            pmContext.SaveChanges();
        }

        // Update Tasks
        public void UpdateTask(Task editTask)
        {
            ProjectManagerContext pmContext = new ProjectManagerContext();
            var existingTask = pmContext.Tasks.Where(m => m.Task_ID == editTask.Task_ID).FirstOrDefault();

            existingTask.Parent_ID = editTask.Parent_ID;
            existingTask.TaskName = editTask.TaskName;
            existingTask.Start_Date = editTask.Start_Date;
            existingTask.End_Date = editTask.End_Date;
            existingTask.Priority = editTask.Priority;

            pmContext.SaveChanges();

            var newUser = pmContext.Users.Where(m => m.User_ID == editTask.User_ID).FirstOrDefault();

            var existingUser = pmContext.Users.Where(m => m.Task_ID == editTask.Task_ID).FirstOrDefault();
            existingUser.Employee_ID = newUser.Employee_ID;
            existingUser.FirstName = newUser.FirstName;
            existingUser.LastName = newUser.LastName;
            pmContext.SaveChanges();
        }

        // delete Tasks Method
        public void DeleteTask(int id)
        {
            ProjectManagerContext pmContext = new ProjectManagerContext();
            var existingUser = pmContext.Users.Where(m => m.Task_ID == id).FirstOrDefault();
            existingUser.Task_ID = null;
            pmContext.SaveChanges();

            var deleteTask = pmContext.Tasks.Where(m => m.Task_ID == id).FirstOrDefault();
            pmContext.Tasks.Remove(deleteTask);
            pmContext.SaveChanges();
        }

        #endregion

        //Get List of all projects
        #region Projects
        public List<Project> GetAllProjects()
        {
            ProjectManagerContext pmContext = new ProjectManagerContext();
            return pmContext.Projects.ToList();
        }

        // Add New Project
        public void AddProject(Project newProject)
        {
            ProjectManagerContext pmContext = new ProjectManagerContext();
            pmContext.Projects.Add(newProject);
            pmContext.SaveChanges();

            var existingUser = pmContext.Users.Where(m => m.User_ID == newProject.User_ID).FirstOrDefault();
            
            User newUser = new User();
            newUser.User_ID = 0;
            newUser.FirstName = existingUser.FirstName;
            newUser.LastName = existingUser.LastName;
            newUser.Project_ID = newProject.Project_ID;
            newUser.Employee_ID = existingUser.Employee_ID;
            pmContext.Users.Add(newUser);
            pmContext.SaveChanges();
        }


        // Update Existing Project
        public void UpdateProject(Project editProject)

        {
            ProjectManagerContext pmContext = new ProjectManagerContext();
            var existingProject = pmContext.Projects.Where(m => m.Project_ID == editProject.Project_ID).FirstOrDefault();

            existingProject.Project_ID = editProject.Project_ID;
            existingProject.ProjectName = editProject.ProjectName;
            existingProject.StartDate = editProject.StartDate;
            existingProject.EndDate = editProject.EndDate;
            existingProject.Priority = editProject.Priority;

            pmContext.SaveChanges();

            var newUser = pmContext.Users.Where(m => m.User_ID == editProject.User_ID).FirstOrDefault();
            
            var existingUser = pmContext.Users.Where(m => m.Project_ID == editProject.Project_ID && m.Task_ID==null).FirstOrDefault();
            existingUser.Employee_ID = newUser.Employee_ID;
            existingUser.FirstName = newUser.FirstName;
            existingUser.LastName = newUser.LastName;
            pmContext.SaveChanges();

        }

        //Delete Existing project Method
        public void DeleteProject(int id)
        {
            ProjectManagerContext pmContext = new ProjectManagerContext();
            var existingUser = pmContext.Users.Where(m => m.Project_ID == id && m.Task_ID == null).FirstOrDefault();
            existingUser.Project_ID = null;
            pmContext.SaveChanges();

            var deleteProject = pmContext.Projects.Where(m => m.Project_ID == id).FirstOrDefault();
            pmContext.Projects.Remove(deleteProject);
            pmContext.SaveChanges();
        }
        #endregion

        #region Users
        // Get List of All Users
        public List<User> GetAllUsers()
        {
            ProjectManagerContext pmContext = new ProjectManagerContext();
            return pmContext.Users.ToList();
        }

        //Add New Users
        public void AddUser(User newUser)
        {
            ProjectManagerContext pmContext = new ProjectManagerContext();
            pmContext.Users.Add(newUser);
            pmContext.SaveChanges();
        }

        // Update Existing User
        public void UpdateUser(User editUser)
        {
            ProjectManagerContext pmContext = new ProjectManagerContext();
            var existingUser = pmContext.Users.Where(m => m.User_ID == editUser.User_ID).FirstOrDefault();

            existingUser.Project_ID = editUser.Project_ID;
            existingUser.FirstName = editUser.FirstName;
            existingUser.LastName = editUser.LastName;
            existingUser.Employee_ID = editUser.Employee_ID;

            pmContext.SaveChanges();
        }

        //Delete User
        public void DeleteUser(int id)
        {
            ProjectManagerContext pmContext = new ProjectManagerContext();
            var deleteUser = pmContext.Users.Where(m => m.User_ID == id).FirstOrDefault();
            pmContext.Users.Remove(deleteUser);
            pmContext.SaveChanges();
        }
        #endregion
    }
}
