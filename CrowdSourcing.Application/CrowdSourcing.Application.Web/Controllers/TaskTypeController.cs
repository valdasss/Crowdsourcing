using CrowdSourcing.Application.Web.Extension;
using CrowdSourcing.Application.Web.ViewModels;
using CrowdSourcing.Contract.Interfaces;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;


namespace CrowdSourcing.Application.Web.Controllers
{
    [RoutePrefix("TaskType")]
    public class TaskTypeController : ApiController
    {
        private readonly ITaskTypeService _taskTypeService;
        public TaskTypeController(ITaskTypeService taskTypeService)
        {
            _taskTypeService = taskTypeService;
        }

        [HttpGet]
        [Route("getAll")]
        public async Task<IHttpActionResult> GetAllTaskTypes()
        {
            var taskTypes = await _taskTypeService.GetAllTaskTypesAsync();
            return Ok(taskTypes.Select(x => x.ToViewModel()));
        }

        [HttpGet]
        [Route("Get/{taskTypeId}")]
        public async Task<IHttpActionResult> GetTaskType(int taskTypeId)
        {
            var taskTypes = await _taskTypeService.GetTaskTypeBy(taskTypeId);
            return Ok(taskTypes.ToViewModel());
        }

        [HttpPost]
        [Route("Add")]
        public async Task<IHttpActionResult> AddTaskType(TaskTypeViewModel taskType)
        {
            var addedTaskType = await _taskTypeService.AddTaskTypeAsync(taskType.ToModel());
            return Ok(addedTaskType.ToViewModel());
        }

        [HttpPut]
        [Route("Update")]
        public async Task<IHttpActionResult> UpdateTaskType(TaskTypeViewModel taskType)
        {
            var updatedTaskType = await _taskTypeService.UpdateTaskTypeAsync(taskType.ToModel());
            return Ok(updatedTaskType.ToViewModel());
        }

        [HttpDelete]
        [Route("Delete")]
        public async Task<IHttpActionResult> DelteTaskType(TaskTypeViewModel taskType)
        {
            await _taskTypeService.DeleteTaskTypeAsync(taskType.ToModel());
            return Ok();
        }
        [HttpPost]
        [Route("InsertFile")]
        public async Task<HttpResponseMessage> InsertFiles()
        {

            HttpResponseMessage result = null;
            var httpRequest = HttpContext.Current.Request;
            var taskid = int.Parse(httpRequest.Form["taskId"]);           
            if (httpRequest.Files.Count > 0)
            {

                var docfiles = new List<string>();
                foreach (string file in httpRequest.Files)
                {
                    var postedFile = httpRequest.Files[file];
                    var filePath = HttpContext.Current.Server.MapPath("~/App_Data/Uploads/" + postedFile.FileName);
                    postedFile.SaveAs(filePath);
                    docfiles.Add(filePath);                  
                    docfiles.Add(taskid.ToString());
                }
                result = Request.CreateResponse(HttpStatusCode.Created, docfiles);
            }
            else
            {
                result = Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            return result;           
        }
    }
}
