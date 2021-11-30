using Shared.IOModels.BaseIOModels;
using Shared.IOModels.FilterDTOs;

namespace Shared.IOModels.DTOs.ExpenseDTOs
{
    public class GetExpenseInDTO : BaseInDTO
    {
        public ExpenseFilterDTO Filter { get; set; } 
    }
}