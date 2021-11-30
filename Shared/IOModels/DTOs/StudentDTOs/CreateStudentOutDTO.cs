using Shared.IOModels.BaseIOModels;

namespace Shared.IOModels.DTOs.StudentDTOs
{
    public class CreateStudentOutDTO : BaseOutDTO
    {
        public StudentDTO Student { get; set; }
    }
}
