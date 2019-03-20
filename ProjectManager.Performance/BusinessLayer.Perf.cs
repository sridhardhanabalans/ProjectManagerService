using NBench;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TaskManager.BL;
using TaskManager.Entities;

namespace ProjectManager.Performance
{
    public class BusinessLayerPerf
    {
        BusinessLayer blObj = new BusinessLayer();
        
        [PerfBenchmark(Description = "To check the garbage collections efficiency", NumberOfIterations = 1, RunMode = RunMode.Throughput, TestMode = TestMode.Test, SkipWarmups = true)]
        [GcTotalAssertion(GcMetric.TotalCollections, GcGeneration.Gen2, MustBe.ExactlyEqualTo, 0.0d)]
        //Performance Method used for Getting all Tasks
        public void GetAllTasksTest()
        {
            blObj.GetAllTasks();
        }

        [PerfBenchmark(Description = "To find out the performance of the garbage collector", NumberOfIterations = 5, RunMode = RunMode.Iterations, TestMode = TestMode.Measurement)]
        [GcMeasurement(GcMetric.TotalCollections, GcGeneration.AllGc)]
        //Performance Method used for Getting all Parent Tasks
        public void GetAllParentTasksTest()
        {
            blObj.GetAllParentTasks();

        }

        [PerfBenchmark(Description = "To check if the operation executes within 5 seconds", NumberOfIterations = 5, RunMode = RunMode.Throughput, TestMode = TestMode.Test, SkipWarmups = true)]
        [ElapsedTimeAssertion(MaxTimeMilliseconds = 5000)]
        //Performance Method used for Adding new Tasks
        public void AddTaskTest()
        {
            Task task = new Task { Task_ID = 0, TaskName = "Seat Change", Parent = null, Start_Date = DateTime.Now.AddDays(-10), End_Date = DateTime.Now.AddDays(5), Parent_ID = null, Priority = 10, User_ID = 1, IsParent = false, Project_ID = 4 };
            blObj.AddTask(task);
        }

        [PerfBenchmark(Description = "To verify if the memory allocated inside the block is more than 64 KB", NumberOfIterations = 3, RunMode = RunMode.Throughput, TestMode = TestMode.Test, SkipWarmups = true)]
        [MemoryAssertion(MemoryMetric.TotalBytesAllocated, MustBe.GreaterThanOrEqualTo, ByteConstants.SixtyFourKb)]
        //Performance Method used for Updating Existing Task
        public void UpdateTaskTest()
        {
            Task task = new Task { Task_ID = 1, TaskName = "Seat Change", Parent = null, Start_Date = DateTime.Now.AddDays(-10), End_Date = DateTime.Now.AddDays(5), Parent_ID = null, Priority = 10, User_ID = 1, IsParent = false, Project_ID = 4 };
            blObj.UpdateTask(task);
        }

        [PerfBenchmark(Description = "To find out the performance of the garbage collector", NumberOfIterations = 1, RunMode = RunMode.Iterations, TestMode = TestMode.Measurement)]
        [GcMeasurement(GcMetric.TotalCollections, GcGeneration.AllGc)]
        //Performance Method used for Delete Existing Task
        public void DeleteTaskTest()
        {
            int id = 2;
            blObj.DeleteTask(id);

        }

        [PerfBenchmark(Description = "To check the garbage collections efficiency", NumberOfIterations = 1, RunMode = RunMode.Throughput, TestMode = TestMode.Test, SkipWarmups = true)]
        [GcTotalAssertion(GcMetric.TotalCollections, GcGeneration.Gen2, MustBe.ExactlyEqualTo, 0.0d)]
        //Performance Method used for  Fetching All Projects
        public void GetAllProjectsTest()
        {
            blObj.GetAllProjects();
        }
        
        [PerfBenchmark(Description = "To check if the operation executes within 5 seconds", NumberOfIterations = 5, RunMode = RunMode.Throughput, TestMode = TestMode.Test, SkipWarmups = true)]
        [ElapsedTimeAssertion(MaxTimeMilliseconds = 5000)]
        //Performance Method used for adding new Projects

        public void AddProjectTest()
        {
            Project project = new Project { Project_ID = 0, StartDate = DateTime.Now, EndDate = DateTime.Now.AddDays(10), ProjectName = "Mahindra Bolero", Priority = 9, User_ID = 1 };
            blObj.AddProject(project);
        }

        [PerfBenchmark(Description = "To verify if the memory allocated inside the block is more than 64 KB", NumberOfIterations = 3, RunMode = RunMode.Throughput, TestMode = TestMode.Test, SkipWarmups = true)]
        [MemoryAssertion(MemoryMetric.TotalBytesAllocated, MustBe.GreaterThanOrEqualTo, ByteConstants.SixtyFourKb)]
        //Performance Method used for updating existing Projects

        public void UpdateProjectTest()
        {
            Project project = new Project { Project_ID = 3, StartDate = DateTime.Now, EndDate = DateTime.Now.AddDays(10), ProjectName = "Mahindra Bolero", Priority = 9, User_ID = 1 };
            blObj.UpdateProject(project);
        }

        [PerfBenchmark(Description = "To find out the performance of the garbage collector", NumberOfIterations = 1, RunMode = RunMode.Iterations, TestMode = TestMode.Measurement)]
        [GcMeasurement(GcMetric.TotalCollections, GcGeneration.AllGc)]
        //Performance Method used for deleting existing Projects
        public void DeleteProjectTest()
        {
            int id = 7;
            blObj.DeleteProject(id);

        }

        [PerfBenchmark(Description = "To check the garbage collections efficiency", NumberOfIterations = 1, RunMode = RunMode.Throughput, TestMode = TestMode.Test, SkipWarmups = true)]
        [GcTotalAssertion(GcMetric.TotalCollections, GcGeneration.Gen2, MustBe.ExactlyEqualTo, 0.0d)]
        //Performance Method used for retrieving all Users

        public void GetAllUsersTest()
        {
            blObj.GetAllUsers();
        }

        [PerfBenchmark(Description = "To check if the operation executes within 5 seconds", NumberOfIterations = 5, RunMode = RunMode.Throughput, TestMode = TestMode.Test, SkipWarmups = true)]
        [ElapsedTimeAssertion(MaxTimeMilliseconds = 5000)]

        //Performance Method used for adding new Users
        public void AddUserTest()
        {
            User user = new User { User_ID = 0, FirstName = "Brain", LastName = "Lara", Employee_ID = 1031 };
            blObj.AddUser(user);
        }

        [PerfBenchmark(Description = "To verify if the memory allocated inside the block is more than 64 KB", NumberOfIterations = 3, RunMode = RunMode.Throughput, TestMode = TestMode.Test, SkipWarmups = true)]
        [MemoryAssertion(MemoryMetric.TotalBytesAllocated, MustBe.GreaterThanOrEqualTo, ByteConstants.SixtyFourKb)]
        //Performance Method used for updating existing User

        public void UpdateUserTest()
        {
            User user = new User { User_ID = 10, FirstName = "Brain", LastName = "Lara", Employee_ID = 1031 };
            blObj.UpdateUser(user);
        }

        [PerfBenchmark(Description = "To find out the performance of the garbage collector", NumberOfIterations = 1, RunMode = RunMode.Iterations, TestMode = TestMode.Measurement)]
        [GcMeasurement(GcMetric.TotalCollections, GcGeneration.AllGc)]

        //Performance Method used for deletiong existing User
        public void DeleteUserTest()
        {
            int id = 12;
            blObj.DeleteUser(id);

        }
    }
}
