using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ThreeTierApp.DAL.Models
{
    [Table("tasks")]
    public class TaskDetails
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [Column("title")]
        public string Title { get; set; }

        [Column("description")]
        public string Description { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; }

        [Column("due_date")]
        public DateTime? DueDate { get; set; }

        [Column("is_completed")]
        public bool IsCompleted { get; set; }

        [Column("assigned_employee_ids")]
        public List<int> AssignedEmployeeIds { get; set; }

        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; }
    }
}
