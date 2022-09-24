using System.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using CI.Core.Data.Contexts.EF;

namespace CI.Core.Infrastructor.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly EFContext _dbContext;

        public UnitOfWork(EFContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IDbContextTransaction> CreateTransactionAsync(IsolationLevel isolationLevel = IsolationLevel.Serializable)
        {
            return await RelationalDatabaseFacadeExtensions.BeginTransactionAsync(_dbContext.Database, isolationLevel);
        }

        public async Task CommitAsync(IDbContextTransaction transaction)
        {
            await transaction.CommitAsync();
            Dispose();
        }

        public async Task RollBackAsync(IDbContextTransaction transaction)
        {
            await transaction.RollbackAsync();
            Dispose();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
                _dbContext.Dispose();
        }
    }
}