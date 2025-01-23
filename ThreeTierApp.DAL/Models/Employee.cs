using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using ZeroFormatter;

namespace ThreeTierApp.DAL.Models
{
    [Table("employees")]
    [ZeroFormattable]  
    public class Employee
    {
        [Key]
        [Column("id")]
        [IgnoreFormat]
        public virtual int Id { get; set; }  

        [Required] 
        [Column("name")]
        [Index(0)]  
        public virtual string Name { get; set; }

        [Required]
        [Column("username")]
        [MaxLength(50)] 
        [Index(1)]
        public virtual string Username { get; set; }

        [Required]
        [EmailAddress]
        [Column("email")]
        [Index(2)] 
        public virtual string Email { get; set; }

        [Required]
        [Column("password_hash")]
        [IgnoreFormat]
        public virtual string PasswordHash { get; set; }

        [Column("department")]
        [IgnoreFormat]
        public virtual string Department { get; set; }

        [Column("salary")]
        [IgnoreFormat]
        [Range(0, double.MaxValue, ErrorMessage = "Salary must be a positive value.")]
        public virtual decimal Salary { get; set; }

        [Column("role")]
        [IgnoreFormat]
        public virtual string Role { get; set; }

        [Column("date_of_joining")]
        [IgnoreFormat]
        public virtual DateTime DateOfJoining { get; set; } = DateTime.UtcNow; 

        [Column("is_active")]
        [IgnoreFormat]
        public virtual bool IsActive { get; set; } = true; 

        [Column("last_login")]
        [IgnoreFormat]
        public virtual DateTime? LastLogin { get; set; }

        [Column("created_at")]
        [IgnoreFormat]
        public virtual DateTime? CreatedAt { get; set; } = DateTime.UtcNow; 

        [Column("updated_at")]
        [IgnoreFormat]
        public virtual DateTime? UpdatedAt { get; set; } = DateTime.UtcNow; 
    }
}