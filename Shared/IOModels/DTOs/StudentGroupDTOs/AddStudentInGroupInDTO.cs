using Shared.IOModels.BaseIOModels;

namespace Shared.IOModels.DTOs.StudentGroupDTOs
{
    public class AddStudentInGroupInDTO : BaseInDTO
    {
        public int StudentId { get; set; }
        public int GroupId { get; set; }
    }
}