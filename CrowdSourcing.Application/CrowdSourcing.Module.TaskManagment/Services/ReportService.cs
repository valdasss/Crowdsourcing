using CrowdSourcing.Contract.Interfaces;
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
        public ReportService(IPersonService personService,ISolutionService solutionService,ITaskService taskService)
        {
            _personService = personService;
            _solutionService = solutionService;
            _taskService = taskService;
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
                var listItem = new ExpertReportModel()
                {
                    ExpertName = expert.ExpertName,
                    ExpertLastName = expert.ExpertLastName,
                    TotalDoneCount = solution.Count(),
                    AcceptedCount = accepted,
                    DeclinedCount = declined,
                    InProgress = inProgress,
                };

                list.Add(listItem);
            }
            return list;
        }

        //public async Task<IEnumerable<TaskReportModel>> GetTaskReport()
        //{
        //    var tasks = await _taskService.GetAllTasksWithTypeAsync();
        //    var list = new List<TaskReportModel>();
        //    foreach (var task in tasks)
        //    {
        //        var taskDatas = await _ 
        //        var listItem = new TaskReportModel()
        //        {
        //            TaskName= task.Name,
        //            TaskType = task.TaskType,
        //            TaskDataCount = ,
        //            AcceptedSolutionsCount = ,
        //            InProgressCount = , 
        //            DeclinedSolutionsCount =


        //        }

        //    }
        //}
    }
}
