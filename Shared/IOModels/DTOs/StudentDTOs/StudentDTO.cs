using Shared.Enums;

namespace Shared.IOModels.DTOs.StudentDTOs
{
    public class StudentDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public GenderTypeEnum Gender { get; set; }
        public int Age { get; set; }
        public string PhoneNumber { get; set; }
    }
}
