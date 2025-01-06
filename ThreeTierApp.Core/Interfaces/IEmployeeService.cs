using System.Collections.Generic;
using System.Threading.Tasks;
using ThreeTierApp.DAL.Models;
using ThreeTierApp.Core.Models;

namespace ThreeTierApp.Core.Interfaces
{
    public interface IEmployeeService
    {
        Task<IEnumerable<Employee>> GetAllEmployeesAsync();
        Task<Employee> GetEmployeeByIdAsync(int id);
        Task<Employee> GetEmployeeByEmailOrUsernameAsync(string emailOrUsername);
        Task<ValidationErrorResponse> AddEmployeeAsync(Employee employee);
        Task<ValidationErrorResponse> UpdateEmployeeAsync(Employee employee);
        Task DeleteEmployeeAsync(int id);
        Task<bool> UpdateStatusAsync(int employeeId, bool isActive);
    }
}
