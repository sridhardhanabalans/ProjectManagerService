using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TaskManager.DL;
using TaskManager.Entities;

namespace TaskManager.BL
{
    public class BusinessLayer
    {
        DataLayer dalObj = null;
   
        #region Tasks
        // Get All Tasks Method
        public List<Task> GetAllTasks()
        {
            dalObj = new DataLayer();
            List<Task> allTasks = dalObj.GetAllTasks();
            List<ParentTask> parentTasks=dalObj.GetAllParentTasks();
            List<Task> finalTasks = new List<Task>();
            foreach (Task task in allTasks)
            {
                if (task.Parent_ID != null)
                {
                    task.Parent = parentTasks.Where(m => m.Parent_ID == task.Parent_ID).FirstOrDefault();
                }
                finalTasks.Add(task);
            }
            return finalTasks;
        }

        //Get All Parent Tasks
        public List<ParentTask> GetAllParentTasks()
        {
            dalObj = new DataLayer();
            return dalObj.GetAllParentTasks();
        }

        //Add New Task
        public void AddTask(Task newTask)
        {
            dalObj = new DataLayer();
            dalObj.AddTask(newTask);
        }

        //Update Existing Task Method
        public void UpdateTask(Task editTask)
        {
            dalObj = new DataLayer();
            dalObj.UpdateTask(editTask);
        }

        //Delete Existing Task Method
        public void DeleteTask(int id)
        {
            dalObj = new DataLayer();
            dalObj.DeleteTask(id);
        }

        #endregion

        #region Projects
        //Get List of all projects
        public List<Project> GetAllProjects()
        {
            dalObj = new DataLayer();
            List<Project> allProjects = dalObj.GetAllProjects();
            List<User> allUsers = dalObj.GetAllUsers();
            List<Project> finalProjects = new List<Project>();
            foreach (Project project in allProjects)
            {
                foreach(User user in allUsers)
                {
                    if (user.Project_ID == project.Project_ID && user.Task_ID == null && user.User_ID > 0)
                    {
                        project.User_ID = user.User_ID;

                    }
                    
                }
                //if(allUsers("Project_ID").Project_ID==project.Project_ID && )
                //project.User_ID = allUsers.Where(m => m.Project_ID == project.Project_ID && m.Task_ID == null && m.User_ID>0).FirstOrDefault().User_ID;
                //project.User_ID = allUsers.Where(m => m.Project_ID == project.Project_ID && m.Task_ID == null).FirstOrDefault().User_ID;
                project.projectTotalTasks = allUsers.Where(m => m.Project_ID == project.Project_ID && m.Task_ID != null).Count();
                project.projectTasksCompleted = dalObj.GetCompletedTasksByProjectId(project.Project_ID).Count();
                finalProjects.Add(project);
            }
            return finalProjects;
        }

        //Add New Project
        public void AddProject(Project newProject)
        {
            dalObj = new DataLayer();
            dalObj.AddProject(newProject);
        }

        //Update Exisitng Project
        public void UpdateProject(Project editProject)
        {
            dalObj = new DataLayer();
            dalObj.UpdateProject(editProject);
        }

        //Delete Existing Project
        public void DeleteProject(int id)
        {
            dalObj = new DataLayer();
            dalObj.DeleteProject(id);
        }
        #endregion

        #region Users
        //Get all Users  Method returns List
        public List<User> GetAllUsers()
        {
            dalObj = new DataLayer();
            return dalObj.GetAllUsers();
        }

        // Add New User 
        public void AddUser(User newUser)
        {
            dalObj = new DataLayer();
            dalObj.AddUser(newUser);
        }
        // Update Existing User
        public void UpdateUser(User editUser)
        {
            dalObj = new DataLayer();
            dalObj.UpdateUser(editUser);
        }
        //Delete Existing User
        public void DeleteUser(int id)
        {
            dalObj = new DataLayer();
            dalObj.DeleteUser(id);
        }
        #endregion
    }
}
