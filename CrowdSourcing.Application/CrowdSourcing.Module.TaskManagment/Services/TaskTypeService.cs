using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrowdSourcing.Contract.CustomExeptions;
using CrowdSourcing.Contract.Interfaces;
using CrowdSourcing.Contract.Model;
using CrowdSourcing.EntityCore.Entity;
using CrowdSourcing.EntityCore.Extension;
using CrowdSourcing.Repository.Interface;

namespace CrowdSourcing.Module.TaskManagment.Services
{
    public class TaskTypeService : ITaskTypeService 
    {
        private readonly ITaskTypeRepository _taskTypeRepository;
        public TaskTypeService(ITaskTypeRepository taskTypeRepository)
        {
            _taskTypeRepository = taskTypeRepository;
        }

        public async Task<TaskTypeModel> AddTaskTypeAsync(string name)
        {
            var taskTypeEntity = new TaskTypeEntity()
            {
                Name = name
            };
            var updatedTaskType = await _taskTypeRepository.AddAsync(taskTypeEntity);
            return updatedTaskType.ToModel();
        }

        public async Task DeleteTaskTypeAsync(int id)
        {
            await _taskTypeRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<TaskTypeModel>> GetAllTaskTypesAsync()
        {
            var taskTypes = await _taskTypeRepository.GetAllAsync();
            return taskTypes.Select(x=>x.ToModel());
        }

        public async Task<TaskTypeModel> GetTaskTypeBy(int taskTypeId)
        {
            var taskType = await _taskTypeRepository.GetByIdAsync(taskTypeId);
            if (taskType == null)
            {
                throw new EntityNotFoundException("TaskType not found");
            }
            return taskType.ToModel();
        }

        public async Task<TaskTypeModel> UpdateTaskTypeAsync(TaskTypeModel taskTypeModel)
        {
            var updatingEntity = await _taskTypeRepository.GetByIdAsync(taskTypeModel.Id);
            updatingEntity.Name = taskTypeModel.Name;
            var updatedEntity = await _taskTypeRepository.UpdateAsync(updatingEntity);
            return updatingEntity.ToModel();
        }
    }
}
