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
        Task<IEnumerable<SolutionEntity>> GetDoneSolutionsByTaskId(int taskId);
        Task<IEnumerable<SolutionEntity>> GetSolutionsByExpertId(string expertId);
        Task<IEnumerable<SolutionEntity>> GetAssingedSolutionsByExpertId(string expertId);
        Task<IEnumerable<SolutionEntity>> GetDoneSolutionsByExpertId(string expertId);
    }
}
