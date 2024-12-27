using ThreeTierApp.Core.Interfaces;  // For IEmployeeRepository
using ThreeTierApp.Core.Models;     // For Employee model
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ThreeTierApp.Core.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _repository;

        public EmployeeService(IEmployeeRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Employee>> GetAllEmployeesAsync() => await _repository.GetAllAsync();

        public async Task<Employee> GetEmployeeByIdAsync(int id) => await _repository.GetByIdAsync(id);

        public async Task AddEmployeeAsync(Employee employee) => await _repository.AddAsync(employee);

        public async Task UpdateEmployeeAsync(Employee employee) => await _repository.UpdateAsync(employee);

        public async Task DeleteEmployeeAsync(int id) => await _repository.DeleteAsync(id);
    }
}
