using Shared.IOModels.BaseIOModels;

namespace Shared.IOModels.DTOs.StudentDTOs
{
    public class UpdateStudentOutDTO : BaseOutDTO
    {
        public StudentDTO Student { get; set; }
    }
}