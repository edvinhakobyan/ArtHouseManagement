using Shared.IOModels.BaseIOModels;

namespace Shared.IOModels.DTOs.TeacherDTOs
{
    public class UpdateTeacherInDTO : BaseInDTO
    {
        public TeacherDTO Teacher { get; set; }
    }
}