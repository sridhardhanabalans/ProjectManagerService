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
    [Table("ParentTask")]
    public class ParentTask
    {
        [Key]
        [JsonProperty(PropertyName = "taskId")]
        public int Parent_ID { get; set; }
        [Required]
        [MaxLength(100)]
        [JsonProperty(PropertyName = "taskName")]
        public string Parent_Task { get; set; }
        public ICollection<Task> Tasks { get; set; }
    }
}
