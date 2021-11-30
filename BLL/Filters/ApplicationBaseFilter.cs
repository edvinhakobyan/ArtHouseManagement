using System;
using System.Linq;
using Shared.IOModels;
using System.Linq.Expressions;
using System.Collections.Generic;
using GenericRepository.Abstarction;
using GenericRepository.Implementation;

namespace BLL.Filters
{
    public class ApplicationBaseFilter<TEntity> : FilterBase<TEntity>, IFilterBase<TEntity> where TEntity : class, IBaseEntity
    {
        public ApplicationBaseFilter(int? id,
                                     int? skip,
                                     int? take,
                                     IEnumerable<ISortProperty<TEntity>> sortProperties)
                                     : base(id, skip, take, sortProperties)
        {

        }
        public ApplicationBaseFilter() : base()
        {

        }

        protected static IEnumerable<ISortProperty<TEntity>> ConvertToSortProperties(IEnumerable<SortPropertyModel> sortPropertiesArray)
        {
            var result = new List<SortProperty<TEntity>>();

            if (sortPropertiesArray == null)
                return result;

            var properties = typeof(TEntity).GetProperties();

            foreach (var property in sortPropertiesArray)
            {
                var prop = properties.FirstOrDefault(p => p.Name.ToLower() == property.PropertyName.ToLower());

                if (prop == null) continue;

                var sortProperty = new SortProperty<TEntity>()
                {
                    SourtRule = (SortRuleEnum)property.SortRule
                };

                var parameter = Expression.Parameter(typeof(TEntity), "a");
                var memberExpression = Expression.Property(parameter, prop.Name);
                var unaryExpression = Expression.Convert(memberExpression, typeof(object));
                var lambdaExpression = Expression.Lambda<Func<TEntity, object>>(unaryExpression, parameter);
                sortProperty.Property = lambdaExpression;
                result.Add(sortProperty);
            }
            return result;
        }

    }
}
