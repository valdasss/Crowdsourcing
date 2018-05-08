using CrowdSourcing.EntityCore.Common;
using CrowdSourcing.EntityCore.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CrowdSourcing.Repository.Interface
{
    public interface IFileRepository : IGenericRepository<FileEntity>
    {
        Task<IEnumerable<FileEntity>> GetAllFilesBy(int dataId);
        Task<IEnumerable<FileEntity>> GetAllUsersFiles(string userId);
    }
}
