using GenericRepository.Abstarction;

namespace Core.Models
{
    public class Expense : IBaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Value { get; set; }

        public int StudentGroupId { get; set; }
        public StudentGroup StudentGroup { get; set; }
    }
}
