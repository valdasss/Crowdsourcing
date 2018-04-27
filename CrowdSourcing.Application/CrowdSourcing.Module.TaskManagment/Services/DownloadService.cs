using CrowdSourcing.Contract.Helpers;
using CrowdSourcing.Contract.Interfaces;
using Ionic.Zip;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrowdSourcing.Module.TaskManagment.Services
{
    public class DownloadService : IDownloadService
    {
        private IFileService _fileService;

        public DownloadService(IFileService fileService)
        {
            _fileService = fileService;
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
