using Core.Interfaces.IRepositories;
using Core.Models;
using GenericRepository.Implementation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repositorys
{
    public class ExpenseRepository : BaseRepository<Expense>, IExpenseRepository
    {
        public ExpenseRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
