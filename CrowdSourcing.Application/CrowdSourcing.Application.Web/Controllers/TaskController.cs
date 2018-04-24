using CrowdSourcing.Contract.Interfaces;
using CrowdSourcing.Contract.Model.Taskmodels;
using System.Threading.Tasks;
using System.Web.Http;

namespace CrowdSourcing.Application.Web.Controllers
{
    public class TaskController : ApiController
    {

        private ITaskService _taskService;

        public TaskController(ITaskService taskService)
        {
            _taskService = taskService;
        }
        [Route("Task/GetTask/{id}")]
        [HttpGet]
        public async Task<IHttpActionResult> GetTaskById(int id)
        {
            var user = await _taskService.GetTaskAsync(id);
            return Ok(user);
        }

        [Route("Task/GetTaskFullModel/{id}")]
        [HttpGet]
        public async Task<IHttpActionResult> GetTaskFullModelById(int id)
        {
            var user = await _taskService.GetTaskFullModelAsync(id);
            return Ok(user);
        }
        [Route("Task/GetAllTasks")]
        [HttpGet]
        public async Task<IHttpActionResult> GetAllTasks()
        {
            var tasks = await _taskService.GetAllTasksWithTypeAsync();
            return Ok(tasks);
        }

        [Route("Task/Add")]
        [HttpPost]
        public async Task<IHttpActionResult> AddTask(AddTaskModel model)
        {
            var user = await _taskService.AddTaskAsync(model);
            return Ok(user);
        }
        [Route("Task/Update")]
        [HttpPut]
        public async Task<IHttpActionResult> UpdateTask(UpdateTaskModel model)
        {
            var user = await _taskService.UpdateTaskAsync(model);
            return Ok(user);
        }
        [Route("Task/Delete/{id}")]
        [HttpDelete]
        public async Task<IHttpActionResult> DeleteTask(int id)
        {
            await _taskService.DeleteTaskAsync(id);
            return Ok();
        }

    }
}
