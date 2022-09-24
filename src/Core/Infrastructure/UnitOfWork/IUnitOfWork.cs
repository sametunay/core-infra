using System.Data;
using Microsoft.EntityFrameworkCore.Storage;

namespace CI.Core.Infrastructure.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        Task<IDbContextTransaction> CreateTransactionAsync(IsolationLevel isolationLevel = IsolationLevel.Serializable);
        Task CommitAsync(IDbContextTransaction transaction);
        Task RollBackAsync(IDbContextTransaction transaction);
    }
}