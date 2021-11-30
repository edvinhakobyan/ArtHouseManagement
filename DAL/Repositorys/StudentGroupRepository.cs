using Core.Models;
using Core.Interfaces.IRepositories;
using Microsoft.EntityFrameworkCore;
using GenericRepository.Implementation;

namespace DAL.Repositorys
{
    public class StudentGroupRepository : BaseRepository<StudentGroup>, IStudentGroupRepository
    {
        public StudentGroupRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
