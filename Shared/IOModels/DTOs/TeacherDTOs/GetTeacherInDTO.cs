using Shared.IOModels.BaseIOModels;
using Shared.IOModels.FilterDTOs;

namespace Shared.IOModels.DTOs.TeacherDTOs
{
    public class GetTeacherInDTO : BaseInDTO
    {
        public TeacherFilterDTO Filter { get; set; }
    }
}