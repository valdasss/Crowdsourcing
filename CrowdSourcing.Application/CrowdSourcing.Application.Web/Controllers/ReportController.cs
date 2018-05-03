using CrowdSourcing.Contract.Interfaces;
using System.Threading.Tasks;
using System.Web.Http;

namespace CrowdSourcing.Application.Web.Controllers
{
    [RoutePrefix("Report")]
    public class ReportController : ApiController
    {

        private IReportService _reportService;

        public ReportController(IReportService reportService)
        {
            _reportService = reportService;
        }

        [HttpGet]
        [Route("GetExpertReport")]
        public async Task<IHttpActionResult> GetExpertReport()
        {           
            var experts = await _reportService.GetExpertReport();
            return Ok(experts);
        }
        [HttpGet]
        [Route("GetTaskReport")]
        public async Task<IHttpActionResult> GetTaskReport()
        {
            var tasks = await _reportService.GetTaskReport();
            return Ok(tasks);
        }
        //[HttpGet]
        //[Route("Get")]
        //public async Task<IHttpActionResult> GetExpertReport()
        //{
        //    var experts = await _reportService.GetExpertReport();
        //    return Ok(experts);
        //}
    }
}
