using Core.Models;
using GenericRepository.Abstarction;
using Shared.IOModels.FilterDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.Filters
{
    public class TeacherFilter : ApplicationBaseFilter<Teacher>
    {
        public string Name      { get; set; }
        public string Surname { get; set; }
        public string Phone     { get; set; }

        public TeacherFilter(int? id, 
            int? skip, 
            int? take,
            string name,
            string surname,
            string phone,
            IEnumerable<ISortProperty<Teacher>> sortProperties) 
            : base(id, skip, take, sortProperties)
        {
            Name = name;
            Surname = surname;
            Phone = phone;
        }

        public TeacherFilter() { }


        public override IQueryable<Teacher> Execute(IQueryable<Teacher> query)
        {

            if (Name != null)
                query = query.Where(t => t.Name.ToLower().Contains(Name.ToLower()));

            if (Surname != null)
                query = query.Where(t => t.Surname.ToLower().Contains(Surname.ToLower()));

            if (Phone != null)
                query = query.Where(t => t.Phone.Contains(Phone));

            return base.Execute(query);
        }


        public static explicit operator TeacherFilter(TeacherFilterDTO filter)
        {
            return new TeacherFilter()
            {
                Id = filter?.Id,
                Skip = filter?.Skip,
                Take = filter?.Take,
                Name = filter?.Name,
                Surname = filter?.Surname,
                Phone = filter?.Phone,
                SortProperties = ConvertToSortProperties(filter?.SortProperties)
            };
        }




    }
}
