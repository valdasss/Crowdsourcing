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
        [Authorize(Roles = "admin")]
        public async Task<IHttpActionResult> GetExpertReport()
        {           
            var experts = await _reportService.GetExpertReport();
            return Ok(experts);
        }
        [HttpGet]
        [Route("GetTaskReport")]
        [Authorize(Roles = "admin")]
        public async Task<IHttpActionResult> GetTaskReport()
        {
            var tasks = await _reportService.GetTaskReport();
            return Ok(tasks);
        }
        [HttpGet]
        [Route("GetUploadersReport")]
        [Authorize(Roles = "admin")]
        public async Task<IHttpActionResult> GetUploadersReport()
        {
            var uploaders = await _reportService.GetUploadersReport();
            return Ok(uploaders);
        }
    }
}
