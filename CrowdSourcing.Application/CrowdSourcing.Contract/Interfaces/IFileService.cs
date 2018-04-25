using CrowdSourcing.Contract.Model.FileModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CrowdSourcing.Contract.Interfaces
{
    public interface IFileService
    {
        Task<IEnumerable<FileModel>> GetAllFilesAsync();
        Task<IEnumerable<FileModel>> GetAllFilesAsyncBy(int dataId);
        Task<FileModel> AddFileAsync(string url,int dataId);
        Task<FileModel> UpdateFileAsync(string url, int dataId);
        Task<FileModel> GetFileBy(int id);
        Task DeleteFile(int id);
    }
}
