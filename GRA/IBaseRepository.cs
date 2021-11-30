using System;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Collections.Generic;

namespace GenericRepository.Abstarction
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        void Add(TEntity entity);
        void AddRange(IEnumerable<TEntity> entities);
        void Remove(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entities);
        void Update(TEntity entity);
        void UpdateMany(IEnumerable<TEntity> entities);


        Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate = null, IInclude<TEntity> includes = null);
        Task<bool> AnyAsync(IFilterBase<TEntity> filter = null, IInclude<TEntity> includes = null);
        Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate = null, IInclude<TEntity> includes = null);
        Task<int> CountAsync(IFilterBase<TEntity> filter = null, IInclude<TEntity> includes = null);
        Task<List<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate = null, IInclude<TEntity> includes = null);
        Task<List<TEntity>> FindAsync(IFilterBase<TEntity> filter = null, IInclude<TEntity> includes = null);

    }
}
