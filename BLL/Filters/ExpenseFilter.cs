using Core.Models;
using GenericRepository.Abstarction;
using Shared.IOModels;
using Shared.IOModels.FilterDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.Filters
{
    public class ExpenseFilter : ApplicationBaseFilter<Expense>, IFilterBase<Expense>
    {
        public int? StudentId { get; set; }
        public int? GroupId { get; set; }
        public string Name { get; set; }
        public Range<int> ValueRange { get; set; }

        public ExpenseFilter() { }
        public ExpenseFilter(int? id,
                             int? skip,
                             int? take,
                             IEnumerable<ISortProperty<Expense>> sortProperties) : base(id, skip, take, sortProperties)
        {
        }

        public override IQueryable<Expense> Execute(IQueryable<Expense> query)
        {
            if (StudentId != null)
                query = query.Where(e => e.StudentGroup.StudentId == StudentId);

            if (GroupId != null)
                query = query.Where(e => e.StudentGroup.GroupId == GroupId);

            if (Name != null)
                query = query.Where(e => e.Name.ToLower().Contains(Name.ToLower()));

            if (ValueRange != null)
                query = query.Where(e => ValueRange.Minimum <= e.Value && e.Value <= ValueRange.Maximum);



            return base.Execute(query);
        }

        public static implicit operator ExpenseFilter(ExpenseFilterDTO filter)
        {
            return new ExpenseFilter()
            {
                Id = filter?.Id,
                Skip = filter?.Skip,
                Take = filter?.Take,
                Name = filter?.Name,
                StudentId = filter?.StudentId,
                GroupId = filter?.GroupId,
                ValueRange = filter?.ValueRange,
                SortProperties = ConvertToSortProperties(filter?.SortProperties)
            };
        }


    }
}
