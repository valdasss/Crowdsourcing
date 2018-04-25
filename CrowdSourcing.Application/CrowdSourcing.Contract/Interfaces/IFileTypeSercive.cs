using CrowdSourcing.Contract.Model.FileTypeModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CrowdSourcing.Contract.Interfaces
{
    public interface IFileTypeService
    {
        Task<IEnumerable<FileTypeFullModel>> GetAllFileTypesAsync();
        Task<FileTypeFullModel> AddFileTypeAsync(string name);
        Task<FileTypeFullModel> UpdateFileTypeAsync(FileTypeFullModel model);
        Task<FileTypeFullModel> GetFileTypeBy(int id);
        Task<FileTypeFullModel> GetFileTypeBy(string name);
        Task DeleteFileType(int id);
    }
}
