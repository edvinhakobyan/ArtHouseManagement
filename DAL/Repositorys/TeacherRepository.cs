using Core.Models;
using Core.Interfaces.IRepositories;
using Microsoft.EntityFrameworkCore;
using GenericRepository.Implementation;

namespace DAL.Repositorys
{
    public class TeacherRepository : BaseRepository<Teacher>, ITeacherRepository
    {
        public TeacherRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
