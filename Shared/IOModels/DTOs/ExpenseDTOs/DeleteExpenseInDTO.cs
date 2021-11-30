using Shared.IOModels.BaseIOModels;

namespace Shared.IOModels.DTOs.ExpenseDTOs
{
    public class DeleteExpenseInDTO : BaseInDTO
    {
        public int ExpenseId { get; set; }
    }
}