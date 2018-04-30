using CrowdSourcing.Contract.Model.SolutionModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrowdSourcing.Contract.Interfaces
{
    public interface ISolutionService
    {
        Task<AddSolutionModel> AddSolution(string adminId,string expertId,int taskDataId);
        Task<AddSolutionModel> UpdateSolutionsStatus(int solutionId,int statusId);
        Task<SolutionInfoModel> GetDetailedSolutionInformation(int solutionId);
        Task<DetailedSolutionModelForExpert> GetDetailedSolutionInformationForExpert(int solutionId);
        Task<IEnumerable<SolutionShortInfoModel>> GetSolutionsByTaskId(int taskId);
        Task<IEnumerable<SolutionModelForExpertSolutionList>> GetSolutionsByExpertId(string expertId);
    }
}

