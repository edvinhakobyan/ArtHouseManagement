using System.Linq;
using System.Collections.Generic;
using GenericRepository.Abstarction;

namespace GenericRepository.Implementation
{
    public class FilterBase<TEntity> : IFilterBase<TEntity> where TEntity : class
    {
        public int? Id { get; set; }
        public int? Skip { get; set; }
        public int? Take { get; set; }
        public IEnumerable<ISortProperty<TEntity>> SortProperties { get; set; }

        public FilterBase() { }

        public FilterBase(int? id,int? skip, int? take, IEnumerable<ISortProperty<TEntity>> sortProperties)
        {
            Id = id;
            Skip = skip;
            Take = take;
            SortProperties = sortProperties;
        }

        public virtual IQueryable<TEntity> Execute(IQueryable<TEntity> query)
        {
            if (query == null)
            {
                return query;
            }

            if (SortProperties != null && SortProperties.Any())
            {
                var sortElements = SortProperties.ToList();
                var sortElement = sortElements[0];
                if (sortElement.SourtRule == SortRuleEnum.Asc)
                    query = query.OrderBy(sortElement.Property);
                if (sortElement.SourtRule == SortRuleEnum.Desc)
                    query = query.OrderByDescending(sortElement.Property);

                for (int i = 1; i < sortElements.Count; i++)
                {
                    sortElement = sortElements[i];
                    if (sortElement.SourtRule == SortRuleEnum.Asc)
                        query = (query as IOrderedQueryable<TEntity>).ThenBy(sortElement.Property);
                    if (sortElement.SourtRule == SortRuleEnum.Desc)
                        query = (query as IOrderedQueryable<TEntity>).ThenByDescending(sortElement.Property);
                }
            }

            if (Skip.HasValue)
                query = query.Skip(Skip.Value);
            if (Take.HasValue)
                query = query.Take(Take.Value);

            return query;
        }
    }
}
