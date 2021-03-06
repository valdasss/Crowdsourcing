﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        private ITaskTypeService _taskTypeService;

        public TaskService(ITaskRepository taskRepository, ITaskTypeService taskTypeService)
        {
            _taskRepository = taskRepository;
            _taskTypeService = taskTypeService;
        }

        public async Task<UpdateTaskModel> AddTaskAsync(AddTaskModel taskModel)
        {
            await ValidateNewTaskModel(taskModel);
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

        public async Task ChangeTaskTypeToNotFoundAndDeleteTaskType(int taskTypeId)
        {
            var tasks = await _taskRepository.GetAllTasksByTaskTypeId(taskTypeId);
            foreach (var task in tasks)
            {
                task.TaskTypeId = 1;
                await _taskRepository.UpdateAsync(task);
            }
           var taskType = await _taskTypeService.GetTaskTypeBy(taskTypeId);
           
           await _taskTypeService.DeleteTaskTypeAsync(taskTypeId);
        }

        public async Task DeleteTaskAsync(int id)
        {
            var taskEntity = await _taskRepository.GetByIdAsync(id);
            if (taskEntity == null)
            {
                throw new ValidationException("Bad data");
            }
            taskEntity.Status = 2;
            await _taskRepository.UpdateAsync(taskEntity);
        }

        public async Task<IEnumerable<TaskModel>> GetAllTasksWithTypeAsync()
        {
            var tasks = await _taskRepository.GetAllTaskWithType();
            return tasks.Select(t => t.ToModel());
        }

        public async Task<TaskModel> GetTaskAsync(int id)
        {
            var task = await _taskRepository.GetTaskWithTypeBy(id);
            if (task == null)
            {
                throw new ValidationException("Bad data");
            }
            return task.ToModel();
        }
        public async Task<UpdateTaskModel> GetTaskFullModelAsync(int id)
        {
            var task = await _taskRepository.GetByIdAsync(id);
            if (task == null)      
            {
                throw new ValidationException("Bad data");
            }
            return task.ToFullModel();
        }

        public async Task<UpdateTaskModel> UpdateTaskAsync(UpdateTaskModel taskModel)
        {
            await ValidateTaskUpdate(taskModel);
            var taskEntity = await _taskRepository.GetByIdAsync(taskModel.Id);
            if(taskEntity==null)
            {
                throw new ValidationException("Bad data");
            }
            taskEntity.Name = taskModel.Name;
            taskEntity.TaskTypeId = taskModel.TaskTypeId;
            taskEntity.Description = taskModel.Description;
            taskEntity.Status = taskModel.Status;
            var result = await _taskRepository.UpdateAsync(taskEntity);
            return result.ToFullModel();

        }
        private async Task ValidateNewTaskModel(AddTaskModel model)
        {
            if (string.IsNullOrEmpty(model.Name) || string.IsNullOrEmpty(model.Description))
            {
                throw new ValidationException("Bad data");
            }
          var tasktype= await _taskTypeService.GetTaskTypeBy(model.TaskTypeId);
            
        }
        private async Task ValidateTaskUpdate(UpdateTaskModel model)
        {
            if (string.IsNullOrEmpty(model.Name) || string.IsNullOrEmpty(model.Description)||
                model.Status>=3||model.TaskTypeId<1)
            {
                throw new ValidationException("Bad data");
            }
            await _taskTypeService.GetTaskTypeBy(model.TaskTypeId);
        }
    }
}
