using Core.Models;
using GenericRepository.Abstarction;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Interfaces.IRepositories
{
    public interface IExpenseRepository : IBaseRepository<Expense>
    {
    }
}
