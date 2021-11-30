using Core.Models;
using Core.Interfaces.IRepositories;
using Microsoft.EntityFrameworkCore;
using GenericRepository.Implementation;

namespace DAL.Repositorys
{
    public class StudentRepository : BaseRepository<Student>, IStudentRepository
    {
        public StudentRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
