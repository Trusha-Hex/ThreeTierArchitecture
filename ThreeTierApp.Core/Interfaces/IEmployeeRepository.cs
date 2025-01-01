using System.Collections.Generic;
using System.Threading.Tasks;
using ThreeTierApp.Core.Models; // For Employee model

namespace ThreeTierApp.Core.Interfaces
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> GetAllAsync();
        Task<Employee> GetByIdAsync(int id);
        Task AddAsync(Employee employee);
        Task UpdateAsync(Employee employee);
        Task DeleteAsync(int id);
        Task<Employee> GetByUsernameAsync(string username); // New: Fetch by username
        Task<IEnumerable<Employee>> GetByRoleAsync(string role); // New: Fetch by role
        Task<IEnumerable<Employee>> GetActiveEmployeesAsync(); // New: Fetch active employees
        Task<bool> ChangeStatusAsync(int id, bool isActive);
    }
}
