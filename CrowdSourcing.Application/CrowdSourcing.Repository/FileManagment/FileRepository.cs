using CrowdSourcing.Contract.Interfaces;
using CrowdSourcing.EntityCore.Common;
using CrowdSourcing.EntityCore.Entity;
using CrowdSourcing.Repository.Interface;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace CrowdSourcing.Repository.FileManagment
{
    public class FileRepository : GenericRepository<FileEntity>, IFileRepository
    {
        private readonly IDbContext _dbContext;
        private readonly DbSet<FileEntity> _dbSet;
        private DbContext Context => (DbContext)_dbContext;

        public FileRepository(IDbContext context) : base(context)
        {
            _dbContext = context;
            _dbSet = Context.Set<FileEntity>();
        }

        public async Task<IEnumerable<FileEntity>> GetAllFilesBy(int dataId)
        {
            return await _dbSet.Where(f => f.DataId == dataId).ToListAsync();
        }

        public async Task<IEnumerable<FileEntity>> GetAllUsersFiles(string userId)
        {
            return await _dbSet.Include(f=>f.Data.TaskDatas.Select(x=>x.Task.TaskType)).Where(f => f.Data.PersonId == userId).ToListAsync();
        }
    }
}
