using System.Collections.Generic;
using Shared.IOModels.BaseIOModels;

namespace Shared.IOModels.DTOs.GroupDTOs
{
    public class GetGroupOutDTO : BaseOutDTO
    {
        public List<GroupDTO> Groups { get; set; }
    }
}