using CrowdSourcing.Contract.Model.PersonModel;
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
        Task<AddSolutionModel> AddSolutionForDoubleCheck(string adminId, string expertId, int solutionId)
        Task<AddSolutionModel> UpdateSolutionsStatus(int solutionId, int statusId, string comment);
        Task<SolutionInfoModel> GetDetailedSolutionInformation(int solutionId);
        Task<DetailedSolutionModelForExpert> GetDetailedSolutionInformationForExpert(int solutionId);
        Task<IEnumerable<SolutionShortInfoModel>> GetAssignSolutionsByTaskId(int taskId);
        Task<IEnumerable<SolutionShortInfoModel>> GetDoneSolutionsByTaskId(int taskId);
        Task<IEnumerable<SolutionModelForExpertSolutionList>> GetAssignedSolutionsByExpertId(string expertId);
        Task<IEnumerable<SolutionModelForExpertSolutionList>> GetDoneSolutionsByExpertId(string expertId);
        Task<double> CountExpertRating(string expertId);
        Task<IEnumerable<ExpertForDropdown>> GetAllExpertsWithRating();
        Task<IEnumerable<SolutionModelForDoubleCheck>> GetLatestSolutionsForDoubleCheck(int taskId);
    }
}

