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
    }
}
