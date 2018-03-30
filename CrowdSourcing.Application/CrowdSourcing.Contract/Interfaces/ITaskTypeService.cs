using CrowdSourcing.Contract.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CrowdSourcing.Contract.Interfaces
{
    public interface ITaskTypeService
    {
        Task<IEnumerable<TaskTypeModel>> GetAllTaskTypesAsync();
        Task<TaskTypeModel> AddTaskTypeAsync(TaskTypeModel taskTypeModel);
        Task<TaskTypeModel> UpdateTaskTypeAsync(TaskTypeModel taskTypeModel);
        Task<TaskTypeModel> GetTaskTypeBy(int taskTypeId);
        Task DeleteTaskTypeAsync(TaskTypeModel taskTypeModel);
    }
}

