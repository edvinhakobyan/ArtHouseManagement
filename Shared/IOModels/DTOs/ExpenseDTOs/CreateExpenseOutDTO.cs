using Shared.IOModels.BaseIOModels;

namespace Shared.IOModels.DTOs.ExpenseDTOs
{
    public class CreateExpenseOutDTO : BaseOutDTO
    {
        public ExpenseDTO Expense { get; set; }
    }
}