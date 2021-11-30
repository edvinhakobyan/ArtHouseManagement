using Shared.Enums;
using Shared.IOModels.BaseIOModels;

namespace Shared.IOModels.DTOs.StudentDTOs
{
    public class CreateStudentInDTO : BaseInDTO
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public GenderTypeEnum Gender { get; set; }
        public int Age { get; set; }
        public string PhoneNumber { get; set; }
    }
}
