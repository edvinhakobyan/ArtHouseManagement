using Shared.IOModels.DTOs.ExpenseDTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.IBLL
{
    public interface IExpenseBL
    {
        Task<CreateExpenseOutDTO> CreateExpenseAsync(CreateExpenseInDTO inModel);
        Task<DeleteExpenseOutDTO> DeleteExpenseAsync(DeleteExpenseInDTO inModel);
        Task<UpdateExpenseOutDTO> UpdateExpenseAsync(UpdateExpenseInDTO inModel);
        Task<GetExpenseOutDTO> GetExpensesAsync(GetExpenseInDTO inModel);
    }
}
