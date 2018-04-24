using System.Collections.Generic;
using System.Threading.Tasks;
using CrowdSourcing.Contract.Interfaces;
using CrowdSourcing.Contract.Model;
using CrowdSourcing.Contract.Model.Taskmodels;
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

        public Task<TaskModel> AddTaskAsync(AddTaskModel taskModel)
        {
            throw new System.NotImplementedException();
        }

        public Task DeletePersonAsync(string id)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<TaskModel>> GetAllTasksWithTypeAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<TaskModel> GetPersonByEmail(string email)
        {
            throw new System.NotImplementedException();
        }

        public Task<TaskModel> GetPersonById(string id)
        {
            throw new System.NotImplementedException();
        }

        public Task<TaskModel> UpdatePersonAsync(PersonModel personModel)
        {
            throw new System.NotImplementedException();
        }
    }
}
