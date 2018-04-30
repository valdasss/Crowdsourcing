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

namespace CrowdSourcing.Repository.SolutionManagment
{
    public class SolutionRepository : GenericRepository<SolutionEntity>,ISolutionRepository
    {
        private readonly IDbContext _dbContext;
        private readonly DbSet<SolutionEntity> _dbSet;
        private DbContext Context => (DbContext)_dbContext;

        public SolutionRepository(IDbContext context) : base(context)
        {
            _dbContext = context;
            _dbSet = Context.Set<SolutionEntity>();
        }
        public async Task<SolutionEntity> GetSolutionWithExpertAndAdmin(int id)
        {
            var solution = await _dbSet.Where(s => s.Id == id).FirstOrDefaultAsync();
            return solution;
        }
        public async Task<IEnumerable<SolutionEntity>> GetSolutionsByTaskId(int taskId)
        {
            var solution = await _dbSet.Include(s => s.TaskData.Task).Where(s => s.TaskData.Task.Id == taskId).ToListAsync();
            return solution;
        }

        public async Task<IEnumerable<SolutionEntity>> GetSolutionsByExpertId(string expertId)
        {
            var solution = await _dbSet.Where(s => s.ExpertId == expertId).ToListAsync();
            return solution;
        }
    }
}
