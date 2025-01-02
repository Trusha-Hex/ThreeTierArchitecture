namespace ThreeTierApp.Web.Models
{
    public class RegisterModel
    {
        // Employee-specific fields
        public string Name { get; set; }  // Employee's full name
        public string Username { get; set; }  // Username (this can be different from email)
        public string Department { get; set; }  // Department in which the employee works
        public decimal Salary { get; set; }  // Employee's salary
        public string Role { get; set; }  // Employee role (e.g., Admin, Manager, Employee)

        // Identity-specific fields
        public string Email { get; set; }  // Email used for login
        public string Password { get; set; }  // Password for login
        public string ConfirmPassword { get; set; }  // Confirm password to ensure correct input
    }
}
