using CrowdSourcing.EntityCore.Common;
using CrowdSourcing.EntityCore.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CrowdSourcing.Repository.Interface
{
    public interface ITaskDataRepository : IGenericRepository<TaskDataEntity>
    {
        Task<IEnumerable<TaskDataEntity>> GetDataBy(int taskId);
        Task<IEnumerable<TaskDataEntity>> GetDataForDataReviewDropdownBy(int taskId);
        Task<TaskDataEntity> GetTaskDatawithTaskBy(int taskId);
        Task<IEnumerable<TaskDataEntity>> GetDatasByDataId(int dataId);
        Task<TaskDataEntity> GetTaskDatawithDataBy(int taskDataId);
    }
}
