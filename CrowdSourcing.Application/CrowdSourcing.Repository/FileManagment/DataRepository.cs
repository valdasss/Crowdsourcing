using CrowdSourcing.Contract.Interfaces;
using CrowdSourcing.EntityCore.Common;
using CrowdSourcing.EntityCore.Entity;
using CrowdSourcing.Repository.Interface;
using System.Data.Entity;

namespace CrowdSourcing.Repository.FileManagment
{
    public class DataRepository : GenericRepository<DataEntity>, IDataRepository
    {
        private readonly IDbContext _dbContext;
        private readonly DbSet<DataEntity> _dbSet;
        private DbContext Context => (DbContext)_dbContext;

        public DataRepository(IDbContext context) : base(context)
        {
            _dbContext = context;
            _dbSet = Context.Set<DataEntity>();
        }

    }
}
