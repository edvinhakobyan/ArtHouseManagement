using Shared.IOModels.BaseIOModels;

namespace Shared.IOModels.DTOs.TeacherDTOs
{
    public class DeleteTeacherInDTO : BaseInDTO
    {
        public int TeacherId { get; set; }
    }
}