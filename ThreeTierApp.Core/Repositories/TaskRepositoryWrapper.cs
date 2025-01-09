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

        public Task<IEnumerable<TaskDetails>> GetAllAsync() =>
            _taskRepository.GetAllAsync();

        public Task<TaskDetails> GetByIdAsync(int id) =>
            _taskRepository.GetByIdAsync(id);

        public Task<bool> CreateAsync(TaskDetails task)
        {
            return _taskRepository.AddAsync(task)
                .ContinueWith(_ => true); // Simplified boolean return
        }

        public Task<bool> UpdateAsync(TaskDetails task)
        {
            return _taskRepository.UpdateAsync(task)
                .ContinueWith(_ => true);
        }

        public Task<bool> DeleteAsync(int id)
        {
            return _taskRepository.DeleteAsync(id)
                .ContinueWith(_ => true);
        }
    }
}
