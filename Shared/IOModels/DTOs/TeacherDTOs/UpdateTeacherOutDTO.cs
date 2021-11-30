using Shared.IOModels.BaseIOModels;

namespace Shared.IOModels.DTOs.TeacherDTOs
{
    public class UpdateTeacherOutDTO : BaseOutDTO
    {
        public TeacherDTO Teacher { get; set; }
    }
}