using System.Collections.Generic;
using System.Threading.Tasks;
using ThreeTierApp.DAL.Models;
using ThreeTierApp.Core.Models;

namespace ThreeTierApp.Core.Interfaces
{
    public interface IEmployeeService
    {
        Task<IEnumerable<Employee>> GetAllEmployeesAsync(); // Fetch all employees
        Task<Employee> GetEmployeeByIdAsync(int id); // Fetch employee by ID
        Task<Employee> GetEmployeeByEmailOrUsernameAsync(string emailOrUsername); // Fetch employee by email/username
        Task<ValidationErrorResponse> AddEmployeeAsync(Employee employee); // Add new employee
        Task<ValidationErrorResponse> UpdateEmployeeAsync(Employee employee); // Update existing employee
        Task DeleteEmployeeAsync(int id); // Delete employee
        Task<bool> UpdateStatusAsync(int employeeId, bool isActive); // Update active status of employee
    }
}
