using Shared.IOModels.BaseIOModels;

namespace Shared.IOModels.DTOs.ExpenseDTOs
{
    public class CreateExpenseInDTO : BaseInDTO
    {
        public int StudentId { get; set; }
        public int GroupId { get; set; }
        public string Name { get; set; }
        public int Value { get; set; }
    }
}