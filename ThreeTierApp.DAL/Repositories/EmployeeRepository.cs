using ZeroFormatter;
using StackExchange.Redis;
using Microsoft.EntityFrameworkCore;
using ThreeTierApp.DAL.Models;
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

        public async Task<IEnumerable<Employee>> GetAllEmployeeAsync()
        {
            return await _context.Employees.ToListAsync();
        }

        public async Task<Employee> GetEmployeeByIdAsync(int id)
        {
            return await _context.Employees.FindAsync(id);
        }

        public async Task AddEmployeeAsync(Employee employee)
        {
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateEmployeeAsync(Employee employee)
        {
            _context.Employees.Update(employee);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteEmployeeAsync(int id)
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

        public async Task<bool> UpdateEmployeeStatusAsync(int employeeId, bool isActive)
        {
            var employee = await _context.Employees.FindAsync(employeeId);
            if (employee == null) return false;

            employee.IsActive = isActive;
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
