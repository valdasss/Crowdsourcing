using CrowdSourcing.Contract.Interfaces;
using CrowdSourcing.Contract.Model.PersonModel;
using CrowdSourcing.Contract.Model.SolutionModels;
using CrowdSourcing.EntityCore.Extension;
using CrowdSourcing.Repository.Interface;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrowdSourcing.Module.TaskManagment.Services
{
    public class SolutionService : ISolutionService
    {
        private IPersonService _personService;
        private ISolutionRepository _solutionRepository;
        private IRoleService _roleService;
        private IDataService _dataService;
        private ITaskDataService _taskDataService;
        
        public SolutionService(ISolutionRepository solutionRepository,IPersonService personService,
            IRoleService roleService, IDataService dataService,ITaskDataService taskDataService)
        {
            _personService = personService;
            _solutionRepository = solutionRepository;
            _roleService = roleService;
            _dataService = dataService;
            _taskDataService = taskDataService;
        }

        public async Task<AddSolutionModel> AddSolution(string adminId, string expertId, int taskDataId)
        {         
            var adminRole = await _roleService.GetRoleByName("admin");
            var expertRole = await _roleService.GetRoleByName("expert");
            var solutionEntity = SolutionExtensions.ToEntityModel(expertId, expertRole.Id, adminId, adminRole.Id, taskDataId);
            var result = await _solutionRepository.AddAsync(solutionEntity);
            await _dataService.ChangeDatasStatusByTaskDataId(result.TaskDataId,1);
            return result.ToAddModel();
        }

        public async Task<AddSolutionModel> AddSolutionForDoubleCheck(string adminId, string expertId, int solutionId)
        {
            var adminRole = await _roleService.GetRoleByName("admin");
            var expertRole = await _roleService.GetRoleByName("expert");
            var solution = await _solutionRepository.GetByIdAsync(solutionId);
            var solutionEntity = SolutionExtensions.ToEntityModel(expertId, expertRole.Id, adminId, adminRole.Id, solution.TaskDataId, solution.Id);
            var result = await _solutionRepository.AddAsync(solutionEntity);
            await _dataService.ChangeDatasStatusByTaskDataId(result.TaskDataId, 1);
            return result.ToAddModel();
        }

        public async Task<SolutionInfoModel> GetDetailedSolutionInformation(int solutionId)
        {
            var solution = await _solutionRepository.GetByIdAsync(solutionId);
            var admin = await _personService.GetPersonById(solution.AdminId);
            var expert = await _personService.GetPersonById(solution.ExpertId);
            var taskData = await _dataService.GetDataForMoreDetailsByTaskDataId(solution.TaskDataId);
            return solution.ToSolutionInfoModel(admin,expert,taskData);
        }

        public async Task<DetailedSolutionModelForExpert> GetDetailedSolutionInformationForExpert(int solutionId)
        {
            var solution = await _solutionRepository.GetByIdAsync(solutionId);
            var admin = await _personService.GetPersonById(solution.AdminId);
            var taskData = await _dataService.GetDataForMoreDetailsByTaskDataId(solution.TaskDataId);
            var taskDataWithTask = await _taskDataService.GetTaskDataWithTask(solution.TaskDataId);
            return solution.ToDetailsSolutionModelForExpert(admin, taskData, taskDataWithTask);
        }

        public async Task<IEnumerable<SolutionShortInfoModel>> GetAssignSolutionsByTaskId(int taskId)
        {
            var solutions = await _solutionRepository.GetAssignSolutionsByTaskId(taskId);
            var list = new List<SolutionShortInfoModel>();
            foreach (var solution in solutions)
            {
                var admin = await _personService.GetPersonById(solution.AdminId);
                var expert = await _personService.GetPersonById(solution.ExpertId);
                var solut = solution.ToSolutionShortInfoModel(admin,expert);
                list.Add(solut);
            }
            return list;
        }

        public async Task<IEnumerable<SolutionModelForExpertSolutionList>> GetAssignedSolutionsByExpertId(string expertId)
        {
            var solutions = await _solutionRepository.GetAssingedSolutionsByExpertId(expertId);
            var list = new List<SolutionModelForExpertSolutionList>();
            foreach (var solution in solutions)
            {
                var admin = await _personService.GetPersonById(solution.AdminId);            
                var taskDataWithTask = await _taskDataService.GetTaskDataWithTask(solution.TaskDataId);
                var solut = solution.ToSolutionForExpertSolutionList(admin, taskDataWithTask);
                list.Add(solut);
            }
            return list;

        }

        public async Task<AddSolutionModel> UpdateSolutionsStatus(int solutionId,int statusId,string comment)
        {
            var solution = await _solutionRepository.GetByIdAsync(solutionId);
            solution.Status = statusId;
            solution.Comment = comment;
            var result = await _solutionRepository.UpdateAsync(solution);
            await _dataService.ChangeDatasStatusByTaskDataId(solution.TaskDataId, statusId);
            await _taskDataService.SetFinishDate(solution.TaskDataId);
            return result.ToAddModel();
        }

        public async Task<IEnumerable<SolutionModelForExpertSolutionList>> GetDoneSolutionsByExpertId(string expertId)
        {
            var solutions = await _solutionRepository.GetDoneSolutionsByExpertId(expertId);
            var list = new List<SolutionModelForExpertSolutionList>();
            foreach (var solution in solutions)
            {
                var admin = await _personService.GetPersonById(solution.AdminId);
                var taskDataWithTask = await _taskDataService.GetTaskDataWithTask(solution.TaskDataId);
                var solut = solution.ToSolutionForExpertSolutionList(admin, taskDataWithTask);
                list.Add(solut);
            }
            return list;
        }

        public async Task<IEnumerable<SolutionShortInfoModel>> GetAcceptedSolutionsByTaskId(int taskId)
        {
            var solutions = await _solutionRepository.GetAcceptedSolutionsByTaskId(taskId);
            var list = new List<SolutionShortInfoModel>();
            foreach (var solution in solutions)
            {
                var admin = await _personService.GetPersonById(solution.AdminId);
                var expert = await _personService.GetPersonById(solution.ExpertId);
                var solut = solution.ToSolutionShortInfoModel(admin, expert);
                list.Add(solut);
            }
            return list;

        }

        public async Task<IEnumerable<SolutionShortInfoModel>> GetRejectedSolutionsByTaskId(int taskId)
        {
            var solutions = await _solutionRepository.GetRejectedSolutionsByTaskId(taskId);
            var list = new List<SolutionShortInfoModel>();
            foreach (var solution in solutions)
            {
                var admin = await _personService.GetPersonById(solution.AdminId);
                var expert = await _personService.GetPersonById(solution.ExpertId);
                var solut = solution.ToSolutionShortInfoModel(admin, expert);
                list.Add(solut);
            }
            return list;

        }

        public async Task<IEnumerable<ExpertForDropdown>> GetAllExpertsWithRating()
        {
            var allExperts = await _personService.GetAllExperts();
            foreach (var expert in allExperts)
            {
                var rating = await CountExpertRating(expert.ExpertId);
                expert.Rating = rating;
            }
            return allExperts;
        }

        public async Task<double> CountExpertRating(string expertId)
        {
            var solutions = await _solutionRepository.GetSolutionsWithRatingByExpertId(expertId);
            var amount = solutions.Count();
            if (amount > 0)
            {
                double rating = (double)solutions.Sum(s => s.Rating) / amount;
                return System.Math.Round(rating, 2);
            }
            return 0;
        }

        public async  Task<IEnumerable<SolutionModelForDoubleCheck>> GetLatestSolutionsForDoubleCheck(int taskId)
        {
            var latestSolutions = await _solutionRepository.GetLatestSolutionsByTaskId(taskId);
            var newList = new List<SolutionModelForDoubleCheck>();
            foreach (var solution in latestSolutions)
            {
                var expert = await _personService.GetPersonById(solution.ExpertId);
                var taskDataWithTask = await _taskDataService.GetTaskDataWithTask(solution.TaskDataId);
                var solutionModel = solution.ToSolutionModelForDoubleCheck(expert, taskDataWithTask);
                newList.Add(solutionModel);
            }
            return newList;
        }

        public async Task<SolutionModelForRating> RateSolution(int solutionId, int rating)
        {
            var solutionEntity = await _solutionRepository.GetByIdAsync(solutionId);
            solutionEntity.Rating = rating;
            var result = await _solutionRepository.UpdateAsync(solutionEntity);
            return result.ToRatingModel();
        }

        public async Task<IEnumerable<AddSolutionModel>> GetAllSolutionByExpertId(string expertId)
        {
            var solutions = await _solutionRepository.GetAllSolutionsBy(expertId);
            return solutions.Select(s => s.ToAddModel());
        }
        public async Task<IEnumerable<AddSolutionModel>> GetAllSolutionByTaskId(int taskId)
        {
            var solutions = await _solutionRepository.GetAllSolutionsByTaskId(taskId);
            return solutions.Select(s => s.ToAddModel());
        }

        public async Task<IEnumerable<ExpertSolutionsHistoryModel>> GetExpertsSolutionHistory(string expertId)
        {
            var solutionHistory = await _solutionRepository.GetAllSolutionsByWithTaskAndData(expertId);
            var list = new List<ExpertSolutionsHistoryModel>();
            foreach (var solut in solutionHistory)
            {
                var user = await _personService.GetPersonById(solut.TaskData.Data.PersonId);
                var taskName = solut.TaskData.Task.Name;
                var taskType = solut.TaskData.Task.TaskType.Name;

                var listItem = new ExpertSolutionsHistoryModel()
                {
                    UploaderName = user.Name,
                    UploaderLastName = user.LastName,
                    Status = solut.Status,
                    Date  =solut.SolutionDate,
                    TaskName = taskName,
                    TaskType= taskType
                };
                list.Add(listItem);
            }
            return list;
        }
    }
}
