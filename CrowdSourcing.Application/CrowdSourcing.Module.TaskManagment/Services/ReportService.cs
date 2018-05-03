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
        public ReportService(IPersonService personService,ISolutionService solutionService)
        {
            _personService = personService;
            _solutionService = solutionService;
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

        public Task<IEnumerable<TaskReportModel>> GetTaskReport()
        {
            throw new NotImplementedException();
        }
    }
}
