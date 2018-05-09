using CrowdSourcing.Contract.Interfaces;
using CrowdSourcing.EntityCore.Common;
using CrowdSourcing.EntityCore.Entity;
using CrowdSourcing.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrowdSourcing.Repository.TaskManagment
{
    public class TaskRepository : GenericRepository<TaskEntity>, ITaskRepository
    {
        private readonly IDbContext _dbContext;
        private readonly DbSet<TaskEntity> _dbSet;
        private DbContext Context => (DbContext)_dbContext;

        public TaskRepository(IDbContext context) : base(context)
        {
            _dbContext = context;
            _dbSet = Context.Set<TaskEntity>();
        }

        public async Task<IEnumerable<TaskEntity>> GetAllTaskWithType()
        {
            return await _dbSet.Include(t => t.TaskType).Where(t=>t.Status!=2).ToListAsync();
        }
        public async Task<IEnumerable<TaskEntity>> GetAllTasksByTaskTypeId(int taskTypeId)
        {
            return await _dbSet.Where(t => t.TaskTypeId == taskTypeId).ToListAsync();
        }
        public async Task<TaskEntity> GetTaskWithTypeBy(int id)
        {
            return await _dbSet.Include(t => t.TaskType).Where(t=>t.Id==id).FirstOrDefaultAsync();
        }
    }
}
