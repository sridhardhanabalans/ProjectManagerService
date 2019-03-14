using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Entities
{
    [Table("Project")]
    public class Project
    {
        [Key]
        [JsonProperty("projectId")]
        public int Project_ID { get; set; }
        [Required]
        [JsonProperty("projectName")]
        [MaxLength(100)]
        public string ProjectName { get; set; }
        [JsonProperty("projectStartDate")]
        [Column(TypeName = "Date")]
        public DateTime? StartDate { get; set; }
        [JsonProperty("projectEndDate")]
        [Column(TypeName = "Date")]
        public DateTime? EndDate { get; set; }
        [JsonProperty("projectPriority")]
        public int Priority { get; set; }
        [NotMapped]
        [JsonProperty("projectUserId")]
        public int User_ID { get; set; }
        [NotMapped]
        [JsonProperty("projectTotalTasks")]
        public int projectTotalTasks { get; set; }
        [NotMapped]
        [JsonProperty("projectTasksCompleted")]
        public int projectTasksCompleted { get; set; }
        public ICollection<Task> Tasks { get; set; }
        public ICollection<User> Users { get; set; }

    }
}
