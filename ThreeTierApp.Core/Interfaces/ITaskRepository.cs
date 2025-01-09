using System.Collections.Generic;
using System.Threading.Tasks;
using ThreeTierApp.DAL.Models;

namespace ThreeTierApp.Core.Interfaces
{
    public interface ITaskRepository
    {
        Task<IEnumerable<TaskDetails>> GetAllAsync();
        Task<TaskDetails> GetByIdAsync(int id);
        Task<bool> CreateAsync(TaskDetails task);
        Task<bool> UpdateAsync(TaskDetails task);
        Task<bool> DeleteAsync(int id);
    }
}
