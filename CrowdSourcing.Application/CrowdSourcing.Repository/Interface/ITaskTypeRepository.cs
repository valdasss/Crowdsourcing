using CrowdSourcing.EntityCore.Common;
using CrowdSourcing.EntityCore.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CrowdSourcing.Repository.Interface
{
    public interface ITaskTypeRepository : IGenericRepository<TaskTypeEntity>
    {
        Task<IEnumerable<TaskTypeEntity>> GetAllTaskDatasExeptNotFound();
    }
}
