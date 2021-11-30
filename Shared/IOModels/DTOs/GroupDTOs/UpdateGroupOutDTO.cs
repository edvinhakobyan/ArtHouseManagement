using Shared.IOModels.BaseIOModels;

namespace Shared.IOModels.DTOs.GroupDTOs
{
    public class UpdateGroupOutDTO : BaseOutDTO
    {
        public GroupDTO Group { get; set; }
    }
}