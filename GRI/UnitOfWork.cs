using System;
using System.Threading;
using System.Threading.Tasks;
using GenericRepository.Abstarction;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace GenericRepository.Implementation
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext _dbContext;
        private IDbContextTransaction _transaction;

        public UnitOfWork(DbContext context)
        {
            _dbContext = context;
        }

        public async Task BeginTransactionAsync(CancellationToken cancellationToken = default)
        {
            _transaction = await _dbContext.Database.BeginTransactionAsync(cancellationToken);
        }

        public async Task CommitTransactionAsync()
        {
            await _transaction.CommitAsync();
            _transaction.Dispose();
        }

        public void DisposeTransaction()
        {
            if (_transaction != null)
                _transaction.Dispose();

            _transaction = null;
        }

        public async Task RollbackTransactionAsync()
        {
            if (_transaction != null)
                await _transaction.RollbackAsync();

            DisposeTransaction();
        }

        public async Task SaveAsync()
        {
            await _dbContext.SaveChangesAsync();
        }


        #region Disposing
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool isDisposing)
        {
            if (isDisposing)
            {
                DisposeTransaction();
            }
        }
        #endregion

    }
}
