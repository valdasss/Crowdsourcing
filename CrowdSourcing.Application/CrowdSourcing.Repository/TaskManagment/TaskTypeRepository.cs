using CrowdSourcing.Contract.Interfaces;
using CrowdSourcing.EntityCore.Common;
using CrowdSourcing.EntityCore.Entity;
using CrowdSourcing.Repository.Interface;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace CrowdSourcing.Repository.TaskManagment
{
    public class TaskTypeRepository : GenericRepository<TaskTypeEntity>, ITaskTypeRepository 
    {
        private readonly IDbContext _dbContext;
        private readonly DbSet<TaskTypeEntity> _dbSet;
        private DbContext Context => (DbContext)_dbContext;

        public TaskTypeRepository(IDbContext context) : base(context)
        {
            _dbContext = context;
            _dbSet = Context.Set<TaskTypeEntity>();
        }

        public async Task<IEnumerable<TaskTypeEntity>> GetAllTaskDatasExeptNotFound()
        {
            return await _dbSet.Where(t => t.Id != 1).ToListAsync();
        }
    }
}
