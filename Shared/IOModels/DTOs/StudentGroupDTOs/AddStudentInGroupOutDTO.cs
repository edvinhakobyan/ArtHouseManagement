using Shared.IOModels.BaseIOModels;

namespace Shared.IOModels.DTOs.StudentGroupDTOs
{
    public class AddStudentInGroupOutDTO : BaseOutDTO
    {
        public StudentGroupDTO StudentGroup { get; set; }
    }
}