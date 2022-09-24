using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using CI.Core.Data.Contexts.EF;
using CI.Core.Domain.Entities;
using CI.Core.Infrastructure.Repositories.Interfaces;

namespace CI.Core.Infrastructure.Repositories.Implementation
{
    public abstract class BaseRepository<TEntity, TKey> : IBaseRepository<TEntity, TKey> where TEntity : BaseEntity<TKey>, new() where TKey : unmanaged
    {
        private readonly EFContext _dbContext;
        private readonly DbSet<TEntity> _dbSet;

        public BaseRepository(EFContext context)
        {
            _dbContext = context;
            _dbSet = _dbContext.Set<TEntity>();
        }

        public virtual async Task CreateAsync(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
            await SaveChangesAsync();
        }

        public virtual async Task HardDeleteAsync(TEntity entity)
        {
            _dbSet.Remove(entity);
            await SaveChangesAsync();
        }

        public virtual List<TEntity> Filter(int pageIndex, int pageSize, Expression<Func<TEntity, bool>> condition = null, Func<TEntity, object> orderBy = null, bool descending = false)
        {
            var query = _dbSet.AsNoTracking();

            if (orderBy is null) orderBy = entity => entity.Audit.CreatedAt;

            if(condition is not null) query.Where(condition);

            query.Skip(pageIndex * pageSize);
            query.Take(pageSize);

            query = descending == true ? query.OrderByDescending(orderBy).AsQueryable() : query.OrderBy(orderBy).AsQueryable();

            return query.ToList();
        }

        public virtual async Task<TEntity> GetByIdAsync(TKey key)
        {
            return await _dbSet.FirstOrDefaultAsync(entity => entity.Id.Equals(key));
        }

        public virtual async Task<TEntity> GetOneAsync(Expression<Func<TEntity, bool>> condition)
        {
            return await _dbSet.FirstOrDefaultAsync(condition);
        }

        public virtual async Task UpdateAsync(TEntity entity)
        {
            _dbSet.Update(entity);
            await SaveChangesAsync();
        }
        
        public virtual async Task SoftDeleteAsync(TEntity entity)
        {
            entity.Audit.SoftDelete();

            _dbSet.Update(entity);
            await SaveChangesAsync();
        }

        public virtual async Task<long> CountAsync()
        {
            return await _dbSet.LongCountAsync();
        }

        public virtual async Task<long> CountAsync(Expression<Func<TEntity, bool>> condition)
        {
            return await _dbSet.LongCountAsync(condition);
        }

        public virtual async Task CreateBulkAsync(List<TEntity> entities)
        {
            await _dbSet.AddRangeAsync(entities);
            await SaveChangesAsync();
        }

        public virtual async Task UpdateBulkAsync(List<TEntity> entities)
        {
            _dbSet.UpdateRange(entities);
            await SaveChangesAsync();
        }

        public virtual async Task SoftDeleteBulkAsync(List<TEntity> entities)
        {
            foreach (var entity in entities)
            {
                entity.Audit.SoftDelete();
            }

            _dbSet.UpdateRange(entities);
            await SaveChangesAsync();
        }

        public virtual async Task HardDeleteBulkAsync(List<TEntity> entities)
        {
            _dbSet.RemoveRange(entities);
            await SaveChangesAsync();
        }

        public virtual async Task<long> FindAndHardDeleteAsync(Expression<Func<TEntity, bool>> condition)
        {
            var entities = await _dbSet.Where(condition).ToListAsync();

            await HardDeleteBulkAsync(entities);
            await SaveChangesAsync();

            return entities.Count;
        }

        public virtual async Task<long> FindAndSoftDeleteAsync(Expression<Func<TEntity, bool>> condition)
        {
            var entities = await _dbSet.Where(condition).ToListAsync();

            await SoftDeleteBulkAsync(entities);
            await SaveChangesAsync();

            return entities.Count;
        }

        public virtual async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> condition)
        {
            return await _dbSet.AnyAsync(condition);
        }

        public virtual async Task<bool> AnyAsync(TKey key)
        {
            return await _dbSet.AnyAsync(x => x.Id.Equals(key));
        }

        private async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
            
            _dbContext.ChangeTracker.Clear();
        }
    }
}