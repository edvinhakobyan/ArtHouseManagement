using System.Linq;
using System.Collections.Generic;

namespace GenericRepository.Abstarction
{
    public interface IInclude<TEntity> where TEntity : class
    {
        public IEnumerable<IIncludeProperty<TEntity>> IncludeProperties { get; set; }
        public IQueryable<TEntity> Execute(IQueryable<TEntity> query);
    }
}
