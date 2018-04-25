using CrowdSourcing.Contract.Interfaces;
using CrowdSourcing.EntityCore.Common;
using CrowdSourcing.EntityCore.Entity;
using CrowdSourcing.Repository.Interface;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace CrowdSourcing.Repository.FileManagment
{
    public class FileTypeRepository : GenericRepository<FileTypeEntity>, IFileTypeRepository
    {
        private readonly IDbContext _dbContext;
        private readonly DbSet<FileTypeEntity> _dbSet;
        private DbContext Context => (DbContext)_dbContext;

        public FileTypeRepository(IDbContext context) : base(context)
        {
            _dbContext = context;
            _dbSet = Context.Set<FileTypeEntity>();
        }

        public async Task<FileTypeEntity> GetFileTypeBy(string name)
        {
            return await _dbSet.Where(f => f.Name == name).FirstOrDefaultAsync();
        }
    }
}
