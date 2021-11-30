using Shared.IOModels.BaseIOModels;

namespace Shared.IOModels.DTOs.GroupDTOs
{
    public class CreateGroupOutDTO : BaseOutDTO
    {
        public GroupDTO Group { get; set; }
    }
}