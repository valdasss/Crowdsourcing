using CrowdSourcing.Contract.Model;
using CrowdSourcing.Contract.Model.DataModels;
using CrowdSourcing.Contract.Model.TaskDataModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CrowdSourcing.Contract.Interfaces
{
    public interface IDataService
    {
        Task<IEnumerable<DataModel>> GetAllDatasAsync();
        Task<DataModel> AddDataAsync(AddTaskDataModel model);
        Task<DataModel> UpdateRoleAsync(UpdateDataModel roleModel);
        Task<DataModel> GetDataBy(int id);
        Task DeleteDataAsync(int id);
    }
}
