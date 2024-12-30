using System.Collections.Generic;
using System.Threading.Tasks;
using ThreeTierApp.Core.Models;

namespace ThreeTierApp.Core.Interfaces
{
    public interface IEmployeeService
    {
        Task<IEnumerable<Employee>> GetAllEmployeesAsync();
        Task<Employee> GetEmployeeByIdAsync(int id);
        //Task AddEmployeeAsync(Employee employee);
        Task<ValidationErrorResponse> AddEmployeeAsync(Employee employee);
        Task UpdateEmployeeAsync(Employee employee);
        Task DeleteEmployeeAsync(int id);
    }
}
