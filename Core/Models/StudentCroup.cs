using System;
using System.Collections.Generic;
using GenericRepository.Abstarction;

namespace Core.Models
{
    public class StudentGroup : IBaseEntity
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; } = DateTime.Now;
        public DateTime? EndDate { get; set; }

        public int StudentId { get; set; }
        public Student Student { get; set; }
        public int GroupId { get; set; }
        public Group Group { get; set; }

        public ICollection<Payment> Payments { get; set; }
        public ICollection<Expense> Expenses { get; set; }

    }
}
