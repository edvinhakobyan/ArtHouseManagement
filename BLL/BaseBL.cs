using System;
using Core.Interfaces.IBLL;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Collections.Generic;
using GenericRepository.Abstarction;

namespace BLL
{
    public class BaseBL<TEntity> : IBaseBL<TEntity> where TEntity : class
    {

        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IBaseRepository<TEntity> _baseRepository;

        public BaseBL(IUnitOfWork unitOfWork, 
                      IBaseRepository<TEntity> baseRepository)
        {
            _unitOfWork = unitOfWork;
            _baseRepository = baseRepository;
        }
       
        public virtual void Add(TEntity entity)
        {
            _baseRepository.Add(entity);
        }
        public virtual void AddRange(IEnumerable<TEntity> entities)
        {
            _baseRepository.AddRange(entities);
        }
        public virtual void Remove(TEntity entity)
        {
            _baseRepository.Remove(entity);
        }
        public virtual void RemoveRange(IEnumerable<TEntity> entities)
        {
            _baseRepository.RemoveRange(entities);
        }
        public virtual void Update(TEntity entity)
        {
            _baseRepository.Update(entity);
        }
        public virtual void UpdateMany(IEnumerable<TEntity> entities)
        {
            _baseRepository.UpdateMany(entities);
        }

        public Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate = null, IInclude<TEntity> includes = null)
        {
            return _baseRepository.AnyAsync(predicate, includes);
        }
        public Task<bool> AnyAsync(IFilterBase<TEntity> filter = null, IInclude<TEntity> includes = null)
        {
            return _baseRepository.AnyAsync(filter, includes);
        }
        public Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate = null, IInclude<TEntity> includes = null)
        {
            return _baseRepository.CountAsync(predicate, includes);
        }
        public Task<int> CountAsync(IFilterBase<TEntity> filter = null, IInclude<TEntity> includes = null)
        {
            return _baseRepository.CountAsync(filter, includes);
        }
        public Task<List<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate = null, IInclude<TEntity> includes = null)
        {
            return _baseRepository.FindAsync(predicate, includes);
        }
        public Task<List<TEntity>> FindAsync(IFilterBase<TEntity> filter = null, IInclude<TEntity> includes = null)
        {
            return _baseRepository.FindAsync(filter, includes);
        }

    }
}
