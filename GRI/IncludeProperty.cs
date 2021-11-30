using System.Linq;
using System.Collections.Generic;
using GenericRepository.Abstarction;
using Microsoft.EntityFrameworkCore;

namespace GenericRepository.Implementation
{
    public class Include<TEntity> : IInclude<TEntity> where TEntity : class
    {
        public IEnumerable<IIncludeProperty<TEntity>> IncludeProperties { get ; set; }

        public Include(IEnumerable<IIncludeProperty<TEntity>> includePropertis)
        {
            IncludeProperties = includePropertis;
        }

        public IQueryable<TEntity> Execute(IQueryable<TEntity> query)
        {
            if (query == null) return query;

            IncludeProperties?.Aggregate(query, (query, expresion) => query.Include(expresion.IncludeProperty));

            return query;
        }
    }
}
