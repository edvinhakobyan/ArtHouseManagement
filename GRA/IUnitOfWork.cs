using System;
using System.Data;
using System.Threading;
using System.Threading.Tasks;

namespace GenericRepository.Abstarction
{
    public interface IUnitOfWork : IDisposable
    {
        Task BeginTransactionAsync(CancellationToken cancellationToken = default);
        Task CommitTransactionAsync();
        Task RollbackTransactionAsync();
        Task SaveAsync();
        void DisposeTransaction();
    }
}
