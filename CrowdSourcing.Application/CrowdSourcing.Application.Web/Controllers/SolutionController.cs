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
        public async Task<IHttpActionResult> AddSolution(AddSolutionModelVM model)
        {          
            var identityClaims = (ClaimsIdentity)User.Identity;
            var adminId = identityClaims.FindFirst("Id").Value;
            var solution = await _solutionService.AddSolution(adminId,model.ExpertId,model.TaskDataId);
            return Ok(solution);
        }
        [HttpPost]
        [Route("AddDoubleCheck")]
        public async Task<IHttpActionResult> AddSolutionForDoubleCheck(AddSolutionForDoubleCheckVM model)
        {
            var identityClaims = (ClaimsIdentity)User.Identity;
            var adminId = identityClaims.FindFirst("Id").Value;
            var solution = await _solutionService.AddSolutionForDoubleCheck(adminId, model.ExpertId, model.SolutionId);
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
        [Route("GetAssignTaskSolutions/{id}")]
        public async Task<IHttpActionResult> GetAssignTasksSolutions(int id)
        {
            var solution = await _solutionService.GetAssignSolutionsByTaskId(id);
            return Ok(solution);
        }
        [HttpGet]
        [Route("GetAcceptedTaskSolutions/{id}")]
        public async Task<IHttpActionResult> GetAcceptedTasksSolutions(int id)
        {
            var solution = await _solutionService.GetAcceptedSolutionsByTaskId(id);
            return Ok(solution);
        }
        [HttpGet]
        [Route("GetRejectedTaskSolutions/{id}")]
        public async Task<IHttpActionResult> GeRejectedTasksSolutions(int id)
        {
            var solution = await _solutionService.GetRejectedSolutionsByTaskId(id);
            return Ok(solution);
        }
        [HttpGet]
        [Route("GetLatestSolutionsForDoubleCheck/{id}")]
        public async Task<IHttpActionResult> GetLatestSolutionsForDoubleCheck(int id)
        {
            var solutions = await _solutionService.GetLatestSolutionsForDoubleCheck(id);
            return Ok(solutions);
        }

        [HttpGet]
        [Route("GetAssignedExpertSolutions")]
        public async Task<IHttpActionResult> GetAssignedExertSolutions()
        {
            var identityClaims = (ClaimsIdentity)User.Identity;
            var expertId = identityClaims.FindFirst("Id").Value;
            var solution = await _solutionService.GetAssignedSolutionsByExpertId(expertId);
            return Ok(solution);
        }
        [HttpGet]
        [Route("GetDoneExpertSolutions")]
        public async Task<IHttpActionResult> GetDoneExertSolutions()
        {
            var identityClaims = (ClaimsIdentity)User.Identity;
            var expertId = identityClaims.FindFirst("Id").Value;
            var solution = await _solutionService.GetDoneSolutionsByExpertId(expertId);
            return Ok(solution);
        }
        [HttpPut]
        [Route("ChangeSolutionStatus")]
        public async Task<IHttpActionResult> ChangeSolutionStatus(ChangeSolutionStatusVM statusVM)
        {
            var solution = await _solutionService.UpdateSolutionsStatus(statusVM.SolutionId,statusVM.StatusId,statusVM.Comment);
            return Ok(solution);
        }
        [HttpPut]
        [Route("RateSolution")]
        public async Task<IHttpActionResult> RateSolution(RateSolutionVM statusVM)
        {
            var solution = await _solutionService.RateSolution(statusVM.SolutionId, statusVM.Rating);
            return Ok(solution);
        }
    }
}
