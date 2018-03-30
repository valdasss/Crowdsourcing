using CrowdSourcing.Contract.Interfaces;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace CrowdSourcing.EntityCore.Common
{
    public abstract class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private readonly IDbContext _dbContext;
        private readonly DbSet<TEntity> _dbSet;
        private DbContext Context => (DbContext)_dbContext;

        protected GenericRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = Context.Set<TEntity>();
        }
        public virtual async Task<TEntity> AddAsync(TEntity model)
        {
            var insertedEntity = _dbSet.Add(model);
            await Context.SaveChangesAsync();
            return insertedEntity;
        }

        public virtual async Task DeleteAsync(int id)
        {
            var entity = await Context.Set<TEntity>().FindAsync(id);
            _dbSet.Remove(entity);
            await Context.SaveChangesAsync();
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public virtual async Task<TEntity> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public virtual async Task<TEntity> UpdateAsync(TEntity entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
            await Context.SaveChangesAsync();
            return entity;
        }
    }
}
