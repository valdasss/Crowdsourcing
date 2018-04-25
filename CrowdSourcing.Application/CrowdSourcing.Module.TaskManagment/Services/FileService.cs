using CrowdSourcing.Contract.Helpers;
using CrowdSourcing.Contract.Interfaces;
using CrowdSourcing.Contract.Model.FileModels;
using CrowdSourcing.EntityCore.Entity;
using CrowdSourcing.EntityCore.Extension;
using CrowdSourcing.Repository.Interface;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrowdSourcing.Module.TaskManagment.Services
{
    public class FileService : IFileService
    {
        private IFileRepository _fileRepository;
        private IFileTypeService _fileTypeService;

        public FileService(IFileRepository fileRepository, IFileTypeService fileTypeService)
        {
            _fileRepository = fileRepository;
            _fileTypeService = fileTypeService;
        }

        public async Task<FileModel> AddFileAsync(string url, int dataId)
        {
            var format = UrlParser.GetFileFormatFromPathUrl(url);
            var fileType = await _fileTypeService.GetFileTypeBy(format);
            
            var fileEntity = new FileEntity()
            {
                DataId = dataId,
                FileTypeId = fileType.Id,
                Url = url
            };
            var result = await _fileRepository.AddAsync(fileEntity);
            return result.ToModel();
        }

        public async Task DeleteFile(int id)
        {
            await _fileRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<FileModel>> GetAllFilesAsync()
        {
            var files = await _fileRepository.GetAllAsync();
            return files.Select(f => f.ToModel());
        }

        public async Task<IEnumerable<FileModel>> GetAllFilesAsyncBy(int dataId)
        {
            var filesByDataId = await _fileRepository.GetAllFilesBy(dataId);
            return filesByDataId.Select(f => f.ToModel());
        }

        public async Task<FileModel> GetFileBy(int id)
        {
            var file = await _fileRepository.GetByIdAsync(id);
            return file.ToModel();
        }

        public async Task<FileModel> UpdateFileAsync(int id, string url, int dataId)
        {
            string format = UrlParser.GetFileFormatFromPathUrl(url);
            var fileEntity = await _fileRepository.GetByIdAsync(id);
            var fileType = await _fileTypeService.GetFileTypeBy(format);
            if (fileType == null)
            {
                var newFileType = await _fileTypeService.AddFileTypeAsync(format);
                fileEntity.FileTypeId = newFileType.Id;
            }
            else
            {
                fileEntity.FileTypeId = fileType.Id;
            }
            fileEntity.Url = url;
            fileEntity.DataId = dataId;
            var result = await _fileRepository.UpdateAsync(fileEntity);
            return result.ToModel();
        }
        
    }
}
