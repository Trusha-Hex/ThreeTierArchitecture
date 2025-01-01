using System.Collections.Generic;
using System.Threading.Tasks;
using ThreeTierApp.Core.Models;

namespace ThreeTierApp.Core.Interfaces
{
    public interface IEmployeeService
    {
        // Retrieve all employees
        Task<IEnumerable<Employee>> GetAllEmployeesAsync();

        // Retrieve an employee by ID
        Task<Employee> GetEmployeeByIdAsync(int id);

        // Retrieve an employee by username
        Task<Employee> GetEmployeeByUsernameAsync(string username);

        // Retrieve employees by role
        Task<IEnumerable<Employee>> GetEmployeesByRoleAsync(string role);

        // Retrieve all active employees
        Task<IEnumerable<Employee>> GetActiveEmployeesAsync();

        // Add a new employee with validation
        Task<ValidationErrorResponse> AddEmployeeAsync(Employee employee);

        // Update an existing employee
        Task<ValidationErrorResponse> UpdateEmployeeAsync(Employee employee);

        // Delete an employee
        Task DeleteEmployeeAsync(int id);

        Task<bool> ChangeEmployeeStatusAsync(int id, bool isActive);

    }
}
