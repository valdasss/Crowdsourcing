using CrowdSourcing.Contract.Interfaces;
using CrowdSourcing.EntityCore.Common;
using CrowdSourcing.EntityCore.Entity;
using CrowdSourcing.Repository.Interface;
using System.Data.Entity;

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
    }
}
