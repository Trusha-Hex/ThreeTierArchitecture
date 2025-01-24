using System.Collections.Generic;
using System.Threading.Tasks;
using ThreeTierApp.DAL.Models;

namespace ThreeTierApp.Core.Interfaces
{
    public interface ITaskRepository
    {
        Task<IEnumerable<TaskDetails>> GetAllTaskAsync();
        Task<TaskDetails> GetTaskByIdAsync(int id);
        Task<bool> CreateTaskAsync(TaskDetails task);
        Task<bool> UpdateTaskAsync(TaskDetails task);
        Task<bool> DeleteTaskAsync(int id);
    }
}
