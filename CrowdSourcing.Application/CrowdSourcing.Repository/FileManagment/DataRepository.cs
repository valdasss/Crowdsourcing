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
        public async Task<DataEntity> GetDataWithFilesAndPersonBy(int dataId)
        {
            return await _dbSet.Include(f=>f.Files.Select(t=>t.FileType)).Include(f=>f.Uploader).Where(f => f.Id == dataId).FirstOrDefaultAsync();
        }
        public async Task<IEnumerable<DataEntity>> GetPersonDatas(string personId)
        {
            return await _dbSet.Include(f => f.Files.Select(t => t.FileType)).Include(f => f.Uploader).Where(f => f.PersonId==personId).ToListAsync();
        }
        public async Task<IEnumerable<DataEntity>> GetAllGoodTaskData(int taskId)
        {
            return await _dbSet.Include(f => f.Files).Where(f => f.TaskDatas.Select(s=>s.Task.Id).Contains(taskId)&&f.Status==2).ToListAsync();
        }

        public async Task<DataEntity> GetDataWithFilesAndPersonByTaskDataId(int taskdataId)
        {
            return await _dbSet.Include(f => f.Files.Select(t => t.FileType)).Include(f => f.Uploader).Include(f => f.TaskDatas).Where(f => f.TaskDatas.Select(t=>t.Id).Contains(taskdataId)).FirstOrDefaultAsync();
        }
       

    }
}
