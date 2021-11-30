using Shared.IOModels.BaseIOModels;

namespace Shared.IOModels.DTOs.GroupDTOs
{
    public class UpdateGroupInDTO : BaseInDTO
    {
        public GroupDTO Group { get; set; }
    }
}