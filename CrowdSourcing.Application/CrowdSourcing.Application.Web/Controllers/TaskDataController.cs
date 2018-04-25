using CrowdSourcing.Contract.Interfaces;
using CrowdSourcing.Contract.Model.TaskDataModel;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace CrowdSourcing.Application.Web.Controllers
{
    [RoutePrefix("TaskData")]
    public class TaskDataController : ApiController
    {
        private ITaskDataService _taskDataService;

        public TaskDataController(ITaskDataService taskDataService)
        {
            _taskDataService = taskDataService;
        }

        [HttpPost]
        [Route("Add")]
        public async Task<IHttpActionResult> AddTaskData()
        {       
            var httpRequest = HttpContext.Current.Request;
            var model = new AddTaskDataModel
            {
                TaskId = int.Parse(httpRequest.Form["TaskId"]),
                Description = httpRequest.Form["Description"]
            };
            var identityClaims = (ClaimsIdentity)User.Identity;
            model.UploaderId = identityClaims.FindFirst("Id").Value;
            model.UploadedFiles = httpRequest.Files;         
            var result = await _taskDataService.AddTaskDataAsync(model);
            return Ok(result);
        }
        [HttpGet]
        [Route("GetForTable/{id}")]
        public async Task<IHttpActionResult> GetDataForTable(int id)
        {
            var datas = await _taskDataService.GetTaskDatasForTableBy(id);
            return Ok(datas);
        }

    }
}
