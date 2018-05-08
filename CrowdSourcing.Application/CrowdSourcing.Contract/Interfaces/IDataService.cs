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
        Task<DataModel> ChangeDatasStatusByTaskDataId(int taskDataId, int statusId);
        Task<DataModel> GetDataBy(int id);
        Task<DataForMoreDetails> GetDataForMoreDetailsBy(int id);
        Task DeleteDataAsync(int id);
        Task<DataForMoreDetails> GetDataForMoreDetailsByTaskDataId(int TaskDataid);
        Task<IEnumerable<DataModel>> GetAllPersonDatasAsync(string personId);
        Task<IEnumerable<int>> GetAllGoodTaskDatasIds(int taskId);
        Task DetelePersonsData(string personId);
        Task<DataModel> UpdateDataStatus(int dataId, int status);
    }
}
