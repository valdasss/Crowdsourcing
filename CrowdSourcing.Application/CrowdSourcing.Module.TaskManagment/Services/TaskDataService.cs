using CrowdSourcing.Contract.Interfaces;
using CrowdSourcing.Contract.Model.TaskDataModel;
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

        public Task<TaskDataModel> AddTaskDataAsync(TaskDataModel roleName)
        {
            throw new NotImplementedException();
        }

        public Task DeleteTaskDataAsync(string taskId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TaskDataModel>> GetAllTaskData()
        {
            throw new NotImplementedException();
        }

        public Task<TaskDataModel> GetTaskDataBy(string taskId)
        {
            throw new NotImplementedException();
        }

        public Task<TaskDataModel> UpdateTaskDataAsync(TaskDataModel roleModel)
        {
            throw new NotImplementedException();
        }
    }
}
