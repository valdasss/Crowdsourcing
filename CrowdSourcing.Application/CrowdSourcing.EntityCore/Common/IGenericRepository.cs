using System.Collections.Generic;
using System.Threading.Tasks;

namespace CrowdSourcing.EntityCore.Common
{
    public interface IGenericRepository<TEntity>
    {
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity> GetByIdAsync(int id);
        Task<TEntity> AddAsync(TEntity model);
        Task DeleteAsync(int id);
        Task<TEntity> UpdateAsync(TEntity entity);
    }
}
