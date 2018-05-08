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

namespace CrowdSourcing.Repository.FileManagment
{
    public class TaskDataRepository : GenericRepository<TaskDataEntity>, ITaskDataRepository
    {
        private readonly IDbContext _dbContext;
        private readonly DbSet<TaskDataEntity> _dbSet;
        private DbContext Context => (DbContext)_dbContext;

        public TaskDataRepository(IDbContext context) : base(context)
        {
            _dbContext = context;
            _dbSet = Context.Set<TaskDataEntity>();
        }

        public async Task<IEnumerable<TaskDataEntity>> GetDataBy(int taskId)
        {
          return await _dbSet.Include(t => t.Data.Uploader).Where(t => t.TaskId == taskId).ToListAsync();
        }
        public async Task<IEnumerable<TaskDataEntity>> GetDatasByDataId(int dataId)
        {
            return await _dbSet.Include(t => t.Data.Uploader).Where(t => t.DataId == dataId).ToListAsync();
        }
        public async Task<TaskDataEntity> GetTaskDatawithTaskBy(int taskDataId)
        {
            return await _dbSet.Include(t => t.Task.TaskType).Where(t => t.Id == taskDataId).FirstOrDefaultAsync();
        }
        public async Task<TaskDataEntity> GetTaskDatawithDataBy(int taskDataId)
        {
            return await _dbSet.Include(t => t.Data).Where(t => t.Id == taskDataId).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<TaskDataEntity>> GetDataForDataReviewDropdownBy(int taskId)
        {
            return await _dbSet.Include(t => t.Data.Uploader).Where(t => t.TaskId == taskId&& t.Data.Status==0).ToListAsync();
        }
    }
}
