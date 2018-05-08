using CrowdSourcing.EntityCore.Common;
using CrowdSourcing.EntityCore.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CrowdSourcing.Repository.Interface
{
    public interface ISolutionRepository : IGenericRepository<SolutionEntity>
    {
        Task<SolutionEntity> GetSolutionWithExpertAndAdmin(int id);
        Task<IEnumerable<SolutionEntity>> GetSolutionsByTaskId(int taskId);
        Task<IEnumerable<SolutionEntity>> GetAssignSolutionsByTaskId(int taskId);
        Task<IEnumerable<SolutionEntity>> GetLatestSolutionsByTaskId(int taskId);
        Task<IEnumerable<SolutionEntity>> GetAcceptedSolutionsByTaskId(int taskId);
        Task<IEnumerable<SolutionEntity>> GetRejectedSolutionsByTaskId(int taskId);
        Task<IEnumerable<SolutionEntity>> GetSolutionsByExpertId(string expertId);
        Task<IEnumerable<SolutionEntity>> GetAssingedSolutionsByExpertId(string expertId);
        Task<IEnumerable<SolutionEntity>> GetDoneSolutionsByExpertId(string expertId);
        Task<IEnumerable<SolutionEntity>> GetSolutionsWithRatingByExpertId(string expertId);
        Task<IEnumerable<SolutionEntity>> GetAllSolutionsBy(string expertId);
        Task<IEnumerable<SolutionEntity>> GetAllSolutionsByTaskId(int taskId);
        Task<IEnumerable<SolutionEntity>> GetAllDoneSolutionsByWithTaskAndData(string expertId);
    }
}
