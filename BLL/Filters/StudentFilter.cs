using Core.Models;
using System.Linq;
using System.Collections.Generic;
using Shared.IOModels.FilterDTOs;
using GenericRepository.Abstarction;

namespace BLL.Filters
{
    public class StudentFilter : ApplicationBaseFilter<Student>, IFilterBase<Student>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PhoneNumber { get; set; }
        public int? GroupId { get; set; }

        public StudentFilter(int? id,
                             int? skip, 
                             int? take, 
                             string name,
                             string surname,
                             string phoneNumber,
                             int? groupId,
                             IEnumerable<ISortProperty<Student>> sortProperties) 
                             : base(id, skip, take, sortProperties)
        {
            Name = name;
            Surname = surname;
            PhoneNumber = phoneNumber;
            GroupId = groupId;
        }

        public StudentFilter() { }

        public override IQueryable<Student> Execute(IQueryable<Student> query)
        {
            if(Name != null)
                query = query.Where(s => s.Name.ToLower().Contains(Name.ToLower()));

            if(Surname != null)
                query = query.Where(s => s.Surname.ToLower().Contains(Surname.ToLower()));

            if(PhoneNumber != null)
                query = query.Where(s => s.PhoneNumber.Contains(PhoneNumber));

            if (GroupId != null)
                query = query.Where(s => s.StudentGroups.Any(sg => sg.GroupId == GroupId));

            query = base.Execute(query);

            return query;
        }

        public static implicit operator StudentFilter(StudentFilterDTO filter)
        {
            return new StudentFilter()
            {
                Id = filter?.Id,
                Skip = filter?.Skip,
                Take = filter?.Take,
                Name = filter?.Name,
                Surname = filter?.Surname,
                PhoneNumber = filter?.PhoneNumber,
                GroupId = filter?.GroupId,
                SortProperties = ConvertToSortProperties(filter?.SortProperties)
            };
        }
    }
}
