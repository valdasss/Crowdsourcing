using CrowdSourcing.Contract.Interfaces;
using CrowdSourcing.Contract.Model.PersonModel;
using CrowdSourcing.Contract.Model.SolutionModels;
using CrowdSourcing.EntityCore.Entity;
using CrowdSourcing.EntityCore.Extension;
using CrowdSourcing.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            var admin = await _personService.GetPersonById(adminId);
            var adminRole = await _roleService.GetRoleByName("admin");
            var expertRole = await _roleService.GetRoleByName("expert");
            var expert = await _personService.GetPersonById(expertId);
            var solutionEntity = new SolutionEntity()
            {
                AdminId=admin.Id,
                AdminRoleId=adminRole.Id,
                ExpertId=expert.Id,
                ExpertRoleId=expertRole.Id,
                TaskDataId= taskDataId,
                Status = 1,
                SolutionDate = DateTime.Now              
            };
            var result = await _solutionRepository.AddAsync(solutionEntity);
            await _dataService.ChangeDatasStatusByTaskDataId(result.TaskDataId,1);
            return result.ToAddModel();
        }

        public async Task<SolutionInfoModel> GetDetailedSolutionInformation(int solutionId)
        {
            var solution = await _solutionRepository.GetByIdAsync(solutionId);
            var admin = await _personService.GetPersonById(solution.AdminId);
            var expert = await _personService.GetPersonById(solution.ExpertId);
            var taskData = await _dataService.GetDataForMoreDetailsByTaskDataId(solution.TaskDataId);
            var result = new SolutionInfoModel()
            {
                SolutionId = solution.Id,
                AssignDate = solution.SolutionDate,
                AssignerName = admin.Name,
                AssignerLastName = admin.LastName,
                ExpertsComment = solution.Comment,
                Status = solution.Status,
                UploadersComment = taskData.UploaderComment,
                Files = taskData.Files,
                DataId = taskData.DataId
            };
            return result;

        }
        public async Task<DetailedSolutionModelForExpert> GetDetailedSolutionInformationForExpert(int solutionId)
        {
            var solution = await _solutionRepository.GetByIdAsync(solutionId);
            var admin = await _personService.GetPersonById(solution.AdminId);
            var expert = await _personService.GetPersonById(solution.ExpertId);
            var taskData = await _dataService.GetDataForMoreDetailsByTaskDataId(solution.TaskDataId);
            var taskDataWithTask = await _taskDataService.GetTaskDataWithTask(solution.TaskDataId);
            var result = new DetailedSolutionModelForExpert()
            {
                SolutionId = solution.Id,
                AssignDate = solution.SolutionDate,
                AssignerName = admin.Name,
                AssignerLastName = admin.LastName,
                ExpertsComment = solution.Comment,
                Status = solution.Status,
                UploadersComment = taskData.UploaderComment,
                DataId =taskData.DataId,
                Files = taskData.Files,
                TaskName = taskDataWithTask.Name,
                TaskDescription = taskDataWithTask.Description
            };
            return result;

        }

        public async Task<IEnumerable<SolutionShortInfoModel>> GetAssignSolutionsByTaskId(int taskId)
        {
            var solutions = await _solutionRepository.GetAssignSolutionsByTaskId(taskId);
            var list = new List<SolutionShortInfoModel>();
            foreach (var solution in solutions)
            {
                var admin = await _personService.GetPersonById(solution.AdminId);
                var expert = await _personService.GetPersonById(solution.ExpertId);
                var solut = new SolutionShortInfoModel()
                {
                    Solutionid = solution.Id,
                    AdminName = admin.Name,
                    AdminLastName = admin.LastName,
                    ExpertName = expert.Name,
                    ExpertLastName = expert.LastName,
                    SolutionCreationDate = solution.SolutionDate,
                    Status = solution.Status
                };
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
                var expert = await _personService.GetPersonById(solution.ExpertId);
                var taskDataWithTask = await _taskDataService.GetTaskDataWithTask(solution.TaskDataId);
                var solut = new SolutionModelForExpertSolutionList()
                {
                    Solutionid = solution.Id,
                    AdminName = admin.Name,
                    AdminLastName = admin.LastName,
                    SolutionCreationDate = solution.SolutionDate,
                    Status = solution.Status,
                    TaskName = taskDataWithTask.Name

                };
                list.Add(solut);
            }
            return list;

        }

        public async Task<AddSolutionModel> UpdateSolutionsStatus(int solutionId,int statusId)
        {
            var solution = await _solutionRepository.GetByIdAsync(solutionId);
            solution.Status = statusId;
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
                var expert = await _personService.GetPersonById(solution.ExpertId);
                var taskDataWithTask = await _taskDataService.GetTaskDataWithTask(solution.TaskDataId);
                var solut = new SolutionModelForExpertSolutionList()
                {
                    Solutionid = solution.Id,
                    AdminName = admin.Name,
                    AdminLastName = admin.LastName,
                    SolutionCreationDate = solution.SolutionDate,
                    Status = solution.Status,
                    TaskName = taskDataWithTask.Name

                };
                list.Add(solut);
            }
            return list;
        }

        public async Task<IEnumerable<SolutionShortInfoModel>> GetDoneSolutionsByTaskId(int taskId)
        {
            var solutions = await _solutionRepository.GetDoneSolutionsByTaskId(taskId);
            var list = new List<SolutionShortInfoModel>();
            foreach (var solution in solutions)
            {
                var admin = await _personService.GetPersonById(solution.AdminId);
                var expert = await _personService.GetPersonById(solution.ExpertId);
                var solut = new SolutionShortInfoModel()
                {
                    Solutionid = solution.Id,
                    AdminName = admin.Name,
                    AdminLastName = admin.LastName,
                    ExpertName = expert.Name,
                    ExpertLastName = expert.LastName,
                    SolutionCreationDate = solution.SolutionDate,
                    Status = solution.Status
                };
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
                return solutions.Sum(s => s.Rating) / amount;
            }
            return 0;
        }
    }
}
