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

        public Task<IEnumerable<Employee>> GetAllEmployeeAsync() => _employeeRepository.GetAllEmployeeAsync();

        public Task<Employee> GetEmployeeByIdAsync(int id) => _employeeRepository.GetEmployeeByIdAsync(id);

        public Task AddEmployeeAsync(Employee employee) => _employeeRepository.AddEmployeeAsync(employee);

        public Task UpdateEmployeeAsync(Employee employee) => _employeeRepository.UpdateEmployeeAsync(employee);

        public Task DeleteEmployeeAsync(int id) => _employeeRepository.DeleteEmployeeAsync(id);

        public Task<Employee> GetEmployeeByEmailOrUsernameAsync(string emailOrUsername) =>
            _employeeRepository.GetEmployeeByEmailOrUsernameAsync(emailOrUsername);

        public Task<bool> UpdateEmployeeStatusAsync(int employeeId, bool isActive) =>
         _employeeRepository.UpdateEmployeeStatusAsync(employeeId, isActive);
        
    }
}
