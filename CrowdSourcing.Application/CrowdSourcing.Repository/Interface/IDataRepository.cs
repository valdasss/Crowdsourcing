using CrowdSourcing.EntityCore.Common;
using CrowdSourcing.EntityCore.Entity;
using System.Threading.Tasks;

namespace CrowdSourcing.Repository.Interface
{
    public interface IDataRepository : IGenericRepository<DataEntity>
    {
        Task<DataEntity> GetDataWithFilesAndPersonBy(int dataId);
        Task<DataEntity> GetDataWithFilesAndPersonByTaskDataId(int taskdataId);
    }
}
