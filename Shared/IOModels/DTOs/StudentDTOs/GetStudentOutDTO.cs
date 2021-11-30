using System.Collections.Generic;

namespace Shared.IOModels.DTOs.StudentDTOs
{
    public class GetStudentOutDTO
    {
        public IEnumerable<StudentDTO> Students { get; set; }
    }
}