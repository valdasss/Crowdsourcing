﻿using CrowdSourcing.Contract.Helpers;
using CrowdSourcing.Contract.Interfaces;
using CrowdSourcing.Contract.Model.DataModels;
using CrowdSourcing.Contract.Model.TaskDataModel;
using CrowdSourcing.EntityCore.Entity;
using CrowdSourcing.EntityCore.Extension;
using CrowdSourcing.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace CrowdSourcing.Module.TaskManagment.Services
{
    public class DataService : IDataService 
    {
        private IRoleService _roleService;
        private IPersonService _personService;
        private IFileService _fileService;
        private IDataRepository _dataRepository;
        private ITaskService _taskService;
        public DataService(IDataRepository dataRepository, IFileService fileService,ITaskService taskService,
            IPersonService personService,IRoleService roleService)
        {
            _dataRepository = dataRepository;
            _fileService = fileService;
            _taskService = taskService;
            _personService = personService;
            _roleService = roleService;
        }

        public async  Task<DataModel> AddDataAsync(AddTaskDataModel model)
        {
            var uploaderRole = await _roleService.GetRoleByName("user");
            var dataEntity = new DataEntity()
            {
                PersonRoleId= uploaderRole.Id,
                Description = model.Description,
                PersonId = model.UploaderId,
                UploadTime = DateTime.Now,
                Status = 0
            };
            var result = await _dataRepository.AddAsync(dataEntity);
            var task = await _taskService.GetTaskAsync(model.TaskId);
            var person = await _personService.GetPersonById(dataEntity.PersonId);
           
            var folderPath = HttpContext.Current.Server.MapPath(string.Format("~/App_Data/Uploads/{0}/{1}/",
                task.Id + task.Name, dataEntity.Id + person.Name + person.LastName));
  
            System.IO.Directory.CreateDirectory(folderPath);
            var filePath = "";
            for (int Loop1 = 0; Loop1 < model.UploadedFiles.Count; Loop1++)
            {
                filePath = string.Format("{0}{1}", folderPath, model.UploadedFiles[Loop1].FileName);
                if (System.IO.File.Exists(filePath))
                {
                    while (System.IO.File.Exists(filePath))
                    {
                        int i = 1;
                        var fileName = UrlParser.GetFileNameWithOutExtension(filePath);
                        var format = UrlParser.GetFileFormatFromPathUrl(filePath);
                        filePath = string.Format("{0}{1}.{2}", folderPath,fileName+
                            string.Format("({0})",i),format);
                    }
                }
                await _fileService.AddFileAsync(filePath,dataEntity.Id);
                model.UploadedFiles[Loop1].SaveAs(filePath);
            }
            return result.ToModel();
        }

        public async Task<DataModel> ChangeDatasStatusToAssignByTaskDataId(int taskDataId)
        {
            var data = await _dataRepository.GetDataWithFilesAndPersonByTaskDataId(taskDataId);
            data.Status = 1;
            var result = await _dataRepository.UpdateAsync(data);
            return result.ToModel();
        }
        public async Task<DataModel> ChangeDatasStatusByTaskDataId(int taskDataId,int statusId)
        {
            var data = await _dataRepository.GetDataWithFilesAndPersonByTaskDataId(taskDataId);
            data.Status = statusId;
            var result = await _dataRepository.UpdateAsync(data);
            return result.ToModel();
        }

        public  Task DeleteDataAsync(int id)
        {
            throw new NotImplementedException();
        }
        public async Task<DataModel> UpdateDataStatus(int dataId,int status)
        {
            var dataEntity = await _dataRepository.GetByIdAsync(dataId);
            dataEntity.Status = status;
            var result = await _dataRepository.UpdateAsync(dataEntity);
            return result.ToModel();
        }


        public Task<IEnumerable<DataModel>> GetAllDatasAsync()
        {
            throw new NotImplementedException();
        }
        public async Task<IEnumerable<int>> GetAllGoodTaskDatasIds(int taskId)
        {
            var datas = await _dataRepository.GetAllGoodTaskData(taskId);
            var list = new List<int>();
            foreach(var data in datas)
            {
                list.Add(data.Id);

            }
            return list;
        }
        public async Task<IEnumerable<DataModel>> GetAllPersonDatasAsync(string personId)
        {
            var data = await _dataRepository.GetPersonDatas(personId);
            return data.Select(d => d.ToModel());
        }

        public  Task<DataModel> GetDataBy(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<DataForMoreDetails> GetDataForMoreDetailsBy(int id)
        {
            var dataEntity = await _dataRepository.GetDataWithFilesAndPersonBy(id);          
            var person = await _personService.GetPersonById(dataEntity.Uploader.UserId);
            return dataEntity.ToForDetailsModel(person.Name, person.LastName);
        }
        public async Task<DataForMoreDetails> GetDataForMoreDetailsByTaskDataId(int TaskDataid)
        {
            var dataEntity = await _dataRepository.GetDataWithFilesAndPersonByTaskDataId(TaskDataid);
            var person = await _personService.GetPersonById(dataEntity.Uploader.UserId);
            return dataEntity.ToForDetailsModel(person.Name, person.LastName);
        }

        public async Task DetelePersonsData(string personId)
        {
            var userDatas = await _dataRepository.GetPersonDatas(personId);
            foreach (var data in userDatas)
            {
                await _fileService.DeleteFilesForServer(data.Id);
                await _dataRepository.DeleteAsync(data.Id);
            }
        }
    }

    
}
