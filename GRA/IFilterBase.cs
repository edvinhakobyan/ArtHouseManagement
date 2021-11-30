using System.Linq;
using System.Collections.Generic;

namespace GenericRepository.Abstarction
{
    public interface IFilterBase<TEntity> where TEntity : class
    {
        public int? Id { get; set; }
        public int? Skip { get; set; }
        public int? Take { get; set; }
        public IEnumerable<ISortProperty<TEntity>> SortProperties { get; set; }
        public IQueryable<TEntity> Execute(IQueryable<TEntity> query);
    }
}
