using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrowdSourcing.Contract.Interfaces;
using CrowdSourcing.Contract.Model;
using CrowdSourcing.Contract.Model.Taskmodels;
using CrowdSourcing.EntityCore.Entity;
using CrowdSourcing.EntityCore.Extension;
using CrowdSourcing.Repository.Interface;

namespace CrowdSourcing.Module.TaskManagment.Services
{
    public class TaskService : ITaskService
    {
        private ITaskRepository _taskRepository;
        
        public TaskService(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public async Task<UpdateTaskModel> AddTaskAsync(AddTaskModel taskModel)
        {
            
            var taskEntity = new TaskEntity()
            {
                Name = taskModel.Name,
                TaskTypeId = taskModel.TaskTypeId,
                Description = taskModel.Description,
                Status = 0
            };

            var result= await _taskRepository.AddAsync(taskEntity);
            return result.ToFullModel();
        }

        public async Task DeleteTaskAsync(int id)
        {
            await _taskRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<TaskModel>> GetAllTasksWithTypeAsync()
        {
            var tasks = await _taskRepository.getAllTaskWithType();
            return tasks.Select(t => t.ToModel());
        }

        public async Task<TaskModel> GetTaskAsync(int id)
        {
            var task = await _taskRepository.getTaskWithTypeBy(id);
            return task.ToModel();
        }
        public async Task<UpdateTaskModel> GetTaskFullModelAsync(int id)
        {
            var task = await _taskRepository.GetByIdAsync(id);
            return task.ToFullModel();
        }

        public async Task<UpdateTaskModel> UpdateTaskAsync(UpdateTaskModel taskModel)
        {
            var taskEntity = await _taskRepository.GetByIdAsync(taskModel.Id);
            taskEntity.Name = taskModel.Name;
            taskEntity.TaskTypeId = taskModel.TaskTypeId;
            taskEntity.Description = taskModel.Description;
            taskEntity.Status = taskModel.Status;
            var result = await _taskRepository.UpdateAsync(taskEntity);
            return result.ToFullModel();

        }
    }
}
