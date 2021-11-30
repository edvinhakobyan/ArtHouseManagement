using System;
using System.Linq;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Collections.Generic;
using GenericRepository.Abstarction;
using Microsoft.EntityFrameworkCore;

namespace GenericRepository.Implementation
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext _dbContext;
        protected readonly DbSet<TEntity> _dbSet;

        public BaseRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<TEntity>();
        }

        public virtual void Add(TEntity entity)
        {
            if (entity == null)
                throw new NullReferenceException("entity is null");

            _dbSet.Add(entity);
        }

        public virtual void AddRange(IEnumerable<TEntity> entities)
        {
            if (entities == null)
                throw new NullReferenceException("entities is null");

            _dbSet.AddRange(entities);
        }


        public virtual void Remove(TEntity entity)
        {
            if (entity == null)
                throw new NullReferenceException("entity is null");

            _dbSet.Remove(entity);
        }


        public virtual void RemoveRange(IEnumerable<TEntity> entities)
        {
            if (entities == null)
                throw new NullReferenceException("entities is null");

            _dbSet.RemoveRange(entities);
        }


        public virtual void Update(TEntity entity)
        {
            if (entity == null)
                throw new NullReferenceException("entity is null");

            _dbSet.Update(entity);
        }

        public virtual void UpdateMany(IEnumerable<TEntity> entities)
        {
            if (entities == null)
                throw new NullReferenceException("entities is null");

            _dbSet.UpdateRange(entities);
        }

        private IQueryable<TEntity> ApplyFilters(Expression<Func<TEntity, bool>> predicate,
                                                 IFilterBase<TEntity> filter,
                                                 IInclude<TEntity> includes)
        {
            var query = _dbSet.AsQueryable();

            if (predicate != null)
                query = query.Where(predicate);

            if (includes != null)
                query = includes.Execute(query);

            if (filter != null)
                query = filter.Execute(query);

            return query;
        }

        public virtual Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate = null,
                                           IInclude<TEntity> includes = null)
        {
            var query = ApplyFilters(predicate, null, includes);

            return query.AnyAsync();
        }

        public virtual Task<bool> AnyAsync(IFilterBase<TEntity> filter = null,
                                           IInclude<TEntity> includes = null)
        {
            var query = ApplyFilters(null, filter, includes);

            return query.AnyAsync();
        }


        public virtual Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate = null,
                                            IInclude<TEntity> includes = null)
        {
            var query = ApplyFilters(predicate,  null, includes);

            return query.CountAsync();
        }

        public virtual Task<int> CountAsync(IFilterBase<TEntity> filter = null,
                                            IInclude<TEntity> includes = null)
        {
            var query = ApplyFilters(null,  filter, includes);

            return query.CountAsync();
        }

        public virtual Task<List<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate = null,
                                                     IInclude<TEntity> includes = null)
        {
            var query = ApplyFilters(predicate,  null, includes);

            return query.AsNoTracking().ToListAsync();
        }

        public virtual Task<List<TEntity>> FindAsync(IFilterBase<TEntity> filter = null,
                                                     IInclude<TEntity> includes = null)
        {
            var query = ApplyFilters(null, filter, includes);

            return query.AsNoTracking().ToListAsync();
        }
    }
}
