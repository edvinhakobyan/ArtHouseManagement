using Shared.IOModels.BaseIOModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.IOModels.FilterDTOs
{
    public class PaymentFilterDTO : FilterBaseDTO
    {
        public int? StudentId { get; set; }
        public int? GroupId { get; set; }
        public string Name { get; set; }
        public Range<int> Value { get; set; } 
        public Range<DateTime> PaymentDate { get; set; }
    }
}
