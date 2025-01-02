using ThreeTierApp.Core.Interfaces;  // For IEmployeeRepository
using ThreeTierApp.Core.Models;      // For Employee model
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ThreeTierApp.DAL.Data;         // For AppDbContext
using System;

namespace ThreeTierApp.DAL.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly AppDbContext _context;

        public EmployeeRepository(AppDbContext context)
        {
            _context = context;
        }

        // Get all employees
        public async Task<IEnumerable<Employee>> GetAllAsync() => await _context.Employees.ToListAsync();

        // Get employee by ID
        //public async Task<Employee> GetByIdAsync(int id) => await _context.Employees.FindAsync(id);

        public async Task<Employee> GetByIdAsync(int id)
        {
            // Assuming you are using Entity Framework or similar ORM, ensure that the method signature matches
            var employee = await _context.Employees.FindAsync(id);
            return employee;
        }


        // Add a new employee
        public async Task AddAsync(Employee employee)
        {
            employee.CreatedAt = DateTime.UtcNow; // Set creation timestamp
            employee.UpdatedAt = DateTime.UtcNow; // Set update timestamp
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();
        }

        // Update an existing employee
        public async Task UpdateAsync(Employee employee)
        {
            var existingEmployee = await _context.Employees.FindAsync(employee.Id);
            if (existingEmployee != null)
            {
                existingEmployee.Name = employee.Name;
                existingEmployee.UserName = employee.UserName;
                existingEmployee.Email = employee.Email;
                existingEmployee.PasswordHash = employee.PasswordHash;
                existingEmployee.Department = employee.Department;
                existingEmployee.Salary = employee.Salary;
                existingEmployee.Role = employee.Role;
                existingEmployee.IsActive = employee.IsActive;
                existingEmployee.LastLogin = employee.LastLogin;
                existingEmployee.UpdatedAt = DateTime.UtcNow; // Update timestamp

                _context.Employees.Update(existingEmployee);
                await _context.SaveChangesAsync();
            }
        }

        // Delete an employee by ID
        public async Task DeleteAsync(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee != null)
            {
                _context.Employees.Remove(employee);
                await _context.SaveChangesAsync();
            }
        }

        // Get employee by username
        public async Task<Employee> GetByUsernameAsync(string username)
        {
            return await _context.Employees.FirstOrDefaultAsync(e => e.UserName == username);
        }

        // Get employees by role
        public async Task<IEnumerable<Employee>> GetByRoleAsync(string role)
        {
            return await _context.Employees.Where(e => e.Role == role).ToListAsync();
        }

        // Get active employees
        public async Task<IEnumerable<Employee>> GetActiveEmployeesAsync()
        {
            return await _context.Employees.Where(e => e.IsActive).ToListAsync();
        }

        public async Task<bool> ChangeStatusAsync(int id, bool isActive)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
            {
                return false; // Employee not found
            }

            employee.IsActive = isActive;
            _context.Employees.Update(employee);
            await _context.SaveChangesAsync();
            return true;
        }

    }
}
