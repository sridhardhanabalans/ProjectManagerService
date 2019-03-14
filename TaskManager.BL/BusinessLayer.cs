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

        public List<ParentTask> GetAllParentTasks()
        {
            dalObj = new DataLayer();
            return dalObj.GetAllParentTasks();
        }

        public void AddTask(Task newTask)
        {
            dalObj = new DataLayer();
            dalObj.AddTask(newTask);
        }

        public void UpdateTask(Task editTask)
        {
            dalObj = new DataLayer();
            dalObj.UpdateTask(editTask);
        }

        public void DeleteTask(int id)
        {
            dalObj = new DataLayer();
            dalObj.DeleteTask(id);
        }

        #endregion

        #region Projects
        public List<Project> GetAllProjects()
        {
            dalObj = new DataLayer();
            List<Project> allProjects = dalObj.GetAllProjects();
            List<User> allUsers = dalObj.GetAllUsers();
            List<Project> finalProjects = new List<Project>();
            foreach (Project project in allProjects)
            {
                //project.User_ID = allUsers.Where(m => m.Project_ID == project.Project_ID && m.Task_ID == null).FirstOrDefault().User_ID;
                project.projectTotalTasks = allUsers.Where(m => m.Project_ID == project.Project_ID && m.Task_ID != null).Count();
                project.projectTasksCompleted = dalObj.GetCompletedTasksByProjectId(project.Project_ID).Count();
                finalProjects.Add(project);
            }
            return finalProjects;
        }

        public void AddProject(Project newProject)
        {
            dalObj = new DataLayer();
            dalObj.AddProject(newProject);
        }

        public void UpdateProject(Project editProject)
        {
            dalObj = new DataLayer();
            dalObj.UpdateProject(editProject);
        }

        public void DeleteProject(int id)
        {
            dalObj = new DataLayer();
            dalObj.DeleteProject(id);
        }
        #endregion

        #region Users
        public List<User> GetAllUsers()
        {
            dalObj = new DataLayer();
            return dalObj.GetAllUsers();
        }

        public void AddUser(User newUser)
        {
            dalObj = new DataLayer();
            dalObj.AddUser(newUser);
        }

        public void UpdateUser(User editUser)
        {
            dalObj = new DataLayer();
            dalObj.UpdateUser(editUser);
        }

        public void DeleteUser(int id)
        {
            dalObj = new DataLayer();
            dalObj.DeleteUser(id);
        }
        #endregion
    }
}
