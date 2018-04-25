﻿using CrowdSourcing.Contract.Interfaces;
using CrowdSourcing.Contract.Model.TaskDataModel;
using CrowdSourcing.EntityCore.Entity;
using CrowdSourcing.EntityCore.Extension;
using CrowdSourcing.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrowdSourcing.Module.TaskManagment.Services
{
    public class TaskDataService : ITaskDataService
    {

        private ITaskDataRepository _taskDataRepository;

        public TaskDataService(ITaskDataRepository taskDataRepository)
        {
            _taskDataRepository = taskDataRepository;
        }

        public async Task<TaskDataModel> AddTaskDataAsync(AddTaskDataModel model)
        {
            var taskData = new TaskDataEntity()
            {
                DataId = model.DataId,
                TaskId = model.TaskId
            };
            var result = await _taskDataRepository.AddAsync(taskData);
            return result.ToModel();
        }

        public async Task DeleteTaskDataAsync(string taskId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<TaskDataModel>> GetAllTaskData()
        {
            throw new NotImplementedException();
        }

        public async Task<TaskDataModel> GetTaskDataBy(string taskId)
        {
            throw new NotImplementedException();
        }

        public async Task<TaskDataModel> UpdateTaskDataAsync(TaskDataModel roleModel)
        {
            throw new NotImplementedException();
        }
    }
}
