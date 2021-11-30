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
    public class PaymentFilter : ApplicationBaseFilter<Payment>, IFilterBase<Payment>
    {
        public int? StudentId { get; set; }
        public int? GroupId { get; set; }
        public string Name { get; set; }
        public Range<int> Value { get; set; }
        public Range<DateTime> PaymentDate { get; set; }

        public PaymentFilter(int? id, 
                             int? skip, 
                             int? take,
                             int? studentId,
                             int? groupId,
                             string name,
                             Range<int> value,
                             Range<DateTime> paymentDate,
                             IEnumerable<ISortProperty<Payment>> sortProperties)
                             : base(id, skip, take, sortProperties)
        {
            StudentId = studentId;
            GroupId = groupId;
            Name = name;
            Value = value;
            PaymentDate = paymentDate;
        }

        public PaymentFilter() { }

        public override IQueryable<Payment> Execute(IQueryable<Payment> query)
        {
            if (StudentId != null)
                query =  query.Where(p => p.StudentGroup.StudentId == StudentId);

            if (GroupId != null)
                query = query.Where(p => p.StudentGroup.GroupId == GroupId);

            if (Name != null)
                query = query.Where(p => p.Name.ToLower().Contains(Name.ToLower()));

            if (Value != null && Value.IsValid())
                query = query.Where(p => Value.Minimum <= p.Value && p.Value <= Value.Maximum);

            if (PaymentDate != null && PaymentDate.IsValid())
                query = query.Where(p => PaymentDate.Minimum <= p.PaymentDate && p.PaymentDate <= PaymentDate.Maximum);

            return base.Execute(query);
        }

        public static explicit operator PaymentFilter(PaymentFilterDTO filter)
        {
            return new PaymentFilter()
            {
                Id = filter?.Id,
                Skip = filter?.Skip,
                Take = filter?.Take,
                Name = filter?.Name,
                GroupId = filter?.GroupId,
                StudentId = filter?.StudentId,
                Value = filter?.Value,
                PaymentDate = filter?.PaymentDate,
                SortProperties = ConvertToSortProperties(filter?.SortProperties)
            };
        }

    }
}
