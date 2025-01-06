using System.Collections.Generic;
using System.Threading.Tasks;
using ThreeTierApp.DAL.Models;

namespace ThreeTierApp.Core.Interfaces
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> GetAllAsync();
        Task<Employee> GetByIdAsync(int id);
        Task AddAsync(Employee employee);
        Task UpdateAsync(Employee employee);
        Task DeleteAsync(int id);
        Task<Employee> GetEmployeeByEmailOrUsernameAsync(string emailOrUsername);
        Task<bool> UpdateStatusAsync(int employeeId, bool isActive);
    }
}
