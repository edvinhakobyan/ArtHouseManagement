using System;
using GenericRepository.Abstarction;

namespace Core.Models
{
    public class Payment : IBaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Value { get; set; }
        public DateTime PaymentDate { get; set; } = DateTime.Now; 

        public int StudentGroupId { get; set; }
        public StudentGroup StudentGroup { get; set; }
    }
}
