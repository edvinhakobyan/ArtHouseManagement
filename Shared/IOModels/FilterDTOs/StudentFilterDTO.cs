using Shared.IOModels.BaseIOModels;

namespace Shared.IOModels.FilterDTOs
{
    public class StudentFilterDTO : FilterBaseDTO
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PhoneNumber { get; set; }
        public int? GroupId { get; set; }
    }
}
