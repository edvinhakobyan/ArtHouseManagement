using Shared.Enums;
using System.Collections.Generic;
using GenericRepository.Abstarction;

namespace Core.Models
{
    public class Group : IBaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public GroupTypeEnum GroupType { get; set; }
        public int DayTime { get; set; }

        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }

        public ICollection<StudentGroup> StudentGroups { get; set; }
    }
}
