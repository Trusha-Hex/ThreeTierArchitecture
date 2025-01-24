using System.Collections.Generic;
using System.Threading.Tasks;
using ThreeTierApp.DAL.Models;

namespace ThreeTierApp.Core.Interfaces
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> GetAllEmployeeAsync();
        Task<Employee> GetEmployeeByIdAsync(int id);
        Task AddEmployeeAsync(Employee employee);
        Task UpdateEmployeeAsync(Employee employee);
        Task DeleteEmployeeAsync(int id);
        Task<Employee> GetEmployeeByEmailOrUsernameAsync(string emailOrUsername);
        Task<bool> UpdateEmployeeStatusAsync(int employeeId, bool isActive);
    }
}
