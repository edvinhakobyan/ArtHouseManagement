using System;

namespace Shared.IOModels.DTOs.StudentGroupDTOs
{
    public class StudentGroupDTO
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int StudentId { get; set; }
        public int GroupId { get; set; }

    }
}
