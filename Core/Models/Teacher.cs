using System.Collections.Generic;
using GenericRepository.Abstarction;

namespace Core.Models
{
    public class Teacher : IBaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Phone { get; set; }
        public ICollection<Group> Groups { get; set; }
    }
}
