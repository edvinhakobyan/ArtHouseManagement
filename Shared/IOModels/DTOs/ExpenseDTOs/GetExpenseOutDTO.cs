using Shared.IOModels.BaseIOModels;
using System.Collections.Generic;

namespace Shared.IOModels.DTOs.ExpenseDTOs
{
    public class GetExpenseOutDTO : BaseOutDTO
    {
        public List<ExpenseDTO> Expenses { get; set; }
    }
}