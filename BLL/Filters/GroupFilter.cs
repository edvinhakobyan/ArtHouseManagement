using Core.Models;
using System.Linq;
using Shared.Enums;
using Shared.IOModels.FilterDTOs;
using System.Collections.Generic;
using GenericRepository.Abstarction;

namespace BLL.Filters
{
    public class GroupFilter : ApplicationBaseFilter<Group>, IFilterBase<Group>
    {
        public string Name { get; set; }
        public GroupTypeEnum? GroupType { get; set; }
        public int? DayTime { get; set; }
        public int? TeacherId { get; set; }

        public GroupFilter(int? id, 
                           int? skip, 
                           int? take,
                           string name,
                           int? dayTime,
                           int? teacherId,
                           GroupTypeEnum? groupType,
                           IEnumerable<ISortProperty<Group>> sortProperties) : base(id, skip, take, sortProperties)
        {
            Name = name;
            DayTime = dayTime;
            TeacherId = teacherId;
            GroupType = groupType;
        }

        public GroupFilter() { }

        public override IQueryable<Group> Execute(IQueryable<Group> query)
        {
            if (Name != null)
                query = query.Where(a => a.Name.ToLower().Contains(Name.ToLower()));

            if (GroupType != null)
                query = query.Where(a => a.GroupType == GroupType);

            if (DayTime != null)
                query = query.Where(a => a.DayTime == DayTime);

            if (TeacherId != null)
                query = query.Where(a => a.TeacherId == TeacherId);

            query = base.Execute(query);

            return query;
        }

        public static implicit operator GroupFilter(GroupFilterDTO filter)
        {
            return new GroupFilter()
            {
                Id = filter?.Id,
                Skip = filter?.Skip,
                Take = filter?.Take,
                Name = filter?.Name,
                DayTime = filter?.DayTime,
                TeacherId = filter?.TeacherId,
                GroupType = filter?.GroupType,
                SortProperties = ConvertToSortProperties(filter?.SortProperties)
            };
        }

    }
}
