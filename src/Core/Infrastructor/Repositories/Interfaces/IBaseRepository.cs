using System.Linq.Expressions;
using CI.Core.Domain.Entities;

namespace CI.Core.Infrastructor.Repositories.Interfaces
{
    public interface IBaseRepository<TEntity, TKey> where TEntity : BaseEntity<TKey>, new() where TKey : unmanaged
    {
        Task CreateAsync(TEntity entity);
        Task CreateBulkAsync(List<TEntity> entities);
        Task UpdateAsync(TEntity entity);
        Task UpdateBulkAsync(List<TEntity> entities);
        Task HardDeleteAsync(TEntity entity);
        Task HardDeleteBulkAsync(List<TEntity> entities);
        Task<long> FindAndHardDeleteAsync(Expression<Func<TEntity, bool>> condition);
        Task<TEntity> GetByIdAsync(TKey key);
        Task<TEntity> GetOneAsync(Expression<Func<TEntity, bool>> condition);
        List<TEntity> Filter(int pageIndex, int pageSize, Expression<Func<TEntity, bool>> condition = null, Func<TEntity, object> orderBy = null, bool descending = false);
        Task<long> CountAsync();
        Task<long> CountAsync(Expression<Func<TEntity, bool>> condition);
        Task SoftDeleteAsync(TEntity entity);
        Task SoftDeleteBulkAsync(List<TEntity> entities);
        Task<long> FindAndSoftDeleteAsync(Expression<Func<TEntity, bool>> condition);
        Task<bool> AnyAsync(Expression<Func<TEntity, bool>> condition);
        Task<bool> AnyAsync(TKey key);
    }
}