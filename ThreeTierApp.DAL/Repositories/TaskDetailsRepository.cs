using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ThreeTierApp.DAL.Data;
using ThreeTierApp.DAL.Models;

namespace ThreeTierApp.DAL.Repositories
{
    public class TaskDetailsRepository
    {
        private readonly AppDbContext _context;

        public TaskDetailsRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TaskDetails>> GetAllAsync()
        {
            return await _context.TaskDetails.ToListAsync();
        }

        public async Task<TaskDetails> GetByIdAsync(int id)
        {
            return await _context.TaskDetails.FindAsync(id);
        }

        public async Task AddAsync(TaskDetails taskDetails)
        {
            await _context.TaskDetails.AddAsync(taskDetails);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(TaskDetails taskDetails)
        {
            _context.TaskDetails.Update(taskDetails);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var taskDetails = await GetByIdAsync(id);
            if (taskDetails != null)
            {
                _context.TaskDetails.Remove(taskDetails);
                await _context.SaveChangesAsync();
            }
        }
    }
}
