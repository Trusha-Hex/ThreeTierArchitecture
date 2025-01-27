using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;  // Add this line
using System.Threading.Tasks;
using ThreeTierApp.DAL.Data;
using ThreeTierApp.DAL.Models;
using ThreeTierApp.DAL.Repositories;

namespace ThreeTierApp.Core.Services
{
    public class TaskDetailsService
    {
        private readonly TaskDetailsRepository _repository;
        private readonly AppDbContext _context;

        public TaskDetailsService(TaskDetailsRepository repository, AppDbContext context)
        {
            _repository = repository;
            _context = context;
        }

        public async Task<IEnumerable<TaskDetails>> GetAllTasksAsync()
        {
            return await _repository.GetAllTaskAsync();  // Now returns IEnumerable
        }

        public async Task<TaskDetails> GetTaskByIdAsync(int id)
        {
            return await _repository.GetTaskByIdAsync(id);
        }

        public async Task AddTaskAsync(TaskDetails taskDetails)
        {
            await _repository.AddTaskAsync(taskDetails);
        }

        public async Task UpdateTaskAsync(TaskDetails taskDetails)
        {
            await _repository.UpdateTaskAsync(taskDetails);
        }

        public async Task DeleteTaskAsync(int id)
        {
            await _repository.DeleteTaskAsync(id);
        }

        public async Task<IEnumerable<TaskDetails>> GetTasksByAssignedEmployeeIdAsync(int employeeId)
        {
            var allTasks = await _repository.GetAllTaskAsync();
            return allTasks.Where(task =>
                task.AssignedEmployeeIds != null && task.AssignedEmployeeIds.Contains(employeeId));
        }

        public async Task<List<Employee>> GetEmployeesByIdsAsync(List<int> employeeIds)
        {
            // Fetch employees by their IDs
            var employees = await _context.Employees
                .Where(e => employeeIds.Contains(e.Id))
                .ToListAsync();

            return employees;
        }
    }
}
