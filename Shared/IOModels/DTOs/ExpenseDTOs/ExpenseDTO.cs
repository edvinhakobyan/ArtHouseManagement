using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.IOModels.DTOs.ExpenseDTOs
{
    public class ExpenseDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Value { get; set; }
        public int StudentGroupId { get; set; }
    }
}
