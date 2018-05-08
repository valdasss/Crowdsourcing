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

        public async Task<IEnumerable<SolutionEntity>> GetAssingedSolutionsByExpertId(string expertId)
        {
            var solution = await _dbSet.Where(s => s.ExpertId == expertId && s.Status==1).ToListAsync();
            return solution;
        }

        public async Task<IEnumerable<SolutionEntity>> GetDoneSolutionsByExpertId(string expertId)
        {
            var solution = await _dbSet.Where(s => s.ExpertId == expertId && (s.Status == 2 ||s.Status==3)).ToListAsync();
            return solution;
        }

        public async Task<IEnumerable<SolutionEntity>> GetAssignSolutionsByTaskId(int taskId)
        {
            var solution = await _dbSet.Include(s => s.TaskData.Task).Where(s => s.TaskData.Task.Id == taskId&&s.Status==1).ToListAsync();
            return solution;
        }

        public async Task<IEnumerable<SolutionEntity>> GetAcceptedSolutionsByTaskId(int taskId)
        {
            var solution = await _dbSet.Include(s => s.TaskData.Task).Where(s => s.TaskData.Task.Id == taskId&&s.Status==2).ToListAsync();
            return solution;
        }
        public async Task<IEnumerable<SolutionEntity>> GetRejectedSolutionsByTaskId(int taskId)
        {
            var solution = await _dbSet.Include(s => s.TaskData.Task).Where(s => s.TaskData.Task.Id == taskId && s.Status == 3).ToListAsync();
            return solution;
        }
        public async Task<IEnumerable<SolutionEntity>> GetSolutionsWithRatingByExpertId(string expertId)
        {
            var solution = await _dbSet.Where(s => s.ExpertId==expertId && s.Rating>0).ToListAsync();
            return solution;
        }
        public async Task<IEnumerable<SolutionEntity>> GetAllSolutionsBy(string expertId)
        {
            var solution = await _dbSet.Where(s => s.ExpertId == expertId).ToListAsync();
            return solution;
        }
        public async Task<IEnumerable<SolutionEntity>> GetAllSolutionsByWithTaskAndData(string expertId)
        {
            var solution = await _dbSet.Include(s=>s.TaskData.Data).Include(s=>s.TaskData.Task.TaskType).Where(s => s.ExpertId == expertId).ToListAsync();
            return solution;
        }

        public async Task<IEnumerable<SolutionEntity>> GetAllSolutionsByTaskId(int taskId)
        {
            var solution = await _dbSet.Include(s=>s.TaskData.Task).Where(s => s.TaskData.Task.Id == taskId).ToListAsync();
            return solution;
        }

        public async Task<IEnumerable<SolutionEntity>> GetLatestSolutionsByTaskId(int taskId)
        {
            var latestSolutions = await _dbSet.Include(s => s.TaskData.Task).Where(s => s.TaskData.Task.Id == taskId &&(s.Status==2||s.Status==3)).ToListAsync();
            return latestSolutions.GroupBy(s =>s.TaskDataId).Select(x=> 
            {
                var nextReviewDate = x.Max(y => y.SolutionDate);
                return x.LastOrDefault(y => y.SolutionDate == nextReviewDate);
            });
        }
       
    }
}
