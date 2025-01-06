using ThreeTierApp.DAL.Models;
using Microsoft.EntityFrameworkCore;
using ThreeTierApp.DAL.Data;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ThreeTierApp.DAL.Repositories
{
    public class EmployeeRepository
    {
        private readonly AppDbContext _context;

        public EmployeeRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Employee>> GetAllAsync() => await _context.Employees.ToListAsync();

        public async Task<Employee> GetByIdAsync(int id) => await _context.Employees.FindAsync(id);

        public async Task AddAsync(Employee employee)
        {
            employee.CreatedAt = DateTime.UtcNow;
            employee.UpdatedAt = DateTime.UtcNow;
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Employee employee)
        {
            var existingEmployee = await _context.Employees.FindAsync(employee.Id);
            if (existingEmployee != null)
            {
                existingEmployee.Name = employee.Name;
                existingEmployee.Username = employee.Username;
                existingEmployee.Email = employee.Email;
                existingEmployee.PasswordHash = employee.PasswordHash;
                existingEmployee.Department = employee.Department;
                existingEmployee.Salary = employee.Salary;
                existingEmployee.Role = employee.Role;
                existingEmployee.IsActive = employee.IsActive;
                existingEmployee.LastLogin = employee.LastLogin;
                existingEmployee.UpdatedAt = DateTime.UtcNow;

                _context.Employees.Update(existingEmployee);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee != null)
            {
                _context.Employees.Remove(employee);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Employee> GetEmployeeByEmailOrUsernameAsync(string emailOrUsername)
        {
            return await _context.Employees
                .FirstOrDefaultAsync(e => e.Email == emailOrUsername || e.Username == emailOrUsername);
        }

        public async Task<bool> UpdateStatusAsync(int employeeId, bool isActive)
        {
            var employee = await _context.Employees.FindAsync(employeeId);
            if (employee == null)
            {
                return false;
            }

            Console.WriteLine($"Repository: Setting isActive = {isActive}");
            employee.IsActive = isActive;
            await _context.SaveChangesAsync();
            return true;
        }


    }
}
