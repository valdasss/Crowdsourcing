using CrowdSourcing.EntityCore.Common;
using CrowdSourcing.EntityCore.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrowdSourcing.Repository.Interface
{
    public interface ITaskRepository : IGenericRepository<TaskEntity>
    {
        Task<IEnumerable<TaskEntity>> getAllTaskWithType();
        Task<TaskEntity> getTaskWithTypeBy(int id);
    }
}
