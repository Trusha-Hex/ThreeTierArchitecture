using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ThreeTierApp.Core.Models
{
    [Table("employees")]
    public class Employee : IdentityUser<int>  // Inherit from IdentityUser
    {
        // Ignore the inherited Id property to avoid serialization conflict
        [JsonIgnore]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public new int Id { get; set; }  // Ensure it's an int

        [Required] // Ensures this field is not null
        [Column("name")]
        public string Name { get; set; }

        // Remove the conflicting "Username" property and use the inherited UserName from IdentityUser
        [JsonPropertyName("employee_user_name")]  // Custom serialization name to avoid collision
        public override string UserName { get; set; }  // Inherit from IdentityUser, and serialize with a custom name

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

        [Column("access_failed_count")]
        public int AccessFailedCount { get; set; }

        [Column("lockout_enabled")]
        public bool LockoutEnabled { get; set; }

        // Ignore the inherited LockoutEnd property to avoid serialization conflict
        [JsonIgnore]
        [Column("lockout_end")]
        public DateTime? LockoutEnd { get; set; }

        [Column("security_stamp")]
        public string SecurityStamp { get; set; }

        [Column("concurrency_stamp")]
        public string ConcurrencyStamp { get; set; }

        [Column("email_confirmed")]
        public bool EmailConfirmed { get; set; }

        [Column("normalized_email")]
        public string NormalizedEmail { get; set; }

        [Column("normalized_user_name")]
        public string NormalizedUserName { get; set; }

        [Column("phone_number")]
        public string PhoneNumber { get; set; }

        [Column("phone_number_confirmed")]
        public bool PhoneNumberConfirmed { get; set; }

        [Column("two_factor_enabled")]
        public bool TwoFactorEnabled { get; set; }
    }
}
