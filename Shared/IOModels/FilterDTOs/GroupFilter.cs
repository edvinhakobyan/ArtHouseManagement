using Shared.Enums;
using Shared.IOModels.BaseIOModels;

namespace Shared.IOModels.FilterDTOs
{
    public class GroupFilterDTO : FilterBaseDTO
    {
        public string Name { get; set; }
        public GroupTypeEnum? GroupType { get; set; }
        public int? DayTime { get; set; }
        public int? TeacherId { get; set; }
    }
}
