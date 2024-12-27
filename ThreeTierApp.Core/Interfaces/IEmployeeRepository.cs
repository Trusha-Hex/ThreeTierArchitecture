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
    }
}
