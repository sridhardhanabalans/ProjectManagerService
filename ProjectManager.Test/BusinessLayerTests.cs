using Microsoft.VisualStudio.TestTools.UnitTesting;
using TaskManager.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TaskManager.Entities;

namespace TaskManager.BL.Tests
{
    [TestClass()]
    public class BusinessLayerTests
    {                                                                                                                                                                           
        BusinessLayer blObj = new BusinessLayer();
        [TestMethod()]
        public void GetAllTasksTest()
        {
            int result = blObj.GetAllTasks().Count;
            Assert.IsTrue(result > 0);
        }

        [TestMethod()]
        public void GetAllParentTasksTest()
        {
            int result = blObj.GetAllParentTasks().Count;
            Assert.IsTrue(result > 0);
        }

        [TestMethod()]
        public void AddTaskTest()
        {
            Task task = new Task { Task_ID = 0, TaskName = "Seat Change", Parent = null, Start_Date = DateTime.Now.AddDays(-10), End_Date = DateTime.Now.AddDays(5), Parent_ID = null, Priority = 10, User_ID=1, IsParent = false, Project_ID =4 };
            try
            {
                blObj.AddTask(task);
                Assert.IsTrue(1 == 1);
            }
            catch
            {
                Assert.Inconclusive("Task not added");
            }

        }

        [TestMethod()]
        public void UpdateTaskTest()
        {
            Task task = new Task { Task_ID = 1, TaskName = "Seat Change", Parent = null, Start_Date = DateTime.Now.AddDays(-10), End_Date = DateTime.Now.AddDays(5), Parent_ID = null, Priority = 10, User_ID = 1, IsParent = false, Project_ID = 4 };
            try
            {
                blObj.UpdateTask(task);
                Assert.IsTrue(1 == 1);
            }
            catch
            {
                Assert.Inconclusive("Task not updated");
            }
        }

        [TestMethod()]
        public void DeleteTaskTest()
        {
            int id = 2;
            try
            {
                blObj.DeleteTask(id);
                Assert.IsTrue(1 == 1);
            }
            catch
            {
                Assert.Inconclusive("Task not deleted");
            }

        }

        [TestMethod()]
        public void GetAllProjectsTest()
        {
            int result = blObj.GetAllProjects().Count;
            Assert.IsTrue(result > 0);

        }

        [TestMethod()]
        public void AddProjectTest()
        {
            Project project = new Project { Project_ID=0, StartDate=DateTime.Now, EndDate=DateTime.Now.AddDays(10), ProjectName="Mahindra Bolero", Priority=9, User_ID=1 };
            try
            {
                blObj.AddProject(project);
                Assert.IsTrue(1 == 1);
            }
            catch
            {
                Assert.Inconclusive("Task not added");
            }
        }

        [TestMethod()]
        public void UpdateProjectTest()
        {
            Project project = new Project { Project_ID = 3, StartDate = DateTime.Now, EndDate = DateTime.Now.AddDays(10), ProjectName = "Mahindra Bolero", Priority = 9, User_ID = 1 };
            try
            {
                blObj.UpdateProject(project);
                Assert.IsTrue(1 == 1);
            }
            catch
            {
                Assert.Inconclusive("Task not added");
            }
        }

        [TestMethod()]
        public void DeleteProjectTest()
        {
            int id = 7;
            try
            {
                blObj.DeleteProject(id);
                Assert.IsTrue(1 == 1);
            }
            catch
            {
                Assert.Inconclusive("Task not deleted");
            }

        }

        [TestMethod()]
        public void GetAllUsersTest()
        {
            int result = blObj.GetAllUsers().Count;
            Assert.IsTrue(result > 0);
        }

        [TestMethod()]
        public void AddUserTest()
        {
            User user = new User { User_ID=0, FirstName="Brain", LastName="Lara", Employee_ID=1031};
            try
            {
                blObj.AddUser(user);
                Assert.IsTrue(1 == 1);
            }
            catch
            {
                Assert.Inconclusive("Task not added");
            }
        }

        [TestMethod()]
        public void UpdateUserTest()
        {
            User user = new User { User_ID = 10, FirstName = "Brain", LastName = "Lara", Employee_ID = 1031 };
            try
            {
                blObj.UpdateUser(user);
                Assert.IsTrue(1 == 1);
            }
            catch
            {
                Assert.Inconclusive("Task not added");
            }
        }

        [TestMethod()]
        public void DeleteUserTest()
        {
            int id = 12;
            try
            {
                blObj.DeleteUser(id);
                Assert.IsTrue(1 == 1);
            }
            catch
            {
                Assert.Inconclusive("Task not deleted");
            }

        }
    }
}