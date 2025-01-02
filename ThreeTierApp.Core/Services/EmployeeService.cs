using ThreeTierApp.Core.Interfaces;  // For IEmployeeRepository
using ThreeTierApp.Core.Models;      // For Employee model
using System.Collections.Generic;
using System.Linq;                   // For LINQ
using System.Threading.Tasks;
using System;

namespace ThreeTierApp.Core.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _repository;

        public EmployeeService(IEmployeeRepository repository)
        {
            _repository = repository;
        }

        // Get all employees
        public async Task<IEnumerable<Employee>> GetAllEmployeesAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Employee> GetEmployeeByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }


        // Get employee by ID
        //public async Task<Employee> GetEmployeeByIdAsync(int id)
        //{
        //    if (id <= 0)
        //        throw new ArgumentException("Employee ID must be greater than 0.");

        //    return await _repository.GetByIdAsync(id)
        //        ?? throw new KeyNotFoundException($"Employee with ID {id} not found.");
        //}

        // Get employee by username
        public async Task<Employee> GetEmployeeByUsernameAsync(string username)
        {
            if (string.IsNullOrWhiteSpace(username))
                throw new ArgumentException("Username cannot be empty.");

            return await _repository.GetByUsernameAsync(username)
                ?? throw new KeyNotFoundException($"Employee with username '{username}' not found.");
        }

        // Get employees by role
        public async Task<IEnumerable<Employee>> GetEmployeesByRoleAsync(string role)
        {
            if (string.IsNullOrWhiteSpace(role))
                throw new ArgumentException("Role cannot be empty.");

            return await _repository.GetByRoleAsync(role);
        }

        // Get active employees
        public async Task<IEnumerable<Employee>> GetActiveEmployeesAsync()
        {
            return await _repository.GetActiveEmployeesAsync();
        }

        // Add a new employee with validations
        public async Task<ValidationErrorResponse> AddEmployeeAsync(Employee employee)
        {
            var validationErrors = ValidateEmployeeForAddOrUpdate(employee);

            // If there are validation errors, return them
            if (validationErrors.Errors.Any())
            {
                return validationErrors;
            }

            // No validation errors, proceed to add the employee
            employee.PasswordHash = HashPassword(employee.PasswordHash); // Hash the password
            employee.CreatedAt = DateTime.UtcNow; // Set creation timestamp
            employee.UpdatedAt = DateTime.UtcNow; // Set update timestamp

            await _repository.AddAsync(employee);

            return null; // No validation errors
        }

        // Update an existing employee
        public async Task<ValidationErrorResponse> UpdateEmployeeAsync(Employee employee)
        {
            if (employee.Id <= 0)
                throw new ArgumentException("Employee ID must be greater than 0.");

            var validationErrors = ValidateEmployeeForAddOrUpdate(employee);

            // If there are validation errors, return them
            if (validationErrors.Errors.Any())
            {
                return validationErrors;
            }

            var existingEmployee = await _repository.GetByIdAsync(employee.Id);
            if (existingEmployee == null)
                throw new KeyNotFoundException($"Employee with ID {employee.Id} not found.");

            employee.UpdatedAt = DateTime.UtcNow; // Set update timestamp
            await _repository.UpdateAsync(employee);

            return null; // No validation errors
        }

        // Delete an employee
        public async Task DeleteEmployeeAsync(int id)
        {
            if (id <= 0)
                throw new ArgumentException("Employee ID must be greater than 0.");

            var existingEmployee = await _repository.GetByIdAsync(id);
            if (existingEmployee == null)
                throw new KeyNotFoundException($"Employee with ID {id} not found.");

            await _repository.DeleteAsync(id);
        }

        // Private validation method
        private ValidationErrorResponse ValidateEmployeeForAddOrUpdate(Employee employee)
        {
            var validationErrors = new ValidationErrorResponse();

            if (string.IsNullOrWhiteSpace(employee.Name))
                validationErrors.Errors.Add("Name", "Employee name cannot be empty.");

            if (string.IsNullOrWhiteSpace(employee.Department))
                validationErrors.Errors.Add("Department", "Employee department cannot be empty.");

            if (employee.Salary <= 0)
                validationErrors.Errors.Add("Salary", "Employee salary must be greater than 0.");

            if (string.IsNullOrWhiteSpace(employee.UserName))
                validationErrors.Errors.Add("Username", "Username cannot be empty.");

            if (string.IsNullOrWhiteSpace(employee.Email))
                validationErrors.Errors.Add("Email", "Email cannot be empty.");

            return validationErrors;
        }

        // Dummy password hashing method (replace with actual implementation)
        private string HashPassword(string password)
        {
            // Use a secure hashing algorithm such as BCrypt, PBKDF2, or SHA-256 in a real application
            return Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(password));
        }

        // Change employee status
        public async Task<bool> ChangeEmployeeStatusAsync(int id, bool isActive)
        {
            if (id <= 0)
            {
                throw new ArgumentException("Employee ID must be greater than 0.");
            }

            var employee = await _repository.GetByIdAsync(id);
            if (employee == null)
            {
                throw new KeyNotFoundException($"Employee with ID {id} not found.");
            }

            return await _repository.ChangeStatusAsync(id, isActive);
        }

    }
}
