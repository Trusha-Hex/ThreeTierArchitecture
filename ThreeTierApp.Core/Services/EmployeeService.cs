using ThreeTierApp.Core.Interfaces;
using ThreeTierApp.Core.Models;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<IEnumerable<Employee>> GetAllEmployeesAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Employee> GetEmployeeByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<Employee> GetEmployeeByEmailOrUsernameAsync(string emailOrUsername)
        {
            return await _repository.GetEmployeeByEmailOrUsernameAsync(emailOrUsername);
        }

        public async Task<ValidationErrorResponse> AddEmployeeAsync(Employee employee)
        {
            var validationErrors = ValidateEmployeeForAddOrUpdate(employee);
            if (validationErrors.Errors.Any())
            {
                return validationErrors;
            }

            employee.PasswordHash = HashPassword(employee.PasswordHash);
            employee.CreatedAt = DateTime.UtcNow;
            employee.UpdatedAt = DateTime.UtcNow;

            await _repository.AddAsync(employee);
            return null;
        }

        public async Task<ValidationErrorResponse> UpdateEmployeeAsync(Employee employee)
        {
            if (employee.Id <= 0)
                throw new ArgumentException("Employee ID must be greater than 0.");

            var validationErrors = ValidateEmployeeForAddOrUpdate(employee);

            if (validationErrors.Errors.Any())
            {
                return validationErrors;
            }

            var existingEmployee = await _repository.GetByIdAsync(employee.Id);
            if (existingEmployee == null)
                throw new KeyNotFoundException($"Employee with ID {employee.Id} not found.");

            employee.UpdatedAt = DateTime.UtcNow;
            await _repository.UpdateAsync(employee);

            return null;
        }

        public async Task DeleteEmployeeAsync(int id)
        {
            if (id <= 0)
                throw new ArgumentException("Employee ID must be greater than 0.");

            var existingEmployee = await _repository.GetByIdAsync(id);
            if (existingEmployee == null)
                throw new KeyNotFoundException($"Employee with ID {id} not found.");

            await _repository.DeleteAsync(id);
        }

        private ValidationErrorResponse ValidateEmployeeForAddOrUpdate(Employee employee)
        {
            var validationErrors = new ValidationErrorResponse();

            if (string.IsNullOrWhiteSpace(employee.Name))
                validationErrors.Errors.Add("Name", "Employee name cannot be empty.");

            if (string.IsNullOrWhiteSpace(employee.Department))
                validationErrors.Errors.Add("Department", "Employee department cannot be empty.");

            if (employee.Salary <= 0)
                validationErrors.Errors.Add("Salary", "Employee salary must be greater than 0.");

            if (string.IsNullOrWhiteSpace(employee.Username))
                validationErrors.Errors.Add("Username", "Username cannot be empty.");

            if (string.IsNullOrWhiteSpace(employee.Email))
                validationErrors.Errors.Add("Email", "Email cannot be empty.");

            return validationErrors;
        }

        private string HashPassword(string password)
        {
            return Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(password));
        }
    }
}
