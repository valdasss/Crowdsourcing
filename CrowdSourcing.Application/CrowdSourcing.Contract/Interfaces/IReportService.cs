using CrowdSourcing.Contract.Model.ReportModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CrowdSourcing.Contract.Interfaces
{
    public interface IReportService
    {
        Task<IEnumerable<ExpertReportModel>> GetExpertReport();
       // Task<IEnumerable<TaskReportModel>> GetTaskReport();
        
    }
}
