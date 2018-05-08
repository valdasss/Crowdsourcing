using CrowdSourcing.Contract.Helpers;
using CrowdSourcing.Contract.Interfaces;
using CrowdSourcing.Contract.Model.Download;
using Ionic.Zip;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CrowdSourcing.Module.TaskManagment.Services
{
    public class DownloadService : IDownloadService
    {
        private IFileService _fileService;
        private IDataService _dataService;

        public DownloadService(IFileService fileService, IDataService dataService)
        {
            _fileService = fileService;
            _dataService = dataService;
        }
        public async Task<ZipFile> DownloadArchiveAsyncByDataId(int dataId)
        {          
            var datasFiles = await _fileService.GetAllFilesAsyncBy(dataId);
            var filesNames = new List<string>();
            foreach (var file in datasFiles)
            {
                filesNames.Add(file.Url);
            }
            return FormatZipFile(filesNames);
        }
        public async Task<ZipFile> DownloadGoodTaskFiles(int taskId)
        {
            var datasIds = await _dataService.GetAllGoodTaskDatasIds(taskId);
            if (datasIds.Count() == 0)
            {
                throw new ValidationException("Duomenų nėra");
            }
            var list = new List<TaskDataDownloadModel>();
            foreach (var dataId in datasIds)
            {
                var files = await _fileService.GetAllFilesAsyncBy(dataId);
                var directory = UrlParser.GetDirectoryFullName(files.FirstOrDefault().Url);
                var dataModel = new TaskDataDownloadModel()
                {
                    DirectoryUrl = directory,
                    FolderName = UrlParser.GetDirectoryName(directory)
                };
                list.Add(dataModel);
            }         
            return FormatZipFileByDirectory(list);
        }
        private ZipFile FormatZipFileByDirectory(List<TaskDataDownloadModel> list)
        {
            using (var zipFile = new ZipFile())
            {
                foreach(var listItem in list)
                {
                    zipFile.AddDirectory(listItem.DirectoryUrl, listItem.FolderName);
                }            
                return zipFile;
            }
        }

        private ZipFile FormatZipFile(List<string> filesNames)
        {         
            using (var zipFile = new ZipFile())
            {
                zipFile.AddFiles(filesNames, false, "");
                return zipFile;
            }
        }

    }
}
