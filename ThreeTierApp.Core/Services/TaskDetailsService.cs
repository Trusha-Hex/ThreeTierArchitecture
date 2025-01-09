using System.Collections.Generic;
using System.Linq;  // Add this line
using System.Threading.Tasks;
using ThreeTierApp.DAL.Models;
using ThreeTierApp.DAL.Repositories;

namespace ThreeTierApp.Core.Services
{
    public class TaskDetailsService
    {
        private readonly TaskDetailsRepository _repository;

        public TaskDetailsService(TaskDetailsRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<TaskDetails>> GetAllTasksAsync()
        {
            return await _repository.GetAllAsync();  // Now returns IEnumerable
        }

        public async Task<TaskDetails> GetTaskByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task AddTaskAsync(TaskDetails taskDetails)
        {
            await _repository.AddAsync(taskDetails);
        }

        public async Task UpdateTaskAsync(TaskDetails taskDetails)
        {
            await _repository.UpdateAsync(taskDetails);
        }

        public async Task DeleteTaskAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }

        public async Task<IEnumerable<TaskDetails>> GetTasksByAssignedEmployeeIdAsync(int employeeId)
        {
            var allTasks = await _repository.GetAllAsync();
            return allTasks.Where(task =>
                task.AssignedEmployeeIds != null && task.AssignedEmployeeIds.Contains(employeeId));
        }
    }
}
