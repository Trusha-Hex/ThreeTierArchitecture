using ThreeTierApp.Core.Interfaces;
using ThreeTierApp.DAL.Repositories;
using ThreeTierApp.DAL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ThreeTierApp.Core.Repositories
{
    public class EmployeeRepositoryWrapper : IEmployeeRepository
    {
        private readonly EmployeeRepository _employeeRepository;

        public EmployeeRepositoryWrapper(EmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public Task<IEnumerable<Employee>> GetAllAsync() => _employeeRepository.GetAllAsync();

        public Task<Employee> GetByIdAsync(int id) => _employeeRepository.GetByIdAsync(id);

        public Task AddAsync(Employee employee) => _employeeRepository.AddAsync(employee);

        public Task UpdateAsync(Employee employee) => _employeeRepository.UpdateAsync(employee);

        public Task DeleteAsync(int id) => _employeeRepository.DeleteAsync(id);

        public Task<Employee> GetEmployeeByEmailOrUsernameAsync(string emailOrUsername) =>
            _employeeRepository.GetEmployeeByEmailOrUsernameAsync(emailOrUsername);

        public Task<bool> UpdateStatusAsync(int employeeId, bool isActive) =>
         _employeeRepository.UpdateStatusAsync(employeeId, isActive);
        
    }
}
