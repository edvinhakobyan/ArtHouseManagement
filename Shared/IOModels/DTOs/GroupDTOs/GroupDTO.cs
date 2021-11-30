using Shared.Enums;

namespace Shared.IOModels.DTOs.GroupDTOs
{
    public class GroupDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public GroupTypeEnum GroupType { get; set; }
        public int DayTime { get; set; }
        public int TeacherId { get; set; }
    }
}
