using Shared.IOModels.BaseIOModels;

namespace Shared.IOModels.DTOs.TeacherDTOs
{
    public class CreateTeacherOutDTO : BaseOutDTO
    {
        public TeacherDTO Teacher { get; set; }
    }
}