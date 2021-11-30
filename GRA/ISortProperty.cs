using System;
using System.Linq.Expressions;

namespace GenericRepository.Abstarction
{
    public interface ISortProperty<TEntity> where TEntity : class
    {
        public SortRuleEnum SourtRule { get; set; }
        public Expression<Func<TEntity, object>> Property { get; set; }
    }
}
