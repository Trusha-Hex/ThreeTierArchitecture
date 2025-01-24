using System.Collections.Generic;
using System.Threading.Tasks;
using ThreeTierApp.Core.Interfaces;
using ThreeTierApp.DAL.Repositories;
using ThreeTierApp.DAL.Models;

namespace ThreeTierApp.Core.Repositories
{
    public class TaskRepositoryWrapper : ITaskRepository
    {
        private readonly TaskDetailsRepository _taskRepository;

        public TaskRepositoryWrapper(TaskDetailsRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public Task<IEnumerable<TaskDetails>> GetAllTaskAsync() =>
            _taskRepository.GetAllTaskAsync();

        public Task<TaskDetails> GetTaskByIdAsync(int id) =>
            _taskRepository.GetTaskByIdAsync(id);

        public Task<bool> CreateTaskAsync(TaskDetails task)
        {
            return _taskRepository.AddTaskAsync(task)
                .ContinueWith(_ => true); // Simplified boolean return
        }

        public Task<bool> UpdateTaskAsync(TaskDetails task)
        {
            return _taskRepository.UpdateTaskAsync(task)
                .ContinueWith(_ => true);
        }

        public Task<bool> DeleteTaskAsync(int id)
        {
            return _taskRepository.DeleteTaskAsync(id)
                .ContinueWith(_ => true);
        }
    }
}
