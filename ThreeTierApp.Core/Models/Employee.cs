using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ThreeTierApp.Core.Models
{
    [Table("employees")]
    public class Employee
    {
        [Key] // Specifies the primary key
        [Column("id")]
        public int Id { get; set; }

        [Required] // Ensures this field is not null
        [Column("name")]
        public string Name { get; set; }

        [Required]
        [Column("username")]
        [MaxLength(50)] // Restricts username length to 50 characters
        public string Username { get; set; }

        [Required]
        [EmailAddress] // Ensures the field is a valid email format
        [Column("email")]
        public string Email { get; set; }

        [Required]
        [Column("password_hash")]
        public string PasswordHash { get; set; } // Store the hashed password

        [Column("department")]
        public string Department { get; set; }

        [Column("salary")]
        [Range(0, double.MaxValue, ErrorMessage = "Salary must be a positive value.")]
        public decimal Salary { get; set; }

        [Column("role")]
        public string Role { get; set; } // e.g., Admin, Manager, Employee

        [Column("date_of_joining")]
        public DateTime DateOfJoining { get; set; } = DateTime.UtcNow; // Default to current UTC date

        [Column("is_active")]
        public bool IsActive { get; set; } = true; // For soft deletes or account activation status

        [Column("last_login")]
        public DateTime? LastLogin { get; set; } // Nullable to track login history

        [Column("created_at")]
        public DateTime? CreatedAt { get; set; } = DateTime.UtcNow; // Automatically set on creation

        [Column("updated_at")]
        public DateTime? UpdatedAt { get; set; } = DateTime.UtcNow; // Automatically update when modified
    }
}
