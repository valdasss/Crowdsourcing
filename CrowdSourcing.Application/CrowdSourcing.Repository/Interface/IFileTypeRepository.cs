using CrowdSourcing.EntityCore.Common;
using CrowdSourcing.EntityCore.Entity;
using System.Threading.Tasks;

namespace CrowdSourcing.Repository.Interface
{
    public interface IFileTypeRepository : IGenericRepository<FileTypeEntity>
    {
        Task<FileTypeEntity> GetFileTypeBy(string name);
    }
}
