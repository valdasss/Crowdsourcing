using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using CrowdSourcing.Contract.Interfaces;
using CrowdSourcing.Contract.Model.FileTypeModels;
using CrowdSourcing.EntityCore.Entity;
using CrowdSourcing.EntityCore.Extension;
using CrowdSourcing.Repository.Interface;

namespace CrowdSourcing.Module.TaskManagment.Services
{
    public class FileTypeService : IFileTypeService
    {
        private IFileTypeRepository _fileTypeRepository;

        public FileTypeService(IFileTypeRepository fileTypeRepository)
        {
            _fileTypeRepository = fileTypeRepository;
        }

        public async Task<FileTypeFullModel> AddFileTypeAsync(string name)
        {
            var fileType = new FileTypeEntity()
            {
                Name = name
            };
            var result = await _fileTypeRepository.AddAsync(fileType);
            return result.ToModel();
        }

        public async Task DeleteFileType(int id)
        {
            await _fileTypeRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<FileTypeFullModel>> GetAllFileTypesAsync()
        {
            var fileTasks = await _fileTypeRepository.GetAllAsync();
            return fileTasks.Select(f => f.ToModel());
        }

        public async Task<FileTypeFullModel> GetFileTypeBy(int id)
        {
            var fileType = await _fileTypeRepository.GetByIdAsync(id);
            return fileType.ToModel();
        }

        public async Task<FileTypeFullModel> GetFileTypeBy(string name)
        {
            var fileType = await _fileTypeRepository.GetFileTypeBy(name);
            if (fileType == null)
            {
                throw new ValidationException("Don't support file Format");
            }
            return fileType.ToModel();
        }

        public async Task<FileTypeFullModel> UpdateFileTypeAsync(FileTypeFullModel model)
        {
            var fileTypeEntity = await _fileTypeRepository.GetByIdAsync(model.Id);
            fileTypeEntity.Name = model.Name;
            var result = await _fileTypeRepository.UpdateAsync(fileTypeEntity);
            return result.ToModel();
        }
    }
}
