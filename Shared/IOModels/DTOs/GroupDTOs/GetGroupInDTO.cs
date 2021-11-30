using Shared.IOModels.FilterDTOs;
using Shared.IOModels.BaseIOModels;

namespace Shared.IOModels.DTOs.GroupDTOs
{
    public class GetGroupInDTO : BaseInDTO
    {
        public GroupFilterDTO Filter { get; set; }
    }
}