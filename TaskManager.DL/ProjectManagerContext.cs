using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using TaskManager.Entities;

namespace TaskManager.DL
{
    class ProjectManagerContext : DbContext
    {
        public ProjectManagerContext() : base("ProjectManagerConnection")
        {
        }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<ParentTask> ParentTasks { get; set; }
    }
}
