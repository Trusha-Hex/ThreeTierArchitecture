using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using ZeroFormatter;
using ThreeTierApp.DAL.Enums;

namespace ThreeTierApp.DAL.Models
{
    [Table("employees")]
    [ZeroFormattable]  
    public class Employee
    {
        [Key]
        [Column("id")]
        //[IgnoreFormat]
        [Index(7)]
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
        //[IgnoreFormat]
        [Index(3)]
        public virtual string PasswordHash { get; set; }

        [Column("department")]
        //[IgnoreFormat]
        [Index(4)]
        public virtual int Department { get; set; }

        [Column("salary")]
        //[IgnoreFormat]
        [Index(5)]
        [Range(0, double.MaxValue, ErrorMessage = "Salary must be a positive value.")]
        public virtual decimal Salary { get; set; }

        [Column("role")]
        //[IgnoreFormat]
        [Index(6)]
        public virtual int Role { get; set; }

        [Column("date_of_joining")]
        [IgnoreFormat]
        public virtual DateTime DateOfJoining { get; set; } = DateTime.UtcNow; 

        [Column("is_active")]
        //[IgnoreFormat]
        [Index(8)]
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

        [NotMapped] // Ensures these properties are not mapped to database columns
        [IgnoreFormat]
        public virtual string RoleName => Enum.GetName(typeof(Role), (Role)Role);

        [NotMapped]
        [IgnoreFormat]
        public virtual string DepartmentName => Enum.GetName(typeof(Department), (Department)Department);

    }
}