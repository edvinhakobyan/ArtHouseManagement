using Shared.Enums;
using System.Collections.Generic;
using GenericRepository.Abstarction;

namespace Core.Models
{
    public class Student : IBaseEntity
    {
        public int Id { get; set; }
        public GenderTypeEnum Gender { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public string PhoneNumber { get; set; }
        public ICollection<StudentGroup> StudentGroups { get; set; }
    }
}
