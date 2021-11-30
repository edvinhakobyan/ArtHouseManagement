using Shared.IOModels.BaseIOModels;

namespace Shared.IOModels.DTOs.TeacherDTOs
{
    public class CreateTeacherInDTO : BaseInDTO
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Phone { get; set; }
    }
}