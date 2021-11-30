using System.Collections.Generic;

namespace Shared.IOModels.BaseIOModels
{
    public class FilterBaseDTO
    {
        public int? Id { get; set; }
        public int? Skip { get; set; }
        public int? Take { get; set; }
        public IEnumerable<SortPropertyModel> SortProperties { get; set; }
    }
}
