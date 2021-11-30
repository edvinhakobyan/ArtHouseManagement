using System;
using System.Linq.Expressions;

namespace GenericRepository.Abstarction
{
    public interface IIncludeProperty<TEntity>  where TEntity : class
    {
        Expression<Func<TEntity, object>> IncludeProperty { get; set; }
    }
}
