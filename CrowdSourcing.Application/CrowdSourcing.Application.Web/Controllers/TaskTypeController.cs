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
        public async Task<IHttpActionResult> AddTaskType(AddNameVM name)
        {
            var addedTaskType = await _taskTypeService.AddTaskTypeAsync(name.Name);
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
        [Route("Delete/{id}")]
        public async Task<IHttpActionResult> DelteTaskType(int id)
        {
            await _taskTypeService.DeleteTaskTypeAsync(id);
            return Ok();
        }
      
    }
}
