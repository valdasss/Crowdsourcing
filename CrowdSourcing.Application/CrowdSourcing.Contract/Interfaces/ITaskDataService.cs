using CrowdSourcing.Contract.Model.TaskDataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrowdSourcing.Contract.Interfaces
{
    public interface ITaskDataService
    {
        Task<IEnumerable<TaskDataModel>> GetAllTaskData();
        Task<TaskDataModel> AddTaskDataAsync(AddTaskDataModel model);
        Task<TaskDataModel> UpdateTaskDataAsync(TaskDataModel model);
        Task<IEnumerable<TaskDataForTable>> GetTaskDatasForTableBy(int taskId);
        Task<IEnumerable<ModelForDataReviewDropdown>> GetTaskDatasForDropdownSetReviewBy(int taskId);
        Task DeleteTaskDataAsync(int id);
    }
}
