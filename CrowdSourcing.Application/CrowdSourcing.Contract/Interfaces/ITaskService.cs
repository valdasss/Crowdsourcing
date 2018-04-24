using CrowdSourcing.Contract.Model;
using CrowdSourcing.Contract.Model.Taskmodels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CrowdSourcing.Contract.Interfaces
{
    public interface ITaskService
    {
        Task<IEnumerable<TaskModel>> GetAllTasksWithTypeAsync();
        Task<UpdateTaskModel> AddTaskAsync(AddTaskModel taskModel);
        Task<UpdateTaskModel> UpdateTaskAsync(UpdateTaskModel taskModel);
        Task<TaskModel> GetTaskAsync(int id);
        Task<UpdateTaskModel> GetTaskFullModelAsync(int id);
        Task DeleteTaskAsync(int id);
    }
}
