using CrowdSourcing.Contract.Helpers;
using CrowdSourcing.Contract.Interfaces;
using CrowdSourcing.Contract.Model.DataModels;
using CrowdSourcing.Contract.Model.TaskDataModel;
using CrowdSourcing.EntityCore.Entity;
using CrowdSourcing.EntityCore.Extension;
using CrowdSourcing.Repository.Interface;
using System;
using System.Collections.Generic;
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
        public DataService(IDataRepository dataRepository, IFileService fileService,ITaskService taskService, IPersonService personService,IRoleService roleService)
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

        public async Task DeleteDataAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<DataModel>> GetAllDatasAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<DataModel> GetDataBy(int id)
        {
            throw new NotImplementedException();
        }
   

        public async Task<DataModel> UpdateRoleAsync(UpdateDataModel roleModel)
        {
            throw new NotImplementedException();
        }
    }
}
