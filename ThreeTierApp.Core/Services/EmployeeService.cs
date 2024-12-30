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

        // Get employee by ID
        public async Task<Employee> GetEmployeeByIdAsync(int id)
        {
            if (id <= 0)
                throw new ArgumentException("Employee ID must be greater than 0.");

            return await _repository.GetByIdAsync(id)
                ?? throw new KeyNotFoundException($"Employee with ID {id} not found.");
        }

        // Add a new employee with validations
        public async Task<ValidationErrorResponse> AddEmployeeAsync(Employee employee)
        {
            var validationErrors = new ValidationErrorResponse();

            // Validate Name
            if (string.IsNullOrWhiteSpace(employee.Name))
            {
                validationErrors.Errors.Add("Name", "Employee name cannot be empty.");
            }

            // Validate Department
            if (string.IsNullOrWhiteSpace(employee.Department))
            {
                validationErrors.Errors.Add("Department", "Employee department cannot be empty.");
            }

            // Validate Salary
            if (employee.Salary <= 0)
            {
                validationErrors.Errors.Add("Salary", "Employee salary must be greater than 0.");
            }

            // If there are validation errors, return them
            if (validationErrors.Errors.Any())
            {
                return validationErrors;
            }

            // No validation errors, proceed to add the employee
            await _repository.AddAsync(employee);

            return null; // No validation errors
        }


        // Update an existing employee
        public async Task UpdateEmployeeAsync(Employee employee)
        {
            if (employee.Id <= 0)
                throw new ArgumentException("Employee ID must be greater than 0.");

            ValidateEmployee(employee);

            var existingEmployee = await _repository.GetByIdAsync(employee.Id);
            if (existingEmployee == null)
                throw new KeyNotFoundException($"Employee with ID {employee.Id} not found.");

            await _repository.UpdateAsync(employee);
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
        private void ValidateEmployee(Employee employee)
        {
            if (string.IsNullOrWhiteSpace(employee.Name))
                throw new ArgumentException("Employee name cannot be empty.");

            if (string.IsNullOrWhiteSpace(employee.Department))
                throw new ArgumentException("Employee department cannot be empty.");

            if (employee.Salary <= 0 || employee.Salary == null)
                throw new ArgumentException("Employee salary must be greater than 0.");

        }
    }
}
