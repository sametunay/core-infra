using System.Data;
using Microsoft.EntityFrameworkCore.Storage;

namespace MyGallery.Core.Infrastructor.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        Task<IDbContextTransaction> CreateTransactionAsync(IsolationLevel isolationLevel = IsolationLevel.Serializable);
        Task CommitAsync(IDbContextTransaction transaction);
        Task RollBackAsync(IDbContextTransaction transaction);
    }
}