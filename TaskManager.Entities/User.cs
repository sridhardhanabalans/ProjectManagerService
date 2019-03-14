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
    [Table("User")]
    public class User
    {
        [Key]
        [JsonProperty("userId")]
        public int User_ID { get; set; }
        [Required]
        [MaxLength(100)]
        [JsonProperty("firstName")]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(100)]
        [JsonProperty("lastName")]
         public string LastName { get; set; }
        [Required]
        [JsonProperty("employeeId")]
        public int Employee_ID { get; set; }
        [JsonProperty("projectId")]
        public int? Project_ID { get; set; }
        [JsonProperty("taskId")]
        public int? Task_ID { get; set; }
        public Task Task { get; set; }
        public Project Project { get; set; }
    }
}
