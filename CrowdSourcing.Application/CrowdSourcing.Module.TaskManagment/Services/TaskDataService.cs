using CrowdSourcing.Contract.Interfaces;
using CrowdSourcing.Contract.Model.TaskDataModel;
using CrowdSourcing.EntityCore.Entity;
using CrowdSourcing.EntityCore.Extension;
using CrowdSourcing.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrowdSourcing.Module.TaskManagment.Services
{
    public class TaskDataService : ITaskDataService
    {
        private IPersonService _personService;
        private ITaskDataRepository _taskDataRepository;
        private IDataService _dataService;

        public TaskDataService(ITaskDataRepository taskDataRepository,IDataService dataService,IPersonService personService)
        {
            _taskDataRepository = taskDataRepository;
            _dataService = dataService;
            _personService = personService;
        }

        public async Task<TaskDataModel> AddTaskDataAsync(AddTaskDataModel model)
        {
            var data = await _dataService.AddDataAsync(model);
            var taskData = new TaskDataEntity()
            {
                DataId = data.Id,
                TaskId = model.TaskId
            };
            var result = await _taskDataRepository.AddAsync(taskData);
            return result.ToModel();
        }

        public async Task DeleteTaskDataAsync(int id)
        {
            await _taskDataRepository.DeleteAsync(id);
        }

        public async Task DeleteTaskDataAsyncBy(int dataId)
        {
            var taskDatas = await _taskDataRepository.GetDatasByDataId(dataId);
            foreach(var taskData in taskDatas)
            {
                await _taskDataRepository.DeleteAsync(taskData.Id);
            }
        }

        public  Task<IEnumerable<TaskDataModel>> GetAllTaskData()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ModelForDataReviewDropdown>> GetTaskDatasForDropdownSetReviewBy(int taskId)
        {
            var taskDatas = await _taskDataRepository.GetDataForDataReviewDropdownBy(taskId);
            var listOfModels = new List<ModelForDataReviewDropdown>();
            foreach (var data in taskDatas)
            {
                var person = await _personService.GetPersonById(data.Data.Uploader.UserId);
                var model = new ModelForDataReviewDropdown()
                {
                    TaskDataId = data.Id,
                    UploadTime = data.Data.UploadTime,
                    UploaderLastName = person.LastName,
                    UploaderName = person.Name
                };
                listOfModels.Add(model);
            }
            return listOfModels;
        }

        public async Task<IEnumerable<TaskDataForTable>> GetTaskDatasForTableBy(int taskId)
        {
            var data = await _taskDataRepository.GetDataBy(taskId);
            var newList = new List<TaskDataForTable>();
            foreach (var  element in data)
            {
                var person = await _personService.GetPersonById(element.Data.Uploader.UserId);
                newList.Add(element.ToTableModel(person.Name, person.LastName));
            }
            return newList;
        }

        public async Task<TaskDataWithTaskModel> GetTaskDataWithTask(int taskDataId)
        {
            var taskData = await _taskDataRepository.GetTaskDatawithTaskBy(taskDataId);
            return taskData.TowithTaskModel();
            
        }

        public async Task<TaskDataModel> SetFinishDate(int taskDataId)
        {
            var taskData = await _taskDataRepository.GetByIdAsync(taskDataId);
            taskData.FinishDate = DateTime.Now;
            var result = await _taskDataRepository.UpdateAsync(taskData);
            return result.ToModel();
        }
        public async Task<TaskDataModel> UnsetFinishDateAndChangeDataStatus(int taskDataId)
        {
            var taskData = await _taskDataRepository.GetTaskDatawithDataBy(taskDataId);
            taskData.FinishDate = null;
            var result = await _taskDataRepository.UpdateAsync(taskData);
            await _dataService.UpdateDataStatus(taskData.Data.Id,0);
            return result.ToModel();
        }

        public  Task<TaskDataModel> UpdateTaskDataAsync(TaskDataModel model)
        {
            throw new NotImplementedException();
        }
    }
}
