using ThreeTierApp.Core.Interfaces;
using ThreeTierApp.DAL.Models;
using ThreeTierApp.Core.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;
using ThreeTierApp.DAL.Repositories;
using ZeroFormatter;
using StackExchange.Redis;

namespace ThreeTierApp.Core.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _repository;
        private readonly ICacheService _cacheService;

        public EmployeeService(IEmployeeRepository repository, ICacheService cacheService)
        {
            _repository = repository;
            _cacheService = cacheService;
        }

        public async Task<IEnumerable<Employee>> GetAllEmployeesAsync()
        {
            return await _repository.GetAllEmployeeAsync();
        }

        public async Task<Employee> GetEmployeeByIdAsync(int id)
        {
            string cacheKey = $"employee:{id}";

            // Fetch from cache
            var employee = await _cacheService.GetCacheData<Employee>(cacheKey);
            if (employee != null)
                return employee;

            // Fetch from repository and update cache
            employee = await _repository.GetEmployeeByIdAsync(id);
            if (employee != null)
            {
                await _cacheService.SetCacheData(cacheKey, employee);
            }

            return employee;
        }


        public async Task<Employee> GetEmployeeByEmailOrUsernameAsync(string emailOrUsername)
        {
            return await _repository.GetEmployeeByEmailOrUsernameAsync(emailOrUsername);
        }

        public async Task<ValidationErrorResponse> AddEmployeeAsync(Employee employee)
        {
            var validationErrors = ValidateEmployeeForAddOrUpdate(employee);
            if (validationErrors.Errors.Any())
                return validationErrors;

            employee.PasswordHash = HashPassword(employee.PasswordHash);
            employee.CreatedAt = DateTime.UtcNow;
            employee.UpdatedAt = DateTime.UtcNow;

            await _repository.AddEmployeeAsync(employee);

            // Cache the new employee
            await _cacheService.SetCacheData($"employee:{employee.Id}", employee);

            return null;
        }

        public async Task<ValidationErrorResponse> UpdateEmployeeAsync(Employee employee)
        {
            var validationErrors = ValidateEmployeeForAddOrUpdate(employee);
            if (validationErrors.Errors.Any())
                return validationErrors;

            await _repository.UpdateEmployeeAsync(employee);

            // Update the cache
            await _cacheService.SetCacheData($"employee:{employee.Id}", employee);

            return null;
        }

        public async Task DeleteEmployeeAsync(int id)
        {
            await _repository.DeleteEmployeeAsync(id);

            // Remove from cache
            await _cacheService.DeleteCacheData($"employee:{id}");
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

        public async Task<bool> UpdateStatusAsync(int employeeId, bool isActive)
        {
            var result = await _repository.UpdateEmployeeStatusAsync(employeeId, isActive);

            if (result)
            {
                // Update cache
                var employee = await _cacheService.GetCacheData<Employee>($"employee:{employeeId}");
                if (employee != null)
                {
                    employee.IsActive = isActive;
                    await _cacheService.SetCacheData($"employee:{employeeId}", employee);
                }
            }

            return result;
        }
    }
}
