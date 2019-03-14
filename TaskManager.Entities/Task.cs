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
    [Table("Task")]
    public class Task
    {
        [Key]
        [JsonProperty(PropertyName = "taskId")]
        public int Task_ID { get; set; }
        [JsonProperty(PropertyName = "parentId")]
        public int? Parent_ID { get; set; }
        [Column("Task")]
        [MaxLength(100)]
        [JsonProperty(PropertyName = "taskName")]
        public string TaskName { get; set; }
        [JsonProperty(PropertyName = "projectId")]
        public int Project_ID { get; set; }
        [NotMapped]
        [JsonProperty(PropertyName = "userId")]
        public int User_ID { get; set; }
        [NotMapped]
        [JsonProperty(PropertyName = "isParentTask")]
        public bool IsParent { get; set; }
        [Column(TypeName = "Date")]
        [JsonProperty(PropertyName = "startDate")]
        public DateTime? Start_Date { get; set; }
        [Column(TypeName = "Date")]
        [JsonProperty(PropertyName = "endDate")]
        public DateTime? End_Date { get; set; }
        [JsonProperty(PropertyName = "priority")]
        public int Priority { get; set; }
        [JsonProperty(PropertyName = "parent")]
        [ForeignKey("Parent_ID")]
        public ParentTask Parent { get; set; }
        public Project Project { get; set; }

    }
}
