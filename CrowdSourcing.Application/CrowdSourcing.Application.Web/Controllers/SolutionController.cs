using CrowdSourcing.Application.Web.ViewModels;
using CrowdSourcing.Contract.Interfaces;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.Http;

namespace CrowdSourcing.Application.Web.Controllers
{
    [RoutePrefix("Solution")]
    public class SolutionController : ApiController
    {
        private ISolutionService _solutionService;

        public SolutionController(ISolutionService solutionService)
        {
            _solutionService = solutionService;
        }

        [HttpPost]
        [Route("Add")]
        public async Task<IHttpActionResult> AddTask(AddSolutionModelVM model)
        {          
            var identityClaims = (ClaimsIdentity)User.Identity;
            var adminId = identityClaims.FindFirst("Id").Value;
            var solution = await _solutionService.AddSolution(adminId,model.ExpertId,model.TaskDataId);
            return Ok(solution);
        }
        [HttpGet]
        [Route("GetDetailedSolutionInfo/{id}")]
        public async Task<IHttpActionResult> GetDetailedSolutionInfo(int id)
        {
            var solution = await _solutionService.GetDetailedSolutionInformation(id);
            return Ok(solution);
        }
        [HttpGet]
        [Route("GetDetailedSolutionInfoForExpert/{id}")]
        public async Task<IHttpActionResult> GetDetailedSolutionInfofForExpert(int id)
        {
            var solution = await _solutionService.GetDetailedSolutionInformationForExpert(id);
            return Ok(solution);
        }
        [HttpGet]
        [Route("GetTaskSolutions/{id}")]
        public async Task<IHttpActionResult> GetTasksSolutions(int id)
        {
            var solution = await _solutionService.GetSolutionsByTaskId(id);
            return Ok(solution);
        }
        [HttpGet]
        [Route("GetExpertSolutions")]
        public async Task<IHttpActionResult> GetExertSolutions()
        {
            var identityClaims = (ClaimsIdentity)User.Identity;
            var expertId = identityClaims.FindFirst("Id").Value;
            var solution = await _solutionService.GetSolutionsByExpertId(expertId);
            return Ok(solution);
        }
        [HttpPut]
        [Route("ChangeSolutionStatus")]
        public async Task<IHttpActionResult> ChangeSolutionStatus(ChangeSolutionStatusVM statusVM)
        {
            var solution = await _solutionService.UpdateSolutionsStatus(statusVM.SolutionId,statusVM.StatusId);
            return Ok(solution);
        }
    }
}
