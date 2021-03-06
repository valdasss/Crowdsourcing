﻿using CrowdSourcing.Contract.Interfaces;
using CrowdSourcing.Contract.Model.ReportModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrowdSourcing.Module.TaskManagment.Services
{
    public class ReportService : IReportService
    {
        private IPersonService _personService;
        private ISolutionService _solutionService;
        private ITaskService _taskService;
        private ITaskDataService _taskDataService;
        private IDataService _dataService;
        public ReportService(IPersonService personService,ISolutionService solutionService,
            ITaskService taskService, ITaskDataService taskDataService, IDataService dataService)
        {
            _personService = personService;
            _solutionService = solutionService;
            _taskService = taskService;
            _taskDataService = taskDataService;
            _dataService = dataService;
        }

        public async Task<IEnumerable<ExpertReportModel>> GetExpertReport()
        {
            var experts = await _personService.GetAllExperts();
            var list = new List<ExpertReportModel>();
            foreach (var expert in experts)
            {
                var solution = await _solutionService.GetAllSolutionByExpertId(expert.ExpertId);
                var accepted = solution.Where(x => x.Status == 2).Count();
                var declined = solution.Where(x => x.Status == 3).Count();
                var inProgress = solution.Where(x => x.Status == 1).Count();
                var rating = await _solutionService.CountExpertRating(expert.ExpertId);
                var listItem = new ExpertReportModel()
                {
                    ExpertName = expert.ExpertName,
                    ExpertLastName = expert.ExpertLastName,
                    TotalDoneCount = solution.Count(),
                    AcceptedCount = accepted,
                    DeclinedCount = declined,
                    InProgress = inProgress,
                    Rating = rating
                };

                list.Add(listItem);
            }
            return list;
        }

        public async Task<IEnumerable<TaskReportModel>> GetTaskReport()
        {
            var tasks = await _taskService.GetAllTasksWithTypeAsync();
            var list = new List<TaskReportModel>();
            foreach (var task in tasks)
            {
                var taskDatas = await _taskDataService.GetTaskDatasForTableBy(task.Id);
                var solutions = await _solutionService.GetAllSolutionByTaskId(task.Id);
                var accepted = solutions.Where(s => s.Status == 2).Count();
                var inProgress = solutions.Where(s => s.Status == 1).Count();
                var declined = solutions.Where(s => s.Status == 3).Count();
                var listItem = new TaskReportModel()
                {
                    TaskName = task.Name,
                    TaskType = task.TaskType,
                    TaskDataCount = taskDatas.Count(),
                    AcceptedSolutionsCount = accepted,
                    InProgressCount = inProgress,
                    DeclinedSolutionsCount = declined
                };
                list.Add(listItem);
            }
            return list;
        }

        public async Task<IEnumerable<DataUploadersReportModel>> GetUploadersReport()
        {
            var uploaders = await _personService.GetAllUploaders();
            var list = new List<DataUploadersReportModel>();
            foreach (var uploader in uploaders)
            {
                var datas = await _dataService.GetAllPersonDatasAsync(uploader.ExpertId);
                var acceptedData = datas.Where(d => d.Status == 2).Count();
                var declinedData = datas.Where(d => d.Status == 3).Count();
                var inProgressData = datas.Where(d => d.Status == 1).Count();
                var notAssignedData = datas.Where(d => d.Status == 0).Count();
                var listItem = new DataUploadersReportModel()
                {
                    Name = uploader.ExpertName,
                    LastName = uploader.ExpertLastName,
                    TotalDataCount = datas.Count(),
                    DataAcceptedCount = acceptedData,
                    DataDeclinedCount = declinedData,
                    DataInProgressCount = inProgressData,
                    DataNotAssignedCount = notAssignedData
                };
                list.Add(listItem);
            }
            return list;         
        }
    }
}
