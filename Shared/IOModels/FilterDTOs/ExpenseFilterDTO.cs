using Shared.IOModels.BaseIOModels;

namespace Shared.IOModels.FilterDTOs
{
    public class ExpenseFilterDTO : FilterBaseDTO
    {
        public int? StudentId { get; set; }
        public int? GroupId { get; set; }
        public string Name { get; set; }
        public Range<int> ValueRange { get; set; }
    }
}