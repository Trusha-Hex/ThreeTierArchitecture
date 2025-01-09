using System.Collections.Generic;
using System.Threading.Tasks;
using ThreeTierApp.DAL.Models;

namespace ThreeTierApp.Core.Interfaces
{
    public interface ITaskService
    {
        Task<IEnumerable<TaskDetails>> GetAllTasksAsync();
        Task<TaskDetails> GetTaskByIdAsync(int id);
        Task<bool> CreateTaskAsync(TaskDetails task);
        Task<bool> UpdateTaskAsync(TaskDetails task);
        Task<bool> DeleteTaskAsync(int id);
    }
}
