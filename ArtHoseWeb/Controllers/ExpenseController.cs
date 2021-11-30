using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Interfaces.IBLL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shared.IOModels.DTOs.ExpenseDTOs;

namespace ArtHoseWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpenseController : ControllerBase
    {
        public readonly IExpenseBL _expenseBL;
        public ExpenseController(IExpenseBL expenseBL)
        {
            _expenseBL = expenseBL;
        }

        [HttpPost("CreateExpense")]
        public Task<CreateExpenseOutDTO> CreateExpenseAsync(CreateExpenseInDTO inModel)
        {
            return _expenseBL.CreateExpenseAsync(inModel);
        }

        [HttpPost("DeleteExpense")]
        public Task<DeleteExpenseOutDTO> DeleteExpenseAsync(DeleteExpenseInDTO inModel)
        {
            return _expenseBL.DeleteExpenseAsync(inModel);
        }

        [HttpPost("GetExpenses")]
        public Task<GetExpenseOutDTO> GetExpensesAsync(GetExpenseInDTO inModel)
        {
            return _expenseBL.GetExpensesAsync(inModel);
        }

        [HttpPost("UpdateExpense")]
        public Task<UpdateExpenseOutDTO> UpdateExpenseAsync(UpdateExpenseInDTO inModel)
        {
            return _expenseBL.UpdateExpenseAsync(inModel);
        }
    }
}
