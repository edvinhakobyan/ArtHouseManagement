using Shared.Enums;
using Shared.IOModels.BaseIOModels;

namespace Shared.IOModels.DTOs.GroupDTOs
{
    public class CreateGroupInDTO : BaseInDTO
    {
        public string Name { get; set; }
        public GroupTypeEnum GroupType { get; set; }
        public int DayTime { get; set; }
        public int TeacherId { get; set; }
    }
}